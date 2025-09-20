using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Exceptions
{
    public sealed class BasketNotFoundEx(string id): NotFoundEx($"Basket With Id= {id} Not Found")
    {
    }
}
