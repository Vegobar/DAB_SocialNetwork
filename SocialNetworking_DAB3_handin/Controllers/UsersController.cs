using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialNetworking_DAB3_handin.Data;
using SocialNetworking_DAB3_handin.Models;
using SocialNetworking_DAB3_handin.Repository;

namespace SocialNetworking_DAB3_handin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _dataAccessProvider = new UserseRespository();

        

        // GET: Users
        public async Task<IActionResult> Index()
        {
            IEnumerable<Users> user = await _dataAccessProvider.GetUsers();

            return View(user);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _dataAccessProvider.GetUsers(id);

            if (users == null)
            {
                return NotFound();
            }


            //This is a test to see if it was possible to unhash password for users when der need to login.
            if(BCrypt.Net.BCrypt.Verify("HejLena12332", users.Password))
            {
               return Content("Password is correct");
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Username,Email,Gender,Age,FollowId,CurrentFollowers")] Users users)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Add(users);
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _dataAccessProvider.GetUsers(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Password,Username,Email,Gender,Age,FollowId,CurrentFollowers")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _dataAccessProvider.Update(users);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _dataAccessProvider.GetUsers(id);

            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _dataAccessProvider.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
