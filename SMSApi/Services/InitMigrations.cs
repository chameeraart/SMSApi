using SMSApi.Models;
using Microsoft.EntityFrameworkCore;


namespace SMSApi.Services
{
    public class InitMigrations
    {
        private readonly SMSDbContext context;
        public InitMigrations(SMSDbContext context)
        {
            this.context = context;
        }
        public void MigrateDatabase()
        {
            context.Database.Migrate();
        }
    }
}
