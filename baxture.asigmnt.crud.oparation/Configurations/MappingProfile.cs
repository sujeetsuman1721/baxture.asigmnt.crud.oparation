using AutoMapper;
using baxture.asigmnt.crud.oparation.Application.Dtos;
namespace baxture.asigmnt.crud.oparation.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            this.CreateMap<Model.RegisterUser, UserRegistrationDto>().ReverseMap();
            this.CreateMap<domain.Models.RegisterUser, UserRegistrationDto>().ReverseMap();

        }
    }
}
