
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace WinsoftTask.Models
{
    public class EmployeeModel
    {
        public int EmpNo { get; set; }

        [DisplayName("Employee Name")]
        public string Name { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Degree { get; set; }

        [DisplayName("Hire Name")]
        public string HireDate { get; set; }

        public string Certificate { get; set; }

        public string Address { get; set; }

       
    }
}