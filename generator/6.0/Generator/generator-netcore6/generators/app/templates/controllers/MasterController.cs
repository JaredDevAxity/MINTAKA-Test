// <summary>
// <copyright file="[%= controllerName %]Controller.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Api.Controllers
{
    /// <summary>
    /// [%= controllerName %]Controller class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class [%= controllerName %]Controller : ControllerBase
    {
        private readonly I[%= controllerName %]Facade [%= controllerNameLower %]Facade;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= controllerName %]Controller"/> class.
        /// </summary>
        /// <param name="[%= controllerNameLower %]Facade">User Facade.</param>
        public [%= controllerName %]Controller(I[%= controllerName %]Facade [%= controllerNameLower %]Facade)
            => this.[%= controllerNameLower %]Facade = [%= controllerNameLower %]Facade ?? throw new ArgumentNullException(nameof([%= controllerNameLower %]Facade));
[% if (controllerGet) { %]
        /// <summary>
        /// Method for get all [%= controllerNameLower %].
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{[%= singularControllerName %]Dto}}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => this.Ok(await this.[%= controllerNameLower %]Facade.GetAllAsync());

        /// <summary>
        /// Method for get a [%= singularControllerNameLower %] by id.
        /// </summary>
        /// <param name="id">[%= singularControllerName %] Id.</param>
        /// <returns>A <see cref="Task{[%= singularControllerName %]Dto}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => this.Ok(await this.[%= controllerNameLower %]Facade.GetByIdAsync(id));
[% } %][% if (controllerPost) { %]
        /// <summary>
        /// Method for insert a [%= singularControllerNameLower %].
        /// </summary>
        /// <param name="[%= singularControllerNameLower %]Request">Object to insert.</param>
        /// <returns>A <see cref="Task{[%= singularControllerName %]Dto}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] Create[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request)
        {
            string user = "userToken";
            var response = await this.[%= controllerNameLower %]Facade.InsertAsync(user, [%= singularControllerNameLower %]Request);
            return this.Created($"/api/[%= controllerName %]/{response.Id}", response);
        }
[% } %][% if (controllerPut) { %]
        /// <summary>
        /// Method for update a [%= singularControllerNameLower %].
        /// </summary>
        /// <param name="id">[%= singularControllerName %] Id.</param>
        /// <param name="[%= singularControllerNameLower %]Request">Object to update.</param>
        /// <returns>A <see cref="Task{[%= singularControllerName %]Dto}"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] Update[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request)
        {
            string user = "userToken";
            var response = await this.[%= controllerNameLower %]Facade.UpdateAsync(id, user, [%= singularControllerNameLower %]Request);
            return this.Ok(response);
        }
[% } %][% if (controllerDelete) { %]
        /// <summary>
        /// Method to DeleteAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this.[%= controllerNameLower %]Facade.DeleteAsync(id);
            return this.Ok();
        }
[% } %]
        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <returns>Pong.</returns>
        [Route("ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return this.Ok("Pong");
        }
    }
}
