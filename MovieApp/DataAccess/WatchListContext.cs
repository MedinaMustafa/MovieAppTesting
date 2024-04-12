using System;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
namespace MovieApp.DataAccess
{
	public class WatchListContext : DbContext
	{
		public WatchListContext(DbContextOptions<WatchListContext> options) : base(options)
        {

		}


		public DbSet<User> Users { get; set; }
		public DbSet<WatchList> WatchLists { get; set; }	


	}
}