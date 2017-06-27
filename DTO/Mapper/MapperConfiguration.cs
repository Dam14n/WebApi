using Model;

namespace DTO.Mapper
{
	public class MapperConfiguration
	{
		public static void RegisterMappings()
		{
			ConfigureDivision();
		}

		private static void ConfigureDivision()
		{
			AutoMapper.Mapper.CreateMap<Division, DivisionDTO>()
			.ForMember(dest => dest.SubDivisions,
					   opts => opts.MapFrom(src => src.SubDivisions))
			.ReverseMap();
		}
	}
}
