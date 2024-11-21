namespace Association.Application.Features.IntentionTypes.Commands.Create;

public class CreatedIntentionTypeResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
