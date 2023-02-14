using Bakerbots.Configuration;
using Bakerbots.Data;
using Bakerbots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakerbots.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public UserRolesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: UserRoles
        //Obtener todos los roles
        public async Task<ActionResult<UserRole>> Index()
        {
            return View(await _unitOfWork.UserRoleRepository.GetAllAsync());
        }

        // GET: UserRoles/Details/5
        public async Task<ActionResult<UserRole>> Details(int id)
        {

            var rol = await _unitOfWork.UserRoleRepository.GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: UserRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserRole>> Create([Bind("Id,UserRole_Name")] UserRole rol)
        {

            _unitOfWork.UserRoleRepository.Add(rol);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));

        }

        // GET: UserRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var rol = await _context.UserRole.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: UserRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserRole_Name")] UserRole rol)
        {
            if (id != rol.Id)
            {
                return NotFound();
            }

            _unitOfWork.UserRoleRepository.Update(rol);
            try
            {

                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));


        }

        // GET: UserRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var rol = await _context.UserRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: UserRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserRole == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserRole'  is null.");
            }

            _unitOfWork.UserRoleRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool RolExists(int id)
        {
            return _context.UserRole.Any(e => e.Id == id);
        }
    }
}
