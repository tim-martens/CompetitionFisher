namespace CompetitionFisher.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Championship",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Auth0UserId = c.String(nullable: false, maxLength: 50),
                    Name = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Competition",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ChampionshipId = c.Guid(),
                    Auth0UserId = c.String(nullable: false, maxLength: 50),
                    Name = c.String(nullable: false, maxLength: 50),
                    Date = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Championship", t => t.ChampionshipId)
                .Index(t => t.ChampionshipId);

            CreateTable(
                "dbo.Contestant",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Auth0UserId = c.String(maxLength: 50),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirstName, t.LastName }, unique: true, name: "UX_Contestant_FirstName_LastName");

            CreateTable(
                "dbo.Result",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    CompetitionId = c.Guid(nullable: false),
                    ContestantId = c.Guid(nullable: false),
                    TotalNumber = c.Int(nullable: false),
                    TotalWeight = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contestant", t => t.ContestantId)
                .ForeignKey("dbo.Competition", t => t.CompetitionId)
                .Index(t => t.CompetitionId)
                .Index(t => t.ContestantId);

            CreateTable(
                "dbo.Message",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Subject = c.String(),
                    Auth0UserId = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Contestants_Competitions",
                c => new
                {
                    CompetitionId = c.Guid(nullable: false),
                    ContestantId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.CompetitionId, t.ContestantId })
                .ForeignKey("dbo.Competition", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Contestant", t => t.ContestantId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.ContestantId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Competition", "ChampionshipId", "dbo.Championship");
            DropForeignKey("dbo.Result", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.Contestants_Competitions", "ContestantId", "dbo.Contestant");
            DropForeignKey("dbo.Contestants_Competitions", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.Result", "ContestantId", "dbo.Contestant");
            DropIndex("dbo.Contestants_Competitions", new[] { "ContestantId" });
            DropIndex("dbo.Contestants_Competitions", new[] { "CompetitionId" });
            DropIndex("dbo.Result", new[] { "ContestantId" });
            DropIndex("dbo.Result", new[] { "CompetitionId" });
            DropIndex("dbo.Contestant", "UX_Contestant_FirstName_LastName");
            DropIndex("dbo.Competition", new[] { "ChampionshipId" });
            DropTable("dbo.Contestants_Competitions");
            DropTable("dbo.Message");
            DropTable("dbo.Result");
            DropTable("dbo.Contestant");
            DropTable("dbo.Competition");
            DropTable("dbo.Championship");
        }
    }
}
