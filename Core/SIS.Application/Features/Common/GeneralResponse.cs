using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Common
{
	public class GeneralResponse
	{
		public bool Success { get; set; }
		public string? ErrorMessage { get; set; }

	}
}
