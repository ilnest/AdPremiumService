using AutoMapper;
using Model.Entities;
using Contracts.DTO;
using Contracts.Requests;
using Contracts.Responses;

namespace AdPremiumService.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Location, LocationDto>().ReverseMap();
			CreateMap<Subcategory, SubcategoryDTO>().ReverseMap();
			CreateMap<AdPremiumRequest, AdPremium>()
				.ForMember(x => x.Location, m => m.MapFrom(n => new Location() { Id = n.LocationId }))
				.ForMember(x => x.Subcategory, m => m.MapFrom(n => new Subcategory() { Id = n.SubcategoryId }))
				.ReverseMap();
			CreateMap<AdPremium, AdPremiumResponse>().ReverseMap();
		}
	}
}
