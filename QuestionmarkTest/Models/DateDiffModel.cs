using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;

namespace QuestionmarkTest.Models
{
    //Clas for the Date Difference Model.
    public class DateDiffModel
    {
        //Data annotations for validations
        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [RegularExpression(@"^(19|20)[0-9][0-9][-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The {0} must be in the form yyyy-mm-dd.")]
        [Display(Name = "DateFrom")]
        public string DateFrom { get; set; }

        //Data annotations for validations
        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long")]
        [RegularExpression(@"^(19|20)[0-9][0-9][-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The {0} must be in the form yyyy-mm-dd.")]
        [Display(Name = "DateTo")]
        public string DateTo { get; set; }

        [Display(Name = "Days")]
        public string Days { get; set; }

        // incremental total days a normal year 
        private static int[] DaysInYr = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

        // incremental total days in a leap year 
        private static int[] DaysInLeapYr = new int[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };

        //calulate the days 
        public long GetDays(int[] dt_start, int[] dt_end)
        {
            //initial variables
            int s_year = dt_start[0];
            int e_year = dt_end[0];
            int yr_diff = e_year - s_year;
            int day_diff = dt_end[2] - dt_start[2];
            int s_mth = dt_start[1];
            int e_mth = dt_end[1];


            return day_diff + (yr_diff > 0 ?
                // use months as boundaries, cater for leap years
                             (YrType(e_year)[e_mth - 1] +
                             (YrType(s_year)[YrType(s_year).Length - 1] - YrType(s_year)[s_mth - 1])) +
                             (yr_diff == 1 ? 0 : AddMiddleYears(s_year, e_year))

                             // get month sums in same year 
                             : YrType(e_year)[e_mth - 1] - YrType(e_year)[s_mth - 1]);
        }

        //get the days between two year
        //who are apart by more than one ya
        private static int AddMiddleYears(int s_year, int e_year)
        {
            int total_days = 0;
            for (int i = s_year + 1; i <= e_year - 1; i++) 
                total_days += YrType(i)[YrType(i).Length - 1];
            return total_days;
        }

        //return the number day
        //based on year type
        //leap year 366
        //normal year 365
        private static int[] YrType(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0 ? DaysInLeapYr : DaysInYr;
        }
    }
}