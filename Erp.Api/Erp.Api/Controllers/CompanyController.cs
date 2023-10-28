using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Data.UoW;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyController(MyDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Company> Get()
        {
            return unitOfWork.CompanyRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return unitOfWork.CompanyRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Company request)
        {
            unitOfWork.CompanyRepository.Insert(request);
            unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company request)
        {
            unitOfWork.CompanyRepository.Update(request);
            unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.CompanyRepository.Delete(id);
            unitOfWork.Complete();
        }

    }
}
