using InsureTech.EdModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InsureTech.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidateUser(string userid, string password,bool rememberme)
        {
        
 
            String SqlconString = ConfigurationManager.ConnectionStrings["Db_Insure_TechEntity"].ConnectionString;


            string Response;
            using (SqlConnection sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();



                SqlCommand sql_cmnd = new SqlCommand("spt_login", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = userid;
                sql_cmnd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = password;
                sql_cmnd.ExecuteNonQuery();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sql_cmnd);
                DataSet ds = new DataSet();
                
                sqlAdapter.Fill(ds);



                DataTable firstTable = ds.Tables[0];
                Response = firstTable.Rows[0]["Response"].ToString();



                sqlCon.Close();
            }

            return Json(new { Response = Response });
        }
        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
