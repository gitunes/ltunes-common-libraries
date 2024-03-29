﻿namespace LTunes.Lib.Shared.Constants
{
    internal static class ExceptionMessage
    {
        internal const string EnumValueRequired = "Numaralandırıcı (enum) değeri boş olamaz.";
        internal const string ObjectValueRequired = "Object değeri boş olamaz";
        internal const string TextRequired = "Kaynak değere (url) dönüştürülecek metin boş olamaz";
        internal const string AnUnspecifiedErrorHasOccurred = "Belirlenemeyen bir hata oluştu.";
        internal const string NoMatchingBrandCode = "Eşleşen marka kodu bulunamadı.";
    }

    public static class SuccessMessage
    {
        public const string TransactionSuccessful = "İşlem başarılı.";
    }
}
