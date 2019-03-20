using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class Year
    {
        public string year { get; set; }
        public string amount { get; set; }
        public List<Month> Months { get; set; }
    }
}