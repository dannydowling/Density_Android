﻿using System.Collections.Generic;
using System.Linq;
using DensityServer.Data;
using DensityServer.Shared;

namespace DensityServer.Api.Models
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