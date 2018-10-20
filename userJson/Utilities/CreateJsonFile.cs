using Newtonsoft.Json.Linq;
using userJson.Helpers;
using userJson.Models;

namespace userJson.Utilities
{
    public class CreateJsonFile
    {
        private static CalculateAge _calculateAge = new CalculateAge();
        private static ValidateDate _validateDate = new ValidateDate();

        public JObject CreateJson(string firstName, string secondName, string tableOfStringDataNumbers, out bool isCreated)
        {
            var newUser = new User();
            var tableOfIntsDataNumers = _validateDate.CheckDate(tableOfStringDataNumbers);

            if (tableOfIntsDataNumers.Length == 3)
            {
                newUser.Name = firstName + " " + secondName;
                newUser.Age = _calculateAge.ComputeAge(tableOfIntsDataNumers);
                isCreated = true;
                return JObject.FromObject(newUser);
            }
            else
            {
                isCreated = false;
                return JObject.FromObject(newUser);
            }
            
        }
    }
}
