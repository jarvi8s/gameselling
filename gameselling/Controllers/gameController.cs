using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gameselling.Models;


namespace gameselling.Controllers
{
    public class gameController : Controller
    {

        private static IEnumerable<game> games = new List<game>
        {
            new game(1,"fifa21",210,"game"),
            new game(2,"cyberpunk2077",190,"game"),
            new game(3,"nba2k21",200,"game"),
            new game(4,"witcher3",100,"game"),
             new game(5,"Doom",130,"game"),
              new game(6,"Gamepad",100,"furniture"),
               new game(7,"Gamer Mouse",100,"furniture"),
                new game(8,"GamerKeyboard",100,"furniture")

        };
        //   games=GameMapper.GetAll();
        // GETt: game
        public void qwe()

        {

            for (int i = 0; i < 5; i++)
            {
                string msg = "gameinfo" + i.ToString();

            }
        }
        public ActionResult Index(string sortOrder)
        { 
            IEnumerable<game> gams;
            ViewBag.NextSortOrder = sortOrder==null||sortOrder=="descending"?"ascending":"descending";
            switch(sortOrder)
            {
                case "ascending":
                    gams = games.OrderBy(game => game.Title);
                    break;
                case "descending":
                    gams = games.OrderByDescending(game => game.Title);
                    break;
                default:
                    gams = games;
                    break;
            }
            return View(gams);
        }
        // POST: game
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string searchString = collection["searchString"];
             ViewBag.currentSearchString = searchString;
           
            var gams = games.Where(game => game.Title.Contains(searchString));
            return View(gams);
        }
 
         // GET: game/Details/5
        public ActionResult Details(int id)
        {
            return View(games);
        }

        // GET: game/Create
        public ActionResult Create(int id)
        {
            var game = games.Single(obj => obj.GameId == id);
            return View();
        }

        // POST: game/Create
        [HttpPost]
        public ActionResult Create(int id,FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                games.Single(obj => obj.GameId == id).Title = collection["Title"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: game/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var game = games.Single(obj => obj.GameId == id);
            return View();
        }

        // POST: game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                games.Single(obj=>obj.GameId == id).Title = collection["Title"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: game/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
