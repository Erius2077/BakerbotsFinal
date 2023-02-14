using Bakerbots.Configuration;
using Bakerbots.Data;
using Bakerbots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bakerbots.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Users
        public async Task<ActionResult<User>> Index()
        {

            return View(await _unitOfWork.UserRepository.GetAllAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "UserRole_Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User_Name,Role_ID,User_Email,User_Password")] User user)
        {

            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RolId"] = new SelectList(_context.UserRole, "Id", "UserRole_Name", user.Role_ID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User_Name,Role_ID,User_Email,User_Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
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

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ExamenEasyShopContext.User'  is null.");
            }

            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _unitOfWork.UserRepository.GetByIdAsync(id) != null;
        }
    }
}
