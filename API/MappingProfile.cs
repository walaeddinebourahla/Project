using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace API;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Journal, JournalDto>();
		CreateMap<JournalForCreationDto, Journal>();
        CreateMap<JournalForUpdateDto, Journal>();

        CreateMap<Article, ArticleDto>();
		CreateMap<ArticleForCreationDto, Article>();
        CreateMap<ArticleForUpdateDto, Article>();
    }
}
