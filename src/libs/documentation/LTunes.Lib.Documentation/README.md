LTunes.Lib.Documentation
============


### LTunes.Lib.Documentation nedir?

Api uygulamalarında oluşturulan servis (endpoint) adreslerinin okunaklı ve client-side çalışan takım arkadaşların işini kolaylaştırması için oluşturulmuş dokümantasyon kütüphanesidir. 

### Nasıl  projeye eklenir?

- libs/documentation klasörü içindeki LTunes.Lib.Documentation kütüphanesini projenize eklemelisiniz.
- Container'a gerekli kayıtları (AddSwagger) yapmalısınız. Kayıt ederken hangi güvenlik yöntemini kullandığınızı metot parametresi olarak bildirmelisiniz. Örn: JWT, Basic Auth
- Container'a kayıt yaptıysanız middleware (ara katman) olarak UseSwaggerConfiguration metotunu tanıtmalısınız. Tanıtırken kullanılan sınıf şemalarını görünür kılıp kılmayacağınızı metot parametresi olarak bildirmelisiniz.
- Kütüphaneyi projesinize ekledikten sonra ihtiyaçlarınıza göre kütüphane kodlarında gerekli düzenlemeleri gerçekleştirebilirsiniz.

```csharp

public void ConfigureServices(IServiceCollection services)
{
	services.AddSwagger();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	app.UseSwaggerConfiguration();
	app.UseRedoclyConfiguration();
}
```
- Swagger ayarlarını istediğiniz sınıfta, interface aracılığıyla aşağıdaki gibi kullanabilirsiniz.

```csharp
 public class Class
{
	private readonly ISwaggerSetting _swaggerSetting;
	
	public Class(ISwaggerSetting _swaggerSetting)
	{
		_swaggerSetting = swaggerSetting;
	}
	
	public void Metot()
	{
		string title = _swaggerSetting.Title;
	}
}
```
- Örnek TokenSessionModel class

```csharp
public interface ISwaggerSetting : ISetting
{
    string DefinitionName { get; init; }
    string Title { get; init; }
    string Description { get; init; }
    string Version { get; init; }
    string TermsOfService { get; init; }
    string ContactName { get; init; }
    string ContactUrl { get; init; }
    string ContactEmail { get; init; }
    string LicenseName { get; init; }
    string LicenseUrl { get; init; }
}
```
