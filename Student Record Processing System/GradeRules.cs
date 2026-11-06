using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Processing_System
{
    public class GradeWeights
    {
        public decimal Midterm = 30;
        public decimal Final = 30;
        public decimal Attendance = 10;
        public decimal ClassStanding = 30;

        public decimal Total
        {
            get { return Midterm + Final + Attendance + ClassStanding; }
        }
    }

    public class GradeResult
    {
        public decimal? Percent;        // halimbawa 91.00
        public decimal? GradePoint;     // 1.00 hanggang 5.00
        public string GradeText = "";   // "1.75", "5.00", "DRP", o blangko
        public string Remark = "";      // Passed, Failed, Dropped, Pending
    }

    public static class GradeRules
    {
        public const decimal PassingGradePoint = 3.00m;

        // Ang scale ng school. Ito ang tinatawag pagkatapos i-round ang percent sa buong numero.
        public static decimal ToGradePoint(int percent)
        {
            if (percent >= 98) return 1.00m;
            if (percent >= 95) return 1.25m;
            if (percent >= 92) return 1.50m;
            if (percent >= 89) return 1.75m;
            if (percent >= 86) return 2.00m;
            if (percent >= 83) return 2.25m;
            if (percent >= 80) return 2.50m;
            if (percent >= 78) return 2.75m;
            if (percent >= 75) return 3.00m;
            return 5.00m;
        }

        // Purong function: walang UI at walang shared na data, kaya ligtas gamitin sa Parallel.For.
        public static GradeResult Compute(decimal? midterm, decimal? finalExam,
                                          decimal? attendance, decimal? classStanding,
                                          bool dropped, GradeWeights w)
        {
            var r = new GradeResult();

            if (dropped)
            {
                r.GradeText = "DRP";
                r.Remark = "Dropped";
                return r;
            }

            if (!midterm.HasValue || !finalExam.HasValue ||
                !attendance.HasValue || !classStanding.HasValue)
            {
                r.Remark = "Pending";
                return r;
            }

            decimal raw = (midterm.Value * w.Midterm
                         + finalExam.Value * w.Final
                         + attendance.Value * w.Attendance
                         + classStanding.Value * w.ClassStanding) / 100m;

            // Dito inaayos ang rounding rule kung mag-iba ang patakaran
            int rounded = (int)Math.Round(raw, 0, MidpointRounding.AwayFromZero);
            decimal gp = ToGradePoint(rounded);

            r.Percent = Math.Round(raw, 2);
            r.GradePoint = gp;
            r.GradeText = gp.ToString("0.00", CultureInfo.InvariantCulture);
            r.Remark = gp <= PassingGradePoint ? "Passed" : "Failed";
            return r;
        }

        // Blangko = null (ayos lang). Kapag may laman, dapat numero mula 0 hanggang 100.
        public static bool TryParseScore(object cellValue, out decimal? score)
        {
            score = null;
            string s = cellValue == null ? "" : cellValue.ToString().Trim();
            if (s == "") return true;

            decimal d;
            if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out d))
                return false;
            if (d < 0 || d > 100) return false;

            score = d;
            return true;
        }

        // Kasalukuyang school year at tatlong nauna, halimbawa "2026-2027"
        public static string[] SchoolYears()
        {
            int start = AcademicRules.CurrentAyStart();
            var list = new string[4];
            for (int i = 0; i < 4; i++)
                list[i] = (start - i) + "-" + (start - i + 1);
            return list;
        }
    }
}
