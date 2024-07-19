using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniApp.Helpers
{
    public static class Extensions
    {
        public static bool CheckName(this string value)
        {
            if (!char.IsUpper(value[0]) && value.Length < 3)
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == ' ')
                    return false;
            }
            return true;
        }

        public static bool CheckClassroomName(this string value)
        {
            return (char.IsUpper(value[0]) && char.IsUpper(value[1])
                  && char.IsDigit(value[2]) && char.IsDigit(value[3])
                  && char.IsDigit(value[4]));
        }
    }
}
