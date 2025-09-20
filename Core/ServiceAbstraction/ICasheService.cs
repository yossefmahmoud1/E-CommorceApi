using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ICasheService
    {

        Task<string?> GetAsync(string Cashekey);






        Task SetAsync(string Cashekey, object CashVakue , TimeSpan timeSpan  );




    }
}
