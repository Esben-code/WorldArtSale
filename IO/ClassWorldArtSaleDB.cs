using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassWorldArtSaleDB : ClassDbCon
    {

        public ClassWorldArtSaleDB()
        {
            SetCon(@"Server=ESBENSPC\SQLEXPRESS;Database=WorldArtSale;Trusted_Connection=True;");
        }


        public List<ClassCustomer> GetAllCustomerFromDB(ClassCurrency inCurrency)
        {
            List<ClassCustomer> listCCres = new List<ClassCustomer>();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetAllCustomerFromDB";

            DataTable dataTable = MakeCallToStoredProcedure(cmd);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassCustomer customer = new ClassCustomer();

                customer.customerID = Convert.ToInt32(row["id"]);
                customer.name = row["name"].ToString();
                customer.address = row["address"].ToString();
                customer.zipCity = row["zipCity"].ToString();
                customer.country = row["country"].ToString();
                customer.email = row["email"].ToString();
                customer.phoneNo = row["phone"].ToString();
                customer.classSalesValue.bidUSD = row["maximumBid"].ToString();
                customer.customerCurrencyID = row["preferredCurrency"].ToString();
                customer.isActive = Convert.ToBoolean(row["isActive"]);

                listCCres.Add(customer);
            }

            return listCCres;
        }

        public List<ClassArt> GetAllArtFromDB()
        {
            List<ClassArt> listCAres = new List<ClassArt>();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetAllArtFromDB";

            DataTable dataTable = MakeCallToStoredProcedure(cmd);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassArt art = new ClassArt();

                art.artID = Convert.ToInt32(row["id"]);
                art.picturePath = row["picturePath"].ToString();
                art.pictureDescription = row["description"].ToString();
                art.pictureTitel = row["titel"].ToString();
                art.isAvailable = Convert.ToBoolean(row["isAvailable"]);

                listCAres.Add(art);
            }

            return listCAres;

        }

        // AddCustomerToDB    metode til at oprætte kunde

        // AddArtToDB         metode til at oprætte kunst

        // EditCustomerInDB   metode til at ændre kunde

        // EditArtInDB        metode til at ændre kunst

        // HideCustomerInDB   metode til at "slette" kunde

        // HideArtInDB        metode til at "slette" kunst



    }
}
