using SwordLMS.Web.Models;
using SwordLMS.Web.Request;
using SwordLMS.Web.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace SwordLMS.Web.Repository
{
    public class UserRepository : IUserRepository 
    
    {
        private readonly SwordLmstwoContext _context;
    
        private readonly IPasswordHasher _passwordHasher;
        public IWebHostEnvironment _hostingEnvironment;
      

        public UserRepository(SwordLmstwoContext context, IPasswordHasher passwordHasher, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _passwordHasher = passwordHasher;
          

        }


        //public List<TEntity> GetAll<TEntity>() where TEntity : class
        //{
        //    var category = _context.Categories.ToListAsync();
        //    return ca
        //   // return _context.Set<TEntity>().ToList();
        //}


     
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
            _context.SaveChanges();
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

        //public List<SubCategory> GetSubCategory(int categoryId)
        //{
        //    var subcategoriesList = _context.SubCategories.Where(u => u.CategoryId == categoryId).ToList();
        //    return subcategoriesList;
        //}

        //public List<Skill> GetSkills(int skillsId)
        //{
        //   // var subcategory = GetSubCategory(skillsId);
        //    var skillList = _context.Skills.Where(u => u.SubCategoryId == skillsId).ToList();
        //    return skillList;
        //}

    }
}




