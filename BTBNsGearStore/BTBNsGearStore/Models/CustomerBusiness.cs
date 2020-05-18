using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class CustomerBusiness
    {
        public List<Customer> LayDanhSachCustomer()
        {
            List<Customer> lstCustomer = new List<Customer>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_LayDanhSachCustomer";

                SqlDataReader reader = comm.ExecuteReader();
                Customer objCustomer;
                while(reader.Read())
                {
                    objCustomer = new Customer();
                    objCustomer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    if(!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        objCustomer.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                    {
                        objCustomer.Email = reader.GetString(reader.GetOrdinal("Email"));
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                    {
                        objCustomer.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Address")))
                    {
                        objCustomer.Address = reader.GetString(reader.GetOrdinal("Address"));
                    }

                    lstCustomer.Add(objCustomer);
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

            return lstCustomer;
        }

        public bool ThemMoiCustomer(Customer objCustomer)
        {
            SqlParameter[] parameter = new SqlParameter[4];

            parameter[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            parameter[0].Value = objCustomer.Name;

            parameter[1] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
            parameter[1].Value = objCustomer.Email;

            parameter[2] = new SqlParameter("@Phone", SqlDbType.VarChar, 100);
            parameter[2].Value = objCustomer.Phone;

            parameter[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 1000);
            parameter[3].Value = objCustomer.Address;

            return DataProvider.ThucHien("usp_ThemMoiCustomer", parameter, true);
        }

        public bool SuaCustomer()
        {
            return false;
        }

        public bool XoaCustomer(int Id)
        {
            SqlParameter[] parameter = new SqlParameter[1];

            parameter[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameter[0].Value = Id;

            return DataProvider.ThucHien("usp_XoaCustomer", parameter, true);
        }
    }
}