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
        
        public INHACUNGCAPRepository NHACUNGCAPRepository { get; }
        public IPHIEUNHAPRepository PHIEUNHAPRepository { get; }
        public INGUYENLIEURepository NGUYENLIEURepository { get; }
        public ICHITIETPHIEUNHAPRepository CHITIETPHIEUNHAPRepository { get; }
       
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
            NHACUNGCAPRepository = new NHACUNGCAPRepository(_dbContext);
            PHIEUNHAPRepository = new PHIEUNHAPRepository(_dbContext);
            NGUYENLIEURepository = new NGUYENLIEURepository(_dbContext);
            CHITIETPHIEUNHAPRepository = new CHITIETPHIEUNHAPRepository(_dbContext);
            


            
    }
        public INHACUNGCAPRepository NHACUNGCAPRepository { get; }
        public IPHIEUNHAPRepository PHIEUNHAPRepository { get; }
        public INGUYENLIEURepository NGUYENLIEURepository { get; }
        public ICHITIETPHIEUNHAPRepository CHITIETPHIEUNHAPRepository { get; }

       

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

