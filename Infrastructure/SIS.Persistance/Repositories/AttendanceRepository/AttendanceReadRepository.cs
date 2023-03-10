using SIS.Application.Repositories.AttendanceRepository;
using SIS.Domain.Entities;
using SIS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Repositories.AttendanceRepository
{
    public class AttendanceReadRepository : ReadRepository<Attendance>, IAttendanceReadRepository
    {
        public AttendanceReadRepository(SISDbContext context) : base(context)
        {
        }
    }
}
