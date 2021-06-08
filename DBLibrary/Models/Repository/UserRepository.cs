using DBLibrary.Models.Base;
using DBLibrary.Models.DBContext;
using DBLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Repository
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(DatabaseContext ctx) : base(ctx) { }

        public async override Task<User> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(u => u.Id == id);
        }

        public User Get(int id)
        {
            return table.FirstOrDefault(u => u.Id == id);
        }

        public async override Task UpdateAsync(User item)
        {
            User user = await GetAsync(item.Id);

            if (user != null)
            {
                user.Nickname = item.Nickname;
                user.Login = item.Login;
                user.Password = item.Password;

                await ctx.SaveChangesAsync();
            }
        }
    }
}
