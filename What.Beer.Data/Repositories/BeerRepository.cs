using System.Collections.Concurrent;
using System.Threading.Tasks;
using What.Beer.Data.DataStores;
using DomainBeer = What.Beer.Common.Domain.Beer;

namespace What.Beer.Data.Repositories
{
    class BeerRepository : IBeerRepository
    {
        private readonly IDataStore dataStore;

        private ConcurrentDictionary<string, DomainBeer> beerCache;

        public BeerRepository(IDataStore dataStore)
        {
            this.beerCache = new ConcurrentDictionary<string, DomainBeer>();
            this.dataStore = dataStore;
        }

        public async Task<DomainBeer> FindById(string id)
        {
            if(!this.beerCache.TryGetValue(id, out DomainBeer cachedBeer))
            {
                var result = await this.dataStore.Find<DomainBeer>(beer => beer.Id == id);
                this.beerCache.TryAdd(id, result);
                return result;
            }

            return cachedBeer;
        }

        public async Task SaveOrUpdate(DomainBeer beer)
        {
            if (string.IsNullOrEmpty(beer.Id))
            {
                await Save(beer);
                return;
            }

            await Update(beer);
        }

        private async Task Update(DomainBeer beer)
        {
            this.beerCache.TryGetValue(beer.Id, out DomainBeer cachedBeer);
            cachedBeer = beer;
            await this.dataStore.Save(cachedBeer);
            this.beerCache.TryUpdate(cachedBeer.Id, cachedBeer, beer);
        }

        private async Task Save(DomainBeer beer)
        {
            await this.dataStore.Save(beer);
            this.beerCache.TryAdd(beer.Id, beer);
        }
    }
}
