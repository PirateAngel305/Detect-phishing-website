﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MyProject
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = desktop-i7io25e ; Initial Catalog=phishing ; Integrated Security = true;";
                con.Open();
                string query = "select * from AdminLogin where Admin_Id= @adminid and Password = @password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@adminid", TextBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@password", TextBox2.Text));
                SqlDataReader DR = cmd.ExecuteReader();

                if (DR.Read())
                {


                    Session["adminid"] = DR["Admin_Id"];
          
                    Response.Redirect("View List.aspx");
                }
                else
                {
                    Response.Redirect("Error.aspx");
                }

                con.Close();

            }
            catch (Exception z)
            {
                Response.Write(z.Message);
            }
        }
    }
    }