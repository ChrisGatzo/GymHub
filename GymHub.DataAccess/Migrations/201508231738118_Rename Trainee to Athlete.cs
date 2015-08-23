namespace GymHub.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTraineetoAthlete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TraineeStatistics", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.TraineeCheckIns", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.TraineeStatistics", "TraineeId", "dbo.Trainees");
            DropIndex("dbo.TraineeStatistics", new[] { "TraineeId" });
            DropIndex("dbo.TraineeStatistics", new[] { "ExerciseId" });
            DropIndex("dbo.TraineeCheckIns", new[] { "TraineeId" });
            CreateTable(
                "dbo.AthleteCheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AthleteId = c.Int(nullable: false),
                        CheckInDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Athletes", t => t.AthleteId, cascadeDelete: true)
                .Index(t => t.AthleteId);
            
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AthleteStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AthleteId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Athletes", t => t.AthleteId, cascadeDelete: true)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.AthleteId)
                .Index(t => t.ExerciseId);
            
            DropTable("dbo.TraineeStatistics");
            DropTable("dbo.Trainees");
            DropTable("dbo.TraineeCheckIns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TraineeCheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.Int(nullable: false),
                        CheckInDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.TraineeStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.Int(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AthleteStatistics", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.AthleteStatistics", "AthleteId", "dbo.Athletes");
            DropForeignKey("dbo.AthleteCheckIns", "AthleteId", "dbo.Athletes");
            DropIndex("dbo.AthleteStatistics", new[] { "ExerciseId" });
            DropIndex("dbo.AthleteStatistics", new[] { "AthleteId" });
            DropIndex("dbo.AthleteCheckIns", new[] { "AthleteId" });
            DropTable("dbo.AthleteStatistics");
            DropTable("dbo.Athletes");
            DropTable("dbo.AthleteCheckIns");
            CreateIndex("dbo.TraineeCheckIns", "TraineeId");
            CreateIndex("dbo.TraineeStatistics", "ExerciseId");
            CreateIndex("dbo.TraineeStatistics", "TraineeId");
            AddForeignKey("dbo.TraineeStatistics", "TraineeId", "dbo.Trainees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TraineeCheckIns", "TraineeId", "dbo.Trainees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TraineeStatistics", "ExerciseId", "dbo.Exercises", "Id", cascadeDelete: true);
        }
    }
}
