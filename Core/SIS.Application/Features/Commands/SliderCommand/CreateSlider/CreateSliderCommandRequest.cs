using MediatR;
using Microsoft.AspNetCore.Http;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SliderCommand.CreateSlider
{
    public class CreateSliderCommandRequest : IRequest<CreateSliderCommandResponse>
    {
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }

        [StringLength(maximumLength: 70)]
        public string Caption { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
