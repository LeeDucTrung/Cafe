
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
        Task<List<NHACUNGCAP>> Get_list(string name,int status, int pageSize, int pageNumber);
        Task<NHACUNGCAP> FindById(int id);
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
        public async Task<List<NHACUNGCAP>> Get_list(string name,int status, int pageSize, int pageNumber)
        {
            try
            {
                List<NHACUNGCAP> data;
                if (status == (int)StatusEnum.All)
                {
                    data = (await _unitOfWork.NHACUNGCAPRepository.FindBy(x =>((string.IsNullOrEmpty(name) || x.TENNHACUNGCAP.ToLower().Contains(name.ToLower())))
                                                                   )
                    ).ToList();
                    return data;
                }
                data = (await _unitOfWork.NHACUNGCAPRepository.FindBy(x =>((string.IsNullOrEmpty(name) || x.TENNHACUNGCAP.ToLower().Contains(name.ToLower())))
                                                                   )
                ).ToList();
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
        

    }

}
