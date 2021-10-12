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
    public interface IStudentService
    {
        ResultModel Get(Guid? id);
        ResultModel Create(StudentAddModel model);
        ResultModel Update(Guid id, StudentUpdateModel model);
        ResultModel Delete(Guid id);
    }
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public StudentService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public ResultModel Get(Guid? id)
        {
            var result = new ResultModel();
            try
            {
                var students = _dbContext.Students.Where(s => id == null || (s.Id == id)).ToList();

                result.Data = _mapper.Map<List<Student>, List<StudentViewModel>>(students);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Create(StudentAddModel model)
        {
            var result = new ResultModel();
            try
            {
                var student = _mapper.Map<StudentAddModel, Student>(model);

                _dbContext.Add(student);
                _dbContext.SaveChanges();

                result.Data = student.Id;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public ResultModel Update(Guid id, StudentUpdateModel model)
        {
            var result = new ResultModel();
            try
            {
                var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    throw new Exception("Invalid Id");
                }

                student = _mapper.Map<StudentUpdateModel, Student>(model);


                _dbContext.Update(student);
                _dbContext.SaveChanges();

                result.Data = student.Id;
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
                var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    throw new Exception("Invalid Id");
                }



                _dbContext.Update(student);
                _dbContext.SaveChanges();

                result.Data = student.Id;
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
