using SMSApi.Models;

namespace SMSApi.Services
{
    public class Seed
    {
        public SMSDbContext Context { get; }

        public Seed(SMSDbContext context)
        {

            Context = context;
        }

        public void SeedData()
        {


            var users = Context.users.ToList() ;

            if (users.Count==0)
            {
                var userlist = new List<User> {
                   new User {username="admin",password="admin",UserType= SMSApi.Models.User.UserTypes.Admin,isactive=true},
                        new User {username=" Devuplink",password="123",UserType= SMSApi.Models.User.UserTypes.Admin, isactive = true},
            };

                Context.AddRange(userlist);
                Context.SaveChanges();

            }

        }
    }
}
