using SecLog.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecLog.Domain.Model;
using SecLog.Domain.DTO;

namespace SecLog.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LogModel, LogDTO>();
            CreateMap<LogDTO, LogModel>();
        }
    }
}
