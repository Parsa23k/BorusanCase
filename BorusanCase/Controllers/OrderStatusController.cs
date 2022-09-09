using BorusanCase.Models;
using BorusanCase.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BorusanCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderStatusController : ControllerBase
    {
        [HttpGet]
        public async Task<List<OrderStatusDTO>> Get()
        {
            using (var context = new BorusanCaseContext())
            {
                return await context.OrderStatus.Select(x => new OrderStatusDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            }
        }

        [HttpPut]
        public async Task<UpdateOrderStatusResponse> UpdateOrderStatus(OrderStatusModel model)
        {
            using (var context = new BorusanCaseContext())
            {
                var order = await context.Order.FirstOrDefaultAsync(x => x.Id == model.OrderId);

                #region Validation
                if (order == null)
                {
                    return new UpdateOrderStatusResponse
                    {
                        Status = 0,
                        Message = "Sipariş bulunamadı."
                    };
                }

                var orderStatus = await context.OrderStatus.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.StatusId);
                if (orderStatus == null)
                {
                    return new UpdateOrderStatusResponse
                    {
                        Status = 0,
                        Message = "Hatalı durum gönderdiniz"
                    };
                }

                if (order.OrderStatusId == model.StatusId)
                {
                    return new UpdateOrderStatusResponse
                    {
                        Status = 0,
                        Message = "Farklı bir sipariş durumu göndermelisiniz."
                    };
                }
                #endregion

                order.OrderStatusId = model.StatusId;
                order.UpdateDate = DateTime.Now;
                await context.SaveChangesAsync();

                return new UpdateOrderStatusResponse
                {
                    CustomerOrderNo = order.CustomerOrderNumber.ToString(),
                    Status = 1,
                    Message = $"Sipariş durumu {orderStatus.Name} olarak güncellendi.",
                    UpdateDate = order.UpdateDate,
                    OrderStatus = orderStatus.Name
                };
            }

        }

    }
}
