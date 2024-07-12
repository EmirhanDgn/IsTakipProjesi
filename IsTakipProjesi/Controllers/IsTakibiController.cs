using IsTakipProjesi.Data;
using IsTakipProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IsTakipProjesi.Controllers
{
    public class IsTakibiController : Controller
    {
        private readonly AppDbContext _context;

        public IsTakibiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Yeni()
        {
            ViewBag.Users = await _context.Users
                .OrderBy(u => u.FirstName)
                .Select(u => new { u.UserId, FullName = u.FirstName + " " + u.LastName, u.Username })
                .ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Yeni(TaskList task, string[] Uyeler, string[] Onaycilar)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserID");
                if (string.IsNullOrEmpty(userId))
                {
                    ModelState.AddModelError("", "Oturum süresi dolmuş veya geçersiz. Lütfen tekrar giriş yapın.");
                    return View(task);
                }

                task.CreateUserID = int.Parse(userId);
                task.OlusturmaTarihi = DateTime.Now;
                task.isDeleted = false;
                _context.TaskLists.Add(task);
                await _context.SaveChangesAsync();

                foreach (var user in Uyeler)
                {
                    _context.TaskMembers.Add(new TaskMember
                    {
                        TaskID = task.TaskID,
                        UserID = int.Parse(user),
                        OnayDurum = false,
                        IsDeleted = false
                    });
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Liste");
            }

            ViewBag.Users = await _context.Users
                .OrderBy(u => u.FirstName)
                .Select(u => new { u.UserId, FullName = u.FirstName + " " + u.LastName, u.Username })
                .ToListAsync();

            return View(task);
        }

        public async Task<IActionResult> Liste()
        {
            var currentUserStr = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(currentUserStr) || !int.TryParse(currentUserStr, out var currentUser))
            {
                return RedirectToAction("Index", "Auth");
            }

            var tasks = await _context.TaskLists
                .Include(t => t.TaskMembers)
                .Where(t => !t.isDeleted)
                .OrderByDescending(t => t.OlusturmaTarihi)
                .Take(30)
                .ToListAsync();

            var filteredTasks = tasks
                .Where(t => t.CreateUserID == currentUser || t.TaskMembers.Any(m => m.UserID == currentUser))
                .ToList();

            return View(filteredTasks);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var task = await _context.TaskLists
         .Include(t => t.TaskMembers)
         .Include(t => t.Comments)
             .ThenInclude(c => c.User)
         .FirstOrDefaultAsync(t => t.TaskID == id && t.isDeleted == false);

            if (task == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(currentUser))
            {
                return RedirectToAction("Index", "Auth");
            }

            ViewBag.CurrentUser = currentUser;
            ViewBag.Users = await _context.Users
                .Select(u => new { u.UserId, FullName = u.FirstName + " " + u.LastName, u.Username })
                .ToListAsync();

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> YorumEkle(int TaskID, string editorContent)
        {
            var currentUser = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(currentUser))
            {
                return RedirectToAction("Index", "Auth");
            }

            var comment = new TaskComment
            {
                TaskID = TaskID,
                UserID = int.Parse(currentUser),
                Comment = editorContent,
                Datetime = DateTime.Now,
                IsDeleted = false
            };

            _context.TaskComments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Detay", new { id = TaskID });
        }

        [HttpPost]
        public async Task<IActionResult> DurumDegistir(int TaskID, string inputStatus)
        {
            var task = await _context.TaskLists.FindAsync(TaskID);
            if (task == null)
            {
                return NotFound();
            }

            task.Durum = inputStatus;
            _context.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Detay", new { id = TaskID });
        }

       
    }
}
