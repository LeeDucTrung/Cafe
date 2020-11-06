using System;
using System.Collections.Generic;
using System.Text;

namespace VPDT.Utils
{
    public class Validation
    {
        public static bool HasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}-;'<>_";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                    return true;
            }
            return false;
        }
    }
}
