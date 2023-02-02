using CodingTracker.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CodingTracker
{
    internal class Reports
    {
        public class PeriodReport
        {
            public Period Period { get; set; }
            public string DisplayValue { get; set; }
            public double Total_Hours { get; set; }
            public double Average_Hours_Per_Session { get; set; }
        }
        public List<PeriodReport> GenerateReports(List<CodingSession> sessions, Period period)
        {
            var reports = new List<PeriodReport>();

            switch (period)
            {
                case Period.Day:
                    var dayGroups = sessions.GroupBy(s => DateTime.Parse(s.StartTime!).Date);
                    foreach (var dayGroup in dayGroups)
                    {
                        reports.Add(new PeriodReport
                        {
                            Period = period,
                            DisplayValue = dayGroup.Key.ToShortDateString(),
                            Total_Hours = dayGroup.Sum(s => s.Duration),
                            Average_Hours_Per_Session = Math.Round(dayGroup.Average(s => s.Duration), 1)
                        });
                    }
                    break;
                case Period.Week:
                    var weekGroups = sessions.GroupBy(s => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Parse(s.StartTime!).Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
                    foreach (var weekGroup in weekGroups)
                    {
                        var datesInWeek = weekGroup.Select(s => DateTime.Parse(s.StartTime!).Date);
                        var minDate = datesInWeek.Min();
                        var maxDate = datesInWeek.Max();
                        reports.Add(new PeriodReport
                        {
                            Period = period,
                            DisplayValue = $"{minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}",
                            Total_Hours = weekGroup.Sum(s => s.Duration),
                            Average_Hours_Per_Session = Math.Round(weekGroup.Average(s => s.Duration), 1)
                        });
                    }
                    break;
                case Period.Month:
                    var monthGroups = sessions.GroupBy(s => DateTime.Parse(s.StartTime!).Month);
                    foreach (var monthGroup in monthGroups)
                    {
                        var datesInMonth = monthGroup.Select(s => DateTime.Parse(s.StartTime!).Date);
                        var minDate = datesInMonth.Min();
                        var maxDate = datesInMonth.Max();
                        reports.Add(new PeriodReport
                        {
                            Period = period,
                            DisplayValue = $"{minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}",
                            Total_Hours = monthGroup.Sum(s => s.Duration),
                            Average_Hours_Per_Session = Math.Round(monthGroup.Average(s => s.Duration), 1)
                        });
                    }
                    break;
                case Period.Year:
                    var yearGroups = sessions.GroupBy(s => DateTime.Parse(s.StartTime!).Year);
                    foreach (var yearGroup in yearGroups)
                    {
                        var start = new DateTime(yearGroup.Key, 1, 1);
                        var end = new DateTime(yearGroup.Key, 12, 31);
                        reports.Add(new PeriodReport
                        {
                            Period = period,
                            DisplayValue = $"{start.ToShortDateString()} - {end.ToShortDateString()}",
                            Total_Hours = yearGroup.Sum(s => s.Duration),
                            Average_Hours_Per_Session = Math.Round(yearGroup.Average(s => s.Duration), 1)
                        });
                    }
                    break;

            }

            return reports;
        }

    }
}

