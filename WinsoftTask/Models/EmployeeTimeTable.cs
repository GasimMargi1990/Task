using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WinsoftTask.Models
{
    public class EmployeeTimeTable
    {

      

        [DisplayName("Start Work")]
        public DateTime StartWork { get; set; }

        [DisplayName("End Work")]
        public DateTime EndWork { get; set; }


        

    }
}