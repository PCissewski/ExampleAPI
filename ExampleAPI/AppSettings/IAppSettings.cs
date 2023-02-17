namespace ExampleAPI.AppSettings;

public interface IAppSettings
{
    string JwtSigningKey { get; }
}