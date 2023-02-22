using MediatR;
using Microsoft.AspNetCore.Hosting;
using SIS.Application.Extentions;
using SIS.Application.Features.Commands.SubjectCommand.CreateSubject;
using SIS.Application.Repositories.SliderImageRepository;
using SIS.Application.Repositories.SliderRepository;
using SIS.Application.Repositories.SubjectRepository;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Application.Features.Commands.SliderCommand.CreateSlider
{
    public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommandRequest, CreateSliderCommandResponse>
    {
        private readonly ISliderWriteRepository _sliderWriteRepository;
        private readonly ISliderImageWriteRepository _sliderImageWriteRepository;
		private readonly IWebHostEnvironment _env;

		public CreateSliderCommandHandler(
            ISliderWriteRepository sliderWriteRepository, 
            ISliderImageWriteRepository sliderImageWriteRepository,
            IWebHostEnvironment env
            )
        {
            _sliderWriteRepository = sliderWriteRepository;
            _sliderImageWriteRepository = sliderImageWriteRepository;
			_env = env;
		}
        public async Task<CreateSliderCommandResponse> Handle(CreateSliderCommandRequest request, CancellationToken cancellationToken)
        {
            List<SliderImage> images = new();

            Slider slider = new Slider
            {
                CreatedDate = DateTime.UtcNow,
                RemovedDate = null,
                IsDeleted = false,
                Caption = request.Caption,
                Title = request.Title
            };

            request.Images.ForEach(x =>
            {
                SliderImage sliderImage = new SliderImage
                {
                    CreatedDate = DateTime.UtcNow,
                    RemovedDate = null,
                    IsDeleted = false,
                    ImageSrc = x.Save(_env.WebRootPath, "SliderPhotos"),
                    Slider = slider
                };
                
                images.Add(sliderImage);
                _sliderImageWriteRepository.Add(sliderImage);

            });

            slider.Images = images;

            _sliderWriteRepository.Add(slider);
            _sliderWriteRepository.Save();
            _sliderImageWriteRepository.Save();

            return new CreateSliderCommandResponse() { Success = true };
        }
    }
}
