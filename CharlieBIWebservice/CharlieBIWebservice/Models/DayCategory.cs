using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class DayCategory
    {
        public string month { get; set; }
        public string day { get; set; }
        public string food { get; set; }
        public string nonFood { get; set; }
        public string unknown { get; set; }
    }
}