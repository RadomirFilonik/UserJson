using System;
using System.Collections.Generic;
using System.Text;

namespace userJson.Helpers
{
    public class CalculateAge
    {
        // Simply method to calculate age: https://stackoverflow.com/a/11942
        public int ComputeAge(int[] tableOfIntsDataNumers)
        {
            var month = tableOfIntsDataNumers[0];
            var year = tableOfIntsDataNumers[1];
            var day = tableOfIntsDataNumers[2];

            var today = (DateTime.Today.Year * 100 + DateTime.Today.Month) * 100 + DateTime.Today.Day;
            var birthday = (year * 100 + month) * 100 + day;
            return (today - birthday) / 10000;
        }
    }
}
