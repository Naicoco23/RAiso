using RAiso.Handler;
using RAiso.Models;
using RAiso.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;

namespace RAiso.Controller
{
    public class MsUserController
    {
        public static Response<MsUser> LoginUser(String Username, String Password)
        {
            String Error = "";
            if(Username.Equals("") || Password.Equals(""))
            {
                Error = "All fields must be filled!";
            }

            if (Error.Equals(""))
            {
                return MsUserHandler.LoginUser(Username, Password);
            }
            else
            {
                return new Response<MsUser>
                {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };
            }
        }

        public static Response<MsUser> RegisterUser(String UserName, String UserGender, DateTime UserDOB,
            String UserPhone, String UserAddress, String UserPassword)
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            String Error = "";
            if (UserName.Equals(""))
            {
                Error = "Username must be filled!";
            }
            else if (UserDOB == DateTime.MinValue)
            {
                Error = "DOB must be filled!";
            }
            else if (UserGender.Equals(""))
            {
                Error = "Gender must be filled!";
            }
            else if (UserAddress.Equals(""))
            {
                Error = "Address must be filled!";
            }
            else if (UserPassword.Equals(""))
            {
                Error = "Password must be filled!";
            }
            else if (UserPhone.Equals(""))
            {
                Error = "Phone Number must be filled!";
            }
            else if (UserName.Length <= 5 || UserName.Length >= 50)
            {
                Error = "Username must be between 5 and 50 characters!";
            }
            else if (UserDOB > oneYearAgo)
            {
                Error = "Must be at least 1 year old!";
            }
            else if (!Regex.IsMatch(UserPassword, "^[a-zA-Z0-9]+$"))
            {
                Error = "Password must be alphanumeric!";
            }

            if (Error.Equals(""))
            {
                return MsUserHandler.RegisterUser(UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword);
            }
            else
            {
                return new Response<MsUser> {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };

            }
        }

        public static Response<MsUser> LogInWithCookie(String UserName)
        {
            return MsUserHandler.LogInWithCookie(UserName);
        }

        public static Response<MsUser> UpdateUser(int UserId, String UserName, String UserGender, DateTime UserDOB,
            String UserPhone, String UserAddress, String UserPassword)
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            String Error = "";
            if (UserName.Equals(""))
            {
                Error = "Username must be filled!";
            }
            else if (UserDOB == DateTime.MinValue)
            {
                Error = "DOB must be filled!";
            }
            else if (UserGender.Equals(""))
            {
                Error = "Gender must be filled!";
            }
            else if (UserAddress.Equals(""))
            {
                Error = "Address must be filled!";
            }
            else if (UserPassword.Equals(""))
            {
                Error = "Password must be filled!";
            }
            else if (UserPhone.Equals(""))
            {
                Error = "Phone Number must be filled!";
            }
            else if (UserName.Length <= 5 || UserName.Length >= 50)
            {
                Error = "Username must be between 5 and 50 characters!";
            }
            else if (UserDOB > oneYearAgo)
            {
                Error = "Must be at least 1 year old!";
            }
            else if (!Regex.IsMatch(UserPassword, "^[a-zA-Z0-9]+$"))
            {
                Error = "Password must be alphanumeric!";
            }

            if (Error.Equals(""))
            {
                return MsUserHandler.UpdateUser(UserId,UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword);
            }
            else
            {
                return new Response<MsUser>
                {
                    IsSuccess = false,
                    Message = Error,
                    Payload = null
                };

            }
        }
    }
}