using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MvcApplication.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Timesheet : Entity
    {
        public Timesheet()
        {
            Year = DateTime.Now.Year;
        }

        [JsonProperty(PropertyName = "firstname")]
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "month")]
        [Display(Name = "Month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "year")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        public IEnumerable<SelectListItem> Months
        {
            get
            {
                var months = DateTimeFormatInfo.InvariantInfo.MonthNames.Select((monthName, index) => new SelectListItem
                    {
                        Value = (index + 1).ToString(),
                        Text = monthName
                    }).ToList();
                months.RemoveAt(12); // 13th item is empty
                return months;
            }
        }
    }
}