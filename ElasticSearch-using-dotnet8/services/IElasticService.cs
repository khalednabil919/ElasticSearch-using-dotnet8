using ElasticSearch_using_dotnet8.Models;

namespace ElasticSearch_using_dotnet8.services
{
    public interface IElasticService
    {
        //create index
        Task CreateIndexIfNotExistAsync(string indexName);

        //add or update user
        Task<bool> AddOrUpdate(User user);

        //add or update bulk
        Task<bool> AddOrUpdateBulk(IEnumerable<User> users, string indexName);

        //get user
        Task<User> Get(string key);

        //get all users
        Task<List<User>?> GetAll();

        //remove
        Task<bool> Remove(string key);

        //remove all
        Task<long?> RemoveAll();

    }
}
