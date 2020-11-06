
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
    public interface ITBL_Chuc_VuManager
    {
        Task Create(TBL_Chuc_Vu inputModel);
        Task Update(TBL_Chuc_Vu inputModel);
        Task<List<TBL_Chuc_Vu>> Get_list(string name,int status, int pageSize, int pageNumber);
        Task<TBL_Chuc_Vu> FindById(int id);
    }
    public class TBL_Chuc_VuManager : ITBL_Chuc_VuManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public TBL_Chuc_VuManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(TBL_Chuc_Vu inputModel)
        {
            try
            {
                var result = await _unitOfWork.TBL_Chuc_VuRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(TBL_Chuc_Vu inputModel)
        {
            await _unitOfWork.CreateTransaction();
            try
            {
                await _unitOfWork.TBL_Chuc_VuRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        } 
        public async Task<List<TBL_Chuc_Vu>> Get_list(string name,int status, int pageSize, int pageNumber)
        {
            try
            {
                List<TBL_Chuc_Vu> data;
                if (status == (int)StatusEnum.All)
                {
                    data = (await _unitOfWork.TBL_Chuc_VuRepository.FindBy(x =>((string.IsNullOrEmpty(name) || x.TENNHACUNGCAP.ToLower().Contains(name.ToLower())))
                                                                   )
                    ).ToList();
                    return data;
                }
                data = (await _unitOfWork.TBL_Chuc_VuRepository.FindBy(x =>((string.IsNullOrEmpty(name) || x.TENNHACUNGCAP.ToLower().Contains(name.ToLower())))
                                                                   )
                ).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TBL_Chuc_Vu> FindById(int id)
        {
            return await _unitOfWork.TBL_Chuc_VuRepository.Get(x => x.ID == id);
        }
        

    }

}
