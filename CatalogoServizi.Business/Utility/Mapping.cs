using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Utility
{
    /// <summary>
    /// Mapping
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public static class Mapping<TSource, TDestination>
    {
        /// <summary>
        /// Crea il Mapping tra TSource e TDestination
        /// </summary>
        public static TDestination Map(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<TSource, TDestination>());
            var mapper = new Mapper(config);

            return mapper.Map<TDestination>(source);
        }

    }
}
