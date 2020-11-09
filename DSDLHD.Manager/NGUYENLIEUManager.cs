
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
    public interface INGUYENLIEUManager
    {
        Task Create(NGUYENLIEU inputModel);
        Task Update(NGUYENLIEU inputModel);
        Task<List<NGUYENLIEU>> Get_list(string name, int pageSize, int pageNumber);
        Task<NGUYENLIEU> FindById(int id);
        Task<List<NGUYENLIEU>> Look_up();
    }
    public class NGUYENLIEUManager : INGUYENLIEUManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public NGUYENLIEUManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(NGUYENLIEU inputModel)
        {
            try
            {
                var result = await _unitOfWork.NGUYENLIEURepository.Add(inputModel);
                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(NGUYENLIEU inputModel)
        {
            await _unitOfWork.CreateTransaction();
            try
            {
                await _unitOfWork.NGUYENLIEURepository.Update(inputModel);
                await _unitOfWork.SaveChange();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        } 
        public async Task<List<NGUYENLIEU>> Get_list(string name, int pageSize, int pageNumber)
        {
            try
            {
                List<NGUYENLIEU> data;
                data = (await _unitOfWork.NGUYENLIEURepository.FindBy(x => ((string.IsNullOrEmpty(name) || x.TENNGUYENLIEU.ToLower().Contains(name.ToLower())))
                                                                   )).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NGUYENLIEU> FindById(int id)
        {
            return await _unitOfWork.NGUYENLIEURepository.Get(x => x.ID == id);
        }
        public async Task<List<NGUYENLIEU>> Look_up()
        {
            return (await _unitOfWork.NGUYENLIEURepository.GetAll()).ToList();
        }
    }

}
