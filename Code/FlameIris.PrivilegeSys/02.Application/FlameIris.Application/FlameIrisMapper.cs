using AutoMapper;
using FlameIris.Application.ManagerApp.Dtos;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application
{
    public class FlameIrisMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Manager, ManagerDto>();
                cfg.CreateMap<ManagerDto, Manager>();
            });
        }
    }
}
