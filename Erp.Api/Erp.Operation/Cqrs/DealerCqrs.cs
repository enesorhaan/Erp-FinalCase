using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateCompanyCommand(CompanyRequest Model) : IRequest<ApiResponse<CompanyResponse>>;
    public record UpdateCompanyCommand(CompanyRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteCompanyCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllCompanyQuery() : IRequest<ApiResponse<List<CompanyResponse>>>;
    public record GetCompanyByIdQuery(int Id) : IRequest<ApiResponse<CompanyResponse>>;

}
