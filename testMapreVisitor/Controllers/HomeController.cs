using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testMapreVisitor.DbContext;
using testMapreVisitor.Models;
using testMapreVisitor.ViewModel;

namespace testMapreVisitor.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        private readonly testMapreDbContext mapreDbContext;

        public HomeController(testMapreDbContext testMapreDbContext)
        {
            this.mapreDbContext = testMapreDbContext;
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var admin = await mapreDbContext.UserRoles.ToListAsync();

            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var visitor = await mapreDbContext.visitors.ToListAsync();
            return View(visitor);
        }

        [AllowAnonymous]
        public IActionResult Add()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(AddVisitorViewModel addVisitorRequest)
        {
            var visitor = new Visitor()
            {
                Id = Guid.NewGuid(),
                Name = addVisitorRequest.Name,
                LastName = addVisitorRequest.LastName,
                Phone = addVisitorRequest.Phone,
                Mail = addVisitorRequest.Mail,
                DateVisit = addVisitorRequest.DateVisit,
            };

            await mapreDbContext.visitors.AddAsync(visitor);
            await mapreDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }

        [AllowAnonymous]
        public async Task<IActionResult> Edit(Guid id)
        {
            var visitor = await mapreDbContext.visitors.FirstOrDefaultAsync(x => x.Id == id);

            if (visitor != null)
            {
                var visitorModel = new UpdateVisitorViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = visitor.Name,
                    LastName = visitor.LastName,
                    Phone = visitor.Phone,
                    Mail = visitor.Mail,
                    DateVisit = visitor.DateVisit,
                };

                return await Task.Run(() => View("Edit", visitorModel));

            }
            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateVisitorViewModel model)
        {
            var visitor = await mapreDbContext.visitors.FindAsync(model.Id);
            if (visitor != null)
            {
                visitor.Name = model.Name;
                visitor.LastName = model.LastName;
                visitor.Phone = model.Phone;
                visitor.Mail = model.Mail;
                visitor.DateVisit = model.DateVisit;

                await mapreDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction($"Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Delete(UpdateVisitorViewModel model)
        {
            var visitor = await mapreDbContext.visitors.FindAsync(model.Id);

            if (visitor != null)
            {
                mapreDbContext.visitors.Remove(visitor);
                await mapreDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}