namespace FoolBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BetProperties", "Match_ID", "dbo.Matches");
            DropIndex("dbo.BetProperties", new[] { "Match_ID" });
            AddColumn("dbo.Matches", "FirstWin", c => c.Double(nullable: false));
            AddColumn("dbo.Matches", "SecondWin", c => c.Double(nullable: false));
            AddColumn("dbo.Matches", "Draw", c => c.Double(nullable: false));
            DropColumn("dbo.BetProperties", "Match_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BetProperties", "Match_ID", c => c.Int());
            DropColumn("dbo.Matches", "Draw");
            DropColumn("dbo.Matches", "SecondWin");
            DropColumn("dbo.Matches", "FirstWin");
            CreateIndex("dbo.BetProperties", "Match_ID");
            AddForeignKey("dbo.BetProperties", "Match_ID", "dbo.Matches", "ID");
        }
    }
}
