namespace FoolBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserBets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Accounts_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Accounts_ID)
                .Index(t => t.Accounts_ID);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MatchTime = c.DateTime(nullable: false),
                        TeamAway_ID = c.Int(),
                        TeamHome_ID = c.Int(),
                        UserBet_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamAway_ID)
                .ForeignKey("dbo.Teams", t => t.TeamHome_ID)
                .ForeignKey("dbo.UserBets", t => t.UserBet_ID)
                .Index(t => t.TeamAway_ID)
                .Index(t => t.TeamHome_ID)
                .Index(t => t.UserBet_ID);
            
            CreateTable(
                "dbo.BetProperties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coef = c.Double(nullable: false),
                        Match_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Matches", t => t.Match_ID)
                .Index(t => t.Match_ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coach = c.String(),
                        League_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Leagues", t => t.League_ID)
                .Index(t => t.League_ID);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Country = c.String(),
                        Position = c.String(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.Team_ID)
                .Index(t => t.Team_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBets", "Accounts_ID", "dbo.Accounts");
            DropForeignKey("dbo.Matches", "UserBet_ID", "dbo.UserBets");
            DropForeignKey("dbo.Matches", "TeamHome_ID", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamAway_ID", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_ID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "League_ID", "dbo.Leagues");
            DropForeignKey("dbo.BetProperties", "Match_ID", "dbo.Matches");
            DropIndex("dbo.Players", new[] { "Team_ID" });
            DropIndex("dbo.Teams", new[] { "League_ID" });
            DropIndex("dbo.BetProperties", new[] { "Match_ID" });
            DropIndex("dbo.Matches", new[] { "UserBet_ID" });
            DropIndex("dbo.Matches", new[] { "TeamHome_ID" });
            DropIndex("dbo.Matches", new[] { "TeamAway_ID" });
            DropIndex("dbo.UserBets", new[] { "Accounts_ID" });
            DropTable("dbo.Players");
            DropTable("dbo.Leagues");
            DropTable("dbo.Teams");
            DropTable("dbo.BetProperties");
            DropTable("dbo.Matches");
            DropTable("dbo.UserBets");
            DropTable("dbo.Accounts");
        }
    }
}
