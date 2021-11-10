using Microsoft.Extensions.DependencyInjection;
using MovieApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.API.StaticFiles
{
    class GetMoviesFromApiA
    {
        public static void GetMoviesFromApiAuto(IServiceProvider serviceProvider)
        {
            var movieService = serviceProvider.GetRequiredService<IMovieService>();
            string url = "https://api.themoviedb.org/3/movie/popular";
            string apiKey = "113287fcce86d993c720b63139ee4826";
            string language = "en-US";
            int pageNumber = 55;
            movieService.GetMoviesFromApi(url, apiKey, language, pageNumber);

        }
    }
}
