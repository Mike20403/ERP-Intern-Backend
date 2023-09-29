namespace DotNetStarter.Common
{
    public static class PrivilegeNames
    {
        #region CRUD Actions
        public const string ViewTalents = "VIEW_TALENTS";
        public const string CreateTalents = "CREATE_TALENTS";
        public const string UpdateTalents = "UPDATE_TALENTS";
        public const string DeleteTalents = "DELETE_TALENTS";
        public const string ViewAgencyMembers = "VIEW_AGENCY_MEMBERS";
        public const string CreateAgencyMembers = "CREATE_AGENCY_MEMBERS";
        public const string UpdateAgencyMembers = "UPDATE_AGENCY_MEMBERS";
        public const string DeleteAgencyMembers = "DELETE_AGENCY_MEMBERS";
        public const string ViewProjects = "VIEW_PROJECTS";
        public const string CreateProjects = "CREATE_PROJECTS";
        public const string UpdateProjects = "UPDATE_PROJECTS";
        public const string DeleteProjects = "DELETE_PROJECTS";
        public const string ViewTasks = "VIEW_TASKS";
        public const string CreateTasks = "CREATE_TASKS";
        public const string UpdateTasks = "UPDATE_TASKS";
        public const string DeleteTasks = "DELETE_TASKS";
        #endregion

        #region Other actions
        public const string InviteTalents = "INVITE_TALENTS";
        public const string RemoveTalentsFromProject = "REMOVE_TALENTS_FROM_PROJECT";
        public const string CreatePayments = "CREATE_PAYMENTS";
        public const string UpdatePayments = "UPDATE_PAYMENTS";
        public const string AcceptPayments = "ACCEPT_PAYMENTS";
        public const string FinalizePayments = "FINALIZE_PAYMENTS";
        #endregion

    }
}
