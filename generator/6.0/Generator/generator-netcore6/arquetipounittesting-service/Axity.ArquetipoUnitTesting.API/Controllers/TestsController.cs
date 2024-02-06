// <summary>
// <copyright file="TestsController.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Api.Controllers
{
    /// <summary>
    /// TestsController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestsFacade testsFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsController"/> class.
        /// </summary>
        /// <param name="testsFacade">User Facade.</param>
        public TestsController(ITestsFacade testsFacade)
            => this.testsFacade = testsFacade ?? throw new ArgumentNullException(nameof(testsFacade));

        /// <summary>
        /// Method for get all tests.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{TestDto}}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => this.Ok(await this.testsFacade.GetAllAsync());

        /// <summary>
        /// Method for get a test by id.
        /// </summary>
        /// <param name="id">Test Id.</param>
        /// <returns>A <see cref="Task{TestDto}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => this.Ok(await this.testsFacade.GetByIdAsync(id));

        /// <summary>
        /// Method for insert a test.
        /// </summary>
        /// <param name="testRequest">Object to insert.</param>
        /// <returns>A <see cref="Task{TestDto}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateTestDto testRequest)
        {
            string user = "userToken";
            var response = await this.testsFacade.InsertAsync(user, testRequest);
            return this.Created($"/api/Tests/{response.Id}", response);
        }

        /// <summary>
        /// Method for update a test.
        /// </summary>
        /// <param name="id">Test Id.</param>
        /// <param name="testRequest">Object to update.</param>
        /// <returns>A <see cref="Task{TestDto}"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateTestDto testRequest)
        {
            string user = "userToken";
            var response = await this.testsFacade.UpdateAsync(id, user, testRequest);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to DeleteAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this.testsFacade.DeleteAsync(id);
            return this.Ok();
        }

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
