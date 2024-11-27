namespace Association.Application.Features.DonationOptions.Commands.Create;
public record CreatedDonationOptionResponse(
    int Sequence, 
    string Name, 
    decimal Price
);
