using ElasticSearch_using_dotnet8.Models;
using ElasticSearch_using_dotnet8.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ElasticSearch_using_dotnet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IElasticService _elasticService;
        public UsersController(IElasticService elasticService)
        {
            _elasticService = elasticService;
        }
        [HttpPost("create-index")]
        public async Task<IActionResult> CreateIndex(string indexName)
        {
            await _elasticService.CreateIndexIfNotExistAsync(indexName);
            return Ok($"Index {indexName} Created Successfully");
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(User user)
        {
            var response = await _elasticService.AddOrUpdate(user);
            return response ? Ok("user added or updated successfully") : StatusCode(500, "Error adding or updating User");
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var response = await _elasticService.AddOrUpdate(user);
            return response ? Ok("user updated successfully") : StatusCode(500, "Error updating User");
        }

        [HttpGet("get-user/{key}")]
        public async Task<IActionResult> GetUser(string key)
        {
            var user = await _elasticService.Get(key);
            return user != null? Ok(user):NotFound("User not Found");
        }

        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _elasticService.GetAll();
            return users != null ? Ok(users) : StatusCode(500, "Error retrieving users.");
        }

        [HttpDelete("Delete/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var response = await _elasticService.Remove(key);
            return response ? Ok("User Deleted Successfully") : StatusCode(500, "failed in Deleting User");
        }

        [HttpDelete("Delete-all-users")]
        public async Task<IActionResult> DeleteAll()
        {
            var response = await _elasticService.RemoveAll();
            return response.HasValue ? Ok($"{response.Value} users has been deleted") : StatusCode(500, "failed to delete all users");
        }
    }
}

