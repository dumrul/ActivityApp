namespace ETAP.Application.DTOs.Activities
{
public class CreateActivityRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;

    public int Category { get; set; }
    public Guid OrganizationId { get; set; }
    public Guid OrganizerId { get; set; }
}
}