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
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreatePost(PostForCreationDto postForCreationDto)
        {
            // if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();
            var status = _mapper.Map<Post>(postForCreationDto);
            _repo.Add(status);
            await _repo.SaveAll();

            return StatusCode(201);

        }




        // [HttpGet]
        // public async Task<IActionResult> GetPosts()
        // {
        //     var posts = _repo.GetPosts();
        //     var postToReturn = _mapper.Map<IEnumerable<PostForCreationDto>>(posts);
        //     return Ok(postToReturn);
        // }

    }
}









