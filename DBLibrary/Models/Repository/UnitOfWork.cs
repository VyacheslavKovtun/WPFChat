using DBLibrary.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models.Repository
{
    public class UnitOfWork : IDisposable
    {
        private static UnitOfWork instance;
        public static UnitOfWork Instance
            => instance ?? (instance = new UnitOfWork());

        private DatabaseContext ctx;

        private UserRepository userRepository;
        private MessageRepository messageRepository;
        private GroupRepository groupRepository;
        private GroupMessageRepository groupMessageRepository;

        public UserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(ctx));

        public MessageRepository MessageRepository => messageRepository ?? (messageRepository = new MessageRepository(ctx));

        public GroupRepository GroupRepository => groupRepository ?? (groupRepository = new GroupRepository(ctx));

        public GroupMessageRepository GroupMessageRepository => groupMessageRepository ?? (groupMessageRepository = new GroupMessageRepository(ctx));

        private UnitOfWork()
        {
            ctx = new DatabaseContext();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
