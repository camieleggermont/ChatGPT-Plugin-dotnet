namespace ChatGPT_Plugin.Domain
{
    /// <summary>
    /// A todo item.
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// The id of the todo item.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The title of the todo item.
        /// </summary>
        public string? Title { get; set; }
        
        /// <summary>
        /// Indicates if the todo item is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// The due date of the todo item.
        /// </summary>
        public DateTime? Due { get; set; }

        /// <summary>
        /// Creates a new todo item.
        /// </summary>
        public ToDo()
        {
            Id = Guid.NewGuid();
            IsCompleted = false;
        }
    }
}
