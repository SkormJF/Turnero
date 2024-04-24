using Microsoft.EntityFrameworkCore;

namespace Data 

{
    public class TurneroContext: DbContext
    { 
        public TurneroContext(DbContextOptions<TurneroContext> options)
            : base(options)
        {
        }
    }
}