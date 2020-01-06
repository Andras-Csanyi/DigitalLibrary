namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Utils
{
    using Ctx.Context;

    using DomainModel.Entities;

    public static class TeamManagerSeed
    {
        public static long PeopleEventLogsActiveAmount { get; private set; } = 5;

        public static long PeopleEventLogsInActiveAmount { get; private set; } = 5;

        public static long PeopleActiveAmount { get; private set; } = 5;

        public static long PeopleInActiveAmount { get; private set; } = 5;

        public static long PositionActiveAmount { get; private set; } = 5;

        public static long PositionInActiveAmount { get; private set; } = 5;

        public static long EventsActiveAmount { get; private set; } = 5;

        public static long EventsInActiveAmount { get; private set; } = 5;

        public static long TitleActiveAmount { get; private set; } = 5;

        public static long TitleInActiveAmount { get; private set; } = 5;

        public static long CompanyActiveAmount { get; set; } = 5;

        public static long CompanyInActiveAmount { get; set; } = 5;

        public static void Seed(TeamManagerContext db)
        {
            SeedActiveCompany(db);
            SeedInactiveCompany(db);

            SeedActiveTitle(db);
            SeedInActiveTitle(db);

            SeedActiveEvents(db);
            SeedInActiveEvents(db);

            SeedInActivePosition(db);
            SeedActivePosition(db);

            SeedActivePeople(db);
            SeedInActivePeople(db);

            SeedActivePeopleEventLogs(db);
            SeedInActivePeopleEventLogs(db);
        }

        private static void SeedActivePeopleEventLogs(TeamManagerContext db)
        {
            for (long i = 0; i < PeopleEventLogsActiveAmount; i++)
            {
                PeopleEventLog p = new PeopleEventLog
                {
                    Details = $"details and details...{i}",
                    IsActive = 1,
                    EventId = i + 1,
                    PeopleId = i + 1
                };
                db.PeopleEventLogs.Add(p);
                db.SaveChanges();
            }
        }

        private static void SeedInActivePeopleEventLogs(TeamManagerContext db)
        {
            for (long i = 0; i < PeopleEventLogsInActiveAmount; i++)
            {
                PeopleEventLog p = new PeopleEventLog
                {
                    Details = $"details and details...{i}",
                    IsActive = 0,
                    EventId = i + 1,
                    PeopleId = i + 1
                };
                db.PeopleEventLogs.Add(p);
                db.SaveChanges();
            }
        }

        private static void SeedActivePeople(TeamManagerContext db)
        {
            for (long i = 0; i < PeopleActiveAmount; i++)
            {
                People p = new People
                {
                    FirstName = $"first name{i}",
                    MiddleName = $"middle name{i}",
                    LastName = $"last name{i}",
                    IsActive = 1,
                    CompanyId = i + 1,
                    PositionId = i + 1,
                    TitleId = i + 1
                };
                db.Peoples.Add(p);
                db.SaveChanges();
            }
        }

        private static void SeedInActivePeople(TeamManagerContext db)
        {
            for (long i = 0; i < PeopleInActiveAmount; i++)
            {
                People p = new People
                {
                    FirstName = $"first name{i}",
                    MiddleName = $"middle name{i}",
                    LastName = $"last name{i}",
                    IsActive = 0,
                    CompanyId = i + 1,
                    PositionId = i + 1,
                    TitleId = i + 1
                };
                db.Peoples.Add(p);
                db.SaveChanges();
            }
        }

        private static void SeedActivePosition(TeamManagerContext db)
        {
            for (int i = 0; i < PositionActiveAmount; i++)
            {
                Position p = new Position
                {
                    Name = $"position{i}",
                    IsActive = 1
                };
                db.Positions.Add(p);
                db.SaveChanges();
            }
        }

        private static void SeedInActivePosition(TeamManagerContext db)
        {
            for (int i = 0; i < PositionInActiveAmount; i++)
            {
                Position p = new Position
                {
                    Name = $"position{i}",
                    IsActive = 0
                };
                db.Positions.Add(p);
                db.SaveChanges();
            }
        }

        private static void SeedActiveEvents(TeamManagerContext db)
        {
            for (int i = 0; i < EventsActiveAmount; i++)
            {
                Event e = new Event
                {
                    Name = $"event{i}",
                    IsActive = 1
                };
                db.Events.Add(e);
                db.SaveChanges();
            }
        }

        private static void SeedInActiveEvents(TeamManagerContext db)
        {
            for (int i = 0; i < EventsInActiveAmount; i++)
            {
                Event e = new Event
                {
                    Name = $"event{i}",
                    IsActive = 0
                };
                db.Events.Add(e);
                db.SaveChanges();
            }
        }

        private static void SeedActiveTitle(TeamManagerContext db)
        {
            for (int i = 0; i < TitleActiveAmount; i++)
            {
                Title t = new Title
                {
                    Name = $"title{i}",
                    IsActive = 1
                };
                db.Titles.Add(t);
                db.SaveChanges();
            }
        }

        private static void SeedInActiveTitle(TeamManagerContext db)
        {
            for (int i = 0; i < TitleInActiveAmount; i++)
            {
                Title t = new Title
                {
                    Name = $"title{i}",
                    IsActive = 0
                };
                db.Titles.Add(t);
                db.SaveChanges();
            }
        }

        private static void SeedActiveCompany(TeamManagerContext db)
        {
            for (int i = 0; i < CompanyActiveAmount; i++)
            {
                Company c = new Company
                {
                    Name = $"Company{i}",
                    Description = $"Description{i}",
                    Url = $"http://company{i}.test",
                    IsActive = 1
                };
                db.Companies.Add(c);
                db.SaveChanges();
            }
        }

        private static void SeedInactiveCompany(TeamManagerContext db)
        {
            for (int i = 0; i < CompanyInActiveAmount; i++)
            {
                Company c = new Company
                {
                    Name = $"Company{i}",
                    Description = $"Description{i}",
                    Url = $"http://company{i}.test",
                    IsActive = 0
                };
                db.Companies.Add(c);
                db.SaveChanges();
            }
        }
    }
}