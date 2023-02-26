using Microsoft.AspNetCore.Http;
using SIS.Application.Features.Commands.SettingCommand.UpdateSetting;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Queries.SettingQuery.GetAll
{
	public class GetAllSettingQueryResponse
	{
		public UpdateSettingCommandRequest Request { get; set; }
	}
}
