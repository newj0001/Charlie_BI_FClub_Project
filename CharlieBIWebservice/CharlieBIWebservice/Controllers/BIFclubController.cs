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
            List<Year> Year = new List<Year>();
            List<Month> Month = new List<Month>();
            List<Day> Day = new List<Day>();
            GetDate getdate = new GetDate();
            Day = getdate.Getdays();
            Month = getdate.GetMonth();
            Year = getdate.GetYear();
            int counter = 0;
            for (int i = 0; i < Month.Count; i++)
            {
                Month[i].days = new List<Day>();
                while (Month[i].month == Day[counter].month)
                {
                    Month[i].days.Add(Day[counter]);
                    if (counter < Day.Count - 1)
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
            for (int i = 0; i < Year.Count; i++)
            {
                Year[i].Months = new List<Month>();
                while (Year[i].year == Month[counter].year)
                {
                    Year[i].Months.Add(Month[counter]);
                    if (counter < Month.Count - 1)
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }


            return Year;
        }
    }
}