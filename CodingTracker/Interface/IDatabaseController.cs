using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Model;
using Microsoft.Extensions.DependencyInjection;

namespace CodingTracker.Interface
{
    public interface IDatabaseController
    {
        List<CodingSession> GetAllSessions(Period? period, int value, bool ascending);
        List<CodingSession> GetAllSessions(bool ascending = true);
        Task<CodingSession> GetOneSession(int? id);
        Task<CodingSession> AddSession(CodingSession session);
        Task<CodingSession> UpdateSession(int? id, CodingSession updatedSession);
        void DeleteSession(int? id);

    }
}
