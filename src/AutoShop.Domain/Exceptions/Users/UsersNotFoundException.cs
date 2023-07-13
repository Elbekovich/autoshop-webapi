using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShop.Domain.Exceptions.Users;

public class UsersNotFoundException : NotFoundException
{
    public UsersNotFoundException()
    {
        this.TitleMessage = "User not found";
    }

}
