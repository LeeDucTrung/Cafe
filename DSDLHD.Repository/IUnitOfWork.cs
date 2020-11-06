using VPDT.Data;
using VPDT.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VPDT.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        
        public ITBL_Chuc_VuRepository TBL_Chuc_VuRepository { get; }
       
        Task CreateTransaction();
        void Commit();
        void Rollback();
        Task SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        VPDTDbContext _dbContext;
        IDbContextTransaction _transaction;

        public UnitOfWork(IDbContextFactory<VPDTDbContext> dbContextFactory, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContextFactory.GetContext();
            TBL_Chuc_VuRepository = new TBL_Chuc_VuRepository(_dbContext);
            



    }
        public ITBL_Chuc_VuRepository TBL_Chuc_VuRepository { get; }

       

        #region Transaction
        public async Task CreateTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task SaveChange()
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        private bool disposedValue = false;



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}

