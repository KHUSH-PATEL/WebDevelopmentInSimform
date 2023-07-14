using AutoMapper;
using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Handler
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler() 
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
