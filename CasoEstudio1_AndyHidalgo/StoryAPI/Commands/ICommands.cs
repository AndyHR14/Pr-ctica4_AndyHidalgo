namespace StoryAPI.Commands
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}