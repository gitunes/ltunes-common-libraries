namespace LTunes.Lib.Jwt.Infrastructure.Constants
{
    internal static class ExceptionMessage
    {
        internal const string ClaimTypeRequired = "Talep türü boş olamaz.";
        internal const string SecurityKeyRequired = "Güvenlik anahtarı boş olamaz.";
        internal const string TokenOptionsSettingRequired = "Konfigurasyon dosyasına jwt token ayarlarınızı ekleyiniz veya geçerli değerler tanımlayınız.";
        internal const string ClaimTypeEmailRequired = "Email talep türü bulunamadı.";
        internal const string ClaimTypeNameRequired = "Ad talep türü bulunamadı.";
        internal const string ClaimTypeNameIdentifierRequired = "Ad tanımlayıcı (id) talep türü bulunamadı.";
        internal const string ClaimTypeRoleRequired = "Rol talep türü bulunamadı.";
        internal const string ClaimTypeJtiRequired = "Jti benzersiz anahtar talep türü bulunamadı.";
        internal const string ClaimTypeAudienceRequired = "Sağlayıcı talep türü bulunamadı.";
        internal const string ClaimTypePlatformTypeRequired = "Platform talep türü bulunamadı.";
        internal const string ClaimTypeUsernameRequired = "Kullanıcı adı talep türü bulunamadı.";
    }
}