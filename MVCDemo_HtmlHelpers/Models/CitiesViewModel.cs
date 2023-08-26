using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo_HtmlHelpers.Models
{
    public class CitiesViewModel
    {
        public List<SelectListItem> Cities { get; set; }
        public List<String> SelectedCities { get; set; }
    }
}