using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ts.Restaurant.Order.Routing.Mapper
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig(IServiceCollection service)
        {
            this.AutoMapperConfigure(service);
        }
        private void AutoMapperConfigure(IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                

            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
