using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Common.Contracts
{
    public interface ICurrentUser
    {
        public Guid? Id { get; }
    }
}
