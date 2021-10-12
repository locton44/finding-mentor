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
   public interface IUserService
    {
        ResultModel Get(string id);
        ResultModel Delete(string id);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ResultModel Get(string id)
        {
            var result = new ResultModel();
            try
            {
                var user = _dbContext.Users.Where(s => id == null || (s.IsDisable == false && s.Id == id)).ToList();

                result.Data = _mapper.Map<List<User>, List<UserViewModels>>(user);
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
                var service = _dbContext.User.FirstOrDefault(s => s.Id == id);

                if (service == null)
                {
                    throw new Exception("Invalid Id");
                }

                service.IsDisable = true;
                //service.DateUpdated = DateTime.Now;

                _dbContext.Update(service);
                _dbContext.SaveChanges();

                result.Data = service.Id;
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
