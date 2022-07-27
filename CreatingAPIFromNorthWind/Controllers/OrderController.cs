using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreatingAPIFromNorthWind.Models;

namespace CreatingAPIFromNorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public NorthwindContext northwindcontext = new NorthwindContext();

        [HttpGet("GetOrderInfoById")]
        public OrderDetail GetById(int Id)
        {
            return northwindcontext.OrderDetails.FirstOrDefault(x => x.ProductId == Id);
        }

        [HttpGet("GetQuantity")]
        public List<OrderDetail> GetQuantity(int quantity)
        {
            return northwindcontext.OrderDetails.Where(p => p.Quantity < quantity).ToList();
        }

        [HttpDelete("RemoveDetailsByQuantity")]
        public OrderDetail DeletePets(int quantity)
        {
            OrderDetail removed = northwindcontext.OrderDetails.FirstOrDefault(p => p.Quantity == quantity);

            northwindcontext.OrderDetails.Remove(removed);
            northwindcontext.SaveChanges();
            return removed;
        }



    }
}
