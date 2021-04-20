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
    public class MessageRepository : BaseRepository<Message, int>
    {
        public MessageRepository(DatabaseContext ctx) : base(ctx) { }

        public async override Task<Message> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<Message> GetUserMessages(int userId)
        {
            return table.Where(m => m.FromId == userId || m.ToId == userId);
        }

        public async override Task UpdateAsync(Message item)
        {
            Message msg = await GetAsync(item.Id);

            if (msg != null)
            {
                msg.From = item.From;
                msg.FromId = item.FromId;

                msg.To = item.To;
                msg.ToId = item.ToId;

                msg.Text = item.Text;

                await ctx.SaveChangesAsync();
            }
        }
    }
}
