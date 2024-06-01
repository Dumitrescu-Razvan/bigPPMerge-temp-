using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Controllers
{
    public class NotificationsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUserRepo _userRepo;
        private readonly INotificationRepo _notificationRepo;

        public NotificationsController(IUserRepo userRepo, INotificationRepo notificationRepo)
        {
            _userRepo = userRepo;
            _notificationRepo = notificationRepo;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var notifications = _notificationRepo.GetAll();
            return View(notifications);
            //return View(await _context.Notifications.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = _notificationRepo.GetById(id.Value);
            /*var notification = await _context.Notifications
                .FirstOrDefaultAsync(m => m.notificationId == id);*/
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("notificationId,userId,activity,timestamp,details,isRead")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _notificationRepo.Add(notification);
                //_context.Add(notification);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = _notificationRepo.GetById(id.Value);
            //var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("notificationId,userId,activity,timestamp,details,isRead")] Notification notification)
        {
            if (id != notification.notificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _notificationRepo.Update(notification);
                    //_context.Update(notification);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.notificationId))
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
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = _notificationRepo.GetById(id.Value);
            //var notification = await _context.Notifications
            //    .FirstOrDefaultAsync(m => m.notificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notification = _notificationRepo.GetById(id);
            //var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _notificationRepo.Delete(id);
                //_context.Notifications.Remove(notification);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
            return _notificationRepo.GetAll().Any(e => e.notificationId == id);
            //return _context.Notifications.Any(e => e.notificationId == id);
        }
    }
}
