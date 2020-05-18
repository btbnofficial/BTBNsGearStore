using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class BillDetailBusiness
    {
        public List<BillDetail> LayDanhSachBillDetail()
        {
            List<BillDetail> lstBillDetail = new List<BillDetail>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachBillDetail";

                SqlDataReader reader = comm.ExecuteReader();
                BillDetail objBillDetail;
                while (reader.Read())
                {
                    objBillDetail = new BillDetail();
                    objBillDetail.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    objBillDetail.BillId = reader.GetInt32(reader.GetOrdinal("BillId"));
                    objBillDetail.ProductId = reader.GetInt32(reader.GetOrdinal("ProductId"));
                    objBillDetail.Count = reader.GetInt32(reader.GetOrdinal("count"));

                    lstBillDetail.Add(objBillDetail);
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

            return lstBillDetail;
        }

        public bool ThemMoiBillDetail(BillDetail objBillDetail)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@BillId", SqlDbType.Int);
            parameters[0].Value = objBillDetail.BillId;

            parameters[1] = new SqlParameter("@ProductId", SqlDbType.Int);
            parameters[1].Value = objBillDetail.ProductId;

            parameters[2] = new SqlParameter("@Count", SqlDbType.Int);
            parameters[3].Value = objBillDetail.Count;

            return DataProvider.ThucHien("usp_ThemMoiBillDetail", parameters, true);
        }

        public bool XoaBillDetail(string Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaBillDetail", parameters, true);
        }
    }
}