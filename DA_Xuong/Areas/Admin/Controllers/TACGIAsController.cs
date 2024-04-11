using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA_Xuong.Database;
using DA_Xuong.Models;

namespace DA_Xuong.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TACGIAsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TACGIAsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/TACGIAs
        public async Task<IActionResult> Index()
        {
              return _context.TACGIA != null ? 
                          View(await _context.TACGIA.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.TACGIA'  is null.");
        }

        // GET: Admin/TACGIAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TACGIA == null)
            {
                return NotFound();
            }

            var tACGIA = await _context.TACGIA
                .FirstOrDefaultAsync(m => m.IDTACGIA == id);
            if (tACGIA == null)
            {
                return NotFound();
            }

            return View(tACGIA);
        }

        // GET: Admin/TACGIAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TACGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDTACGIA,TENTACGIA,TIEUSU")] TACGIA tACGIA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tACGIA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tACGIA);
        }

        // GET: Admin/TACGIAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TACGIA == null)
            {
                return NotFound();
            }

            var tACGIA = await _context.TACGIA.FindAsync(id);
            if (tACGIA == null)
            {
                return NotFound();
            }
            return View(tACGIA);
        }

        // POST: Admin/TACGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDTACGIA,TENTACGIA,TIEUSU")] TACGIA tACGIA)
        {
            if (id != tACGIA.IDTACGIA)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tACGIA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TACGIAExists(tACGIA.IDTACGIA))
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
            return View(tACGIA);
        }

        // GET: Admin/TACGIAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TACGIA == null)
            {
                return NotFound();
            }

            var tACGIA = await _context.TACGIA
                .FirstOrDefaultAsync(m => m.IDTACGIA == id);
            if (tACGIA == null)
            {
                return NotFound();
            }

            return View(tACGIA);
        }

        // POST: Admin/TACGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TACGIA == null)
            {
                return Problem("Entity set 'ApplicationDBContext.TACGIA'  is null.");
            }
            var tACGIA = await _context.TACGIA.FindAsync(id);
            if (tACGIA != null)
            {
                _context.TACGIA.Remove(tACGIA);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TACGIAExists(int id)
        {
          return (_context.TACGIA?.Any(e => e.IDTACGIA == id)).GetValueOrDefault();
        }
    }
}
