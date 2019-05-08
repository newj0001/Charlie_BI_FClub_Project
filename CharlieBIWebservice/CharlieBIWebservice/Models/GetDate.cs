using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharlieBIWebservice.Models
{
    public class GetDate
    {
        public List<Day> Getdays()
        {
            List<Day> Day = new List<Day>();

            AdomdConnection conn = new AdomdConnection(
            "Data Source=.;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count] } ON COLUMNS, NonEmpty({[Dim Date].[Hierarchy].[Day Of Month]}) ON ROWS FROM[Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Day Tempday = new Day();
                Tempday.month = Convert.ToString(item[1]);
                Tempday.day = Convert.ToString(item[2]);
                Tempday.amount = Convert.ToString(item[3]);
                Day.Add(Tempday);
            }

            dr.Close();
            conn.Close();
            return Day;
        }

        public List<Month> GetMonth()
        {
            List<Month> Month = new List<Month>();


            AdomdConnection conn = new AdomdConnection(
            "Data Source=.;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count] } ON COLUMNS, NONEMPTY({[Dim Date].[Hierarchy].[Month]}) ON ROWS FROM[Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Month TempMonth = new Month();
                TempMonth.year = Convert.ToString(item[0]);
                TempMonth.month = Convert.ToString(item[1]);
                TempMonth.amount = Convert.ToString(item[2]);
                Month.Add(TempMonth);
            }

            dr.Close();
            conn.Close();
            return Month;
        }

        public List<Year> GetYear()
        {
            List<Year> Year = new List<Year>();


            AdomdConnection conn = new AdomdConnection(
            "Data Source=.;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count] } ON COLUMNS, NONEMPTY({[Dim Date].[Hierarchy].[Year]} ) ON ROWS FROM[Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Year Tempyear = new Year();
                Tempyear.year = Convert.ToString(item[0]);
                Tempyear.amount = Convert.ToString(item[1]);
                Year.Add(Tempyear);
            }

            dr.Close();
            conn.Close();
            return Year;
        }
        public List<YearCategory> GetCategory()
        {
            List<DayCategory> Day = new List<DayCategory>();
            List<MonthCategory> Month = new List<MonthCategory>();
            List<YearCategory> Year = new List<YearCategory>();
            Day = GetdayCategory();
            Month = GetMonthCategory();
            Year = Getyearcategory();

            int counter = 0;
            for (int i = 0; i < Month.Count; i++)
            {
                Month[i].days = new List<DayCategory>();
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
                Year[i].Months = new List<MonthCategory>();
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
        public List<DayCategory> GetdayCategory()
        {
            List<DayCategory> Day = new List<DayCategory>();

            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Dim Product].[Hierarchy].[Main Category]} ON COLUMNS, NONEMPTY({[Dim Date].[Hierarchy].[Day Of Month]}) ON ROWS FROM [Charlie BI F Club] WHERE [Measures].[Fact Sale Count]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                DayCategory TempDay = new DayCategory();
                TempDay.month = Convert.ToString(item[1]);
                TempDay.day = Convert.ToString(item[2]);
                TempDay.food = Convert.ToString(item[3]);
                TempDay.nonFood = Convert.ToString(item[4]);
                TempDay.unknown = Convert.ToString(item[5]);
                Day.Add(TempDay);
            }

            dr.Close();
            conn.Close();
            return Day;
        }
        public List<MonthCategory> GetMonthCategory()
        {
            List<MonthCategory> Month = new List<MonthCategory>();


            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Dim Product].[Hierarchy].[Main Category]} ON COLUMNS, NONEMPTY({[Dim Date].[Hierarchy].[Month]}) ON ROWS FROM [Charlie BI F Club] WHERE [Measures].[Fact Sale Count]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                MonthCategory TempMonth = new MonthCategory();
                TempMonth.year = Convert.ToString(item[0]);
                TempMonth.month = Convert.ToString(item[1]);
                TempMonth.food = Convert.ToString(item[2]);
                TempMonth.nonFood = Convert.ToString(item[3]);
                TempMonth.unknown = Convert.ToString(item[4]);
                Month.Add(TempMonth);
            }

            dr.Close();
            conn.Close();
            return Month;
        }
        public List<YearCategory> Getyearcategory()
        {
            List<YearCategory> Year = new List<YearCategory>();


            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Dim Product].[Hierarchy].[Main Category]} ON COLUMNS, NONEMPTY({[Dim Date].[Hierarchy].[Year]}) ON ROWS FROM [Charlie BI F Club] WHERE [Measures].[Fact Sale Count]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                YearCategory TempYear = new YearCategory();
                TempYear.year = Convert.ToString(item[0]);
                TempYear.food = Convert.ToString(item[1]);
                TempYear.nonFood = Convert.ToString(item[2]);
                TempYear.unknown = Convert.ToString(item[3]);
                Year.Add(TempYear);
            }

            dr.Close();
            conn.Close();
            return Year;
        }
        public List<Members> Getmembers()
        {
            List<Members> members = new List<Members>();

            AdomdConnection conn = new AdomdConnection(
            "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Measures].[Fact Sale Count]} ON COLUMNS, NONEMPTY({[Dim Member].[Member ID].[Member ID]}) ON ROWS FROM [Charlie BI F Club]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                Members member = new Members();
                member.member = Convert.ToString(item[0]);
                member.Amount = Convert.ToString(item[1]);
                members.Add(member);
            }

            dr.Close();
            conn.Close();
            return members;
        }
        public List<Category> Category()
        {
            List<Category> Categories = new List<Category>();

            AdomdConnection conn = new AdomdConnection(
           "Data Source=LAPTOP-ED7T3RSE\\ETELLERANDET;Initial Catalog=Charlie_BI_AnalysisProject;");
            conn.Open();

            string commandText = @"SELECT {[Dim Product].[Main Category].[Main Category]} ON COLUMNS, [Dim Product].[Product ID].[Product ID] ON ROWS FROM [Charlie BI F CLUB]";
            AdomdCommand cmd = new AdomdCommand(commandText, conn);
            AdomdDataReader dr = cmd.ExecuteReader();

            foreach (var item in dr)
            {
                
            }
            dr.Close();
            conn.Close();
            return Categories;
        }
    }
}