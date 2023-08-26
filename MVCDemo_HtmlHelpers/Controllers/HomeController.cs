using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVCDemo_HtmlHelpers.Models;

namespace MVCDemo_HtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
        //
        // Code for displaying and changing Radio Button
        [HttpGet]
        public ActionResult Index()
        {
            Company company = new Company();
            return View(company);
        }

        // Code for displaying and changing Radio Button
        [HttpPost]
        public string Index(Company company)
        {
            if (string.IsNullOrEmpty(company.SelectedDepartment))
            {
                return "You did not select any department";
            }
            else
            {
                SampleDataContext db = new SampleDataContext();
                int selectedDeptId = int.Parse(company.SelectedDepartment);
                Department dept = db.Departments.Single(d => d.Id == selectedDeptId);
                return "You selected department with ID:" + company.SelectedDepartment + " and name = " + dept.Name;
            }
        }

        //Code for displaying and chaning Checkbox Html Helper
        public ActionResult CheckBox()
        {
            SampleDataContext db = new SampleDataContext();
            return View(db.Cities);
        }

        //Code for displaying and changing Listbox Html Helper
        [HttpGet]
        public ActionResult ListBox()
        {
            SampleDataContext db = new SampleDataContext();
            List<SelectListItem> listSelectListItem = new List<SelectListItem>();
            foreach (var city in db.Cities)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Value = city.Id.ToString(),
                    Text = city.Name,
                    Selected = city.IsSelected
                };
                listSelectListItem.Add(selectListItem);
            }
            CitiesViewModel citiesViewModel = new CitiesViewModel();
            citiesViewModel.Cities = listSelectListItem;
            return View(citiesViewModel);
        }

        //Code for displaying and changing Listbox Html Helper
        [HttpPost]
        public string ListBox(List<string> selectedCities)
        {
            SampleDataContext db = new SampleDataContext();
            if (selectedCities == null)
            {
                return "You did not select any city";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                List<string> cities = new List<string>();
  
                foreach (var city in db.Cities)
                {
                    foreach (var id in selectedCities)
                    {
                        if (city.Id.ToString() == id)
                        {
                            cities.Add(city.Name);
                        }
                    }
                }
                sb.Append("You selected -" + string.Join(",", selectedCities) + " with name(s) " + string.Join(",",cities) + "respectively");
                return sb.ToString();
            }
        }

        //Code for "displayName","displayFormat" and "scaffoldcolumn" attributes
        public ActionResult Details(int id)
        {
            SampleDataContext db = new SampleDataContext();
            Employee employee = db.Employees.Single(emp => emp.EmpoyeeId == id);
            return View(employee);
        }
    }
}
