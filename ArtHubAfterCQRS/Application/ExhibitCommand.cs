using System.Configuration;
using System.Text;
using ArtHub.Models;
using RestSharp;

namespace ArtHub.Application
{
    class ExhibitCommand : IExhibitCommand
    {
        public void Create(Exhibit exhibit)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["ExhibitCommandUrl"]);
            var request = new RestRequest(string.Empty, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(exhibit);

            IRestResponse response = client.Execute(request);
        }
    }
}