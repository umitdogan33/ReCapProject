using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public class Messages
    {
        public static string Added = "eklenme başarılı";
        public static string SameProductName = "aynı isme sahip ürün bulunmakta";
        public static string SameBrandName = "aynı isme sahip marka bulunmakta";
        public static string AddedBrand = "ekleme başarılı";
        public static string SameUserName = "aynı isme sahip kullanıcı bulunmakta";
        public static string AddedUser = "ekleme başarılı";
        public static string CarImageAdded = "ekleme başarılı";
        public static string CarImageDeleted = "silme başarılı";
        public static string CarImageNotFound = "resim bulunamadı";
        public static string CarImageUpdated = "güncelleme başarılı";
        public static string AddSingular = "resim eklendi ";
        public static string UpdateSingular = "resim güncellendi";
        public static string DeleteSingular = "resim silindi";
        public static string NotExist = "bulunamıyor";
        public static string InvalidFileExtension = "bulunamayan dosya yolu";
        public static string ImageNumberLimitExceeded = "resim sınırı yetersiz";
        public static string AuthorizationDenied = "AuthorizationDenied";
        public static string AccessTokenCreated = "token oluşturuldu";
        public static string UserRegistered = "kayır başarılı";
        public static string PasswordError = "şifre hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string UserAlreadyExists = "kullanıcı zaten kayıtlı";
        public static string Updated = "Güncelleme başarılı";
        public static string Deleted = "silme başarılı";
        public static string SameCarName = "bu araba isminde araba var";
        public static string Addedustomer = "müşteri eklendi";
        internal static string CarImageLimit = "limit hatası";
        internal static string UserUpdated = "profil güncellendi";
    }
}
