using RAiso.Factory;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Web;

namespace RAiso.Repository
{
    public class MsStationeryRepository
    {
        static RAisoEntities DB = DatabaseSingleton.CreateInstance();

        public static List<MsStationery> GetAllStationery()
        {
            return DB.MsStationeries.ToList();
        }

        public static MsStationery GetStationeryByName(string name)
        {
            return DB.MsStationeries.Where(u => u.StationeryName == name).FirstOrDefault();
        }

        public static MsStationery GetStationeryById(int StationeryID)
        {
            return DB.MsStationeries.Find(StationeryID);
        }

        public static MsStationery GetLastStationery()
        {
            return DB.MsStationeries.ToList().LastOrDefault();
        }

        public static List<MsStationery> SearchStationery(String search)
        {
            return DB.MsStationeries.Where(u => u.StationeryName.StartsWith(search)).ToList() ;
        }

        public static void CreateStationery(int StationeryID, String StationeryName, int StationeryPrice)
        {
            MsStationery msStationery = MsStationeryFactory.Create(StationeryID, StationeryName, StationeryPrice);
            DB.MsStationeries.Add(msStationery);
            DB.SaveChanges();
        }

        public static void UpdateStationery(int StationeryID, String StationeryName, int StationeryPrice)
        {
            MsStationery msStationery = DB.MsStationeries.Find(StationeryID);
            if (msStationery != null)
            {
                msStationery.StationeryName = StationeryName;
                msStationery.StationeryPrice = StationeryPrice;
                DB.SaveChanges();
            }
        }

        public static void DeleteStationery(int StationeryID)
        {
            MsStationery msStationery = DB.MsStationeries.Find(StationeryID);
            if (msStationery != null)
            {
                DB.MsStationeries.Remove(msStationery);
                DB.SaveChanges();
            }
        }
    }
}