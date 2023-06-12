using Microsoft.AspNetCore.Mvc;

using SwordLMS.Web.Models;
using SwordLMS.Web.Repository;
using SwordLMS.Web.Services;

namespace SwordLMS.Web.ViewComponents
{

    [ViewComponent(Name = "SkillComponent")]
    public class CategoryComponent : ViewComponent
    {
        private readonly SwordLmsContext _context;
        

        public CategoryComponent(SwordLmsContext context)
        {
            _context = context;
            
        }

       

        //public  IViewComponentResult InvokeAsync(int skillId)
        //{
        //    var skill = GetSkills(skillId);
        //    return View(skill);
        //}

        //private List<Skill> GetSkills(int skillsId)
        //{
        //    var skillList = _context.Skills.Where(u => u.SubCategoryId == skillsId).ToList();
        //    return skillList;
        //}



        public async Task<IViewComponentResult> InvokeAsync(int skillId)
        {
            var skill = await GetSkillsAsync(skillId);
            return View(skill);
        }

        private Task<List<Skill>> GetSkillsAsync(int skillsId)
        {
            var skillList = _context.Skills.Where(u => u.SubCategoryId == skillsId).ToList();
            return Task.FromResult(skillList);
        }

    }
}
