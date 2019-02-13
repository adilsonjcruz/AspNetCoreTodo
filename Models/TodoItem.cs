using System;

namespace AspNetCoreTodo.Models
{

    public class TodoItem
    {
        public string OwnerId{get; set;}
        
        public Guid Id { get; set; }
        public bool isDone { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }

    }

}