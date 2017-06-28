using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Model;

namespace DTO.Mapper
{
	public static class MapperConfiguration
	{
		public static void RegisterMappings()
		{
			AutoMapper.Mapper.AssertConfigurationIsValid();
			ConfigureDivision();
		}

		private static void ConfigureDivision()
		{
			//AutoMapper.Mapper.CreateMap<SubDivision, int>().ConvertUsing(src => src.SubDivisionId);

			/*Expression<Func<Division, IEnumerable<SubDivision>>> modelMemberSelector = dto => dto.SubDivisions;
			Expression<Func<IEnumerable<SubDivision>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.SubDivisionId).ToArray();
			var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);*/

			AutoMapper.Mapper.CreateMap<Division, DivisionDTO>()
				.ForEntityDtoIdCollectionMember(dto => dto.SubDivisions, model => model.SubDivisions);
			//.ForMember(dto => dto.SubDivisions, opt => opt.MapFrom(Expression.Lambda<Func<Division, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
			//.ForMember(dto => dto.SubDivisions,model => model.MapFrom);
			//	.ForMember(dto => dto.SubDivisions, opts => opts.MapFrom(src => src.SubDivisions));
			//.ForMember(div => div.SubDivisions, divDto => divDto.Ignore())
			//.ForMember(div => div.SubDivisions, opts => opts.MapFrom(src => src.SubDivisions));
			/*
						Expression<Func<IEnumerable<TModelMemberItem>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.Id).ToArray();
						var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);
						return mappingExpression.ForMember(dtoMemberSelector, opt => opt.MapFrom(Expression.Lambda<Func<TModel, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
					*/
		}

		public static IMappingExpression<TModel, TDto> ForEntityDtoIdCollectionMember<TModel, TModelMemberItem, TDto>(
	this IMappingExpression<TModel, TDto> mappingExpression,
	Expression<Func<TDto, int[]>> dtoMemberSelector,
	Expression<Func<TModel, IEnumerable<TModelMemberItem>>> modelMemberSelector)
			where TModel : class, IIdentificable
			where TModelMemberItem : class, IIdentificable
			where TDto : class, IIdentificable
		{
			if (mappingExpression == null)
			{
				throw new ArgumentNullException("mappingExpression");
			}

			Expression<Func<IEnumerable<TModelMemberItem>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.Id).ToArray();
			var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);
			return mappingExpression.ForMember(dtoMemberSelector, opt => opt.MapFrom(Expression.Lambda<Func<TModel, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
		}

		/*	public static IMappingExpression<TModel, TDto> ForEntityDtoIdCollectionMember<TModel, TModelMemberItem, TDto>(
					this IMappingExpression<TModel, TDto> mappingExpression,
					Expression<Func<TDto, int[]>> dtoMemberSelector,
					Expression<Func<TModel, IEnumerable<TModelMemberItem>>> modelMemberSelector
					)
			{
				Expression<Func<IEnumerable<TModelMemberItem>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.SubDivisionId).ToArray();
				var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);
				return mappingExpression.ForMember(dtoMemberSelector, opt => opt.MapFrom(Expression.Lambda<Func<TModel, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
			}*/

		//mapperConfiguration.CreateMap<Series, SeriesDto>()
		//.ForEntityDtoIdCollectionMember(dto => dto.SeasonsIds, model => model.Seasons, serviceResolver);

		/*	public static void ForEntityDtoIdCollectionMember(
				Expression<Func<DivisionDTO, int[]>> dtoMemberSelector,//dto => dto.SubDivisionsIds
				Expression<Func<Division, IEnumerable<SubDivision>>> modelMemberSelector) //model => model.SubDivisions
			{
				Expression<Func<IEnumerable<SubDivision>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.SubDivisionId).ToArray();
				var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);
				return mappingExpression.ForMember(dtoMemberSelector, opt => opt.MapFrom(Expression.Lambda<Func<TModel, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
			}

			public static IMappingExpression<TModel, TDto> ForEntityDtoIdCollectionMember<TModel, TModelMemberItem, TDto>(
				this IMappingExpression<TModel, TDto> mappingExpression,
				Expression<Func<TDto, int[]>> dtoMemberSelector,
				Expression<Func<TModel, IEnumerable<TModelMemberItem>>> modelMemberSelector
				)
			{
				Expression<Func<IEnumerable<TModelMemberItem>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.Id).ToArray();
				var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);
				return mappingExpression.ForMember(dtoMemberSelector, opt => opt.MapFrom(Expression.Lambda<Func<TModel, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
			}*/
	}
}

//
// Summary:
//     Customize configuration for individual member
//
// Parameters:
//   destinationMember:
//     Expression to the top-level destination member. This must be a member on
//     the TDestinationTDestination
//
//   memberOptions:
//     Callback for member options
//
// Returns:
//     Itself
//IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions);
//
// Summary:
//     Customize configuration for individual member. Used when the name isn't known
//     at compile-time
//
// Parameters:
//   name:
//     Destination member name
//
//   memberOptions:
//     Callback for member options
//IMappingExpression<TSource, TDestination> ForMember(string name, Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);
