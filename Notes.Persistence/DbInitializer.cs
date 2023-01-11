namespace Notes.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
            //При отсутствии БД создаёт её на основе нашего представления
        }
    }
}
