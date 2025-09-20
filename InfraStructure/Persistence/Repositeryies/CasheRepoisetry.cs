using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using StackExchange.Redis;

namespace Persistence.Repositeryies
{
    public class CasheRepoisetry (IConnectionMultiplexer connection) : ICasheRepoisetry
    {

        readonly IDatabase database = connection.GetDatabase();
        public async Task<string?> GetAsync(string Cashekey)
        {
            var CacheValue = await database.StringGetAsync (Cashekey);

            return CacheValue.IsNullOrEmpty ? null : CacheValue.ToString();

        }

        public async Task SetAsync(string Cashekey, string CacheValue, TimeSpan TimeToLive)
        {

         await   database.StringSetAsync(Cashekey, CacheValue, TimeToLive);
        }
    }
}
