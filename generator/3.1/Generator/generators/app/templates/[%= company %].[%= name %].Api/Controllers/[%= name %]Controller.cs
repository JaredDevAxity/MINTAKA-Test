// <summary>
// <copyright file="[%= name %]Controller.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using [%= company %].[%= name %].Dtos.[%= name %];
    using [%= company %].[%= name %].Facade.[%= name %];
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using StackExchange.Redis;

    /// <summary>
    /// Class [%= name %] Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class [%= name %]Controller : ControllerBase
    {
        private readonly I[%= name %]Facade logicFacade;

        private readonly IDatabase database;

        private readonly IConnectionMultiplexer redis;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= name %]Controller"/> class.
        /// </summary>
        /// <param name="logicFacade">[%= name %] Facade.</param>
        /// <param name="redis">Redis Cache.</param>
        public [%= name %]Controller(I[%= name %]Facade logicFacade, IConnectionMultiplexer redis)
        {
            this.logicFacade = logicFacade ?? throw new ArgumentNullException(nameof(logicFacade));
            this.redis = redis ?? throw new ArgumentNullException(nameof(redis));
            this.database = redis.GetDatabase();
        }

        /// <summary>
        /// Method to get all [%= name %].
        /// </summary>
        /// <returns>List of [%= name %].</returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await this.logicFacade.GetList[%= name %]Active();
            return this.Ok(response);
        }

        /// <summary>
        /// Method to get [%= name %] By Id.
        /// </summary>
        /// <param name="id">[%= name %] Id.</param>
        /// <returns>[%= name %] Model.</returns>
        [Route("{[%= name %]Id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            [%= name %]Dto response = null;

            ////Example to get value with Redis Cache
            var result = await this.database.StringGetAsync(id.ToString());

            if (!result.HasValue)
            {
                response = await this.logicFacade.GetList[%= name %]Active(id);

                ////Example to set value with Redis Cache
                await this.database.StringSetAsync(id.ToString(), JsonConvert.SerializeObject(response));
            }
            else
            {
                ////If key in Redis, deserialize response and return object
                response = JsonConvert.DeserializeObject<[%= name %]Dto>(result);
            }

            return this.Ok(response);
        }

        /// <summary>
        /// Method to Add [%= name %].
        /// </summary>
        /// <param name="dataToStore">[%= name %] Model.</param>
        /// <returns>Success or exception.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] [%= name %]Dto dataToStore)
        {
            var response = await this.logicFacade.Insert[%= name %](dataToStore);
            return this.Ok(response);
        }

        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <returns>Pong.</returns>
        [Route("/ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return this.Ok("Pong");
        }
    }
}