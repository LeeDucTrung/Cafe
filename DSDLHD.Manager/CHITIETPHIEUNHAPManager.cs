
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

using System.Linq;
using VPDT.Models;
using VPDT.Repository;
using VPDT.Utils;
using CAFE.Models;

namespace VPDT.Manager
{
    public interface ICHITIETPHIEUNHAPManager
    {
        Task Create(CHITIETPHIEUNHAP inputModel);
        Task Update(CHITIETPHIEUNHAP inputModel);
        Task<List<CHITIETPHIEUNHAP>> Get_list(string name, int pageSize, int pageNumber);
        Task<List<CHITIETPHIEUNHAP>> Get_list_Thong_Tin(int id, int pageSize, int pageNumber);
        Task<CHITIETPHIEUNHAP> FindById(int id);
    }
    public class CHITIETPHIEUNHAPManager : ICHITIETPHIEUNHAPManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CHITIETPHIEUNHAPManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(CHITIETPHIEUNHAP inputModel)
        {
            try
            {
                var result = await _unitOfWork.CHITIETPHIEUNHAPRepository.Add(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(CHITIETPHIEUNHAP inputModel)
        {
            await _unitOfWork.CreateTransaction();
            try
            {
                await _unitOfWork.CHITIETPHIEUNHAPRepository.Update(inputModel);
                await _unitOfWork.SaveChange();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        } 
        public async Task<List<CHITIETPHIEUNHAP>> Get_list(string name, int pageSize, int pageNumber)
        {
            try
            {
                List<CHITIETPHIEUNHAP> data;
                data = (await _unitOfWork.CHITIETPHIEUNHAPRepository.GetAll()).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CHITIETPHIEUNHAP>> Get_list_Thong_Tin(int id, int pageSize, int pageNumber)
        {
            try
            {
                List<CHITIETPHIEUNHAP> data;
                data = (await _unitOfWork.CHITIETPHIEUNHAPRepository.FindBy(x => x.PHIEUNHAPID == id)).ToList();
                for (int i = 0; i < data.Count(); i++)
                {
                    var TENNGUYENLIEU = (await _unitOfWork.NGUYENLIEURepository.Get(x => x.ID == data[i].NGUYENLIEUID)).TENNGUYENLIEU;
                    data[i].NGUYENLIEUNAME = TENNGUYENLIEU;
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CHITIETPHIEUNHAP> FindById(int id)
        {
            return await _unitOfWork.CHITIETPHIEUNHAPRepository.Get(x => x.ID == id);
        }
    }

}
