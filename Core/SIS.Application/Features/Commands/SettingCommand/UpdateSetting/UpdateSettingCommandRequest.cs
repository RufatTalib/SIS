using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SettingCommand.UpdateSetting
{
	public class UpdateSettingCommandRequest : IRequest<UpdateSettingCommandResponse>
	{
		public string CompanyName { get; set; }
		public string CompanyDescription { get; set;}
		public int AwardCount { get; set; }
		public int FacebookFollowerCount { get; set; }
		public int InstagramFollowerCount { get; set; }
		public int TwitterFollowerCount { get; set; }
		public int LinkedInFollowerCount { get; set; }
		public string Adress { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Gmail { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string? LogoUrl { get; set; }
		public IFormFile? Logo { get; set; }
	}
}
