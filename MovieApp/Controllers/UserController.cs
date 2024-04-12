
/*In Entity Framework Core, when you execute a 
 * LINQ query against the database, the default return type is an IEnumerable<T> (or IQueryable<T> in some cases). 
 */



/*TODO: CRUD
 * 
 * C-Create users - SignUp
 * R-Read(retrive) users
 * U-Update users
 * D-Delete users
 * LogIn
 
 */
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace MovieApp.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly WatchListContext _dbContext;

        public UserController(ILogger<UserController> logger, WatchListContext watchListContext)
        {
            _logger = logger;
            _dbContext = watchListContext;
        }




        //GET - Read
        //retrive all users
        [HttpGet(Name = "GetUsers")]
       

        public List<UserResponse> GetAll()
        {

            var query = _dbContext.Users.ToQueryString();
            Console.WriteLine(query);

            return _dbContext.Users.ToList().Select(user => new UserResponse { 
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            }).ToList();
        }

        //retrive a user
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var user = _dbContext.Users.FirstOrDefault(user => user.Id == id);
            var query = _dbContext.Users.Where(u => u.Id == id).ToQueryString();
            Console.WriteLine(query);

            if (user == null) {
                return NotFound();
            }

            return Ok( new UserResponse { 
                Id= user.Id,
                UserName= user.UserName,
                Email= user.Email,
                CreatedAt= user.CreatedAt,

            });
        }


        //POST - Create
        [HttpPost]
        public UserResponse Create([FromBody] UserCreateRequest request) {

            var user = new User
            {
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = request.PasswordHash,
                CreatedAt = DateTime.UtcNow
            };
            
            //TODO password hash:
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return new UserResponse { 
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }


        //PUT - Update
        [HttpPut("{id}")]

        public User Update(int id)
        {
            return new User();
        }


        //DELETE
        [HttpDelete("{id}")]

        public void Delete(int id)
        {

        }




    }

    
}

public class UserCreateRequest {
    
    public string? Email { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

   
}

public class UserResponse {

    public int Id { get; set; }
    public string? Email { get; set; }

    public string? UserName { get; set; }

    public DateTime? CreatedAt { get; set; }

}


