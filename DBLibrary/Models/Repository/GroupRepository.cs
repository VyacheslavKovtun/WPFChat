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
    public class GroupRepository : BaseRepository<Group, int>
    {
        public GroupRepository(DatabaseContext ctx) : base(ctx) { }

        public async override Task<Group> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async override Task UpdateAsync(Group item)
        {
            Group group = await GetAsync(item.Id);

            if (group != null)
            {
                group.Name = item.Name;

                if (group.Users != null)
                {
                    foreach (var u in group.Users)
                    {
                        ctx.Users.Attach(u);
                    }
                }

                group.Users = item.Users;

                await ctx.SaveChangesAsync();
            }
        }
    }
}
