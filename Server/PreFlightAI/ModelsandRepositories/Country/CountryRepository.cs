﻿using System.Collections.Generic;
using System.Linq;
using PreFlightAI.Data;
using PreFlightAI.Shared;

namespace PreFlightAI.Api.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.countries;
        }

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.countries.FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
