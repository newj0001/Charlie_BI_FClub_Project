using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class MonthCategory
    {
        public string month { get; set; }
        public string year { get; set; }
        public List<DayCategory> days { get; set; }
        public string food { get; set; }
        public string nonFood { get; set; }
        public string unknown { get; set; }
    }
}