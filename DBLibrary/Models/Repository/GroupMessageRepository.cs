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
    public class GroupMessageRepository : BaseRepository<GroupMessage, int>
    {
        public GroupMessageRepository(DatabaseContext ctx) : base(ctx) { }

        public async override Task<GroupMessage> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(gm => gm.Id == id);
        }

        public async override Task UpdateAsync(GroupMessage item)
        {
            GroupMessage gm = await GetAsync(item.Id);

            if (gm != null)
            {
                gm.From = item.From;
                gm.FromId = item.FromId;
                gm.To = item.To;
                gm.ToId = item.ToId;
                gm.Text = item.Text;

                await ctx.SaveChangesAsync();
            }
        }
    }
}
