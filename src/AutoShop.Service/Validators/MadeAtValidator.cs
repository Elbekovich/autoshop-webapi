using Microsoft.AspNetCore.Builder;

namespace AutoShop.Service.Validators
{
    public class MadeAtValidator
    {
        public static (bool isValid, string Message) isTrueMadeAt(int madeAt)
        {
            if (madeAt < 1990 || madeAt > 2023)
            {
                return (isValid: false, Message: "the date of manufacture of the car is not correct");
            }
            else
            {
                return (isValid: true, Message: "");
            }
        }
    }
}
