using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class CategoryBusiness
    {
        public List<Category> LayDanhSachCategory()
        {
            List<Category> lstCategory = new List<Category>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachCategory";

                SqlDataReader reader = comm.ExecuteReader();

                Category objCategory;

                while (reader.Read())
                {
                    objCategory = new Category();
                    objCategory.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    objCategory.Name = reader.GetString(reader.GetOrdinal("Name"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                    {
                        objCategory.Image = reader.GetString(reader.GetOrdinal("Image"));
                    }

                    lstCategory.Add(objCategory);
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
            return lstCategory;
        }


        public bool XoaCategory(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaCategory", parameters, true);
        }

        public bool ThemMoiCategory(Category objCategory)
        {
            SqlParameter[] parameters = new SqlParameter[2];
           
            parameters[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameters[0].Value = objCategory.Name;

            parameters[1] = new SqlParameter("@Image", SqlDbType.VarChar, 100);
            parameters[1].Value = objCategory.Image;

            return DataProvider.ThucHien("usp_ThemMoiCategory", parameters, true);
        }
    }
}