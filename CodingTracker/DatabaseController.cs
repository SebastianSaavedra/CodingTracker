using CodingTracker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class DatabaseController
    {
        private CodingTrackerContext _context;
        public DatabaseController()
        {
            _context = new CodingTrackerContext();
        }

        public IQueryable<CodingSession> GetAllSessions()
        {
            if (_context.Sessions == null) return null!;

            var sessions = from s in _context.Sessions select s;
            return sessions;
        }

        public async Task<CodingSession> GetSession(int? id)
        {
            if (id == null || _context.Sessions == null) return null!;

            var session = await _context.Sessions.FindAsync(id);

            if (session == null) return null!;

            return session;
        }


    }
}
