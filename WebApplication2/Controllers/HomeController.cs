using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abstracts;
using Model;
using Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        #region Services
        private readonly ISearchService _SearchService;
        

        #endregion

        #region Constructor
        public HomeController()
        {
            _SearchService = new SearchService();
            
        }
        #endregion
        #region Actions
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCities(string CityName)
        {
            var CitiesList = _SearchService.SearchCity(CityName);
            return Json(CitiesList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            List<ClientVm> Clientlist = new List<ClientVm>()
            {
                //teacher
                new ClientVm() {Key =1 ,Name = "ahmed ali", Email = "ahmedalali@teacher.com", type = 1},
                new ClientVm() {Key =2 ,Name = "mohamed ali", Email = "mohamesalali@teacher.com", type = 1},
                new ClientVm() {Key =3 ,Name = "asraf ali", Email = "asraflali@teacher.com", type = 1},
                new ClientVm() {Key =4 ,Name = "hossam ali", Email = "hossamalali@teacher.com", type = 1},
                //student
                new ClientVm() {Key =5 ,Name = "ali ayman", Email = "aliayman@student.com", type = 2},
                new ClientVm() {Key =6 ,Name = "hosam ayman", Email = "hosamayman@student.com", type = 2},
                new ClientVm() {Key =7 ,Name = "hessan ayman", Email = "hessanayman@student.com", type = 2},
                new ClientVm() {Key =8 ,Name = "basyony ayman", Email = "basyonyayman@student.com", type = 2},
                new ClientVm() {Key =9 ,Name = "hatem ayman", Email = "hatemayman@student.com", type = 2}

            };
            List<string> CourseList = new List<string>()
                { "Arabic" ,"Math","Program","Englis","CCna"};

            ViewBag.AllClient = Clientlist.ToList();
            ViewBag.StudentList = Clientlist.Where(a => a.type == 2).ToList();
            ViewBag.teacherList = Clientlist.Where(a => a.type == 1).ToList();
            ViewBag.courseList = CourseList.ToList();
            return View();
        }
        #endregion
    }
}