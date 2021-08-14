using System.Threading.Tasks;
using Examples.WebApi.Application.Models;

namespace Examples.WebApi.Application.Repositories
{
    public interface IRocketRepository
    {
        Task<Rocket> GetRocket(int rocketId);

        void VisitPlanet(Rocket rocket, Planet planet);

    }
}