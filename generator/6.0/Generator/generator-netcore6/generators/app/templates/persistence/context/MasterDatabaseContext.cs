﻿// <summary>
// <copyright file="DatabaseContext.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Persistence.Context
{
    /// <summary>
    /// Class DBcontext.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="options">Connection Options.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
[% controllers.forEach(function(controller){ %]
        /// <summary>
        /// Gets or sets [%- controller.name %].
        /// </summary>
        /// <value>
        /// <see cref="DbSet{[%- controller.singularName %]Model}"/> [%- controller.name %].
        /// </value>
        public DbSet<[%- controller.singularName %]Model> [%- controller.name %] { get; set; }
[% }); %]
        /// <summary>
        /// Metho On Model Creating.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
