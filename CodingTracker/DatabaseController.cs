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

        //public IQueryable<CodingSession> GetAllSessions()
        //{
        //    if (_context.Sessions == null) return null!;

        //    var sessions = from s in _context.Sessions select s;
        //    return sessions;
        //}

        public async Task<CodingSession> GetSession(int? id)
        {
            if (id == null || _context.Sessions == null) return null!;

            var session = await _context.Sessions.OrderBy(x => x.Id == id).FirstOrDefaultAsync();

            if (session == null) return null!;

            return session;
        }

        public async Task<CodingSession> CreateNewSession(CodingSession session)
        {
            if (_context.Sessions == null) return null!;

            _context.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<CodingSession> UpdateNewSession(int? id, CodingSession updatedSession)
        {
            if (id == null || _context.Sessions == null) return null!;

            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return null!;

            session.StartTime = updatedSession.StartTime;
            session.EndTime = updatedSession.EndTime;

            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
            
            return session;
        }

        public async void DeleteNewSession(int? id)
        {
            if (id == null || _context.Sessions == null) return;

            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return;

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }
    }
}
