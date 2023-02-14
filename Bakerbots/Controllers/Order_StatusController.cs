using Bakerbots.Configuration;
using Bakerbots.Data;
using Bakerbots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakerbots.Controllers
{
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public StatusController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Order_Status
        public async Task<ActionResult<Order_Status>> Index()
        {
            return View(await _unitOfWork.Order_StatusRepository.GetAllAsync());
        }

        // GET: Order_Status/Details/5
        public async Task<ActionResult<Order_Status>> Details(int id)
        {


            var status = await _unitOfWork.Order_StatusRepository.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Order_Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order_Status_Description")] Order_Status status)
        {

            _unitOfWork.Order_StatusRepository.Add(status);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: Order_Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order_Status == null)
            {
                return NotFound();
            }

            var status = await _context.Order_Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Order_Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order_Status_Description")] Order_Status status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            _unitOfWork.Order_StatusRepository.Update(status);
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

        // GET: Order_Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order_Status == null)
            {
                return NotFound();
            }

            var status = await _context.Order_Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order_Status == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Status'  is null.");
            }
            _unitOfWork.Order_StatusRepository.Delete(id);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }

        private bool Order_StatusExists(int id)
        {
            return _context.Order_Status.Any(e => e.Id == id);
        }
    }
}
