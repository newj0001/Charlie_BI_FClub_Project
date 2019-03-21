using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class YearCategory
    {
        public string year { get; set; }
        public List<MonthCategory> Months { get; set; }
        public string food { get; set; }
        public string nonFood { get; set; }
        public string unknown { get; set; }
    }
}