using HRMSAPPLICATION.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMSAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlySalaryController : ControllerBase
    {
        HrmsystemContext _context;
        public MonthlySalaryController(HrmsystemContext context)
        {
            _context = context;
        }
        [HttpGet("{year},{month},{empcode}")]

        public Object Get(int year, int month, string empcode)
        {

            Console.WriteLine(year + ":" + month + ":" + empcode);

            var salary = _context.Database.SqlQueryRaw<Double>("EXEC CalculateMonthlySalaryForMonthYear @Year =" + year + ", @Month  =" + month + ", @EmployeeCode =" + empcode + ";");
            return salary;

        }

    }
}
