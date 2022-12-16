using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAGRO.Challenge.Domain.Core.Interfaces
{
    public interface IDataSource
    {
        public T JsonToObject<T>();
    }
}
