﻿namespace TrainingManagementSystem
{
    public class Lecture : TrainingUnit
    {
        public string? Topic { get; set; }

        public Lecture(string? description, string? topic)
            : base(description)
        {
            Topic = topic;
        }
     
        public override Lecture Clone()
        {
            return new Lecture(Description, Topic);
        }
    }
}
