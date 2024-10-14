using AmazonWebsite.Areas.Admin.Models;
using AmazonWebsite.ViewModels;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
namespace AmazonWebsite.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public  AutoMapperProfile()
        {
            CreateMap<RegisterVM, Customer>();
                //.ForMember(cus => cus.CustomerId, option => option.MapFrom(RegisterVM =>
                //RegisterVM.CustomerId))
                //.ReverseMap();
                
        }
    }
}
