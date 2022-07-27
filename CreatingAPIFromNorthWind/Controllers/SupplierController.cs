using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreatingAPIFromNorthWind.Models;

namespace CreatingAPIFromNorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        public NorthwindContext northwindcontext = new NorthwindContext();

        [HttpGet("GetAllSuppliers")]
        public List<Supplier> GetAll()
        {
            return northwindcontext.Suppliers.ToList();
        }
        [HttpGet("GetSupplierInfoById")]
        public Supplier GetById(int Id)
        {
            return northwindcontext.Suppliers.FirstOrDefault(x => x.SupplierId == Id);
        }
        [HttpPost("AddSupplier")]
        public Supplier AddSupplier(string CompanyName, string ContactName, string ContactTitle)
        {
            Supplier supplier = new Supplier()
            {
                CompanyName = CompanyName,
                ContactName = ContactName,
                ContactTitle = ContactTitle
            };
            northwindcontext.Add(supplier);
            northwindcontext.SaveChanges();
            return supplier;


        }
    }
}
