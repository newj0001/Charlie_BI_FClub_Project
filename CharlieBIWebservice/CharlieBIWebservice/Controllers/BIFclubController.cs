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
            date = getdate.Getdays();
            //boi1 = getdate.Getdays();
            boi2 = getdate.GetMonth();
            boi3 = getdate.GetYear();
            int counter = -1;
            int amounttracker = 0;
            foreach (var item in date)
            {
                Day day = new Day();
                Month month = new Month();
                if(boi3[counter].year == item.Year)
                {

                }
                else
                {
                    counter++;
                    boi3[counter].year = item.Year;
                    
                }
            }
            //boi2[0].days = new List<Day>();
            //int monthcounter = 0;
            //foreach (var item in boi1)
            //{
            //    Day i = new Day();
            //    i = item;
            //    if (item.day == "1")
            //    {
            //        monthcounter++;
            //        boi2[monthcounter].days = new List<Day>();
            //        boi2[monthcounter].days.Add(i);
            //    }
            //    else
            //    {
            //        boi2[monthcounter].days.Add(i);
            //    }
            //}
            return boi2;
        }
        public string Get(string id)
        {
            //SELECT {[Measures].[Fact Sale Count]} ON COLUMNS, NONEMPTY({[Dim Date].[Month].[Month]}) ON ROWS FROM[Charlie BI F Club]
            return null;
        }

    }
}