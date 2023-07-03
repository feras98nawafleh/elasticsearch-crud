using Nest;
namespace elasticsearch_crud;
public static class ElasticsearchDriver 
{

    public static async Task RunDriverAsync(this IServiceCollection services)
    {
        Console.WriteLine("1.Connecting to Elasticsearch");
        var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
            .EnableApiVersioningHeader();
        var client = new ElasticClient(connectionSettings);
        Console.WriteLine("2.Creating 'myindex' Index");
        var elasticsearch = new Elasticsearch(client, "intalio-1");
        await elasticsearch.CreateIndexIfNotExists("intalio-1");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("3.Adding or Updating Documents");
        Console.WriteLine("A. Add or update a single document");
        var document = new { id = 1, name = "Name 001" };
        Console.WriteLine(await elasticsearch.AddOrUpdate(document));

        Console.WriteLine("B. Add or update multiple documents");
        var documents = new[]
        {
            new { id = 2, name = "Name 002" },
            new { id = 3, name = "Name 003" },
        };
        Console.WriteLine(await elasticsearch.AddOrUpdateBulk(documents));
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("4.Retrieving Document");
        Console.WriteLine("A. Retrieve a single document ");
        Console.WriteLine(await elasticsearch.Get<dynamic>("1"));

        Console.WriteLine("B. Retrieve all Documents ");
        Console.WriteLine(await elasticsearch.GetAll<dynamic>());

        Console.WriteLine("C. Retrieve a set of documents that match a given query");
        var query = new TermQuery { Field = "name", Value = "Name002" };
        Console.WriteLine(await elasticsearch.Query<dynamic>(query));
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("5.Removing Documents");
        Console.WriteLine("A.Remove a single document");
        Console.WriteLine(await elasticsearch.Remove<dynamic>("1"));
        Console.WriteLine("B.Remove all documents ");
        Console.WriteLine(await elasticsearch.RemoveAll<dynamic>());
    }
}