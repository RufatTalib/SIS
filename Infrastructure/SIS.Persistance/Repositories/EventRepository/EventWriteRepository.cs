using SIS.Application.Repositories.EventRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.EventRepository
{
    public class EventWriteRepository : WriteRepository<Event>, IEventWriteRepository
    {
        public EventWriteRepository(SISDbContext context) : base(context)
        {
        }
    }
}
