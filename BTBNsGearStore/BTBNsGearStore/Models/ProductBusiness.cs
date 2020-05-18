using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class ProductBusiness
    {
        //Lay danh sach Product
        public List<Product> LayDanhSachProduct()
        {
            List<Product> lstProduct = new List<Product>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachProduct";

                SqlDataReader reader = comm.ExecuteReader();

                Product objProduct;

                while(reader.Read())
                {
                    objProduct = new Product();

                    objProduct.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CategoryId")))
                    {
                        objProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("BrandId")))
                    {
                        objProduct.BrandId = reader.GetString(reader.GetOrdinal("BrandId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Guarantee")))
                    {
                        objProduct.Guarantee = reader.GetInt32(reader.GetOrdinal("Guarantee"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("EntryPrice")))
                    {
                        objProduct.EntryPrice = reader.GetDouble(reader.GetOrdinal("EntryPrice"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        objProduct.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image1")))
                    {
                        objProduct.Image1 = reader.GetString(reader.GetOrdinal("Image1"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image2")))
                    {
                        objProduct.Image2 = reader.GetString(reader.GetOrdinal("Image2"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image3")))
                    {
                        objProduct.Image3 = reader.GetString(reader.GetOrdinal("Image3"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image4")))
                    {
                        objProduct.Image4 = reader.GetString(reader.GetOrdinal("Image4"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                    {
                        objProduct.Detail = reader.GetString(reader.GetOrdinal("Detail"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Amount")))
                    {
                        objProduct.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objProduct.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstProduct.Add(objProduct);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return lstProduct;
        }
        //End lay danh sach product

        public Product ChiTietProductTheoId(int Id)
        {
            Product objProduct = null;

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_ChiTietProductTheoId";

                SqlParameter par = new SqlParameter("@Id", SqlDbType.Int);
                par.Value = Id;
                comm.Parameters.Add(par);

                SqlDataReader reader = comm.ExecuteReader();

                if(reader.Read())
                {
                    objProduct = new Product();

                    objProduct.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CategoryId")))
                    {
                        objProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("BrandId")))
                    {
                        objProduct.BrandId = reader.GetString(reader.GetOrdinal("BrandId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Guarantee")))
                    {
                        objProduct.Guarantee = reader.GetInt32(reader.GetOrdinal("Guarantee"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("EntryPrice")))
                    {
                        objProduct.EntryPrice = reader.GetDouble(reader.GetOrdinal("EntryPrice"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        objProduct.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image1")))
                    {
                        objProduct.Image1 = reader.GetString(reader.GetOrdinal("Image1"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image2")))
                    {
                        objProduct.Image2 = reader.GetString(reader.GetOrdinal("Image2"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image3")))
                    {
                        objProduct.Image3 = reader.GetString(reader.GetOrdinal("Image3"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image4")))
                    {
                        objProduct.Image4 = reader.GetString(reader.GetOrdinal("Image4"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                    {
                        objProduct.Detail = reader.GetString(reader.GetOrdinal("Detail"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Amount")))
                    {
                        objProduct.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objProduct.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return objProduct;
        }
        //End Chi tiet product theo ID

        //ThemMoi product
        public bool ThemMoiProduct(Product objProduct)
        {
            SqlParameter[] parameters = new SqlParameter[13];
            parameters[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameters[0].Value = objProduct.Name;
            parameters[1] = new SqlParameter("@CategoryId", SqlDbType.Int);
            parameters[1].Value = objProduct.CategoryId;
            parameters[2] = new SqlParameter("@BrandId", SqlDbType.VarChar, 100);
            parameters[2].Value = objProduct.BrandId;
            parameters[3] = new SqlParameter("@Guarantee", SqlDbType.Int);
            parameters[3].Value = objProduct.Guarantee;
            parameters[4] = new SqlParameter("@EntryPrice", SqlDbType.Float);
            parameters[4].Value = objProduct.EntryPrice;
            parameters[5] = new SqlParameter("@Price", SqlDbType.Float);
            parameters[5].Value = objProduct.Price;
            parameters[6] = new SqlParameter("@Image1", SqlDbType.VarChar, 100);
            parameters[6].Value = objProduct.Image1;
            parameters[7] = new SqlParameter("@Image2", SqlDbType.VarChar, 100);
            parameters[7].Value = objProduct.Image2;
            parameters[8] = new SqlParameter("@Image3", SqlDbType.VarChar, 100);
            parameters[8].Value = objProduct.Image3;
            parameters[9] = new SqlParameter("@Image4", SqlDbType.VarChar, 100);
            parameters[9].Value = objProduct.Image4;
            parameters[10] = new SqlParameter("@Detail", SqlDbType.NVarChar, 1000);
            parameters[10].Value = objProduct.Detail;
            parameters[11] = new SqlParameter("@Amount", SqlDbType.Int);
            parameters[11].Value = objProduct.Amount;
            parameters[12] = new SqlParameter("@NoiDung", SqlDbType.NText);
            parameters[12].Value = objProduct.NoiDung;

            return DataProvider.ThucHien("usp_ThemMoiProduct", parameters, true);
        }
        //End them moi product

        //Sua product
        public bool SuaProduct(Product objProduct)
        {
            SqlParameter[] parameters = new SqlParameter[14];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = objProduct.Id;
            parameters[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameters[1].Value = objProduct.Name;
            parameters[2] = new SqlParameter("@CategoryId", SqlDbType.Int);
            parameters[2].Value = objProduct.CategoryId;
            parameters[3] = new SqlParameter("@BrandId", SqlDbType.VarChar, 100);
            parameters[3].Value = objProduct.BrandId;
            parameters[4] = new SqlParameter("@Guarantee", SqlDbType.Int);
            parameters[4].Value = objProduct.Guarantee;
            parameters[5] = new SqlParameter("@EntryPrice", SqlDbType.Float);
            parameters[5].Value = objProduct.EntryPrice;
            parameters[6] = new SqlParameter("@Price", SqlDbType.Float);
            parameters[6].Value = objProduct.Price;
            parameters[7] = new SqlParameter("@Image1", SqlDbType.VarChar, 100);
            parameters[7].Value = objProduct.Image1;
            parameters[8] = new SqlParameter("@Image2", SqlDbType.VarChar, 100);
            parameters[8].Value = objProduct.Image2;
            parameters[9] = new SqlParameter("@Image3", SqlDbType.VarChar, 100);
            parameters[9].Value = objProduct.Image3;
            parameters[10] = new SqlParameter("@Image4", SqlDbType.VarChar, 100);
            parameters[10].Value = objProduct.Image4;
            parameters[11] = new SqlParameter("@Detail", SqlDbType.NVarChar, 1000);
            parameters[11].Value = objProduct.Detail;
            parameters[12] = new SqlParameter("@Amount", SqlDbType.Int);
            parameters[12].Value = objProduct.Amount;
            parameters[13] = new SqlParameter("@NoiDung", SqlDbType.NText);
            parameters[13].Value = objProduct.NoiDung;

            return DataProvider.ThucHien("usp_SuaProduct", parameters, true);
        }
        //end sua product

        //Xóa product
        public bool XoaProduc(int Id)
        {
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("@Id", SqlDbType.Int);
            pars[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaProduct", pars, true);
        }
        //End Xoa product

        //Tim kiem Product
        public List<Product> TimKiemProduct(string tuKhoa, string thuongHieu, string danhMuc = null)
        {
            List<Product> lstProduct = new List<Product>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            //string strSql = @"Select * from product inner join Category on product.CategoryId = Category.ID where 1=1 ";
            string strSql = @"Select * from product where 1=1 ";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                strSql += string.Format("And (product.Name like N'%{0}%' or product.Detail like N'%{0}%')", tuKhoa);
            }

            if (!string.IsNullOrEmpty(thuongHieu))
            {
                strSql += string.Format(" And (product.BrandId like '{0}')", thuongHieu);
            }

            if (!string.IsNullOrEmpty(danhMuc))
            {
                strSql += string.Format(" And (Product.CategoryId = {0})", int.Parse(danhMuc));
            }

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;

                SqlDataReader reader = comm.ExecuteReader();

                Product objProduct;

                while (reader.Read())
                {
                    objProduct = new Product();

                    objProduct.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CategoryId")))
                    {
                        objProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("BrandId")))
                    {
                        objProduct.BrandId = reader.GetString(reader.GetOrdinal("BrandId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Guarantee")))
                    {
                        objProduct.Guarantee = reader.GetInt32(reader.GetOrdinal("Guarantee"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("EntryPrice")))
                    {
                        objProduct.EntryPrice = reader.GetDouble(reader.GetOrdinal("EntryPrice"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        objProduct.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image1")))
                    {
                        objProduct.Image1 = reader.GetString(reader.GetOrdinal("Image1"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image2")))
                    {
                        objProduct.Image2 = reader.GetString(reader.GetOrdinal("Image2"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image3")))
                    {
                        objProduct.Image3 = reader.GetString(reader.GetOrdinal("Image3"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image4")))
                    {
                        objProduct.Image4 = reader.GetString(reader.GetOrdinal("Image4"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                    {
                        objProduct.Detail = reader.GetString(reader.GetOrdinal("Detail"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Amount")))
                    {
                        objProduct.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objProduct.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstProduct.Add(objProduct);
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

            return lstProduct;
        }

        public List<Product> LayDanhSachProductTheoCategory(string danhMuc)
        {
            List<Product> lstProduct = new List<Product>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            string strSql = @"Select * from product where 1=1 ";

            strSql += string.Format(" And (Product.CategoryId = {0}) order by id desc", int.Parse(danhMuc));

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;

                SqlDataReader reader = comm.ExecuteReader();

                Product objProduct;

                while (reader.Read())
                {
                    objProduct = new Product();

                    objProduct.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CategoryId")))
                    {
                        objProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("BrandId")))
                    {
                        objProduct.BrandId = reader.GetString(reader.GetOrdinal("BrandId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Guarantee")))
                    {
                        objProduct.Guarantee = reader.GetInt32(reader.GetOrdinal("Guarantee"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("EntryPrice")))
                    {
                        objProduct.EntryPrice = reader.GetDouble(reader.GetOrdinal("EntryPrice"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        objProduct.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image1")))
                    {
                        objProduct.Image1 = reader.GetString(reader.GetOrdinal("Image1"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image2")))
                    {
                        objProduct.Image2 = reader.GetString(reader.GetOrdinal("Image2"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image3")))
                    {
                        objProduct.Image3 = reader.GetString(reader.GetOrdinal("Image3"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image4")))
                    {
                        objProduct.Image4 = reader.GetString(reader.GetOrdinal("Image4"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                    {
                        objProduct.Detail = reader.GetString(reader.GetOrdinal("Detail"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Amount")))
                    {
                        objProduct.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objProduct.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstProduct.Add(objProduct);
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

            return lstProduct;
        }

        public List<Product> LayDanhSachPCTheoGia(string giaMin, string giaMax)
        {
            List<Product> lstProduct = new List<Product>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            string strSql = @"Select * from product where 1=1 ";

            strSql += string.Format(" And (Product.CategoryId = 5) " +
                "and (Product.Price>="+giaMin+ ") " +
                "and (Product.Price<" + giaMax + ") " +
                "order by id desc");

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;

                SqlDataReader reader = comm.ExecuteReader();

                Product objProduct;

                while (reader.Read())
                {
                    objProduct = new Product();

                    objProduct.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CategoryId")))
                    {
                        objProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("BrandId")))
                    {
                        objProduct.BrandId = reader.GetString(reader.GetOrdinal("BrandId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Guarantee")))
                    {
                        objProduct.Guarantee = reader.GetInt32(reader.GetOrdinal("Guarantee"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("EntryPrice")))
                    {
                        objProduct.EntryPrice = reader.GetDouble(reader.GetOrdinal("EntryPrice"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        objProduct.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image1")))
                    {
                        objProduct.Image1 = reader.GetString(reader.GetOrdinal("Image1"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image2")))
                    {
                        objProduct.Image2 = reader.GetString(reader.GetOrdinal("Image2"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image3")))
                    {
                        objProduct.Image3 = reader.GetString(reader.GetOrdinal("Image3"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image4")))
                    {
                        objProduct.Image4 = reader.GetString(reader.GetOrdinal("Image4"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                    {
                        objProduct.Detail = reader.GetString(reader.GetOrdinal("Detail"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Amount")))
                    {
                        objProduct.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objProduct.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstProduct.Add(objProduct);
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

            return lstProduct;
        }

        public List<Product> LayDanhSachProductTheoBrand(string Id)
        {
            List<Product> lstProduct = new List<Product>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            string strSql = @"Select * from product where 1=1 ";

            strSql += " And (BrandId = '"+Id+"') order by id desc";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;

                SqlDataReader reader = comm.ExecuteReader();

                Product objProduct;

                while (reader.Read())
                {
                    objProduct = new Product();

                    objProduct.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CategoryId")))
                    {
                        objProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("BrandId")))
                    {
                        objProduct.BrandId = reader.GetString(reader.GetOrdinal("BrandId"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Guarantee")))
                    {
                        objProduct.Guarantee = reader.GetInt32(reader.GetOrdinal("Guarantee"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("EntryPrice")))
                    {
                        objProduct.EntryPrice = reader.GetDouble(reader.GetOrdinal("EntryPrice"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Price")))
                    {
                        objProduct.Price = reader.GetDouble(reader.GetOrdinal("Price"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image1")))
                    {
                        objProduct.Image1 = reader.GetString(reader.GetOrdinal("Image1"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image2")))
                    {
                        objProduct.Image2 = reader.GetString(reader.GetOrdinal("Image2"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image3")))
                    {
                        objProduct.Image3 = reader.GetString(reader.GetOrdinal("Image3"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Image4")))
                    {
                        objProduct.Image4 = reader.GetString(reader.GetOrdinal("Image4"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                    {
                        objProduct.Detail = reader.GetString(reader.GetOrdinal("Detail"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Amount")))
                    {
                        objProduct.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objProduct.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstProduct.Add(objProduct);
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

            return lstProduct;
        }
    }
}