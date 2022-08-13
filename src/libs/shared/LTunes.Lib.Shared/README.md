LTunes.Lib.Shared
============


### LTunes.Lib.Shared nedir?
Takım içerisinde sürdürülen tüm uygulamarda gerekli olan sabitler, hata sınıfları, numaralandırılacak vb. işlevleri içeren kütüphanedir.

### Nasıl  projeye eklenir?

- libs/shared klasörü içindeki LTunes.Lib.Shared dosyasını projenize eklemelisiniz.
- Kütüphaneyi projesinize ekledikten sonra ihtiyaçlarınıza göre kütüphane kodlarında gerekli düzenlemeleri gerçekleştirebilirsiniz.

Aşağıda hata sınıfı kullanımı veya poco modeli json string'e nasıl çevrileceğiyle ilgili basit bir örnekleme yapılmıştır.

```csharp

throw new DatabaseException("Entity güncellemesinde hata meydana geldi!", exception);

pocoModel.ToJsonString();
```
