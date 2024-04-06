using AutoMapper;
using Bits_Orchestra_Test_Task.Dto.EmployeeDto;
using Bits_Orchestra_Test_Task.Entities;

namespace Bits_Orchestra_Test_Task.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, ResponseEmployeeDto>().ReverseMap();
            CreateMap<RequestEmployeeDto, Employee>();
        }
    }
}
