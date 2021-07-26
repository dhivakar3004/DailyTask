using KendoEmployeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace KendoEmployeeTask.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection conn;
        SqlCommand cmd;
        string strConnection;
        private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
            strConnection = "Server=LAPTOP-874O3SVO\\SQLEXPRESS;Integrated Security=true;database=Inventory";
            conn = new SqlConnection(strConnection);
        }
               
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Employee()
            {

            List<Employee> employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand("Proc_SelectAllEmployee");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            SqlDataAdapter daEmployee = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
           
                daEmployee.Fill(ds, "Employee");
                Employee employee;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employee = new Employee();
                    employee.Emp_Id = Convert.ToInt32(dr[0]);
                    employee.Emp_Name = dr[1].ToString();
                    employee.Emp_Salary = Convert.ToDouble(dr[2]);
                    employee.Emp_DOB = Convert.ToDateTime(dr[3]);
                    employee.Emp_Address = dr[4].ToString();
                    employee.Emp_Status = dr[5].ToString();
                    employees.Add(employee);
                }
                return Json(employees);
           
           
         }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
