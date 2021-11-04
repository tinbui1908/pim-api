﻿using System;
using System.Collections.Generic;
using System.Linq;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Domain.Objects;
using PIMToolCodeBase.Repositories;

namespace PIMToolCodeBase.Services.Imp
{
    /// <summary>
    ///     Implementation of sample service
    /// </summary>
    public class SampleService : BaseService, ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public IQueryable<Sample> Get()
        {
            return _sampleRepository.Get();
        }

        public IEnumerable<Sample> Get(Filter filter)
        {
            return _sampleRepository.Get();
        }

        public Sample Get(int id)
        {
            return _sampleRepository.Get().SingleOrDefault(x => x.ID == id);
        }

        public Sample Create(Sample sample)
        {
            var samples = _sampleRepository.Add(sample);
            _sampleRepository.SaveChange();
            return samples.FirstOrDefault();
        }

        public Sample Update(Sample sample)
        {
            var sampleDb = _sampleRepository.Get(sample.ID);
            if (sampleDb == null)
            {
                throw new ArgumentException();
            }

            sampleDb.Details = sample.Details;
            _sampleRepository.SaveChange();
            return sampleDb;
        }

        public void Delete(int id)
        {
            _sampleRepository.Delete(id);
            _sampleRepository.SaveChange();
        }
    }
}