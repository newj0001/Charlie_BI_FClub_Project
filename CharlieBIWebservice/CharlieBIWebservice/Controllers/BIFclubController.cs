using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml;
using CharlieBIWebservice.Models;
using Microsoft.AnalysisServices.AdomdClient;
using Newtonsoft.Json;

namespace CharlieBIWebservice.Controllers
{
    public class BIFclubController : ApiController
    {
        // GET: BIFclub
        public List<Year> Get()
        {
            List<Year> boi3 = new List<Year>();
            List<Month> boi2 = new List<Month>();
            List<Day> boi1 = new List<Day>();
            GetDate getdate = new GetDate();
            List<Date> date = new List<Date>();
            boi1 = getdate.Getdays();
            //boi1 = getdate.Getdays();
            boi2 = getdate.GetMonth();
            boi3 = getdate.GetYear();
            int counter = 0;
            for (int i = 0; i < boi2.Count; i++)
            {
                boi2[i].days = new List<Day>();
                while (boi2[i].month == boi1[counter].month)
                {
                    boi2[i].days.Add(boi1[counter]);
                    if (counter < boi1.Count - 1)
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            counter = 0;
            for (int i = 0; i < boi3.Count; i++)
            {
                boi3[i].Months = new List<Month>();
                while (boi3[i].year == boi2[counter].year)
                {
                    boi3[i].Months.Add(boi2[counter]);
                    if (counter < boi2.Count - 1)
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }


            return boi3;
        }
        public string Get(string id)
        {
            //SELECT {[Measures].[Fact Sale Count]} ON COLUMNS, NONEMPTY({[Dim Date].[Month].[Month]}) ON ROWS FROM[Charlie BI F Club]
            return null;
        }

    }
}