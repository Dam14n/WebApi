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
				//.ForMember(div => div.SubDivisions, divDto => divDto.Ignore())
				.ReverseMap();
		}
	}
}
