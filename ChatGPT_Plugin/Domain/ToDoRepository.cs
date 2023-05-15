namespace ChatGPT_Plugin.Domain
{
    public class ToDoRepository : IToDoRepository
    {
        private List<ToDo> _toDoList = new List<ToDo>();

        public Task<ToDo> AddAsync(ToDo toDo)
        {
            _toDoList.Add(toDo);
            return Task.FromResult(toDo);
        }

        public Task CompleteAsync(Guid id)
        {
            var toDo = _toDoList.FirstOrDefault(x => x.Id == id);
            if (toDo is null)
            {
                throw new Exception($"ToDo with id: {id} does not exist.");
            }

            toDo.IsCompleted = true;
            return Task.CompletedTask;
        }

        public Task<ToDo> GetAsync(Guid id)
        {
            var toDo = _toDoList.FirstOrDefault(x => x.Id == id);
            if (toDo is null)
            {
                throw new Exception($"ToDo with id: {id} does not exist.");
            }
            return Task.FromResult(toDo);

        }

        public Task<IEnumerable<ToDo>> GetAsync()
        {
            return Task.FromResult(_toDoList.AsEnumerable());
        }

        public Task<IEnumerable<ToDo>> GetDueAsync(DateTime dateTime)
        {
            return Task.FromResult(_toDoList.Where(x => x.Due?.Date == dateTime.Date));
        }

        public Task<IEnumerable<ToDo>> SearchAsync(string searchTerm)
        {
            return Task.FromResult(_toDoList.Where(x => x.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
