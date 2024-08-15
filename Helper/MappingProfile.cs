using AutoMapper;
using PokemonReview.Dtos;
using PokemonReview.Models;

namespace PokemonReview.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Pokemon, PokemonDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Reviewer, ReviewerDto>().ReverseMap();

            //CreateMap<Pokemon, PokemonDto>();
            //CreateMap<PokemonDto, Pokemon>();

            //CreateMap<Category, CategoryDto>();
            //CreateMap<CategoryDto, Category>();

            //CreateMap<Country, CountryDto>();
            //CreateMap<CountryDto, Country>();

            //CreateMap<Owner, OwnerDto>();
            //CreateMap<OwnerDto, Owner>();

            //CreateMap<Review, ReviewDto>();
            //CreateMap<ReviewDto, Review>();

            //CreateMap<Reviewer, ReviewerDto>();
            //CreateMap<ReviewerDto, Reviewer>();
        }
    }
}
