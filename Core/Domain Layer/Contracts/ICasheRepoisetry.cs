using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contracts
{
    public interface ICasheRepoisetry
    {
        //Get
        Task<string?> GetAsync(string Cashekey);





        //Set

        Task SetAsync(string Cashekey ,String CacheValue , TimeSpan TimeToLive);


    }
}
