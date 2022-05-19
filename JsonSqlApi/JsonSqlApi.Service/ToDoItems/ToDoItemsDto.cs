namespace JsonSqlApi.Service.ToDoItems
{
    public class ToDoItemsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ToDoItemsList ToDoItemsLists { get; set; }
    }

    public class ToDoItemsList
    {
        public string Item { get; set; }

        public bool Completed { get; set; }
    }
}
