using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using What.Beer.Common.Domain;

namespace What.Beer.Data.DataStores.MongoDb
{
    public class MongoDataStore : IDataStore
    {
        private readonly IMongoDatabase database;

        public MongoDataStore()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            this.database = client.GetDatabase("WhatBeer");
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> filter) where T : DomainObject
        {
            var collectionName = this.GetCollectionName<T>();
            var result = await this.database
                            .GetCollection<T>(collectionName)
                            .FindAsync(filter);

            return await result.FirstOrDefaultAsync();
        }

        public async Task Save<T>(T domainObject) where T : DomainObject
        {
            var collectionName = this.GetCollectionName<T>();
            var collection = this.database.GetCollection<T>(collectionName);
            domainObject.Id = Guid.NewGuid().ToString();
            collection.InsertOne(domainObject);
        }

        private string GetCollectionName<T>() where T : DomainObject
        {
            return typeof(T).Name;
        }
    }
}
