namespace CompetitionFisher.Data.Migrations
{
    using CompetitionFisher.Data.Context;
    using CompetitionFisher.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        // tim.martens2@gmail.com => username / pw


        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            string auth0UserId1 = "59671de5a9cbf525f7b23185";

            context.Messages.AddOrUpdate(
                  el => el.Subject,
                  new Message { Subject = "Test", Date = DateTime.Now },
                  new Message { Subject = "Test2", Date = DateTime.Now },
                  new Message { Subject = "Test3", Date = DateTime.Now }
                );

            var competitionId1 = Guid.NewGuid();
            var competitionId3 = Guid.NewGuid();

            var contestantId1 = Guid.NewGuid();
            var contestantId2 = Guid.NewGuid();
            var contestantId3 = Guid.NewGuid();
            var contestantId4 = Guid.NewGuid();
            var contestantId5 = Guid.NewGuid();
            var contestantId6 = Guid.NewGuid();
            var contestantId7 = Guid.NewGuid();

            var resultId1 = Guid.NewGuid();
            var resultId2 = Guid.NewGuid();
            var resultId3 = Guid.NewGuid();
            var resultId4 = Guid.NewGuid();
            var resultId5 = Guid.NewGuid();
            var resultId6 = Guid.NewGuid();
            var resultId7 = Guid.NewGuid();

            // Users & ApplicationUsers
            context.Contestants.AddOrUpdate(
                el => new { el.FirstName, el.LastName },
                new Contestant { Id = contestantId1, FirstName = "Tim", LastName = "Martens", Auth0UserId = auth0UserId1 },
                new Contestant { Id = contestantId2, FirstName = "Eddy", LastName = "Pauwels" },
                new Contestant { Id = contestantId3, FirstName = "Peter", LastName = "Martens" },
                new Contestant { Id = contestantId4, FirstName = "Johan", LastName = "Van Ginderen" },
                new Contestant { Id = contestantId5, FirstName = "Werner", LastName = "Janssens" },
                new Contestant { Id = contestantId6, FirstName = "Quinten", LastName = "Van Ginderen" },
                new Contestant { Id = contestantId7, FirstName = "Patrick", LastName = "Vanotterdyck" }
                );

            var user1 = context.Contestants.Find(contestantId1);
            var user2 = context.Contestants.Find(contestantId2);
            var user3 = context.Contestants.Find(contestantId3);
            var user4 = context.Contestants.Find(contestantId4);
            var user5 = context.Contestants.Find(contestantId5);
            var user6 = context.Contestants.Find(contestantId6);
            var user7 = context.Contestants.Find(contestantId7);

            context.Championships.AddOrUpdate(
                el => el.Name,
                new Championship
                {
                    Id = Guid.NewGuid(),
                    Auth0UserId = auth0UserId1,
                    Name = "TEST Umicore 2015",
                    Competitions = new List<Competition>()
                    {
                        new Competition
                        {
                            Id = competitionId1,
                            Auth0UserId = auth0UserId1,
                            Name = "Wedstrijd 1",
                            Date = new DateTime(2017, 1, 23),
                            Contestants = new List<Contestant>
                            {
                                user1, user2, user3, user4, user5, user6
                            },
                            Results = new List<Result>
                            {
                                new Result {Id = resultId1, TotalNumber = 10, TotalWeight = 1230, CompetitionId = competitionId1, ContestantId = contestantId1 },
                                new Result {Id = resultId2, TotalNumber = 7, TotalWeight = 940, CompetitionId = competitionId1, ContestantId = contestantId2 },
                                new Result {Id = resultId3, TotalNumber = 13, TotalWeight = 2810, CompetitionId = competitionId1, ContestantId = contestantId3 },
                                new Result {Id = resultId4, TotalNumber = 0, TotalWeight = 0, CompetitionId = competitionId1, ContestantId = contestantId4 },
                                new Result {Id = resultId5, TotalNumber = 6, TotalWeight = 670, CompetitionId = competitionId1, ContestantId = contestantId5 },
                                new Result {Id = resultId6, TotalNumber = 12, TotalWeight = 1690, CompetitionId = competitionId1, ContestantId = contestantId6 }
                            }
                        },
                        new Competition
                        {
                            Id = Guid.NewGuid(),
                            Auth0UserId = auth0UserId1,
                            Name = "Wedstrijd 2",
                            Date =new DateTime(2017, 2, 23),
                            Contestants = new List<Contestant>
                            {
                                user1, user2, user3, user5, user7
                            }
                           
                            // No results yet
                        }
                    }
                });

            context.Competitions.AddOrUpdate(
                el => el.Name,
                new Competition
                {
                    Id = competitionId3,
                    Auth0UserId = auth0UserId1,
                    Name = "Wedstrijd zonder kampioenschap",
                    Date = new DateTime(2017, 3, 6),
                    Contestants = new List<Contestant>
                    {
                        user1, user2, user3, user4, user5, user6, user7
                    },
                    Results = new List<Result>
                    {
                        new Result {Id = Guid.NewGuid(), TotalNumber = 1, TotalWeight = 123, CompetitionId = competitionId3, ContestantId = contestantId1 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 18, TotalWeight = 2390, CompetitionId = competitionId3, ContestantId = contestantId2 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 18, TotalWeight = 3200, CompetitionId = competitionId3, ContestantId = contestantId3 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 10, TotalWeight = 1435, CompetitionId = competitionId3, ContestantId = contestantId4 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 23, TotalWeight = 3450, CompetitionId = competitionId3, ContestantId = contestantId5 },
                        new Result {Id = Guid.NewGuid(), TotalNumber = 7, TotalWeight = 2690, CompetitionId = competitionId3, ContestantId = contestantId6 }
                    }
                });

        }
    }
}
