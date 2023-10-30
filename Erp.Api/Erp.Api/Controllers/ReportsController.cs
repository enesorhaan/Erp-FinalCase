using AutoMapper;
using Erp.Base.Response;
using Erp.Data.Entities;
using Erp.Data.UoW;
using Erp.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("orders/daily/report")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderDailyReport()
        {
            List<Order> list = unitOfWork.OrderRepository.GetAllOrderDaily();
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("orders/weekly/report")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderWeeklyReport()
        {
            List<Order> list = unitOfWork.OrderRepository.GetAllOrderWeekly();
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("orders/monthly/report")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderMonthlyReport()
        {
            List<Order> list = unitOfWork.OrderRepository.GetAllOrderMonthly();
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("orders/dealer")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderReportByDealerId()
        {
            var id = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            List<Order> list = unitOfWork.OrderRepository.GetAllOrderByDealerId(int.Parse(id));
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("orders/daily/report/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderCompanyDailyReportByDealerId(int id)
        {
            List<Order> list = unitOfWork.OrderRepository.GetAllOrderDailyByDealerId(id);
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("orders/weekly/report/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderCompanyWeeklyReportByDealerId(int id)
        {
            List<Order> list = unitOfWork.OrderRepository.GetAllOrderWeeklyByDealerId(id);
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("orders/monthly/report/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllOrderCompanyMonthlyReportByDealerId(int id)
        {
            List<Order> list = unitOfWork.OrderRepository.GetAllOrderMonthlyByDealerId(id);
            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        [HttpGet("products")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<ProductDetailResponse>>> GetAllProductReport()
        {
            List<Product> list = unitOfWork.ProductRepository.GetAllProduct();
            var mapped = mapper.Map<List<ProductDetailResponse>>(list);

            return new ApiResponse<List<ProductDetailResponse>>(mapped);
        }

        [HttpGet("products/checkstock")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<ProductDetailResponse>>> GetAllProductCheckStockReport()
        {
            List<Product> list = unitOfWork.ProductRepository.GetAllProductCheckStock();
            var mapped = mapper.Map<List<ProductDetailResponse>>(list);

            return new ApiResponse<List<ProductDetailResponse>>(mapped);
        }
    }
}
