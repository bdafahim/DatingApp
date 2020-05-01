using System;

namespace DatingApp.API.Dtos
{
    public class PostForCreationDto
    {
        public string UserName { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }

        public PostForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}