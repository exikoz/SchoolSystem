using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{
    public class ScheduleService
    {
        public readonly SchoolSystemContext _context;

        public ScheduleService(SchoolSystemContext context)
        {
            _context = context;
        }

        public Schedule? CreateSchedule(Schedule schedule)
        {
            if (!ValidateEntity.ValidateDuplicateSchedule(_context, schedule))
            {
                return null;
            }
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
            return schedule;

        }
        public List<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }
        public Schedule? GetScheduleById(int id)
        {
            return _context.Schedules.Find(id);
        }
        public Schedule? UpdateSchedule(int id, Schedule updatedSchedule)
        {
            var schedule = _context.Schedules.Find(id);

            if (schedule == null)
                return null;

            schedule.StartTime = updatedSchedule.StartTime;
            schedule.EndTime = updatedSchedule.EndTime;
            _context.SaveChanges();
            return schedule;
        }
        public bool DeleteSchedule(int id)
        {
            var schedule = _context.Schedules.Find(id);

            if (schedule == null)
                return false;

            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
            return true;
        }
    }
}
