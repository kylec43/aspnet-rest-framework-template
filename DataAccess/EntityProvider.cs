namespace ChatApp.DataAccess 
{
    public class EntityProvider<T> where T : class
    {
        private readonly ChatAppDbContext _context;

        public EntityProvider(ChatAppDbContext context)
        {
            _context = context;
        }

        public List<T> GetEntities()
        {
            return _context.Set<T>().ToList();
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        // Add additional methods as needed for your specific use case
    }
}
