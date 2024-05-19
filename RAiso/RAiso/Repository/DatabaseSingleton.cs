using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class DatabaseSingleton
    {
        private static RAisoEntities db = null;

        public static RAisoEntities CreateInstance()
        {
            if (db == null)
            {
                db = new RAisoEntities();
            }
            return db;
        }
    }
}