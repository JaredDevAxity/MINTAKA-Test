// <summary>
// <copyright file="BaseTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Test
{
    using System;
    using System.Collections.Generic;
    using [%= company %].[%= name %].Dtos.[%= name %];
    using [%= company %].[%= name %].Entities.Model;

    /// <summary>
    /// Class Base Test.
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// List of [%= name %]s.
        /// </summary>
        /// <returns>IEnumerable [%= name %]s.</returns>
        public IEnumerable<[%= name %]Model> GetAll[%= name %]s()
        {
            return new List<[%= name %]Model>()
            {
                new [%= name %]Model { Id = 1, FirstName = "Alejandro", LastName = "Ojeda", Email = "alejandro.ojeda@axity.com", Birthdate = DateTime.Now },
                new [%= name %]Model { Id = 2, FirstName = "Jorge", LastName = "Morales", Email = "jorge.morales@axity.com", Birthdate = DateTime.Now },
                new [%= name %]Model { Id = 3, FirstName = "Arturo", LastName = "Miranda", Email = "arturo.miranda@axity.com", Birthdate = DateTime.Now },
                new [%= name %]Model { Id = 4, FirstName = "Benjamin", LastName = "Galindo", Email = "benjamin.galindo@axity.com", Birthdate = DateTime.Now },
            };
        }

        /// <summary>
        /// Gets user Dto.
        /// </summary>
        /// <returns>the user.</returns>
        public [%= name %]Dto Get[%= name %]Dto()
        {
            return new [%= name %]Dto
            {
                Id = 10,
                FirstName = "Jorge",
                LastName = "Morales",
                Email = "test@test.com",
                Birthdate = DateTime.Now,
            };
        }
    }
}
