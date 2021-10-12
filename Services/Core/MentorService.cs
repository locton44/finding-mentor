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
    public interface IMentorService
    {
        ResultModel Get(Guid? id);
        ResultModel Create(MentorAddModel model);
        ResultModel Update(Guid id, MentorUpdateModel model);
        ResultModel Delete(Guid id);
    }
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public MentorService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public ResultModel Get(Guid? id)
        {
            var result = new ResultModel();
            try
            {
                var mentors = _dbContext.Mentors.Where(s => id == null || (s.Id == id)).ToList();

                result.Data = _mapper.Map<List<Mentor>, List<MentorViewModel>>(mentors);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Create(MentorAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _mapper.Map<MentorAddModel, Mentor>(model);

                _dbContext.Add(mentor);
                _dbContext.SaveChanges();

                result.Data = mentor.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(Guid id, MentorUpdateModel model)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _dbContext.Mentors.FirstOrDefault(s => s.Id == id);

                if (mentor == null)
                {
                    throw new Exception("Invalid Id");
                }

                mentor = _mapper.Map<MentorUpdateModel, Mentor>(model);
                

                _dbContext.Update(mentor);
                _dbContext.SaveChanges();

                result.Data = mentor.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Delete(Guid id)
        {
            var result = new ResultModel();
            try
            {
                var mentor = _dbContext.Mentors.FirstOrDefault(s => s.Id == id);

                if (mentor == null)
                {
                    throw new Exception("Invalid Id");
                }

                

                _dbContext.Update(mentor);
                _dbContext.SaveChanges();

                result.Data = mentor.Id;
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
