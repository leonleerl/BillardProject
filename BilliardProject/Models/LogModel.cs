using System;

namespace BilliardProject.Models
{
    public class LogModel
    {
        public Guid Id { get; set; }
        public string? Tel { get; set; }
        public string? EntertainmentType { get; set; }
        public string? TableIndex { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Income { get; set; }

    }
}
