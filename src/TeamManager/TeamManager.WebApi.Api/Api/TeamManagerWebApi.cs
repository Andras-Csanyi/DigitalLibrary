namespace DigitalLibrary.IaC.TeamManager.WebApi.Api.Api
{
    public struct TeamManagerWebApi
    {
        private const string TeamManager = "api/teammanager";

        public struct CompanyApi
        {
            public const string CompanyBase = TeamManager + "/company";

            public const string Add = "add";

            public const string Delete = "delete";

            public const string Find = "find";

            public const string GetAll = "getall";

            public const string GetAllActive = "getallactive";

            public const string Modify = "modify";
        }

        public struct EventApi
        {
            public const string EventBase = TeamManager + "/event";

            public const string Add = "add";

            public const string Delete = "delete";

            public const string Find = "find";

            public const string GetAll = "getall";

            public const string GetAllActive = "getallactive";

            public const string Modify = "modify";
        }

        public struct PeopleApi
        {
            public const string PeopleBase = TeamManager + "/people";

            public const string Add = "add";

            public const string Delete = "delete";

            public const string Find = "find";

            public const string GetAll = "getall";

            public const string GetAllActive = "getallactive";

            public const string Modify = "modify";
        }

        public struct PeopleEventLogApi
        {
            public const string PeopleEventLogBase = TeamManager + "/peopleeventlog";

            public const string Add = "add";

            public const string Delete = "delete";

            public const string Find = "find";

            public const string GetAll = "getall";

            public const string GetAllActive = "getallactive";

            public const string Modify = "modify";

            public const string GetByPerson = "getbyperson";
        }

        public struct PositionApi
        {
            public const string PositionBase = TeamManager + "/position";

            public const string Add = "add";

            public const string Delete = "delete";

            public const string Find = "find";

            public const string GetAll = "getall";

            public const string GetAllActive = "getallactive";

            public const string Modify = "modify";
        }

        public struct TitleApi
        {
            public const string TitleBase = TeamManager + "/title";

            public const string Add = "add";

            public const string Delete = "delete";

            public const string Find = "find";

            public const string GetAll = "getall";

            public const string GetAllActive = "getallactive";

            public const string Modify = "modify";
        }
    }
}