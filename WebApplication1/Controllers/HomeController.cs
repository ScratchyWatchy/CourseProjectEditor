using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Save(UserDiagram diagram)
        {
            var localDiagram = _applicationDbContext.UserDiagramsDbSet.FirstOrDefault(x => x.Name == diagram.Name && x.UserId == diagram.UserId);
            if (localDiagram != null)
            {
                localDiagram.Data = diagram.Data;
                _applicationDbContext.UserDiagramsDbSet.Update(localDiagram);
            }
            else
            {
                _applicationDbContext.UserDiagramsDbSet.Add(diagram);
            }
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult List()
        {
            var myProjects = _applicationDbContext.UserDiagramsDbSet.Where(x => x.UserId == _userManager.GetUserId(User));
            return View(myProjects);
        }

        public IActionResult Edit(string Id)
        {
            var myProject = _applicationDbContext.UserDiagramsDbSet.FirstOrDefault(x => x.UserId == _userManager.GetUserId(User) && x.Id == Id);
            return View(myProject);
        }

        public RedirectToActionResult Create(string name)
        {
            UserDiagram temp = new UserDiagram();
            temp.UserId = _userManager.GetUserId(User);
            temp.Name = name;

            temp.Data =
                "{ \"class\": \"GraphLinksModel\",\r\n  \"linkFromPortIdProperty\": \"fromPort\",\r\n  \"linkToPortIdProperty\": \"toPort\",\r\n  \"nodeDataArray\": [ \r\n{\"category\":\"one\", \"key\":-10, \"loc\":\"-330 -160\", \"data\":\"6\"},\r\n{\"category\":\"add\", \"key\":-11, \"loc\":\"-200 -100\"},\r\n{\"category\":\"one\", \"key\":-9, \"loc\":\"-360 -70\", \"data\":\"5\"},\r\n{\"category\":\"output\", \"key\":-2, \"loc\":\"-90 -110\", \"data\":\"11\"}\r\n ],\r\n  \"linkDataArray\": [ \r\n{\"from\":-10, \"to\":-11, \"fromPort\":\"\", \"toPort\":\"in1\"},\r\n{\"from\":-9, \"to\":-11, \"fromPort\":\"\", \"toPort\":\"in2\"},\r\n{\"from\":-11, \"to\":-2, \"fromPort\":\"out\", \"toPort\":\"\"}\r\n ]}";

            _applicationDbContext.UserDiagramsDbSet.Add(temp);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Edit", "Home", new {Id = temp.Id});
        }
    }
}
