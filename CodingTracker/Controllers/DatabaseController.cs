using CodingTracker.Database;
using CodingTracker.Interface;
using CodingTracker.Model;
using CodingTracker.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class DatabaseController : IDatabaseController
    {
        private CodingTrackerContext _context;
        public DatabaseController()
        {
            _context = new CodingTrackerContext();
        }

        public List<CodingSession> GetAllSessions(bool ascending = true)
        {
            if (_context.Sessions == null) return null!;

            var sessions = _context.Sessions.ToList();

            return ascending ? sessions.OrderBy(r => DateTime.Parse(r.StartTime!)).ToList() : sessions.OrderByDescending(r => DateTime.Parse(r.StartTime!)).ToList();
        }

        public List<CodingSession> GetAllSessions(Period? period, int value, bool ascending)
        {
            if (_context.Sessions == null) return null!;

            var sessions = _context.Sessions.ToList();

            switch (period)
            {
                case Period.Day:
                    sessions = sessions.Where(r =>
                    {
                        var date = DateTime.Parse(r.StartTime!);
                        return date.Day == value;
                    }).ToList();
                    break;

                //case Period.Week:
                //    sessions = sessions.Where(r =>
                //    {
                //        var date = DateTime.Parse(r.StartTime!);
                //        var weekNumber = Utils.Utils.GetWeekOfMonth(date);
                //        return weekNumber == value;
                //    }).ToList();
                //    break;

                case Period.Month:
                    sessions = sessions.Where(r =>
                    {
                        var date = DateTime.Parse(r.StartTime!);
                        return date.Month == value;
                    }).ToList();
                    break;

                case Period.Year:
                    sessions = sessions.Where(r => DateTime.Parse(r.StartTime!).Year == value)
                    .ToList();
                    break;

                default:
                    return sessions;
            }

            return ascending ? sessions.OrderBy(r => DateTime.Parse(r.StartTime!)).ToList() : sessions.OrderByDescending(r => DateTime.Parse(r.StartTime!)).ToList();
        }


        public async Task<CodingSession> GetOneSession(int? id)
        {
            if (id == null || _context.Sessions == null) return null!;

            var session = await _context.Sessions.OrderBy(x => x.Id).Where(x => x.Id == id).FirstAsync();

            if (session == null) return null!;

            return session;
        }

        public async Task<CodingSession> AddSession(CodingSession session)
        {
            if (_context.Sessions == null) return null!;

            _context.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<CodingSession> UpdateSession(int? id, CodingSession updatedSession)
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

        public async void DeleteSession(int? id)
        {
            if (id == null || _context.Sessions == null) return;

            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return;

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }

    }
}
