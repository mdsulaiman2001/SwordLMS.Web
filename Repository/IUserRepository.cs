using Microsoft.AspNetCore.Mvc;
using SwordLMS.Web.Models;
using SwordLMS.Web.Request;

namespace SwordLMS.Web.Repository
{
    public interface IUserRepository
    {
        User SaveSignUp(RegisterRequest request);

        Task<User> DoLoginAsync(LoginRequest request);

        //List<TEntity> GetAll<TEntity>() where TEntity : class;

        void SaveSkill([FromQuery] string data);


        //IEnumerable<T> GetAll();

        //void Add(T entity);

        //void Save();
        void Save();
        //List<SubCategory> GetSubCategory(int categoryId);

        //List<Skill> GetSkills(int skillsId);





    }
}
