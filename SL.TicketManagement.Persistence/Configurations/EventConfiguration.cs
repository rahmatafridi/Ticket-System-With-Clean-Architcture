using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SL.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.TicketManagement.Persistence.Configurations
{
    public class EventConfiguration
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
