using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi zaten mevcut";
        public static string MaintenanceTime = "Kapalıyız bruh";
        public static string ProductListed = "Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string CategoryLimitError = "kategori limiti aşıldı ürün eklenemez çok saçma bir kuraal bune olm :D";
        public static string AuthorizationDenied = "Yetki yok";
        public static string Success = "Başarılı";
        public static string Error = "Bir hata ile karşılaşıldı";
        public static string UserNotExist = "kullanıcı bulunamadı";
        public static string WrongPassword = "şifre hatalı";
        public static string UserExist = "kullanıcı mevcut";
        public static string TokenCreated = "token oluştu";
    }
}