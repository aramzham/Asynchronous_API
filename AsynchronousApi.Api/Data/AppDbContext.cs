using AsynchronousApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AsynchronousApi.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();
}