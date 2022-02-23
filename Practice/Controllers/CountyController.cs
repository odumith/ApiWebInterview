using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Practice.Models;
using System.Threading.Tasks;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public CountyController(ApiDBContext context)
        {
            _context = context;
        }
        [HttpGet("CountryCode")]
        public async Task<IActionResult> Get(string phone)
        {
            string code = phone.Substring(0, 3);
            var countrycode = await _context.Country.Include(x => x.countryDetails).FirstOrDefaultAsync(u=>u.CountryCode==code);
            string jsonString = JsonConvert.SerializeObject(countrycode); ;

            Countries countries = JsonConvert.DeserializeObject<Countries>(jsonString);
            CountryCode country =new CountryCode() { number = phone, Countries = countries };
           
            return Ok(country);
        }
    }
}
