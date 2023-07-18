using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
            CreateMap<IEnumerable<BookDto>, PagedList<Book>>();
        }
    }
}
