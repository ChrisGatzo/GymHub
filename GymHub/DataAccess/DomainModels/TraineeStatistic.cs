//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymHub.DataAccess.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class TraineeStatistic
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int ExerciseId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Weight { get; set; }
    
        public virtual Exercise Exercises { get; set; }
        public virtual Trainee Trainees { get; set; }
    }
}
