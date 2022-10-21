using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public class Messages : IMessages
    {
        public static string ImageNotExist = "Fotoğraf Bulunamadı";
        public static string AuthorizationDenied = "Yetkinlik Yok!";

        // OperationClaim Manager
        public static string OperationClaimCreated = "Rol eklendi";
        public static string OperationClaimUpdated = "Rol güncellendi";
        public static string OperationClaimDeleted = "Rol silindi";

        // UserOperationClaim Manager
        public static string UserOperationClaimCreated = "Kullanıcı rolü eklendi";
        public static string UserOperationClaimUpdated = "Kullanıcı rolü güncellendi";
        public static string UserOperationClaimDeleted = "Kullanıcı rolü silindi";

        // UserWeight Manager
        public static string UserWeightCreated = "Kullanıcı kilosu eklendi";
        public static string UserWeightUpdated = "Kullanıcı kilosu güncellendi";
        public static string UserWeightDeleted = "Kullanıcı kilosu silindi";

        // UserHeight Manager
        public static string UserHeightCreated = "Kullanıcı boyu eklendi";
        public static string UserHeightUpdated = "Kullanıcı boyu güncellendi";
        public static string UserHeightDeleted = "Kullanıcı boyu silindi";

        // User Manager
        public static string UserCreated = "Kullanıcı yaratıldı";
        public static string AccessTokenCreated = "Token yaratıldı";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string PasswordUpdated = "Şifre güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        // Weight Manager
        public static string WeightCreated = "Kilo eklendi";
        public static string WeightUpdated = "Kilo güncellendi";
        public static string WeightDeleted = "Kilo silindi";

        // Height Manager
        public static string HeightCreated = "Boy eklendi";
        public static string HeightUpdated = "Boy güncellendi";
        public static string HeightDeleted = "Boy silindi";

        // Recipe Manager
        public static string RecipeCreated = "Tarif eklendi";
        public static string RecipeUpdated = "Tarif güncellendi";
        public static string RecipeDeleted = "Tarif silindi";

        // Collaboration Manager
        public static string CollaborationCreated = "İşbirliği eklendi";
        public static string CollaborationUpdated = "İşbirliği güncellendi";
        public static string CollaborationDeleted = "İşbirliği silindi";

        // Event Manager
        public static string EventCreated = "Etkinlik eklendi";
        public static string EventUpdated = "Etkinlik güncellendi";
        public static string EventDeleted = "Etkinlik silindi";

        // Gallery Manager
        public static string GalleryCreated = "Galeri eklendi";
        public static string GalleryUpdated = "Galeri güncellendi";
        public static string GalleryDeleted = "Galeri silindi";

        // Auth Manager
        public static string UserRegistered = "Kullanıcı yaratıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Bu Kullanıcı zaten bulunmakta";
    }
}
