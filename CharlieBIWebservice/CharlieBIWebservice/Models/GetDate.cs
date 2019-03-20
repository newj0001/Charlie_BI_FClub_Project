using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class GetDate
    {
        public List<Date> Getdays()
        {
            List<Day> boi = new List<Day>();
            List<Date> date = new List<Date>();

            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count] } ON COLUMNS, NonEmpty({[Dim Date].[Hierarchy].[Day Of Month]}) ON ROWS FROM[Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Date boi2 = new Date();
                boi2.Year = Convert.ToString(item[0]);
                boi2.Month = Convert.ToString(item[1]);
                boi2.Day = Convert.ToString(item[2]);
                boi2.Amount = Convert.ToString(item[3]);
                date.Add(boi2);
            }

            dr.Close();
            conn.Close();
            return date;
        }

        public List<Month> GetMonth()
        {
            List<Month> boi = new List<Month>();


            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count] } ON COLUMNS, {[Dim Date].[Hierarchy].[Month]} ON ROWS FROM[Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Month boi2 = new Month();
                boi2.month = Convert.ToString(item[1]);
                boi2.amount = Convert.ToString(item[2]);
                boi.Add(boi2);
            }

            dr.Close();
            conn.Close();
            return boi;
        }

        public List<Year> GetYear()
        {
            List<Year> boi = new List<Year>();


            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count] } ON COLUMNS, NONEMPTY({[Dim Date].[Hierarchy].[Year]} ) ON ROWS FROM[Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Year boi2 = new Year();
                boi2.year = Convert.ToString(item[0]);
                boi2.amount = Convert.ToString(item[1]);
                boi.Add(boi2);
            }

            dr.Close();
            conn.Close();
            return boi;
        }
    }
}