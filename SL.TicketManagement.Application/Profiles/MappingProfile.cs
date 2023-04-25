using AutoMapper;
using SL.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using SL.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using SL.TicketManagement.Application.Features.Events;
using SL.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using SL.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using SL.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using SL.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using SL.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using SL.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.TicketManagement.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
            CreateMap<Event,EventListVm>().ReverseMap();
            CreateMap<Event,EventDetailVm>().ReverseMap();
            CreateMap<Category,CategoryDto>();
            CreateMap<Category,CategoryListVm>();
            CreateMap<Category,CategoryEventListVm>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();

            }
    }
}
