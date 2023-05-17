using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using SwordLMS.Web.Models;
using SwordLMS.Web.Request;

using SwordLMS.Web.Services;
using Microsoft.AspNetCore.Routing.Matching;
using Newtonsoft.Json;
using SwordLMS.Web.RequestDto;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace SwordLMS.Web.Repository
{
    public class UserRepository : IUserRepository 
    
    {
        private readonly SwordLmsContext _context;
        //private readonly DbSet<T> _dbSet;
        private readonly IPasswordHasher _passwordHasher;
        public IWebHostEnvironment _hostingEnvironment;
      

        public UserRepository(SwordLmsContext context, IPasswordHasher passwordHasher, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _passwordHasher = passwordHasher;
            //_dbSet = _context.Set<T>();

        }


        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }

        public Task<User> DoLoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public User SaveSignUp(RegisterRequest request)
        {
            var dateTime = DateTime.Now.ToShortDateString();
            request.DateOfBirth = Convert.ToDateTime(dateTime);

            var passwordHash = _passwordHasher.Hash(request.Password);
            request.Password = passwordHash;

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                RoleId = request.RoleId,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Pincode = request.Pincode,
                State = request.State,
                Country = request.Country,
                City = request.City,
                PhoneNumber = request.PhoneNumber,

            };


            _context.Users.Add(user);
            _context.SaveChangesAsync();
            return user;

        }


        public  void  SaveSkill([FromQuery] string data)
        {
            var skills = JsonConvert.DeserializeObject<SkillsViewModel>(data);

            List<CourseSkill> listskills = new List<CourseSkill>();


            if (skills != null)

                foreach (var skillid in skills.SkillsId)
                {
                    CourseSkill skill = new CourseSkill();

                    skill.SkillsId = int.Parse(skillid);
                    skill.CourseId = skills.CourseId;


                    _context.CourseSkills.Add(skill);
                    _context.SaveChanges();
                   
                
                };

        }

        public void SaveTopics([FromQuery] string data1) 
        {
            var courseTopic = JsonConvert.DeserializeObject<CourseTopic>(data1);
            if (courseTopic == null)
            {
                throw new Exception("Not Found");
            }
            _context.CourseTopics.Add(courseTopic);
            _context.SaveChangesAsync();

        }



        //public IEnumerable<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}



        //public void Add(T entity)
        //{
        //    _dbSet.Add(entity);
        //}






        public void Save()
        {
            _context.AddRange();
            _context.SaveChanges();
        }
    }
}




