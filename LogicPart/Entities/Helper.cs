using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart.Entities
{
    public static class Helper
    {
        private static int[] DefaultValuesAray = { 0, 20, 5 };
        public static string DefaultValues => $"({DefaultValuesAray[0]}, {DefaultValuesAray[1]}, {DefaultValuesAray[2]})";
        public static Settings ParseSettingsOrNull(string input)
        {
            if ( input == "" ) return new Settings(DefaultValuesAray[0], DefaultValuesAray[1], DefaultValuesAray[2]);
          
            int[] result = new int[3];
            try
            {
                var inputArray = input.Split(",");
                result[0] = int.Parse(inputArray[0]);
                result[1] = int.Parse(inputArray[1]);
                result[2] = int.Parse(inputArray[2]);
                return new Settings(result[0], result[1], result[2]);
            }
            catch ( Exception )
            {
                return null;
            }
        }
        public static bool TryParse(string input)
        {
            try
            {
                int i = int.Parse(input);
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
