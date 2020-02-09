using System.Collections.Concurrent;
using System.Threading.Tasks;
using What.Beer.Data.DataStores;
using DomainBeer = What.Beer.Common.Domain.Beer;

namespace What.Beer.Data.Repositories
{
    /// <summary>
    /// The <see cref="BeerRepository"/> class.
    /// </summary>
    class BeerRepository : IBeerRepository
    {
        /// <summary>
        /// The data store.
        /// </summary>
        private readonly IDataStore dataStore;

        /// <summary>
        /// The beer cache.
        /// </summary>
        private ConcurrentDictionary<string, DomainBeer> beerCache;

        /// <summary>
        /// Initializes a new instance of <see cref="BeerRepository"/>
        /// </summary>
        /// <param name="dataStore"></param>
        public BeerRepository(IDataStore dataStore)
        {
            this.beerCache = new ConcurrentDictionary<string, DomainBeer>();
            this.dataStore = dataStore;
        }

        /// <summary>
        /// Find a beer by its Id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="DomainBeer"/></returns>
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

        /// <summary>
        /// Save or update beer.
        /// </summary>
        /// <param name="beer">The beer.</param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task SaveOrUpdate(DomainBeer beer)
        {
            if (string.IsNullOrEmpty(beer.Id))
            {
                await Save(beer);
                return;
            }

            await Update(beer);
        }

        /// <summary>
        /// Update a beer.
        /// </summary>
        /// <param name="beer">The beer.</param>
        /// <returns>The <see cref="Task"/></returns>
        private async Task Update(DomainBeer beer)
        {
            this.beerCache.TryGetValue(beer.Id, out DomainBeer cachedBeer);
            cachedBeer = beer;
            await this.dataStore.Save(cachedBeer);
            this.beerCache.TryUpdate(cachedBeer.Id, cachedBeer, beer);
        }

        /// <summary>
        /// Save a new beer.
        /// </summary>
        /// <param name="beer">The beer.</param>
        /// <returns>The <see cref="Task"/></returns>
        private async Task Save(DomainBeer beer)
        {
            await this.dataStore.Save(beer);
            this.beerCache.TryAdd(beer.Id, beer);
        }
    }
}
