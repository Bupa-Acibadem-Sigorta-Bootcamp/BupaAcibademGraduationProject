using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthInsurance.EntityLayer.Concrete.Mappers;

namespace HealthInsurance.BusinessLogicLayer.Concrete.MapperConfiguration
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new AutoMapper.MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });
            return configuration.CreateMapper();
        });

        public static readonly IMapper Mapper = lazy.Value;
    }
}
