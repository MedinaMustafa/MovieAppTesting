/*TODO: 
 * get user's watchlist
 * remove a movie from the watchlist
 * 
 * 
 * api/watchlists/{user_id}
 */



using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;



namespace MovieApp.Controllers
{

    [ApiController]
    [Route("/ApiBehaviorOptions/WatchList")]
    public class WatchListController : ControllerBase
    {
        private readonly ILogger<WatchListController> _logger;
        public WatchListController(ILogger<WatchListController> logger) {
            _logger = logger;   
        }


        //GET
        [HttpGet("{userId}")]

        public IEnumerable<WatchList> Get(int userId) {

            return Enumerable.Empty<WatchList>();
        }


        //POST
        [HttpPost]

        public WatchList Create(int userId, int movieId) {
            return new WatchList();
        }



        //DELETE
        [HttpDelete("{id}")]
        public void Delete(int userId)
        {

        }





    }
}
