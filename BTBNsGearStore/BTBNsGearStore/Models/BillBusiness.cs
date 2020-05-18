using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class BillBusiness
    {
        public List<Bill> LayDanhSachBill()
        {
            List<Bill> lstBill = new List<Bill>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachBill";

                SqlDataReader reader = comm.ExecuteReader();
                Bill objBill;
                while (reader.Read())
                {
                    objBill = new Bill();
                    objBill.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    objBill.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                    objBill.DateOrdered = reader.GetDateTime(reader.GetOrdinal("DateOrdered"));
                    objBill.Status = reader.GetInt32(reader.GetOrdinal("status"));

                    lstBill.Add(objBill);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return lstBill;
        }

        public bool ThemMoiBill(Bill objBill)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
            parameters[0].Value = objBill.CustomerId;

            return DataProvider.ThucHien("usp_ThemMoiBill", parameters, true);
        }

        public bool ThanhToanBill(Bill objBill)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = objBill.Id;

            return DataProvider.ThucHien("usp_ThanhToanBill", parameters, true);
        }

        public bool XoaBill (string Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("Id", SqlDbType.Int);
            parameters[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaBill", parameters, true);
        }
    }
}