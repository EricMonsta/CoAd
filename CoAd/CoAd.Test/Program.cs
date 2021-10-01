using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoAd.Fo.Core;
using System.Data.Linq;
using System.Linq;
using CoAd.Core.Database;
using CoAd.Fo.Core.Database;

namespace CoAd.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddParamType();

            var db = new DataContext(@"Data Source=192.168.187.7\sqlexpress;Initial Catalog=frontdk_stand_test;User ID=sa;Password=mssql;Connect Timeout=30");

            // искомый магазин
            var store = db.GetTable<Classif_depart>().FirstOrDefault(s => s.id_depart == 1003);

            store.name_depart = "допа2 что угодно";

            db.SubmitChanges();
        }

        public static void AddParamType()
        {
            var dbFo = new DataContext(@"Data Source=192.168.187.7\sqlexpress;Initial Catalog=frontdk_stand_test;User ID=sa;Password=mssql;Connect Timeout=30");
            var dbCoAd = new DataContext(@"Data Source=192.168.187.7\sqlexpress;Initial Catalog=coad_test;User ID=sa;Password=mssql;Connect Timeout=30");

            var pTypes = dbFo.GetTable<Str_cash_param>().Where(p=>p.parent != null && p.type_param !=null);
            var paramTypes = dbCoAd.GetTable<TypeParam>();
            foreach (var type in pTypes)
            {
                paramTypes.InsertOnSubmit(new TypeParam
                {
                    mnem_param = type.mnem_str_cash_param,
                    name = type.name_str_cash_param ?? "",
                    description = type.description ?? "",
                    type_param = type.type_param ?? -1,
                    object_param = null,
                    object_str_param = 0,
                    unused = 0

                });
            }

            dbCoAd.SubmitChanges();
        }
    }


}
