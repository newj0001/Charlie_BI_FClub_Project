using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class Month
    {
        public string month { get; set; }
        public string year { get; set; }
        public string amount { get; set; }
        public List<Day> days { get; set; }
    }
}