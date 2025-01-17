﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Domain.Interfaces;
using InterviewProject.Domain.Models;

namespace InterviewProject.Weather
{
    public class StaticWeatherProvider : IWeatherProvider
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IEnumerable<WeatherForecast>> GetForecastFor(string location)
        {
            var rng = new Random();
            IEnumerable<WeatherForecast> result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Task.FromResult(result);
        }
    }
}
