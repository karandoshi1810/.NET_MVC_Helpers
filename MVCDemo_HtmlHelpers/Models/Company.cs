using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo_HtmlHelpers.Models
{
    public class Company
    {
        public string SelectedDepartment { get; set; }
        public List<Department> Departments
        {
            get
            {
                SampleDataContext db = new SampleDataContext();
                return db.Departments.ToList();
            }
        }
    }
}