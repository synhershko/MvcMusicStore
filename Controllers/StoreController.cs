//-----------------------------------------------------------------------
// <copyright file="StoreController.cs" company="Hibernating Rhinos LTD">
//     Copyright (c) Hibernating Rhinos LTD. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
using Raven.Client;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IDocumentSession session = MvcApplication.CurrentSession;

        //
        // GET: /Store/

        public ActionResult Index()
        {
            // Retrieve list of Genres from database
            var genres = GetGenres();

            // Set up our ViewModel
            var viewModel = new StoreIndexViewModel
            {
                Genres = genres,
                NumberOfGenres = genres.Length
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/Browse?Genre=Disco

        public ActionResult Browse(string id)
        {
            // Retrieve Genre from database
            var genre = session.Load<Genre>(id);
            var albums = session.Query<Album>().Where(x => id.Equals(x.Genre.Name)).ToArray();
            var viewModel = new StoreBrowseViewModel
            {
                Genre = genre,
                Albums = albums
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(string id)
        {
            return View(session.Load<Album>(id));
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            return View(GetGenres());
        }

        private Genre[] GetGenres()
        {
            return session.Advanced.LuceneQuery<Genre>().ToArray();
        }
    }
}
