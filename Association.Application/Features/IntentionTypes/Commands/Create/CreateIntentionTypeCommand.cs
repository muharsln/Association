using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Create;
public class CreateIntentionTypeCommand : IRequest<CreatedIntentionTypeResponse>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public CreateIntentionTypeCommand()
    {
        Name = string.Empty;
        IsActive = true;
    }

    public CreateIntentionTypeCommand(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }
}
