using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class BrandBusiness
    {
        public List<Brand> LayDanhSachBrand()
        {
            List<Brand> lstBrand = new List<Brand>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachBrand";

                SqlDataReader reader = comm.ExecuteReader();

                Brand objBrand;

                while (reader.Read())
                {
                    objBrand = new Brand();
                    objBrand.Id = reader.GetString(reader.GetOrdinal("Id"));
                    objBrand.Name = reader.GetString(reader.GetOrdinal("Name"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                    {
                        objBrand.Image = reader.GetString(reader.GetOrdinal("Image"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Info")))
                    {
                        objBrand.Info = reader.GetString(reader.GetOrdinal("Info"));
                    }
                    lstBrand.Add(objBrand);
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
            return lstBrand;
        }


        public bool XoaBrand(string Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.VarChar, 100);
            parameters[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaBrand", parameters, true);
        }

        public bool ThemMoiBrand(Brand objBrand)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Id", SqlDbType.VarChar, 100);
            parameters[0].Value = objBrand.Id;

            parameters[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameters[1].Value = objBrand.Name;

            parameters[2] = new SqlParameter("@Image", SqlDbType.VarChar, 100);
            parameters[2].Value = objBrand.Image;

            parameters[3] = new SqlParameter("@info", SqlDbType.NVarChar, 100);
            parameters[3].Value = objBrand.Info;

            return DataProvider.ThucHien("usp_ThemMoiBrand", parameters, true);
        }
    }
}