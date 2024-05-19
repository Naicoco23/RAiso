using RAiso.Models;
using RAiso.Modules;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class MsStationeryHandler
    {
        public static Response<List<MsStationery>> SearchStationery(String search)
        {
            List<MsStationery> list = MsStationeryRepository.SearchStationery(search);
            if (list == null)
            {
                return new Response<List<MsStationery>>()
                {
                    IsSuccess = false,
                    Message = "No stationery found!",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<MsStationery>>()
                {
                    IsSuccess = true,
                    Message = "Succesfully Retrieved!",
                    Payload = list
                };
            }
        }

        public static Response<List<MsStationery>> GetAllStationery()
        {
            List<MsStationery> list = MsStationeryRepository.GetAllStationery();
            if(list == null)
            {
                return new Response<List<MsStationery>>()
                {
                    IsSuccess = false,
                    Message = "No stationery found!",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<MsStationery>>()
                {
                    IsSuccess = true,
                    Message = "Succesfully Retrieved!",
                    Payload = list
                };
            }
        }

        public static Response<MsStationery> GetStationeryById(int id)
        {
            MsStationery searchid = MsStationeryRepository.GetStationeryById(id);
            if (searchid == null)
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = "No stationery found!",
                    Payload = null
                };
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = true,
                    Message = "Succesfully Retrieved!",
                    Payload = searchid
                };
            }
        }

        public static Response<MsStationery> AddStationery(String name, int price)
        {
            int id=1;
            MsStationery msStationery = MsStationeryRepository.GetLastStationery();
            if(msStationery != null)
            {
                id = msStationery.StationeryID + 1;
            }
            MsStationeryRepository.CreateStationery(id, name, price);
            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "Succesfully added!",
                Payload = null
            };
        }

        public static void DeleteStationery(int id)
        {
            MsStationeryRepository.DeleteStationery(id);
        }

        public static Response<MsStationery> UpdateStationery(int ID, String name, int price)
        {
            MsStationeryRepository.UpdateStationery(ID, name, price);
            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "Succesfully updated!",
                Payload = null
            };
        }
    }
}