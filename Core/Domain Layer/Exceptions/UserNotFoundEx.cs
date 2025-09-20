using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Exceptions
{
    public sealed class UserNotFoundEx (string email):NotFoundEx($"User With Email= {email} Not Found")
    {



    }
}
