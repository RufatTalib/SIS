using MediatR;
using Microsoft.EntityFrameworkCore;
using SIS.Application.Repositories.SliderRepository;
using SIS.Domain.Entities;
using SIS.Infrastructure.Tools;

namespace SIS.Application.Features.Queries.SliderQuery.GetAll
{
	public class GetAllSliderQueryHandler : IRequestHandler<GetAllSliderQueryRequest, GetAllSliderQueryResponse>
	{
		private readonly ISliderReadRepository _sliderReadRepository;

		public GetAllSliderQueryHandler(ISliderReadRepository sliderReadRepository)
		{
			_sliderReadRepository = sliderReadRepository;
		}
		public async Task<GetAllSliderQueryResponse> Handle(GetAllSliderQueryRequest request, CancellationToken cancellationToken)
		{
			IQueryable<Slider> query = _sliderReadRepository.Table.AsQueryable().Where(x => x.IsDeleted == false)
				.Include(x => x.Images);

			if (request.Page == 0) request.Page = 1;
			if (request.PageSize == 0) request.PageSize = 10;

			PaginatedList<Slider> sliders = PaginatedList<Slider>.Create(query, request.Page, request.PageSize);

			return new GetAllSliderQueryResponse { Sliders = sliders };
		}
	}
}
