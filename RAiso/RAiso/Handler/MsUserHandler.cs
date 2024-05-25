using RAiso.Models;
using RAiso.Modules;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class MsUserHandler
    {
        public static Response<MsUser> LoginUser(string username, string password)
        {
            MsUser user = MsUserRepository.GetMsUserByName(username);
            if (user == null)
            {
                return new Response<MsUser>
                {
                    IsSuccess = false,
                    Message = "Invalid username!",
                    Payload = null
                };
            }
            else if (user.UserPassword.Equals(password) == false)
            {
                return new Response<MsUser>
                {
                    IsSuccess = false,
                    Message = "Invalid password!",
                    Payload = null
                };
            }
            else
            {
                return new Response<MsUser>
                {
                    IsSuccess = true,
                    Message = "Succesfully logged in!",
                    Payload = user
                };
            }
        }

        public static Response<MsUser> RegisterUser(String UserName, String UserGender, DateTime UserDOB,
            String UserPhone, String UserAddress, String UserPassword)
        {
            MsUser temp = MsUserRepository.GetLastUser();
            int Id;
            if (temp != null)
            {
                Id = temp.UserID + 1;
            }
            else
            {
                Id = 1;
            }
            temp = MsUserRepository.GetMsUserByName(UserName);
            if (temp != null)
            {
                return new Response<MsUser>
                {
                    IsSuccess = false,
                    Message = "Username taken!",
                    Payload = null
                };
            }
            else
            {

                MsUserRepository.CreateMsUser(Id, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, "User");
                return new Response<MsUser>
                {
                    IsSuccess = true,
                    Message = "Succesfully register account!",
                    Payload = null
                };
            }
        }

        public static Response<MsUser> LogInWithCookie(String UserName)
        {
            MsUser user = MsUserRepository.GetMsUserByName(UserName);
            if (user != null)
            {
                return new Response<MsUser>
                {
                    IsSuccess = true,
                    Message = "Succesfully logged in!",
                    Payload = user
                };
            }
            else
            {
                return new Response<MsUser>
                {
                    IsSuccess = false,
                    Message = "User cookie not found!",
                    Payload = null
                };
            }

        }

        public static Response<MsUser> UpdateUser(int UserId, String UserName, String UserGender, DateTime UserDOB,
            String UserPhone, String UserAddress, String UserPassword)
        {
            MsUser temp = MsUserRepository.GetMsUserByName(UserName);
            MsUser oldUser = MsUserRepository.GetMsUserById(UserId);
            String oldName = oldUser.UserName;
            if (temp != null)
            {
                if (temp.UserName == oldName)
                {
                    MsUserRepository.UpdateMsUser(UserId, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword);
                    return new Response<MsUser>
                    {
                        IsSuccess = true,
                        Message = "Account Updated!",
                        Payload = null
                    };
                }
                else
                {
                    return new Response<MsUser>
                    {
                        IsSuccess = false,
                        Message = "Username taken!",
                        Payload = null
                    };
                }
            }
            else
            {

                MsUserRepository.UpdateMsUser(UserId, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword);
                return new Response<MsUser>
                {
                    IsSuccess = true,
                    Message = "Account Updated!",
                    Payload = null
                };
            }
        }
    }
}