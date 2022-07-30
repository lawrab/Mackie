namespace SnailRacing.Mackie.Domain
{
    internal interface ITeamRepository
    {
        void Add(Team team);
        Task Commit();
    }
}
