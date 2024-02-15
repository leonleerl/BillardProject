using System;

namespace BilliardProject.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string? Tel { get; set; }
        public DateTime? JoinDate { get; set; }
        public int Balance { get; set; }
    }
}
