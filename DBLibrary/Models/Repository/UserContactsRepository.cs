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
    public class UserContactsRepository: BaseRepository<UserContacts, int>
    {
        public UserContactsRepository(DatabaseContext ctx) : base(ctx) { }

        public IQueryable<UserContacts> GetByUserId(int id)
        {
            return table.Where(uc => uc.UserId == id);
        }

        public async override Task<UserContacts> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(uc => uc.Id == id);
        }

        public async override Task UpdateAsync(UserContacts item)
        {
            UserContacts uc = await GetAsync(item.Id);

            if(uc != null)
            {
                uc.UserId = item.UserId;

                foreach (var user in item.Contacts)
                    uc.Contacts.Add(user);

                await ctx.SaveChangesAsync();
            }
        }
    }
}
