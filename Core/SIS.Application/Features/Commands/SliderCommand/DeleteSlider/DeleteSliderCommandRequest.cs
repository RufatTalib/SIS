﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SliderCommand.DeleteSlider
{
	public class DeleteSliderCommandRequest : IRequest<DeleteSliderCommandResponse>
	{
		public int Id { get; set; }
	}
}
