LTunes.Lib.ApiVersion
============


### LTunes.Lib.ApiVersion nedir?

Api uygulamalarında, özellikle kullanımda olan servis (endpoint) adreslerinde yapılacak değişikliklerden, servisi tüketen projelerin etkilenmemesi amacıyla servislerin versiyonlanması için oluşturulmuş kütüphanedir.

### Nasıl  projeye eklenir?

- libs/apiversion klasörü içindeki LTunes.Lib.ApiVersion kütüphanesini projenize eklemelisiniz.
- Container'a gerekli kayıtları (AddApiVersioningWithProvider) yapmalısınız. Kayıt ederken oluşturmuş olduğunuz provider sınıfı varsa metot parametresi olarak bildirmelisiniz.
- Kütüphaneyi projesinize ekledikten sonra ihtiyaçlarınıza göre kütüphane kodlarında gerekli düzenlemeleri gerçekleştirebilirsiniz.

```csharp

public void ConfigureServices(IServiceCollection services)
{
	services.AddApiVersioningWithProvider();
}

```
- Rota ayarlarınızı kurguladığınız yerde VersionConfigurations.cs sınıfı yardımıyla oluşturabilirsiniz. Versiyonlama ayarlarına aşağıdaki gibi ulaşabilirsiniz.

```csharp
[Route(RouteSchema.WithAction)]
[ApiVersion(VersionNo.V1)]
[ApiVersion(VersionNo.V1S2)]
public class BaseApiController : ControllerBase
{
}

public class Class
{
	private readonly IApiVersionSetting _apiVersionSetting;
	
	public Class(IApiVersionSetting apiversionSetting)
	{
		_apiVersionSetting = apiversionSetting;
	}
	
	public void Metot()
	{
		int majorVersion = _apiVersionSetting.MajorVersion;
	}
}
```
- VersionConfiguration.cs sınıfı

```csharp
public static class VersionNo
{
    public const string V1 = "1.0";
    public const string V1S2 = "1.2";
    public const string V2 = "2.0";
    public const string V2S4 = "2.4";
    public const string V3 = "3.0";
    public const string V3S7 = "3.7";
}

public static class RouteSchema
{
    public const string Versioned = "api/v{version:apiVersion}/[controller]/[action]";
    public const string Standart = "api/v1/[controller]/[action]";
    public const string WithAction = "api/[controller]/[action]";
    public const string WithoutAction = "api/v1/[controller]";
}
```
