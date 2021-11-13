using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun eklendi";
        public static string ProductNameInvalid = "Urun ismi gecersiz";
        public static string MaintenanceTime = "Sistem bakimda";
        public static string ProductsListed = "Urunler listelendi";
        public static string ProductCountCategoryError = "Ayni kategoride en fazla 10 urun olabilir";
        public static string ProductNameAlreadyExist ="Ayni isimde urun zaten mevcut";
        public static string CategoryLimitExceeded = "Kategori limiti asildigi icin yeni urun eklenemiyor";
    }
}
