using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using ServiceAbstraction;

namespace Service
{
    public class CasheService (ICasheRepoisetry casheRepoisetry) : ICasheService
    {
        public async Task<string?> GetAsync(string Cashekey)
        {

            return await casheRepoisetry.GetAsync(Cashekey);   

        }

        public async Task SetAsync(string Cashekey, object CashVakue, TimeSpan timeSpan)
        {
            var Value= JsonSerializer.Serialize(CashVakue);

           await  casheRepoisetry.SetAsync(Cashekey, Value, timeSpan);



        }
    }
}
