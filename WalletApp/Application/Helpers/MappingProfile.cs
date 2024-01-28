using AutoMapper;
using WalletApp.Domain;
using WalletApp.Presentation.DTOs;

namespace WalletApp.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDto>().ForMember(tran => tran.transaction_status, opt => opt.MapFrom(src => (int)src.TransactionStatus));
        }
    }
}
