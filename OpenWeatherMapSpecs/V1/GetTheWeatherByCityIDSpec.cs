﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBDD.V1;

namespace OpenWeatherMapSpecs.V1
{
    [TestClass]
    public class GetTheWeatherByCityIDSpec : OpenWeatherMapServiceSpec<GetTheWeatherByCityIDSpec>
    {
        public string CityID { get; set; }
        public string CityName { get; set; }

        [Bdd.Given]
        public void Given_I_want_to_know_the_weather_by_ID()
        {
            var spec = Bdd.DependsOn<GetTheWeatherByCityNameSpec>();

            CityID = spec.Result.Id;
            CityName = spec.Result.Name;
        }

        [Bdd.When]
        public async Task When_I_have_asked_the_forecast_by_city_name()
        {
            Result = await OpenWeatherMapService.GetWeatherForecastAsync(CityID).ConfigureAwait(false);
        }

        [Bdd.Then]
        public void Then_I_will_get_the_wheather_forecast()
        {
            Assert.IsNotNull(Result);
        }

        [Bdd.Then]
        public void And_the_forecast_will_have_the_city_id()
        {
            Assert.AreEqual(CityID, Result.Id);
        }

        [Bdd.Then]
        public void And_the_forecast_will_have_the_city_name()
        {
            Assert.AreEqual(CityName, Result.Name);
        }

        [Bdd.Then]
        public void And_the_forecast_will_have_the_coordinates()
        {
            Assert.IsNotNull(Result.Coord);
        }

        [Bdd.Then]
        public void And_the_forecast_will_have_the_main_information()
        {
            Assert.IsNotNull(Result.Main);
        }

        [Bdd.Then]
        public void And_the_forecast_will_have_the_wheather_information()
        {
            Assert.IsNotNull(Result.Weather);
        }
    }
}