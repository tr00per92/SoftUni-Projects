﻿namespace SportSystem.Common.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public static class AutoMapperConfig
    {
        public static void Execute(ICollection<Assembly> assemblies)
        {
            var types = assemblies.SelectMany(x => x.GetExportedTypes()).ToList();
            LoadStandardFromMappings(types);
            LoadStandardToMappings(types);
            LoadCustomMappings(types);
        }

        private static void LoadStandardFromMappings(IEnumerable<Type> types)
        {
            var maps = GetFromMaps(types);
            CreateMappings(maps);
        }

        private static void LoadStandardToMappings(IEnumerable<Type> types)
        {
            var maps = GetToMaps(types);
            CreateMappings(maps);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                             !t.IsAbstract &&
                             !t.IsInterface
                       select (IHaveCustomMappings)Activator.CreateInstance(t);

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            var fromMaps = from t in types
                           from i in t.GetInterfaces()
                           where i.IsGenericType &&
                                 i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                 !t.IsAbstract &&
                                 !t.IsInterface
                           select new TypesMap
                           {
                               Source = i.GetGenericArguments()[0],
                               Destination = t
                           };

            return fromMaps;
        }

        private static IEnumerable<TypesMap> GetToMaps(IEnumerable<Type> types)
        {
            var toMaps = from t in types
                         from i in t.GetInterfaces()
                         where i.IsGenericType &&
                               i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                               !t.IsAbstract &&
                               !t.IsInterface
                         select new TypesMap
                         {
                             Source = t,
                             Destination = i.GetGenericArguments()[0]
                         };

            return toMaps;
        }

        private static void CreateMappings(IEnumerable<TypesMap> maps)
        {
            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }
    }
}
