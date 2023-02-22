using MediatR;
using SIS.Application.Repositories.SliderImageRepository;
using SIS.Application.Repositories.SliderRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SliderCommand.DeleteSlider
{
	public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommandRequest, DeleteSliderCommandResponse>
	{
		private readonly ISliderReadRepository _sliderReadRepository;
		private readonly ISliderWriteRepository _sliderWriteRepository;
		private readonly ISliderImageReadRepository _sliderImageReadRepository;
		private readonly ISliderImageWriteRepository _sliderImageWriteRepository;

		public DeleteSliderCommandHandler(
			ISliderReadRepository sliderReadRepository, 
			ISliderWriteRepository sliderWriteRepository,
			ISliderImageReadRepository sliderImageReadRepository,
			ISliderImageWriteRepository sliderImageWriteRepository
		)
		{
			_sliderReadRepository = sliderReadRepository;
			_sliderWriteRepository = sliderWriteRepository;
			_sliderImageReadRepository = sliderImageReadRepository;
			_sliderImageWriteRepository = sliderImageWriteRepository;
		}
		public async Task<DeleteSliderCommandResponse> Handle(DeleteSliderCommandRequest request, CancellationToken cancellationToken)
		{
			Slider slider = await _sliderReadRepository.GetByIdAsync(request.Id);

			if(slider is null) return new() { Success = false, ErrorMessage = "Slider not found!" };

			slider.IsDeleted = true;
			slider.RemovedDate = DateTime.UtcNow;

			List<SliderImage> images = _sliderImageReadRepository.GetWhere(x => x.SliderId== request.Id && x.IsDeleted == false).ToList();

			images.ForEach(x =>
			{
				x.IsDeleted = true;
				x.RemovedDate = DateTime.UtcNow;
			});
			_sliderImageWriteRepository.UpdateRange(images);

			if (! _sliderWriteRepository.Update(slider)) return new() { Success = false, ErrorMessage = "Delete operation failed!" };

			_sliderWriteRepository.Save();
			_sliderImageWriteRepository.Save();

			return new() { Success = true };
		}
	}
}
