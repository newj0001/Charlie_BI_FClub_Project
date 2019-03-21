using CharlieBIWebservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CharlieBIWebservice.Controllers
{
    public class MembersController : ApiController
    {
        // GET api/Members
        public List<Members> Get()
        {
            GetDate getdate = new GetDate();
            return getdate.Getmembers();
        }
    }
}
