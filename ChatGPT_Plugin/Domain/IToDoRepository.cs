namespace ChatGPT_Plugin.Domain
{
    public interface IToDoRepository
    {
        Task<ToDo> AddAsync(ToDo toDo);
        Task<ToDo> GetAsync(Guid id);
        Task<IEnumerable<ToDo>> GetAsync();
        Task<IEnumerable<ToDo>> GetDueAsync(DateTime dateTime);
        Task<IEnumerable<ToDo>> SearchAsync(string searchTerm);
        Task CompleteAsync(Guid id);

    }
}
