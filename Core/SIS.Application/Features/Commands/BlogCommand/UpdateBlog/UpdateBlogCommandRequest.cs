using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.BlogCommand.UpdateBlog
{
    public class UpdateBlogCommandRequest : IRequest<UpdateBlogCommandResponse>
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Please, enter blog title !")]
        [StringLength(maximumLength: 55, MinimumLength = 5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, enter description !")]
        [StringLength(maximumLength: 160, MinimumLength = 50)]
        public string Description { get; set; }
        public bool IsAnonymous { get; set; }

        public IFormFile? Image { get; set; }
    }
}
