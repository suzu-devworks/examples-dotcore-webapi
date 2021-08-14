using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.WebApi.Application.Models;

namespace Examples.WebApi.Application.Repositories
{
    public class RocketRepository : IRocketRepository
    {
        public async Task<Rocket> GetRocket(int rocketId)
        {
            var rocket = new Rocket
            {
                RocketId = rocketId
            };

            return await Task.FromResult(rocket);
        }

        public void VisitPlanet(Rocket rocket, Planet planet)
        {
            rocket.VisitedPlanets ??= new List<Planet>();
            rocket.VisitedPlanets = rocket.VisitedPlanets.Append(planet);
        }
    }
}