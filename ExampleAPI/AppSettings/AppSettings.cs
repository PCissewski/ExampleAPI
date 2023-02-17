using System.ComponentModel.DataAnnotations;

namespace ExampleAPI.AppSettings;

public class AppSettings : IAppSettings
{
    [Required] public string JwtSigningKey { get; } = "safdkjha5sadafjghfjhtrdrkhfasd67fsdajhlsdha9df";
}