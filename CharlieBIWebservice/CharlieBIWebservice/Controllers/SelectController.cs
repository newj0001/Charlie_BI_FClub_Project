using CharlieBIWebservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CharlieBIWebservice.Controllers
{
    public class SelectController : ApiController
    {
        public List<Category> Get()
        {
            GetDate getdate = new GetDate();
            return getdate.Category();
        }
    }
}
