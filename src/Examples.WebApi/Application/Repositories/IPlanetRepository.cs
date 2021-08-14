using System.Threading.Tasks;
using Examples.WebApi.Application.Models;

namespace Examples.WebApi.Application.Repositories
{
    public interface IPlanetRepository
    {
        Task<Planet> GetPlanet(int planetId);
    }
}