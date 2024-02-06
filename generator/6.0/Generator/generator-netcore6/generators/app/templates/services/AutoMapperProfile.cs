﻿// <summary>
// <copyright file="AutoMapperProfile.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Services.Mapping
{
    /// <summary>
    /// Class AutoMapperProfile.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {[% controllers.forEach(function(controller){ %]
            this.CreateMap<[%- controller.singularName %]Model, [%- controller.singularName %]Dto>();[% }); %]

            this.CreateMap<DateTime, string>().ConvertUsing(date => date.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
            this.CreateMap<string, DateTime>().ConvertUsing(dateStr => DateTime.Parse(dateStr));
        }
    }
}
