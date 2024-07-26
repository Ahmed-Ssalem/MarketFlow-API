using MarketFlow.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using MarketFlow.Core.Interfaces.Services;

namespace MarketFlow.Api.Controllers
{

    /// <summary>
    /// API controller for managing stores.
    /// </summary>
    /// 
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : Controller
    {
        private readonly IStoreServices _storeServices;

        public StoresController(IStoreServices storeServices)
        {
            _storeServices = storeServices;
        }


        /// <summary>
        /// Gets all stores with their products and quantities.
        /// </summary>
        /// <returns>A list of stores with their products and quantities.</returns>
         
        [HttpGet("GetAllStores")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _storeServices.GetAllStores();

            if (!response.Succeeded) 
                return BadRequest(response);

            return Ok(response);
        }


        /// <summary>
        /// Gets a store by id with its products and quantities.
        /// </summary>
        /// <param name="id">The ID of the store.</param>
        /// <returns>A store with its products and quantities.</returns>

        [HttpGet("GetStoreById")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _storeServices.GetStoreById(id);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Creates a new store.
        /// </summary>
        /// <param name="storeForCreationDto">The store to create.</param>
        /// <returns>The created store.</returns>

        [HttpPost("CreateStore")]
        public async Task<IActionResult> CreateAsync(StoreForCreationDto storeForCreationDto)
        {

            var response = await _storeServices.CreateStore(storeForCreationDto);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
            
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="id">The ID of the store to update.</param>
        /// <param name="storeForUpdateDto">The updated store data.</param>
        /// <returns>The updated store.</returns>

        [HttpPut("UpdateStore")]
        public async Task<IActionResult> UpdateAsync(long id, StoreForCreationDto storeForCreationDto)
        {
            var response = await _storeServices.UpdateStore(id, storeForCreationDto);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Deletes a store.
        /// </summary>
        /// <param name="id">The ID of the store to delete.</param>
        /// <returns>The deleted store.</returns>

        [HttpDelete("DeleteStore")]
        public async Task<IActionResult> DeleteAsync(long id)
        {

            var response = await _storeServices.DeleteStore(id);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);

        }
    }
}
