using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebsiteKinhDoanhCayCanh.Models.OtherModels
{
    public class CCSListView
    {
        private MyDataEF db = null;

        public CCSListView()
        {
            db = new MyDataEF();
        }
        public List<CachChamSoc> listAll()
        {
            return db.CachChamSoc.ToList();
        }
    }
}