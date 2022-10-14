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
        public static string OperationClaimCreated = "OperationClaim created";
        public static string OperationClaimUpdated = "OperationClaim updated";
        public static string OperationClaimDeleted = "OperationClaim deleted";

        // UserOperationClaim Manager
        public static string UserOperationClaimCreated = "UserOperationClaim created";
        public static string UserOperationClaimUpdated = "UserOperationClaim updated";
        public static string UserOperationClaimDeleted = "UserOperationClaim deleted";


        // User Manager
        public static string UserCreated = "User created";
        public static string AccessTokenCreated = "Access token is created";
    }
}
