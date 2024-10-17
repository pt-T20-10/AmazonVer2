using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmazonWebsite.Areas.Admin.Models;

namespace AmazonWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDelegationController : Controller
    {
        private readonly AmazonContext _context;

        public AdminDelegationController(AmazonContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDelegation
        public async Task<IActionResult> Index()
        {
            var amazonContext = _context.Delegations.Include(d => d.Department).Include(d => d.Staff);
            return View(await amazonContext.ToListAsync());
        }

        // GET: Admin/AdminDelegation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delegation = await _context.Delegations
                .Include(d => d.Department)
                .Include(d => d.Staff)
                .FirstOrDefaultAsync(m => m.DelegationId == id);
            if (delegation == null)
            {
                return NotFound();
            }

            return View(delegation);
        }

        // GET: Admin/AdminDelegation/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId");
            return View();
        }

        // POST: Admin/AdminDelegation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DelegationId,StaffId,DepartmentId,DelegationDate,Validation")] Delegation delegation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delegation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", delegation.DepartmentId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", delegation.StaffId);
            return View(delegation);
        }

        // GET: Admin/AdminDelegation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delegation = await _context.Delegations.FindAsync(id);
            if (delegation == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", delegation.DepartmentId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", delegation.StaffId);
            return View(delegation);
        }

        // POST: Admin/AdminDelegation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DelegationId,StaffId,DepartmentId,DelegationDate,Validation")] Delegation delegation)
        {
            if (id != delegation.DelegationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delegation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelegationExists(delegation.DelegationId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", delegation.DepartmentId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", delegation.StaffId);
            return View(delegation);
        }

        // GET: Admin/AdminDelegation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delegation = await _context.Delegations
                .Include(d => d.Department)
                .Include(d => d.Staff)
                .FirstOrDefaultAsync(m => m.DelegationId == id);
            if (delegation == null)
            {
                return NotFound();
            }

            return View(delegation);
        }

        // POST: Admin/AdminDelegation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delegation = await _context.Delegations.FindAsync(id);
            if (delegation != null)
            {
                _context.Delegations.Remove(delegation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DelegationExists(int id)
        {
            return _context.Delegations.Any(e => e.DelegationId == id);
        }
    }
}
