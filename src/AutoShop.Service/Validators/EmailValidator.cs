using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShop.Service.Validators
{
    public class EmailValidator
    {
        public static bool isValid(string email)
        {
            bool lamp = false;
            if (email.Length < 10) lamp = false;
            else if (email.Length > 10)
            {
                if (email.StartsWith("@gmail.com"))
                { 
                    lamp = false;
                }
                else
                {

                    if (email.EndsWith("@gmail.com"))
                    {
                        lamp = true;
                    }
                }

            }
            return lamp;    
        }
    }
}
