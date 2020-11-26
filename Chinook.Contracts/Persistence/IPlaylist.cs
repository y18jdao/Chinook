namespace Chinook.Contracts.Persistence
{
    public interface IPlaylist : IIdentifiable
    {
        string Name { get; set; }
    }
}
