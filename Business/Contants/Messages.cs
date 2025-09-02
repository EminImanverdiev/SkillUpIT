using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static string XAdded = "elave edildi";

        public static string? AuthorizationDenied="Autoriaz olun";
        public static string UserRegistered="istifadeci qeydiyyatdan kecdi";
        public static string SuccessfulLogin ="Ugurla giris edildi";
        public static string UserAlreadyExists = "Istifadeci artiq movcuddur";
        public static string UserNotFound ="Istifadeci tapilmadi";
        public static string PasswordError ="Parol sehvdir";
        public static string AccessTokenCreated ="Token yaradildi";

        public static string XNotFound { get; internal set; }
    }
}
