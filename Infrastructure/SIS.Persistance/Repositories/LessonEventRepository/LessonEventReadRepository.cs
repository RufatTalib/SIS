using SIS.Application.Repositories.LessonEventRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.LessonEventRepository
{
    public class LessonEventReadRepository : ReadRepository<LessonEvent>, ILessonEventReadRepository
    {
        public LessonEventReadRepository(SISDbContext context) : base(context)
        {
        }
    }
}
