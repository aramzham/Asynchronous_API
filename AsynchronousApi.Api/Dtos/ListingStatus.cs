namespace AsynchronousApi.Api.Dtos;

public record ListingStatus(RequestStatus? RequestStatus, DateTime? EstimatedCompletionTime, string? ResourceUrl);