
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
    public interface IPHIEUNHAPManager
    {
        Task Create(PHIEUNHAP inputModel);
        Task Update(PHIEUNHAP inputModel);
        Task<List<PHIEUNHAP>> Get_list(string name, int pageSize, int pageNumber);
        Task<PHIEUNHAP> FindById(int id);
    }
    public class PHIEUNHAPManager : IPHIEUNHAPManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public PHIEUNHAPManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(PHIEUNHAP inputModel)
        {
            try
            {
                var result = await _unitOfWork.PHIEUNHAPRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(PHIEUNHAP inputModel)
        {
            await _unitOfWork.CreateTransaction();
            try
            {
                await _unitOfWork.PHIEUNHAPRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        } 
        public async Task<List<PHIEUNHAP>> Get_list(string name, int pageSize, int pageNumber)
        {
            try
            {
                List<PHIEUNHAP> data;
                data = (await _unitOfWork.PHIEUNHAPRepository.GetAll()).ToList();
                for (int i = 0; i < data.Count(); i++)
                {
                    var nhacungcapname = (await _unitOfWork.NHACUNGCAPRepository.Get(x => x.ID == data[i].NHACUNGCAPID)).TENNHACUNGCAP;
                    data[i].NHACUNGCAPNAME = nhacungcapname;
                }
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PHIEUNHAP> FindById(int id)
        {
            return await _unitOfWork.PHIEUNHAPRepository.Get(x => x.ID == id);
        }
    }

}
