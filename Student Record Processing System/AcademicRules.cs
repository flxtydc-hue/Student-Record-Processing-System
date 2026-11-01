using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Processing_System
{
    public static class AcademicRules
    {
        public const string SchoolCode = "04141";
        public static readonly string[] YearNames = { "First", "Second", "Third", "Fourth" };

        public static int MaxYear(string program)
        {
            if (program == "ACT") return 2;
            if (program == "BSCS") return 4;
            return 0;
        }

        // Pinakahuling letra ng section para sa program at year
        public static char MaxSection(string program, int year)
        {
            if (program == "ACT")
                return (year == 1 || year == 2) ? 'B' : '\0';

            if (program == "BSCS")
            {
                if (year == 1) return 'I';
                if (year == 2) return 'K';
                if (year == 3 || year == 4) return 'G';
            }
            return '\0';
        }

        public static string[] Sections(string program, int year)
        {
            char max = MaxSection(program, year);
            var list = new List<string>();
            if (max != '\0')
                for (char c = 'A'; c <= max; c++) list.Add(c.ToString());
            return list.ToArray();
        }

        public static bool IsValid(string program, int year, string section, out string error)
        {
            error = null;
            int maxYear = MaxYear(program);

            if (maxYear == 0)
            {
                error = "Select a valid program.";
                return false;
            }
            if (year < 1 || year > maxYear)
            {
                error = program + " only has " + maxYear + " years.";
                return false;
            }

            char maxSec = MaxSection(program, year);
            if (string.IsNullOrEmpty(section) || section.Length != 1 ||
                section[0] < 'A' || section[0] > maxSec)
            {
                error = program + " " + YearNames[year - 1] + " year only has sections A to " + maxSec + ".";
                return false;
            }
            return true;
        }

        // Taon kung kailan nagsimula ang kasalukuyang school year. Nagsisimula ang A.Y. sa Hunyo.
        public static int CurrentAyStart()
        {
            DateTime d = DateTime.Today;
            return d.Month >= 7 ? d.Year : d.Year - 1;
        }
    }
}
