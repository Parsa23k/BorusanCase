using BorusanCase.Models;
using BorusanCase.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BorusanCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<OrderResponseModel> Get()
        {
            using (var context = new BorusanCaseContext())
            {
                var result = (from order in context.Order
                            join orderStatus in context.OrderStatus on order.OrderStatusId equals orderStatus.Id
                            join piecesType in context.PiecesType on order.PiecesTypeId equals piecesType.Id
                            join weightType in context.WeightType on order.WeightTypeId equals weightType.Id
                            select new OrderResponseModel()
                            {
                                Id = order.Id,
                                ArrivalAddress = order.ArrivalAddress,
                                CustomerOrderNo = order.CustomerOrderNumber.ToString(),
                                MaterialCode = order.ItemCode,
                                Note = order.Not,
                                OrderNo = "BRS-" + order.Id.ToString(),
                                OrderStatus = orderStatus.Name,
                                PortAddress = order.DepartureAddress,
                                Quantity = order.Quantity.ToString(),
                                Unit = piecesType.Name,
                                Weight = order.Weight.ToString(),
                                WeightUnit = weightType.Name,
                                OrderStatusId=orderStatus.Id
                            }).ToList();
                return result;
            }
        }

        [HttpPost]
        public SaveOrderResponse Insert(SaveOrderRequest request)
        {
            using (var context = new BorusanCaseContext())
            {
                try
                {
                    if (context.Order.Any(x => x.CustomerOrderNumber==request.CustomerOrderNumber))
                    {
                        return new SaveOrderResponse()
                        {
                            CustomerOrderNumber = request.CustomerOrderNumber,
                            Message = "Bu müşteri numarası sistemde kayıtlı, yeni bir müşteri nmumarası giriniz!",
                            Status = true
                        };
                    }
                    Order order = new Order();
                    order.CustomerOrderNumber = request.CustomerOrderNumber;
                    order.ArrivalAddress = request.ArrivalAddress;
                    order.DepartureAddress = request.DepartureAddress;
                    order.Quantity = request.Quantity;
                    order.PiecesTypeId = request.PiecesTypeId;
                    order.Weight = request.Weight;
                    order.WeightTypeId = request.WeightTypeId;
                    order.ItemCode = request.ItemCode;
                    order.ItemName = request.ItemName;
                    order.Not = request.Not;
                    order.OrderStatusId = 1;
                    order.CreateDate = DateTime.Now;
                    order.IsDeleted = false;
                    context.Add(order);
                    int result = context.SaveChanges();

                    return new SaveOrderResponse() { 
                        CustomerOrderNumber = order.CustomerOrderNumber, 
                        Message = "Sipariş Başarıyla Oluşturuldu", 
                        OrderNumber = "BRS-" + order.Id.ToString(), 
                        Status = false };

                }
                catch (Exception ex) 
                {
                    return new SaveOrderResponse() { 
                        CustomerOrderNumber = request.CustomerOrderNumber, 
                        Message = "Hata ile karşılaşıldı " + ex.Message, 
                        Status = true };

                }
            }
            
            
        }

        [HttpPut]
        public UpdateOrderResponse Update(UpdateOrderRequest request)
        {
            using (var context = new BorusanCaseContext())
            {
                try
                {
                    Order order = context.Order.Where(order => order.CustomerOrderNumber == request.CustomerOrderNumber).FirstOrDefault();
                    order.UpdateDate = DateTime.Now;
                    order.Not = request.Not;
                    order.OrderStatusId = request.OrderStatusId;
                    order.IsDeleted = false;
                    context.Update(order);
                    int result = context.SaveChanges();

                    return new UpdateOrderResponse()
                    {
                        OrderStatusId = order.OrderStatusId,
                        CustomerOrderNumber = order.CustomerOrderNumber,
                        Message = "Sipariş Başarıyla Güncellendi",
                        OrderNumber = "BRS-" + order.Id.ToString(),
                        UpdateDate = order.UpdateDate,
                        Status = false
                    };

                }
                catch (Exception ex)
                {
                    return new UpdateOrderResponse()
                    {
                        CustomerOrderNumber = request.CustomerOrderNumber,
                        Message = "Hata ile karşılaşıldı " + ex.Message,
                        Status = true
                    };
                }
            }
        }
    }
}