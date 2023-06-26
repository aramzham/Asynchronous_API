using AsynchronousApi.Api;
using AsynchronousApi.Api.Data;
using AsynchronousApi.Api.Dtos;
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

// status endpoint
app.MapGet("/api/productstatus/{requestId:guid}", async (AppDbContext db, Guid requestId) =>
{
    var listingRequest = await db.ListingRequests.FirstOrDefaultAsync(x => x.RequestId == requestId);
    if (listingRequest is null)
        return Results.NotFound();

    var listingStatus = new ListingStatus(listingRequest.RequestStatus, null, string.Empty);

    return listingRequest.RequestStatus == RequestStatus.Completed
    // if completed => return url to the product
        ? Results.Redirect($"https://localhost:7205/api/products/{Guid.NewGuid()}")
    // if not => return the estimated completion time
        : Results.Ok(listingStatus with
        {
            EstimatedCompletionTime = DateTime.Now.AddHours(1)
        });
});

// final endpoint
app.MapGet("/api/products/{requestId:guid}", async (AppDbContext db, Guid requestId) =>
{
    return Results.Ok($"this is where you would pass back the final result for request id = {requestId}");
});

app.UseHttpsRedirection();

app.Run();