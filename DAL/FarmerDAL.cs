using FarmerInformation.Models;
using FarmerInformation.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerInformation.DAL
{
    public class FarmerDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public FarmerDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];

            con = new SqlConnection(constr);
        }
        public int FarmerRegister(Farmer farmer)
        {
            string qry = "insert into Farmer values(@First_name,@Middle_name,@Last_name,@mobile_no,@Addhar_no,@Farmer_Adderess," +
                "@Discrict_name,@Taluka_name,@Village_name,@Password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@First_name", farmer.First_name);
            cmd.Parameters.AddWithValue("@Middle_name", farmer.Middle_name);
            cmd.Parameters.AddWithValue("@Last_name", farmer.Last_name);
            cmd.Parameters.AddWithValue("@mobile_no", farmer.mobile_no);
            cmd.Parameters.AddWithValue("@Addhar_no", farmer.Addhar_no);
            cmd.Parameters.AddWithValue("@Discrict_name", farmer.District_name);
            cmd.Parameters.AddWithValue("@Taluka_name", farmer.Taluka_name);
            cmd.Parameters.AddWithValue("@Farmer_Adderess", farmer.Farmer_Address);
            cmd.Parameters.AddWithValue("@Village_name", farmer.Village_name);
            cmd.Parameters.AddWithValue("@Password", farmer.Password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Farmer FarmerLogin(Farmer farmer)
        {
            Farmer farmers = new Farmer();
            string qry = "select * from Farmer where mobile_no=@mobile_no";
            cmd = new SqlCommand(qry, con);
           // cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("mobile_no", farmer.mobile_no);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    farmer.First_name =dr["First_name"].ToString();
                    farmer.Middle_name = dr["Middle_name"].ToString();
                    farmer.Last_name = dr["Last_name"].ToString();
                    farmer.mobile_no = dr["mobile_no"].ToString();
                    farmer.Addhar_no = dr["Aadhaar_no"].ToString();
                    farmer.District_name = dr["District_name"].ToString();
                    farmer.Taluka_name = dr["Taluka_name"].ToString();
                    farmer.Village_name = dr["Village_name"].ToString();
                    farmer.Password = Convert.ToInt32(dr["Password"]);


                }
                con.Close();
                return farmer;

            }
            else
            {
                return farmer;
            }
        }

        public List<Farmer> GetAllFarmar()
        {
            List<Farmer> farmersList = new List<Farmer>();
            string qry = "select * from Farmer";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Farmer farmer = new Farmer();
                    farmer.First_name = dr["First_name"].ToString();
                    farmer.Middle_name = dr["Middle_name"].ToString();
                    farmer.Last_name = dr["Last_name"].ToString();
                    farmer.mobile_no = dr["mobile_no"].ToString();
                    farmer.Addhar_no = dr["Aadhaar_no"].ToString();
                    farmer.District_name = dr["District_name"].ToString();
                    farmer.Taluka_name = dr["Taluka_name"].ToString();
                    farmer.Village_name = dr["Village_name"].ToString();
                    farmer.Password = Convert.ToInt32(dr["Password"]);
                    farmersList.Add(farmer);

                }
                con.Close();
                return farmersList;

            }
            else
            {
                return null;
            }
        }
    }
}
    

