using RAiso.Factory;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class MsUserRepository
    {
        static RAisoEntities DB = DatabaseSingleton.CreateInstance();
        public static MsUser GetMsUserByName(String Name)
        {
            return DB.MsUsers.Where(x => x.UserName == Name).FirstOrDefault();
        }

        public static MsUser GetMsUserById(int Id)
        {
            return DB.MsUsers.Find(Id);
        }

        public static MsUser GetLastUser()
        {
            return DB.MsUsers.ToList().LastOrDefault();
        }

        public static void CreateMsUser(int UserID, String UserName, String UserGender, DateTime UserDOB,
            String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            MsUser user = MsUserFactory.Create(UserID, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
            DB.MsUsers.Add(user);
            DB.SaveChanges();
        }

        public static void UpdateMsUser(int UserID, String UserName, String UserGender, DateTime UserDOB,
            String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            MsUser user = DB.MsUsers.Find(UserID);
            user.UserID = UserID;
            user.UserName = UserName;
            user.UserGender = UserGender;
            user.UserDOB = UserDOB;
            user.UserPhone = UserPhone;
            user.UserAddress = UserAddress;
            user.UserPassword = UserPassword;
            user.UserRole = UserRole;
            DB.SaveChanges();
        }

        public static void DeleteMsUser(int UserID)
        {
            MsUser user = DB.MsUsers.Find(UserID);
            DB.MsUsers.Remove(user);
            DB.SaveChanges();
        }
    }
}