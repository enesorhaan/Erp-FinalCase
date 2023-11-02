using Erp.Base.Response;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private IMediator mediator;
        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<CompanyResponse>>> GetAll()
        {
            var operation = new GetAllCompanyQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<CompanyResponse>> Get(int id)
        {
            var operation = new GetCompanyByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<CompanyResponse>> Post([FromBody] CompanyRequest request)
        {
            var operation = new CreateCompanyCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Put(int id, [FromBody] CompanyRequest request)
        {
            var operation = new UpdateCompanyCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteCompanyCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
