using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExcelApp
{
    public class Mathematics
    {        
        public string Add(string value1, string value2)
        {
            return (Convert.ToInt32(value1) + Convert.ToInt32(value2)).ToString();
        }

        public string Subtract(string value1, string value2)
        {
            return (Convert.ToInt32(value1) - Convert.ToInt32(value2)).ToString();
        }

        public string Devide(string value1, string value2)
        {
            return (Convert.ToInt32(value1) / Convert.ToInt32(value2)).ToString();
        }

        public string Multiply(string value1, string value2)
        {
            return (Convert.ToInt32(value1) * Convert.ToInt32(value2)).ToString();
        }
    }
}
