using ChatGPT_Plugin.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatGPT_Plugin.Controllers
{
    /// <summary>
    /// An API controller for managing ToDo items.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }


        /// <summary>
        /// Get all ToDo items.
        /// </summary>
        /// <returns>A list of ToDo items</returns>
        [HttpGet]
        public async Task<IEnumerable<ToDo>> Get()
        {
            return await toDoRepository.GetAsync();
        }

        /// <summary>
        /// Search for ToDo items by title.
        /// </summary>
        /// <param name="term">The search term</param>
        /// <returns>The found todo items</returns>
        [HttpGet("search/{term}")]
        public async Task<IEnumerable<ToDo>> Search(string term)
        {
            return await toDoRepository.SearchAsync(term);
        }

        /// <summary>
        /// Get all ToDo items due on a specific date.
        /// </summary>
        /// <param name="date">The due date</param>
        /// <returns>The todos due on the date</returns>
        [HttpGet("getDue/{date}")]
        public async Task<IEnumerable<ToDo>> GetDue(DateTime date)
        {
            return await toDoRepository.GetDueAsync(date);
        }


        /// <summary>
        /// Get a specific todo item by id.
        /// </summary>
        /// <param name="id">The id for the todo item</param>
        /// <returns>The todo item</returns>
        [HttpGet("{id}")]
        public Task<ToDo> Get(Guid id)
        {
            return toDoRepository.GetAsync(id);
        }

        /// <summary>
        /// Add a new todo item.
        /// </summary>
        /// <param name="value">The todo item</param>
        /// <returns>The added item</returns>
        // POST api/<ToDoController>
        [HttpPost]
        public async Task<ToDo> Post([FromBody] ToDo value)
        {
            return await toDoRepository.AddAsync(value);
        }

        /// <summary>
        /// Complete the todo item with the given id.
        /// </summary>
        /// <param name="id">The id of the todo</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Complete(Guid id)
        {
            await toDoRepository.CompleteAsync(id);
        }
    }
}
