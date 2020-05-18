using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class AccountBusiness
    {
        public List<Account> LayDanhSachAccount()
        {
            List<Account> lstAccount = new List<Account>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachAccount";

                SqlDataReader reader = comm.ExecuteReader();

                Account objAccount;

                while(reader.Read())
                {
                    objAccount = new Account();
                    objAccount.Id = reader.GetString(reader.GetOrdinal("Id"));
                    objAccount.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objAccount.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                    {
                        objAccount.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Type")))
                    {
                        objAccount.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Salary")))
                    {
                        objAccount.Salary = reader.GetDouble(reader.GetOrdinal("Salary"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DateJoined")))
                    {
                        objAccount.DateJoined = reader.GetDateTime(reader.GetOrdinal("DateJoined"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                    {
                        objAccount.Department = reader.GetString(reader.GetOrdinal("Department"));
                    }

                    lstAccount.Add(objAccount);
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

            return lstAccount;
        }

        public bool XoaAccount(string Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("Id",SqlDbType.VarChar,100);
            parameters[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaAccount", parameters, true);
        }

        public Account ChiTietAccountTheoId(string Id)
        {
            Account objAccount = null;

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_ChiTietAccountTheoId";

                SqlParameter parameter = new SqlParameter("@Id", SqlDbType.VarChar,100);
                parameter.Value = Id;
                comm.Parameters.Add(parameter);

                SqlDataReader reader = comm.ExecuteReader();

                if(reader.Read())
                {
                    objAccount = new Account();
                    objAccount.Id = reader.GetString(reader.GetOrdinal("Id"));
                    objAccount.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objAccount.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                    {
                        objAccount.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Type")))
                    {
                        objAccount.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Salary")))
                    {
                        objAccount.Salary = reader.GetDouble(reader.GetOrdinal("Salary"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DateJoined")))
                    {
                        objAccount.DateJoined = reader.GetDateTime(reader.GetOrdinal("DateJoined"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                    {
                        objAccount.Department = reader.GetString(reader.GetOrdinal("Department"));
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

            return objAccount;
        }

        public bool ThemMoiAccount(Account objAccount)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@Id", SqlDbType.VarChar, 100);
            parameters[0].Value = objAccount.Id;

            parameters[1] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
            parameters[1].Value = objAccount.Password;

            parameters[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameters[2].Value = objAccount.Name;

            parameters[3] = new SqlParameter("@Phone", SqlDbType.VarChar, 100);
            parameters[3].Value = objAccount.Phone;

            parameters[4] = new SqlParameter("@Type", SqlDbType.Int);
            parameters[4].Value = objAccount.Type;

            parameters[5] = new SqlParameter("@Salary", SqlDbType.Float);
            parameters[5].Value = objAccount.Salary;

            parameters[6] = new SqlParameter("@Department", SqlDbType.NVarChar,100);
            parameters[6].Value = objAccount.Department;

            return DataProvider.ThucHien("usp_ThemMoiAccount", parameters, true);
        }

        public bool Sua(Account objAccount)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@Id", SqlDbType.VarChar, 100);
            parameters[0].Value = objAccount.Id;

            parameters[1] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
            parameters[1].Value = objAccount.Password;

            parameters[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameters[2].Value = objAccount.Name;

            parameters[3] = new SqlParameter("@Phone", SqlDbType.VarChar, 100);
            parameters[3].Value = objAccount.Phone;

            parameters[4] = new SqlParameter("@Type", SqlDbType.Int);
            parameters[4].Value = objAccount.Type;

            parameters[5] = new SqlParameter("@Salary", SqlDbType.Float);
            parameters[5].Value = objAccount.Salary;

            parameters[6] = new SqlParameter("@Department", SqlDbType.NVarChar, 100);
            parameters[6].Value = objAccount.Department;

            return DataProvider.ThucHien("usp_SuaAccount", parameters, true);
        }

        //Dang nhap
        public bool Login(string username, string password)
        {
            List<Account> lstAccount = new List<Account>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlParameter[] pars = new SqlParameter[2];
                pars[0] = new SqlParameter("@username", SqlDbType.VarChar, 100);
                pars[0].Value = username;

                pars[1] = new SqlParameter("@password", SqlDbType.VarChar, 100);
                pars[1].Value = password;

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.Parameters.AddRange(pars);
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_AccountLogin";

                SqlDataReader reader = comm.ExecuteReader();

                Account objAccount;

                while (reader.Read())
                {
                    objAccount = new Account();
                    objAccount.Id = reader.GetString(reader.GetOrdinal("Id"));
                    objAccount.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objAccount.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                    {
                        objAccount.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Type")))
                    {
                        objAccount.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Salary")))
                    {
                        objAccount.Salary = reader.GetDouble(reader.GetOrdinal("Salary"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DateJoined")))
                    {
                        objAccount.DateJoined = reader.GetDateTime(reader.GetOrdinal("DateJoined"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                    {
                        objAccount.Department = reader.GetString(reader.GetOrdinal("Department"));
                    }

                    lstAccount.Add(objAccount);
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

            //Neu co 1 account trong danh sach get duoc thi la dung
            if(lstAccount.Count==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         public bool Login(string username, string password)
        {
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@username", SqlDbType.VarChar,100);
            pars[0].Value = username;

            pars[1] = new SqlParameter("@password", SqlDbType.VarChar, 100);
            pars[1].Value = password;

            object obj = DataProvider.ExecuteScalar("usp_AccountLogin", pars, true);

            int ketQua = int.Parse(obj);

            if ( ketQua!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         */
    }
}