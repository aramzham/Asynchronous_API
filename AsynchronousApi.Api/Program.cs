using AsynchronousApi.Api;
using AsynchronousApi.Api.Data;
using AsynchronousApi.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppDbContext>(o => o.UseSqlite("Data Source=RequestDb.db"));

var app = builder.Build();

// start endpoint
app.MapPost("/api/products", async (AppDbContext db, ListingRequest? listingRequest) =>
{
    if (listingRequest is null)
        return Results.BadRequest();

    var response = listingRequest with
    {
        RequestStatus = RequestStatus.Accepted,
        EstimatedCompletionTime = DateTime.Now.AddHours(1)
    };
    
    await db.AddAsync(response);
    await db.SaveChangesAsync();
    
    return Results.Accepted($"api/productstatus/{response.RequestId}", response);
});

app.UseHttpsRedirection();

app.Run();