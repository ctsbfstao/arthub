using System;
using System.Linq;
using System.Net;
using System.Data.Entity;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArtHub.CommandService
{
    public class CommandServiceFunction
    {
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            ExhibitData entry = await req.Content.ReadAsAsync<ExhibitData>();

            if (entry == null)
            {
                // were they sent in query?        
                var parameters = req.GetQueryNameValuePairs().ToList();

                var name = parameters.Where(parameter => parameter.Key == "Name").Select(parameter => parameter.Value);
                var description = parameters.Where(parameter => parameter.Key == "Description").Select(parameter => parameter.Value);
                var created = parameters.Where(parameter => parameter.Key == "Created").Select(parameter => parameter.Value);
                var typeid = parameters.Where(parameter => parameter.Key == "TypeId").Select(parameter => parameter.Value);

                if (name.Count() == 1 && description.Count() == 1 && created.Count() == 1 && typeid.Count() == 1)
                {
                    entry = new ExhibitData
                    {
                        Name = name.First(),
                        Description = description.First(),
                        Created = DateTime.Parse(created.First()),
                        TypeId = byte.Parse(typeid.First()),
                    };
                }
                else
                    return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a valid ExhibitData in the request body");
            }

            try
            {
                using (var context = new DbContext(System.Environment.GetEnvironmentVariable("ArtHubConnectionString")))
                {
                    context.Database.Connection.Open();
                    context.Database.ExecuteSqlCommand(string.Format("INSERT INTO [dbo].[Exhibits] ([Name] ,[Description] ,[Created] ,[TypeId]) VALUES ('{0}' ,'{1}' ,'{2}' ,{3}) ", entry.Name, entry.Description, entry.Created, entry.TypeId));
                    context.Database.Connection.Close();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                log.Info(string.Format("Failure with database update {0}.", ex.Message));
                return req.CreateResponse(HttpStatusCode.BadRequest, string.Format("Failure updating inventory.  Please verify the Name {0} Description {1} Created {2}  and TypeId {3} are correct.", entry.Name, entry.Description, entry.Created, entry.TypeId));
            }
            catch (Exception ex)
            {
                log.Info(string.Format("Failure during processing {0}.", ex.Message));
                return req.CreateResponse(HttpStatusCode.InternalServerError, "ArtHub Command api is currently not available.");
            }

            return req.CreateResponse(HttpStatusCode.Created);
        }
    }
}




public class ExhibitData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public byte TypeId { get; set; }
}