using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class DataProvider
    {
        public const string connectionString = @"Data Source=DESKTOP-014K6AU\SQL2012;Initial Catalog=btbnGearsStore;Integrated Security=True";

        public static DataTable LayDanhSach(string strSql, SqlParameter[] pars = null, bool isThuTuc = false)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = strSql;
                if (isThuTuc)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }
                if (pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                // Do ra bang
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public static bool ThucHien(string strSql, SqlParameter[] pars = null, bool isThuTuc = false)
        {
            bool isThucHien = false;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = strSql;
                if (isThuTuc)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }
                if (pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                isThucHien = (comm.ExecuteNonQuery() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isThucHien;
        }

        public static object ExecuteScalar(string strSql, SqlParameter[] pars = null, bool isThuTuc = false)
        {
            object soDong = null;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = strSql;
                if (isThuTuc)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }
                if (pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                soDong = comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return soDong;
        }
    }
}