using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Configuration;
using Model;

namespace DTO.Mappings
{
	public static class MapperInitialize
	{
		public static void RegisterMappings()
		{
			var mappings = new MapperConfigurationExpression();
			ConfigureDivision(mappings);
			ConfigureSubDivision(mappings);

			//var config = new MapperConfiguration(mappings);
			//config.AssertConfigurationIsValid();
			AutoMapper.Mapper.Initialize(mappings);
			//	AutoMapper.Mapper.AssertConfigurationIsValid();
		}

		private static void ConfigureSubDivision(IMapperConfigurationExpression mapperConfiguration)
		{
			mapperConfiguration.CreateMap<SubDivision, SubDivisionDTO>();

			mapperConfiguration.CreateMap<int, SubDivisionDTO>();
		}

		private static void ConfigureDivision(IMapperConfigurationExpression mapperConfiguration)
		{
			//AutoMapper.Mapper.CreateMap<SubDivision, int>().ConvertUsing(src => src.SubDivisionId);

			/*Expression<Func<Division, IEnumerable<SubDivision>>> modelMemberSelector = dto => dto.SubDivisions;
			Expression<Func<IEnumerable<SubDivision>, int[]>> modelIdSelector = models => models == null ? new int[0] : models.Where(i => i != null).Select(i => i.SubDivisionId).ToArray();
			var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);*/

			mapperConfiguration.CreateMap<Division, DivisionDTO>()
				//.ForEntityDtoIdCollectionMember(dto => dto.SubDivisions, model => model.SubDivisions);
				//.ForMember(dto => dto.SubDivisions, opt => opt.MapFrom(Expression.Lambda<Func<Division, int[]>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
				//.ForMember(dto => dto.SubDivisions,model => model.MapFrom);
				.ForMember(dto => dto.SubDivisions, opts => opts.MapFrom(src => src.SubDivisions.Select(sub => sub.DivisionId).ToArray()));
			//.ForMember(div => div.SubDivisions, divDto => divDto.Ignore());
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

		public static IMappingExpression<TModel, TDto> ForEntityDtoIdMember<TModel, TModelMember, TDto>(
	this IMappingExpression<TModel, TDto> mappingExpression,
	Expression<Func<TDto, int>> dtoMemberSelector,
	Expression<Func<TModel, TModelMember>> modelMemberSelector)
			where TModel : class, IIdentificable
			where TModelMember : class, IIdentificable
			where TDto : class, IIdentificable
		{
			if (mappingExpression == null)
			{
				throw new ArgumentNullException("mappingExpression");
			}

			Expression<Func<TModelMember, int>> modelIdSelector = model => model == null ? 0 : model.Id;
			var modelMemberIdSelector = Expression.Invoke(modelIdSelector, modelMemberSelector.Body);
			return mappingExpression.ForMember(dtoMemberSelector, opt => opt.MapFrom(Expression.Lambda<Func<TModel, int>>(modelMemberIdSelector, modelMemberSelector.Parameters)));
		}
	}
}
