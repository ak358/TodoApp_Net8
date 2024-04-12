using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApp_Net8.Data;
using TodoApp_Net8.Models;
using TodoApp_Net8.Models.ViewModels;

namespace TodoApp_Net8.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users.Include(u => u.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["RoleName"] = new SelectList(_context.Roles, "RoleName", "RoleName");
            return View();
        }

        //[???]

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,RoleName")] UserViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                Role role = new();
                role = await _context.Roles.Include(r => r.Users).
                    FirstOrDefaultAsync(r => r.RoleName == UserViewModel.RoleName);
                
                if(role != null)
                {
                    User user = new User
                    {
                        UserName = UserViewModel.UserName,
                        Password = UserViewModel.Password,
                        Role = role,
                        RoleId = role.Id
                    };

                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "登録しました。ログインしてください。";
                    return RedirectToAction("Login", "Login");
                }
            }
            ViewData["RoleName"] = new SelectList(_context.Roles, "RoleName", "RoleName");
            return View(UserViewModel);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,RoleId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
