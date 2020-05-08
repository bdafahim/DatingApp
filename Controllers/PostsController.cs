using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public PostsController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpPost]
        public async Task<IActionResult> CreatePost(PostForCreationDto postForCreationDto, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var status = _mapper.Map<Post>(postForCreationDto);
            _repo.Add(status);

            var statusToReturn = _mapper.Map<PostForReturnDto>(status);

            if (await _repo.SaveAll())
            {

                return CreatedAtRoute("GetPost", new { userId = userId, id = status.Id },
                 statusToReturn);
            }
            return BadRequest("Failed to like user");

        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repo.GetPosts();
            // var postToReturn = _mapper.Map<PostForReturnDto>(posts);
            //_mapper.Map<Source>(destination)

            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPost")]

        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repo.GetPost(id);
            var postToReturn = _mapper.Map<PostForReturnDto>(post);
            return Ok(postToReturn);
        }

    }
}









