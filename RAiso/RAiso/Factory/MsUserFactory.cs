using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class MsUserFactory
    {
        public static MsUser Create(int UserID, String UserName, String UserGender, DateTime UserDOB, 
            String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            MsUser user = new MsUser()
            {
                UserID = UserID,
                UserName = UserName,
                UserGender = UserGender,
                UserDOB = UserDOB,
                UserPhone = UserPhone,
                UserAddress = UserAddress,
                UserPassword = UserPassword,
                UserRole = UserRole
            };
            return user;
        }
    }
}