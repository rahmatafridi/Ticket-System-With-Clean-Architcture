﻿using AutoMapper;
using MediatR;
using SL.TicketManagement.Application.Contracts.Persistence;
using SL.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<EventListVm>>(allEvents);
        }
    }
}
