using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Mapping
{
    /// <summary>
    /// Mapper utility
    /// </summary>
    public static class MapperUtility
    {
        /// <summary>
        /// Configura il mapping
        /// </summary>
        /// <param name="services">Servizio</param>
        /// <param name="entryPoint">Type per entry point</param>
        public static void AddMapping(this IServiceCollection services, Type entryPoint)
        {
            services.AddAutoMapper(entryPoint.Assembly);
        }

        /// <summary>
        /// Mapper
        /// </summary>
        /// <typeparam name="TSource">Origine</typeparam>
        /// <typeparam name="TOutput">Destinazione</typeparam>
        /// <param name="item">Item</param>
        /// <returns></returns>
        public static TOutput MapTo<TSource, TOutput>(this TSource item)
            where TOutput : TSource
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TOutput>());
            var mapper = new Mapper(config);
            return mapper.Map<TOutput>(item);
        }
    }
}
