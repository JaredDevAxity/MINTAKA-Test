// <summary>
// <copyright file="DependencyInjector.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].DependencyInjection
{
    using AutoMapper;
    using [%= company %].[%= name %].DataAccess.DAO.[%= name %];
    using [%= company %].[%= name %].Entities.Context;
    using [%= company %].[%= name %].Facade.[%= name %];
    using [%= company %].[%= name %].Facade.[%= name %].Impl;
    using [%= company %].[%= name %].Services.Mapping;
    using [%= company %].[%= name %].Services.[%= name %];
    using [%= company %].[%= name %].Services.[%= name %].Impl;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Class for DependencyInjector.
    /// </summary>
    public static class DependencyInjector
    {
        private static IServiceCollection Services { get; set; }

        /// <summary>
        /// Method to register Services.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>Interface Service Collection.</returns>
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            Services = services;
            Services.AddTransient<I[%= name %]Facade, [%= name %]Facade>();
            Services.AddTransient<I[%= name %]Service, [%= name %]Service>();
            Services.AddTransient<I[%= name %]Dao, [%= name %]Dao>();
            Services.AddTransient<IDatabaseContext, DatabaseContext>();
            return Services;
        }

        /// <summary>
        /// Method to add Db Context.
        /// </summary>
        /// <param name="configuration">Configuration Options.</param>
        public static void AddDbContext(IConfiguration configuration)
        {
            Services.AddDbContextPool<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(DatabaseContext))));
        }

        /// <summary>
        /// Add configuration Auto Mapper.
        /// </summary>
        public static void AddAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            Services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
