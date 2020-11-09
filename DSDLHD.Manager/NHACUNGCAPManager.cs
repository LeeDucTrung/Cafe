
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

using System.Linq;
using VPDT.Models;
using VPDT.Repository;
using VPDT.Utils;

namespace VPDT.Manager
{
    public interface INHACUNGCAPManager
    {
        Task Create(NHACUNGCAP inputModel);
        Task Update(NHACUNGCAP inputModel);
        Task<List<NHACUNGCAP>> Get_list(string name, int pageSize, int pageNumber);
        Task<NHACUNGCAP> FindById(int id);
        Task<List<NHACUNGCAP>> Look_up();
        Task<NHACUNGCAP> Find_By_Name(string ten);
    }
    public class NHACUNGCAPManager : INHACUNGCAPManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public NHACUNGCAPManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(NHACUNGCAP inputModel)
        {
            try
            {
                var result = await _unitOfWork.NHACUNGCAPRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(NHACUNGCAP inputModel)
        {
            await _unitOfWork.CreateTransaction();
            try
            {
                await _unitOfWork.NHACUNGCAPRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
        async Task<NHACUNGCAP> INHACUNGCAPManager.Find_By_Name(string ten)
        {
            return await _unitOfWork.NHACUNGCAPRepository.Get(c => c.TENNHACUNGCAP.ToLower() == ten.Trim().ToLower());
        }
        public async Task<List<NHACUNGCAP>> Get_list(string name, int pageSize, int pageNumber)
        {
            try
            {
                List<NHACUNGCAP> data;
                data = (await _unitOfWork.NHACUNGCAPRepository.FindBy(x =>((string.IsNullOrEmpty(name) || x.TENNHACUNGCAP.ToLower().Contains(name.ToLower())))
                                                                   )).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NHACUNGCAP> FindById(int id)
        {
            return await _unitOfWork.NHACUNGCAPRepository.Get(x => x.ID == id);
        }
        public async Task<List<NHACUNGCAP>> Look_up()
        {
            return (await _unitOfWork.NHACUNGCAPRepository.GetAll()).ToList();
        }
    }

}
