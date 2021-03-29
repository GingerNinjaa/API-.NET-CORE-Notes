using API_.NET_CORE_Notes.Models;
using Microsoft.EntityFrameworkCore;

namespace API_.NET_CORE_Notes.data
{
    public class ApiDBcontext : DbContext
    {
        public ApiDBcontext(DbContextOptions<ApiDBcontext>options) :base(options)
        {
                
        }

        public DbSet<Song> Songs { get; set; }
    }
}
