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
    public interface ISubjectService
    {
        ResultModel Get(string id);
        ResultModel Add(SubjectAddModels model);
        ResultModel Update(string id, SubjectUpdateModels model);
        ResultModel Delete(string id);
    }
    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ResultModel Add(SubjectAddModels model)
        {
            var result = new ResultModel();
            try
            {
                var subject = _mapper.Map<SubjectAddModels, Subject>(model);

                _dbContext.Add(subject);
                _dbContext.SaveChanges();

                result.Data = subject.Id;
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
                var subject = _dbContext.Subjects.FirstOrDefault(s => s.Id == id);

                if (subject == null)
                {
                    throw new Exception("Invalid Id");
                }

                subject.IsDeleted = true;

                _dbContext.Update(subject);
                _dbContext.SaveChanges();

                result.Data = subject.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Get(string id)
        {

            var result = new ResultModel();
            try
            {
                var subject = _dbContext.Subjects.Where(s => id == null || (s.IsDeleted == false && s.Id == id)).ToList();

                result.Data = _mapper.Map<List<Subject>, List<SubjectViewModel>>(subject);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(string id, SubjectUpdateModels model)
        {
            var result = new ResultModel();
            try
            {
                var subject = _dbContext.Subjects.FirstOrDefault(s => s.Id == id);

                if (subject == null)
                {
                    throw new Exception("Invalid Id");
                }

                subject.Description = model.Description;
                subject.Name = model.Name;
                subject.DateUpdated = DateTime.Now;

                _dbContext.Update(subject);
                _dbContext.SaveChanges();

                result.Data = subject.Id;
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
