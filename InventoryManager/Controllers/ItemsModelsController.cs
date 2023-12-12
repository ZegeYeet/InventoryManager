using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManager.Data;
using InventoryManager.Models;

namespace InventoryManager.Controllers
{
    public class ItemsModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemsModels
        public async Task<IActionResult> Index()
        {
              return _context.ItemsModel != null ? 
                          View(await _context.ItemsModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ItemsModel'  is null.");
        }

        // GET: ItemsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemsModel == null)
            {
                return NotFound();
            }

            var itemsModel = await _context.ItemsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsModel == null)
            {
                return NotFound();
            }

            return View(itemsModel);
        }

        // GET: ItemsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Manufacturer,Price,Description")] ItemsModel itemsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemsModel);
        }

        // GET: ItemsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemsModel == null)
            {
                return NotFound();
            }

            var itemsModel = await _context.ItemsModel.FindAsync(id);
            if (itemsModel == null)
            {
                return NotFound();
            }
            return View(itemsModel);
        }

        // POST: ItemsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manufacturer,Price,Description")] ItemsModel itemsModel)
        {
            if (id != itemsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsModelExists(itemsModel.Id))
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
            return View(itemsModel);
        }

        // GET: ItemsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemsModel == null)
            {
                return NotFound();
            }

            var itemsModel = await _context.ItemsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsModel == null)
            {
                return NotFound();
            }

            return View(itemsModel);
        }

        // POST: ItemsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemsModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItemsModel'  is null.");
            }
            var itemsModel = await _context.ItemsModel.FindAsync(id);
            if (itemsModel != null)
            {
                _context.ItemsModel.Remove(itemsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsModelExists(int id)
        {
          return (_context.ItemsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
