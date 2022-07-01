using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Events;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();
        }
    }
}
