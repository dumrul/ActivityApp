namespace ETAP.Application.DTOs.Activities
{
public class ActivityDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public string OrganizationName { get; set; } = string.Empty;
    public string OrganizerFullName { get; set; } = string.Empty;
}
}