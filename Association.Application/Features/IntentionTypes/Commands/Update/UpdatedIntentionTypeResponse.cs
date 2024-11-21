namespace Association.Application.Features.IntentionTypes.Commands.Update;

public class UpdatedIntentionTypeResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
