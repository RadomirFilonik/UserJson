using System;
using System.Collections.Generic;
using System.Text;

namespace userJson.Helpers
{
    public class ValidateDate
    {
        public int[] CheckDate(string imputString)
        {
            var tableOfDateString = imputString.Split('.');

            if(tableOfDateString.Length == 3)
            {
                var validYear = int.TryParse(tableOfDateString[0], out int argsYear);
                var validMonth = int.TryParse(tableOfDateString[1], out int argsMonth);
                var validDay = int.TryParse(tableOfDateString[2], out int argsDay);
                if (validYear && validMonth && validDay)
                {
                    int[] tableOfInts = new int[3];
                    tableOfInts[0] = argsYear;
                    tableOfInts[1] = argsMonth;
                    tableOfInts[2] = argsDay;
                    return tableOfInts;
                }
                else
                {
                    int[] tableOfInts = new int[1] { 0 };
                    return tableOfInts;
                }

            }
            else
            {
                int[] tableOfInts = new int[1] {0};
                return tableOfInts;
            }
        }
    }
}
