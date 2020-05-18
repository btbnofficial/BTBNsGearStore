using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class PostBusiness
    {
        public List<Post> LayDanhSachPost()
        {
            List<Post> lstPost = new List<Post>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachPost";

                Post objPost;
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    objPost = new Post();
                    objPost.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Title")))
                    {
                        objPost.Title = reader.GetString(reader.GetOrdinal("Title"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DatePosted")))
                    {
                        objPost.DatePosted = reader.GetDateTime(reader.GetOrdinal("DatePosted"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objPost.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstPost.Add(objPost);
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
            return lstPost;
        }
        //End lay danh sach Post

        public Post ChiTietPostTheoId(int Id)
        {
            Post objPost = null;

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_ChiTietPostTheoId";

                SqlParameter par = new SqlParameter("@Id",SqlDbType.Int);
                par.Value = Id;

                comm.Parameters.Add(par);

                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    objPost = new Post();
                    objPost.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Title")))
                    {
                        objPost.Title = reader.GetString(reader.GetOrdinal("Title"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DatePosted")))
                    {
                        objPost.DatePosted = reader.GetDateTime(reader.GetOrdinal("DatePosted"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objPost.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
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
            return objPost;
        }
        //End chi tiet post theo Id

        public bool ThemMoiPost( Post objPost)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Title", SqlDbType.NVarChar, 200);
            parameters[0].Value = objPost.Title;

            parameters[1] = new SqlParameter("@noiDung", SqlDbType.NText);
            parameters[1].Value = objPost.NoiDung;

            return DataProvider.ThucHien("usp_ThemMoiPost", parameters, true);
        }

        //Sua post
        public bool SuaPost(Post objPost)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = objPost.Id;

            parameters[1] = new SqlParameter("@Title", SqlDbType.NVarChar, 200);
            parameters[1].Value = objPost.Title;

            parameters[2] = new SqlParameter("@noiDung", SqlDbType.NText);
            parameters[2].Value = objPost.NoiDung;


            return DataProvider.ThucHien("usp_SuaPost", parameters, true);
        }
        //End sua Post

        //Xoa post
        public bool XoaPost(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaPost", parameters, true);
        }
        //End xoa post

        public List<Post> TimKiemPost(string tuKhoa)
        {
            List<Post> lstPost = new List<Post>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            string strSql = "Select * from Post where 1=1";

            if(!string.IsNullOrEmpty(tuKhoa))
            {
                strSql += string.Format("and Title like N'%{0}%'", tuKhoa);
            }

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;

                Post objPost;
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    objPost = new Post();
                    objPost.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Title")))
                    {
                        objPost.Title = reader.GetString(reader.GetOrdinal("Title"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DatePosted")))
                    {
                        objPost.DatePosted = reader.GetDateTime(reader.GetOrdinal("DatePosted"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("NoiDung")))
                    {
                        objPost.NoiDung = reader.GetString(reader.GetOrdinal("NoiDung"));
                    }
                    lstPost.Add(objPost);
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
            return lstPost;
        }
    }
}