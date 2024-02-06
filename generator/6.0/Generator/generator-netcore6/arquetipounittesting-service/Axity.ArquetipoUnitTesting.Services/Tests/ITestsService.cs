// <summary>
// <copyright file="ITestsService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Services.Tests
{
    /// <summary>
    /// Interface IProjectService.
    /// </summary>
    public interface ITestsService
    {
        /// <summary>
        /// Method for get all tests.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{TestDto}}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TestDto>> GetAllAsync();

        /// <summary>
        /// Method for get a test by id.
        /// </summary>
        /// <param name="id">Test Id.</param>
        /// <returns>A <see cref="Task{TestDto}"/> representing the result of the asynchronous operation.</returns>
        Task<TestDto> GetByIdAsync(int id);

        /// <summary>
        /// Method for insert a test.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="CreateTestDto">Object to insert.</param>
        /// <returns>A <see cref="Task{TestDto}"/> representing the result of the asynchronous operation.</returns>
        Task<TestDto> InsertAsync(string user, CreateTestDto testRequest);

        /// <summary>
        /// Method for update a test.
        /// </summary>
        /// <param name="id">Test Id.</param>
        /// <param name="user">User name.</param>
        /// <param name="UpdateTestDto">Object to update.</param>
        /// <returns>A <see cref="Task{TestDto}"/> representing the result of the asynchronous operation.</returns>
        Task<TestDto> UpdateAsync(int id, string user, UpdateTestDto testRequest);

        /// <summary>
        /// Method for delete a test.
        /// </summary>
        /// <param name="id">Test  Id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}