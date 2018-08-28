namespace FoolBet
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MainDB : DbContext
    {
        // Your context has been configured to use a 'MainDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FoolBet.MainDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MainDB' 
        // connection string in the application configuration file.
        public MainDB()
            : base("name=MainDB")
        {
        }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BetProperties> BetProperties { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<UserBet> UserBets { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}