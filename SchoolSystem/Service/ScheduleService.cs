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
    // Creating a class where user input data will be stored and then used for either Create and Update an entity.
    public class ScheduleInput
    {
        public int ScheduleId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class ScheduleService
    {
        public bool createBool = false;
        public bool deleteBool = false;
        public readonly SchoolSystemContext _context;

        public ScheduleService(SchoolSystemContext context)
        {
            _context = context;
        }

        public void CreateSchedule()
        {
            var scheduleInput = ValidateEntity.ValidateSchedule(_context, createBool = true, deleteBool);
            if (scheduleInput == null)
            {
                return;
            }

            var schedule = new Schedule
            {
                CourseId = scheduleInput.CourseId,
                TeacherId = scheduleInput.TeacherId,
                ClassroomId = scheduleInput.ClassroomId,
                StartTime = scheduleInput.StartTime,
                EndTime = scheduleInput.EndTime
            };

            _context.Schedules.Add(schedule);
            _context.SaveChanges();
            Console.WriteLine($"Successfully created schedule with ID: {schedule.ScheduleId}");
        }

        public List<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public Schedule? GetScheduleById(int id)
        {
            return _context.Schedules.Find(id);
        }

        public void UpdateSchedule()
        {
            // Validation
            var scheduleInput = ValidateEntity.ValidateSchedule(_context, createBool, deleteBool);
            if (scheduleInput == null)
            {
                return;
            }

            // Loading the existing schedule from the database
            var schedule = _context.Schedules.Find(scheduleInput.ScheduleId);
            if (schedule == null)
            {
                Console.WriteLine("Schedule not found.");
                return;
            }

            schedule.CourseId = scheduleInput.CourseId;
            schedule.TeacherId = scheduleInput.TeacherId;
            schedule.ClassroomId = scheduleInput.ClassroomId;
            schedule.StartTime = scheduleInput.StartTime;
            schedule.EndTime = scheduleInput.EndTime;

            _context.SaveChanges();
            Console.WriteLine($"Successfully updated schedule with ID: {schedule.ScheduleId}");
        }

        public void DeleteSchedule()
        {
            // Validation
            var scheduleInput = ValidateEntity.ValidateSchedule(_context, createBool, deleteBool = true);

            if (scheduleInput == null)
            {
                return;
            }

            var schedule = _context.Schedules.Find(scheduleInput.ScheduleId);
            if (schedule == null)
            {
                Console.WriteLine("Schedule not found.");
                return;
            }

            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted schedule with ID: {schedule.ScheduleId}");
        }
    }
}
