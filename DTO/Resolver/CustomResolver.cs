using System.Collections.Generic;
using AutoMapper;
using Model;

namespace DTO.Resolver
{
	public class CustomResolver : ValueResolver<List<SubDivision>, int>
	{
		protected override int ResolveCore(List<SubDivision> source)
		{
			if (source != null)
			{
				return source[0].SubDivisionId;
			}
			return 0;
		}
	}
}
