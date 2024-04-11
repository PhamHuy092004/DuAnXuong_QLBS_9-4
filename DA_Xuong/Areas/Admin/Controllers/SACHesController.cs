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
    public class SACHesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SACHesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Admin/SACHes
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.SACH.Include(s => s.TacGia);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Admin/SACHes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SACH == null)
            {
                return NotFound();
            }

            var sACH = await _context.SACH
                .Include(s => s.TacGia)
                .FirstOrDefaultAsync(m => m.IDSACH == id);
            if (sACH == null)
            {
                return NotFound();
            }

            return View(sACH);
        }

        // GET: Admin/SACHes/Create
        public IActionResult Create()
        {
            ViewData["IDTACGIA"] = new SelectList(_context.TACGIA, "IDTACGIA", "IDTACGIA");
            return View();
        }

        // POST: Admin/SACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSACH,TIEUDE,IDTACGIA,GIA,NGAYXUATBAN,MOTA,SOLUONG,TRANGTHAI,HINHANH")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sACH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDTACGIA"] = new SelectList(_context.TACGIA, "IDTACGIA", "IDTACGIA", sACH.IDTACGIA);
            return View(sACH);
        }

        // GET: Admin/SACHes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SACH == null)
            {
                return NotFound();
            }

            var sACH = await _context.SACH.FindAsync(id);
            if (sACH == null)
            {
                return NotFound();
            }
            ViewData["IDTACGIA"] = new SelectList(_context.TACGIA, "IDTACGIA", "IDTACGIA", sACH.IDTACGIA);
            return View(sACH);
        }

        // POST: Admin/SACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDSACH,TIEUDE,IDTACGIA,GIA,NGAYXUATBAN,MOTA,SOLUONG,TRANGTHAI,HINHANH")] SACH sACH)
        {
            if (id != sACH.IDSACH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sACH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SACHExists(sACH.IDSACH))
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
            ViewData["IDTACGIA"] = new SelectList(_context.TACGIA, "IDTACGIA", "IDTACGIA", sACH.IDTACGIA);
            return View(sACH);
        }

        // GET: Admin/SACHes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SACH == null)
            {
                return NotFound();
            }

            var sACH = await _context.SACH
                .Include(s => s.TacGia)
                .FirstOrDefaultAsync(m => m.IDSACH == id);
            if (sACH == null)
            {
                return NotFound();
            }

            return View(sACH);
        }

        // POST: Admin/SACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SACH == null)
            {
                return Problem("Entity set 'ApplicationDBContext.SACH'  is null.");
            }
            var sACH = await _context.SACH.FindAsync(id);
            if (sACH != null)
            {
                _context.SACH.Remove(sACH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SACHExists(int id)
        {
          return (_context.SACH?.Any(e => e.IDSACH == id)).GetValueOrDefault();
        }
    }
}
