using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using WinsoftTask.Models;

namespace WinsoftTask.Controllers
{
    public class EMPLOYEESController : Controller

    {
        string connectionString = @"Data Source = DESKTOP-D1PB6AI\SQLEXPRESS; initial Catalog = WinSoftTask; Integrated Security = True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblEmployees = new DataTable();
            using (SqlConnection sqlCon= new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM EMPLOYEES ",sqlCon);
                sqlDa.Fill(dtblEmployees);

            }
            return View(dtblEmployees);
        }

        

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        // POST: EMPLOYEES/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            

                using(SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO EMPLOYEES VALUES(@Name,@LastName,@HireDate,@Degree,@Certificate,@Address)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("Name", employeeModel.Name);
                    sqlCmd.Parameters.AddWithValue("LastName", employeeModel.LastName);

                    sqlCmd.Parameters.AddWithValue("Degree", employeeModel.Degree);
                    sqlCmd.Parameters.AddWithValue("HireDate", employeeModel.HireDate);

                    sqlCmd.Parameters.AddWithValue("Certificate", employeeModel.Certificate);
                    sqlCmd.Parameters.AddWithValue("Address", employeeModel.Address);
                    sqlCmd.ExecuteNonQuery();
                }
               

                return RedirectToAction("Index");
            }

       
        public ActionResult Edit(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            DataTable dtbEmployee = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM EMPLOYEES where EmpNo=@EmpNo";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("EmpNo", id);
                sqlDa.Fill(dtbEmployee);

            }
            if (dtbEmployee.Rows.Count == 1)
            {
                employeeModel.EmpNo = Convert.ToInt32(dtbEmployee.Rows[0][0].ToString());
                employeeModel.Name = dtbEmployee.Rows[0][1].ToString();
                employeeModel.LastName = dtbEmployee.Rows[0][2].ToString();
                employeeModel.Degree = dtbEmployee.Rows[0][3].ToString();
                employeeModel.HireDate = dtbEmployee.Rows[0][4].ToString();
                employeeModel.Certificate = dtbEmployee.Rows[0][5].ToString();
                employeeModel.Address = dtbEmployee.Rows[0][6].ToString();
                return View(employeeModel);
            }

            else
            
                return RedirectToAction("Index");

            

        }

        // POST: EMPLOYEES/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Update EMPLOYEES SET Name=@Name,LastName=@LastName,Degree=@Degree,HireDate=@HireDate,Certificate=@Certificate,Address=@Address WHERE EmpNo=@EmpNo";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("EmpNo", employeeModel.EmpNo);
                sqlCmd.Parameters.AddWithValue("Name", employeeModel.Name);
                sqlCmd.Parameters.AddWithValue("LastName", employeeModel.LastName);

                sqlCmd.Parameters.AddWithValue("Degree", employeeModel.Degree);
                sqlCmd.Parameters.AddWithValue("HireDate", employeeModel.HireDate);

                sqlCmd.Parameters.AddWithValue("Certificate", employeeModel.Certificate);
                sqlCmd.Parameters.AddWithValue("Address", employeeModel.Address);
                sqlCmd.ExecuteNonQuery();
            }


            return RedirectToAction("Index");
        }
    

        // GET: EMPLOYEES/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EMPLOYEES/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
