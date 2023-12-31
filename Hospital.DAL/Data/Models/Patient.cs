﻿namespace Hospital.DAL
{
    public class Patient
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }  = string.Empty;

        public Guid DoctorId { get; set; }

        public Doctor Doctor { get; set; } = null!;

        //list of issue
        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

    }
}
