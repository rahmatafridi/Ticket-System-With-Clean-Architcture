using SL.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace SL.TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
