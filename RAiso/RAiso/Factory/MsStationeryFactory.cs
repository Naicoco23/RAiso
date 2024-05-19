using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class MsStationeryFactory
    {
        public static MsStationery Create(int StationeryID, String StationeryName, int StationeryPrice)
        {
            MsStationery msStationery = new MsStationery()
            {
                StationeryID = StationeryID,
                StationeryName = StationeryName,
                StationeryPrice = StationeryPrice
            };
            return msStationery;
        }
    }
}