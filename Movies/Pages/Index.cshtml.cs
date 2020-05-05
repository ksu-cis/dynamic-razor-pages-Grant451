using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        

        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        [BindProperty(SupportsGet =true)]
        public string[] MPAARatings { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerms { get; set; }

        /*
        /// <summary>
        /// The current search terms 
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        [BindProperty]
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty]
        public string[] Genres { get; set; }

        /// <summary>
        /// The minimum IMDB Rating
        /// </summary>
        [BindProperty]
        public double? IMDBMin { get; set; }

        /// <summary>
        /// The maximum IMDB Rating
        /// </summary>
        [BindProperty]
        public double? IMDBMax { get; set; }
        */

        public void OnGet(double? IMDBMin, double? IMDBMax)
        {
            /*
            MPAARatings = Request.Query["MPAARatings"];
            String terms = Request.Query["SearchTerms"];
            Movies = MovieDatabase.Search(SearchTerms);
            */
            //var MPAARatings = Request.Query["MPAARatings"];

            /*
            //SearchTerms = Request.Query["SearchTerms"];
            MPAARatings = Request.Query["MPAARatings"];
            //IMDBMin = double.Parse(Request.Query["IMDBMin"]);
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            
            */

            /*
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            */

            /*
            // Nullable conversion workaround
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            */

            //search movie titles for the search terms
            Movies = MovieDatabase.All;
            if (SearchTerms != null)
            {
                Movies = Movies.Where(movie => movie.Title != null && movie.Title.Contains(SearchTerms, StringComparison.CurrentCultureIgnoreCase));
                //.Select(movie => movie.Title)

                //Movies = from movie in Movies
                //where movie.Title != null && movie.Title.Contains(SearchTerms, StringComparison.CurrentCultureIgnoreCase)
                //select movie;
            }
            //filter by mpaa rating
            if(MPAARatings != null && MPAARatings.Length != 0)
            {
                Movies = Movies.Where(Movie => Movie.MPAARating != null && MPAARatings.Contains(Movie.MPAARating));
            }
        }
    }
}
