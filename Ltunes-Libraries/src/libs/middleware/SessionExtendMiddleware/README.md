SessionExtendMiddleware
============


### SessionExtendMiddleware nedir?

Api uygulamalarında Jwt tokenlardaki claims leri otomatik olarak class modelimize aktaran middleware kütüphanesidir. 

### Nasıl  projeye eklenir?

- middleware klasörü içindeki SessionExtendMiddleware dosyasını projenize eklemelisiniz.
- startup.cs dosyanıza gerekli reegisterları yapmalısınız.
- Aşağıdaki örnekte kullanılan "TokenSessionModel" class property'lerini kendi claimslerinize göre düzenlemelisiniz. Ya da kendi model class'ınız ile değiştirmelisiniz. 
- Propertilerin tipleri string olmalıdır.

```csharp

public void ConfigureServices(IServiceCollection services)
{
	services.AddHttpContextAccessor();
	services.AddScoped<IPerRequestCacheManager, PerRequestCacheManager>();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	app.UseMiddleware<SessionExtendMiddleware<TokenSessionModel>>();
}
```
- Kullanmak istediğiniz class'ta  aşağıdaki gibi kullanabilirsiniz.

```csharp
 public class ClassQueries
{
	private readonly IPerRequestCacheManager _requestCacheManager;
	
	public GameQueries(IPerRequestCacheManager requestCacheManager)
	{
		_requestCacheManager = requestCacheManager;
	}
	
	public void Login()
	{
		var tokenSession = _requestCacheManager.GetSession<TokenSessionModel>();
	}
}
```
- Örnek TokenSessionModel class

```csharp
public class TokenSessionModel
{
	public string UserGuidId { get; set; }
	public string FullName { get; set; }
	public string LastLoginDate { get; set; }
}
```
