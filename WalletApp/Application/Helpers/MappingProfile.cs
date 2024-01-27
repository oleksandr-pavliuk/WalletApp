using AutoMapper;
using WalletApp.Domain;
using WalletApp.Presentation.DTOs;

namespace WalletApp.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>();
        }
    }
}
