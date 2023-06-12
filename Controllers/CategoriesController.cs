using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;

using SwordLMS.Web.Models;
using SwordLMS.Web.Repository;

namespace SwordLMS.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly SwordLmsContext _context;

        public IUserRepository _userRepository { get; }
        private readonly IWebHostEnvironment _hostEnviroment;
        public CategoriesController(SwordLmsContext context, IUserRepository userRepository, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _userRepository = userRepository;
            _hostEnviroment = hostEnviroment;
        }

        // GET: Categories
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.Categories.ToListAsync());
        //}
        public IActionResult Index()
        {
            //var categoryList= _userRepository.GetAll<Category>();
            //return View(categoryList);

            var category = _context.Categories.ToList();
            return View(category);
        }


        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DoCreate(Category category ,IFormFile file)
        //{
        //    string filePath = string.Empty;


        //    string fileName = Path.GetFileName(file.FileName);
        //    string fileExtension = Path.GetExtension(file.FileName);
        //    string newFileName = Guid.NewGuid().ToString() + fileExtension;
        //    filePath = Path.Combine(_hostEnviroment.WebRootPath, "CategoryImage", newFileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    if (category is not null)
        //    {
        //        category.Image = filePath;
        //        _context.Categories.Add(category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        System.IO.File.Delete(filePath);
        //        return Ok();
        //    }
        //}

        public async Task<IActionResult> DoCreate(Category category, IFormFile file)
        {
            string filePath = string.Empty;
            string fileRoot = string.Empty;
            if (file != null && file.Length > 0)
            {
              
                string fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(file.FileName);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;
                filePath = newFileName;
                fileRoot = Path.Combine(_hostEnviroment.WebRootPath, "CategoryImage", newFileName);
                using (var stream = new FileStream(fileRoot, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                if (category != null)
                {
                    category.Image = filePath;
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    System.IO.File.Delete(filePath);
                    return Ok();
                }
            }

            // Handle if no file was uploaded

            return View(category); // Return the view with the model to display validation errors or other details
        }





        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'SwordLmsContext.Category'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _context.Categories.Any(e => e.Id == id);
        }
    }
}
