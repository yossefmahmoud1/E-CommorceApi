using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Exceptions
{
    public class DliveryMethodNotFoundEx(int id):NotFoundEx($"Dlivery Method With Id {id} Not Found")
    {
    }
}
