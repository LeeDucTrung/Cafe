using System;
using System.Collections.Generic;
using System.Text;

namespace VPDT.Data
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
