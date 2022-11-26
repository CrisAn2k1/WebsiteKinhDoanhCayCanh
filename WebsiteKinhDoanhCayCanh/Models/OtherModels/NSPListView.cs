using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models.OtherModels
{
    public class NSPListView
    {
        private MyDataEF db = null;

        public NSPListView()
        {
            db = new MyDataEF();
        }
        public List<NhomSP> listAll()
        {
            return db.NhomSP.ToList();
        }
    }
}