using AutoMapper;
using Data.DbContext;
using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Core
{
    public interface IMajorService
    {
        ResultModel Get(string id);
        ResultModel Add(MajorAddModel model);
        ResultModel Update(string id, MajorUpdateModel model);
        ResultModel Delete(string id);
    }

    public class MajorService : IMajorService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public MajorService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ResultModel Get(string id)
        {
            var result = new ResultModel();
            try
            {
                var major = _dbContext.Majors.Where(s => id == null || (s.IsDeleted == false && s.Id == id)).ToList();

                result.Data = _mapper.Map<List<Major>, List<MajorViewModel>>(major);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
        public ResultModel Add(MajorAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var major = _mapper.Map<MajorAddModel, Major>(model);

                _dbContext.Add(major);
                _dbContext.SaveChanges();

                result.Data = major.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(string id, MajorUpdateModel model)
        {
            var result = new ResultModel();
            try
            {
                var major = _dbContext.Majors.FirstOrDefault(s => s.Id == id);

                if (major == null)
                {
                    throw new Exception("Invalid Id");
                }

                major.Description = model.Description;
                major.Name = model.Name;
                major.DateUpdated = DateTime.Now;

                _dbContext.Update(major);
                _dbContext.SaveChanges();

                result.Data = major.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }


        public ResultModel Delete(string id)
        {
            var result = new ResultModel();
            try
            {
                var major = _dbContext.Majors.FirstOrDefault(s => s.Id == id);

                if (major == null)
                {
                    throw new Exception("Invalid Id");
                }

                major.IsDeleted = true;
                //service.DateUpdated = DateTime.Now;

                _dbContext.Update(major);
                _dbContext.SaveChanges();

                result.Data = major.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }
    }
}
