using CodingTracker.Database;
using CodingTracker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace CodingTracker.Controllers
{
    internal class CodingGoalsController
    {
        CodingTrackerContext _context;

        public CodingGoalsController()
        {
            _context = new CodingTrackerContext();
        }

        public async Task<CodingGoals> AddGoal(CodingGoals goals)
        {
            if (_context.CodingGoals == null) return null!;

            _context.Add(goals);
            await _context.SaveChangesAsync();
            return goals;
        }

        public async Task<CodingGoals> GetOneGoal(int? id)
        {
            if (id == null || _context.CodingGoals == null) return null!;

            var session = await _context.CodingGoals.OrderBy(x => x.Id).Where(x => x.Id == id).FirstAsync();

            if (session == null) return null!;

            return session;
        }

        public List<CodingGoals> GetAllGoals()
        {
            return _context.CodingGoals.ToList();
        }

        public void CalculateProgress(CodingGoals goal, int totalHoursCoded)
        {
            if (!DateTime.TryParse(goal.Deadline, out var deadline))
            {
                Console.WriteLine("Could not parse the deadline string to a DateTime object.");
                return;
            }

            var remainingDays = (deadline - DateTime.Now).TotalDays;
            var remainingHours = (deadline - DateTime.Now).Hours;
            var hoursPerDay = (goal.Hours - totalHoursCoded) / remainingDays;

            Console.WriteLine($"{remainingDays} days remaining until goal deadline.");
            Console.WriteLine($"{remainingHours} hours remaining until goal deadline.");
            Console.WriteLine($"You need to code {hoursPerDay:F2} hours per day to reach your goal.");
        }


    }
}
