using System.Threading.Tasks;
using Examples.WebApi.Application.Models;

namespace Examples.WebApi.Application.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        public async Task<Planet> GetPlanet(int planetId)
        {
            var planet = new Planet
            {
                PlanetId = planetId,
                Name = $"Planet-{planetId:D6}",
            };

            return await Task.FromResult(planet);
        }

    }
}