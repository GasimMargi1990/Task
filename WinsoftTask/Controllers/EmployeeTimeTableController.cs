using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using WinsoftTask.Models;
using System.Configuration;

namespace WinsoftTask.Controllers
{
    public class EmployeeTimeTableController : Controller


    {
        string connectionString = @"Data Source = DESKTOP-D1PB6AI\SQLEXPRESS; initial Catalog = WinSoftTask; Integrated Security = True";
        // GET: EmployeeTimeTable
        public ActionResult Index()
        {
            return View();
        }
    
        

        // GET: EmployeeTimeTable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeTimeTable/Create

       


        [HttpGet]
        public ActionResult Create()
        {
            
           return View(new EmployeeTimeTable());

        }

       

        // POST: EmployeeTimeTable/Create
        [HttpPost]
        public ActionResult Create(EmployeeTimeTable employeeTimeTable)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO EmployeeTimeTable VALUES(@EmpNo,@StartWork,@EndWork)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //sqlCmd.Parameters.AddWithValue("EmpNo", id);
                sqlCmd.Parameters.AddWithValue("StartWork", employeeTimeTable.StartWork);
                sqlCmd.Parameters.AddWithValue("EndWork", employeeTimeTable.EndWork);
                sqlCmd.ExecuteNonQuery();
            }




            return RedirectToAction("Index");
        }


    }


}

