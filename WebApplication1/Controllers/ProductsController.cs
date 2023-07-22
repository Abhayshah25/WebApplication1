using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public string str = "";
        SqlConnection con;
        IConfiguration Adoconfig;

        public ProductsController(IConfiguration c)
        {
            Adoconfig = c;
            str = c.GetConnectionString("Constr");
            con = new SqlConnection();
            con.ConnectionString = str;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductAbhay>> Getdetails()
        {
            SqlCommand cmd = new SqlCommand("select * from ProductAbhay", con);
            SqlDataReader dr;
            con.Open();
            List<ProductAbhay> lst = new List<ProductAbhay>();
            ProductAbhay obj = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

            
            while (dr.Read())
            {
                obj = new ProductAbhay();
                obj.Productid = System.Convert.ToInt32(dr[0]);
                obj.Name = dr[1].ToString();
                obj.Description = dr[2].ToString();
                obj.Price = System.Convert.ToInt32(dr[4]);
                obj.Category = dr[5].ToString();
                    lst.Add(obj);
                
            }
           }
            else
            {
                lst = null;
                return NotFound(lst);
            }
            return Ok(lst);
        }
        [HttpPost]
        public string CreateRecord(int a,string b ,string c,float d, string e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ProductAbhay values (@p1,@p2,@p3,@p4,@p5)";
            cmd.Parameters.Add(new SqlParameter("p1", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("p2", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("p3", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("p4", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("p5", SqlDbType.VarChar));
            cmd.Parameters["p1"].Value = a;
            cmd.Parameters["p2"].Value = b;
            cmd.Parameters["p3"].Value = c;
            cmd.Parameters["p4"].Value = d;
            cmd.Parameters["p5"].Value = e;
            cmd.Connection.Open();
            int ans = cmd.ExecuteNonQuery();
            return ans.ToString() + "Record inserted";
        }

        [HttpDelete]
        public string DeleteRecord(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.CommandText = "delete from ProductAbhay where Productid=@p1";
            cmd.Parameters.Add(new SqlParameter("p1", SqlDbType.Int));
            cmd.Parameters["p1"].Value = id;
            int ans = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (ans == 0)
                return "no record deleted";
            else
                return ans.ToString() + "Record Deleted";
        }

        [HttpPut]
        public string PutRecords(int a, string b, string c, float d, string e) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.CommandText = "Update ProductAbhay set Name=@p1,Description=@p2,Price=@p3,Category=@p4 where Productid=@p5";
            cmd.Parameters.Add(new SqlParameter("p2", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("p3", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("p4", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("p5", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("p1", SqlDbType.Int));
            cmd.Parameters["p2"].Value = b;
            cmd.Parameters["p3"].Value = c;
            cmd.Parameters["p4"].Value = d;
            cmd.Parameters["p5"].Value = e;
            cmd.Parameters["p1"].Value = b;
            int ans = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (ans == 0)
                return "Record not found";
            else
                return ans.ToString() + "Record Inserted";
        }
        [HttpGet("Specific")]
        public ProductAbhay SpecificRecord(int Productid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from ProductAbhay where Productid=@p1";
            cmd.Parameters.Add(new SqlParameter("p1", SqlDbType.Int));
            cmd.Parameters["p1"].Value=Productid;
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ProductAbhay obj = null;
            bool ans = dr.Read();
            if(ans)
            {
                obj = new ProductAbhay();
                obj.Productid = System.Convert.ToInt32(dr[0]);
                obj.Name = dr["Name"].ToString();
                obj.Description = dr[2].ToString();
                obj.Price = System.Convert.ToSingle(dr[3]);
                obj.Category = dr[4].ToString();

            }
            return obj;
        }










        /*  
        [HttpGet{("id")}]
        public async Task<ActionResult<ProductAbhay>> GetProductbyId(int id)
        {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        cmd.Connection= con;
        cmd.CommandType = "select * from ProductAbhay where Productid=@p1";
        cmd.Parameters.Add(new SqlParameter("p1", id));
        con.open();
        await Task.Run(() =>
        {
            SqlDataReader dr = cmd.ExecuteReader();
        });
        ProductAbhay pa = null;

    }*/

    }
}
