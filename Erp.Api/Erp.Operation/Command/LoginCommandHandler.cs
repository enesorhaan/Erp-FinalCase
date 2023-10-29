using Erp.Base;
using Erp.Base.Response;
using Erp.Base.Token;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Erp.Operation.Command
{
    public class LoginCommandHandler :
        IRequestHandler<CreateLoginCommand, ApiResponse<LoginResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly JwtConfig jwtConfig;

        public LoginCommandHandler(MyDbContext dbContext, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.dbContext = dbContext;
            this.jwtConfig = jwtConfig.CurrentValue;
        }

        public async Task<ApiResponse<LoginResponse>> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            var company = await dbContext.Set<Company>().Include(c => c.Dealers).FirstOrDefaultAsync(c => c.Email == request.Model.Email, cancellationToken);

            var dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(d => d.Email == request.Model.Email, cancellationToken);

            if (company == null && dealer == null)
            {
                return new ApiResponse<LoginResponse>("Invalid user informations");
            }

            var md5 = Md5.Create(request.Model.Password.ToLower());

            if (company != null && company.Password != md5)
            {
                company.LastActivityDate = DateTime.Now;
                company.PasswordRetryCount++;
                await dbContext.SaveChangesAsync(cancellationToken);

                return new ApiResponse<LoginResponse>("Invalid user informations");
            }
            else if (company != null && company.Password == md5)
            {
                if (!company.IsActive)
                {
                    return new ApiResponse<LoginResponse>("Invalid user!");
                }

                string token = Token(company);

                LoginResponse loginResponse = new()
                {
                    Token = token,
                    ExpireDate = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Email = company.Email
                };

                return new ApiResponse<LoginResponse>(loginResponse);
            }

            if (dealer != null && dealer.Password != md5)
            {
                dealer.LastActivityDate = DateTime.Now;
                dealer.PasswordRetryCount++;
                await dbContext.SaveChangesAsync(cancellationToken);

                return new ApiResponse<LoginResponse>("Invalid user informations");
            }
            else
            {
                if (!dealer.IsActive)
                {
                    return new ApiResponse<LoginResponse>("Invalid user!");
                }

                string token = Token(dealer);

                LoginResponse loginResponse = new()
                {
                    Token = token,
                    ExpireDate = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Email = dealer.Email
                };

                return new ApiResponse<LoginResponse>(loginResponse);
            }
        }

        private string Token(Company user)
        {
            Claim[] claims = GetClaims(user);
            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                jwtConfig.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }

        private string Token(Dealer user)
        {
            Claim[] claims = GetClaims(user);
            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                jwtConfig.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }

        private Claim[] GetClaims(Company company)
        {
            var claims = new[]
            {
            new Claim("Id", company.Id.ToString()),
            new Claim("Role", company.Role.ToString()),
            new Claim("Email", company.Email),
            new Claim(ClaimTypes.Role, company.Role.ToString())
            };

            return claims;
        }
        
        private Claim[] GetClaims(Dealer dealer)
        {
            var claims = new[]
            {
            new Claim("Id", dealer.Id.ToString()),
            new Claim("Role", dealer.Role.ToString()),
            new Claim("Email", dealer.Email),
            new Claim(ClaimTypes.Role, dealer.Role.ToString())
            };

            return claims;
        }
    }
}
