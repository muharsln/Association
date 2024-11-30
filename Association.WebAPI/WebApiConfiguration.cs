namespace Association.WebAPI;
public record WebApiConfiguration(string ApiDomain, string[] AllowedOrigins)
{
    public WebApiConfiguration() : this(string.Empty, []) { }
}
