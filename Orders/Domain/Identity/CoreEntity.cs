using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity
{
    public abstract class CoreEntity
    {
        protected CoreEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }

        public string Id { get; }



        public int EntityId { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime? DeletedDate { get; private set; }

        public void Delete()
        {
            if (DeletedDate.HasValue)
                return;

            DeletedDate = DateTime.Now;
        }
    }
}
