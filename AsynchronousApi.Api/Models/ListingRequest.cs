namespace AsynchronousApi.Api.Models;

public record ListingRequest(int Id, string? RequestBody, DateTime? EstimatedCompletionTime, RequestStatus RequestStatus, Guid RequestId);