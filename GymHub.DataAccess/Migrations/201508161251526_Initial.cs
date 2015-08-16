namespace GymHub.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TraineeStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.TraineeId)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TraineeCheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.Int(nullable: false),
                        CheckInDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.TraineeId);
            
            CreateTable(
                "dbo.TrainingSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingSchedules", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.TrainingSchedules", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.TraineeStatistics", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.TraineeCheckIns", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.TraineeStatistics", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.TrainingSchedules", new[] { "ExerciseId" });
            DropIndex("dbo.TrainingSchedules", new[] { "ProgramId" });
            DropIndex("dbo.TraineeCheckIns", new[] { "TraineeId" });
            DropIndex("dbo.TraineeStatistics", new[] { "ExerciseId" });
            DropIndex("dbo.TraineeStatistics", new[] { "TraineeId" });
            DropTable("dbo.Programs");
            DropTable("dbo.TrainingSchedules");
            DropTable("dbo.TraineeCheckIns");
            DropTable("dbo.Trainees");
            DropTable("dbo.TraineeStatistics");
            DropTable("dbo.Exercises");
        }
    }
}
