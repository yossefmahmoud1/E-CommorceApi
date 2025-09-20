using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Exceptions
{
    public class AddressNotFoundEx(string UserName):NotFoundEx($"User {UserName} Has No Address")
    {
    }
}
