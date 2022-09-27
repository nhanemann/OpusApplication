using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = UserRole.SelectedIndex;
            RoleQs.Visible = (selected != 0) ? true : false;
            LabelReception.Visible = (selected == 1 || selected == 2) ? true : false;
            UserReception.Visible = (selected == 1 || selected == 2) ? true : false;
            LabelShirt.Visible = (selected == 1) ? true : false;
            UserTShirt.Visible = (selected == 1) ? true : false;
            LabelDiet.Visible = (selected != 0) ? true : false;
            UserFood.Visible = (selected != 0) ? true : false;
            LabelCompany.Visible = (selected == 3) ? true : false;
            UserCompany.Visible = (selected == 3) ? true : false;
            LabelRegion.Visible = (selected == 2) ? true : false;
            UserRegion.Visible = (selected == 2) ? true : false;
            ButtonSubmit.Visible = (selected != 0) ? true : false;

            UserReception.SelectedIndex = 0;
            UserTShirt.SelectedIndex = 0;
            UserFood.Text = "";
            UserCompany.Text = "";
            UserRegion.SelectedIndex = 0;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            DataTransit submit = new DataTransit(UsernameText.Text, UserTitleText.Text, UserFirstText.Text,
                UserMiddleText.Text, UserLastText.Text, UserEmail.Text, UserPhone.Text, UserBlah.Text,
                UserRole.SelectedIndex, UserReception.SelectedIndex, UserTShirt.SelectedIndex,
                UserFood.Text, UserCompany.Text,UserRegion.SelectedIndex);

            LabelUhOh.Text = submit.Save();
        }

        private class DataTransit
        {

            private string uname;
            private string title;
            private string fname;
            private string minit;
            private string lname;
            private string email;
            private string phone;
            private string color;
            private int role;
            private bool reception;
            private int tshirt = 0;
            private string diet;
            private string company;
            private int region;


            private string emessage = "";

            private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\N\\source\repos\\WebApplication3\\WebApplication3\\App_Data\\Database1.mdf;Integrated Security=True";


            public DataTransit(string u, string t, string f, string m, string l, string e, string p, string c, int r, int re, int ts, string di, string com, int reg)
            {
                uname = u;
                title = t;
                fname = f;
                minit = m;
                lname = l;
                email = e;
                phone = new string(p.Where(x => char.IsDigit(x)).ToArray());
                color = c;
                role = r;
                reception = (re == 1) ? true : false;
                tshirt = ts;
                diet = di;
                company = com;
                region = reg;
            }

            public string Save()
            {
                if (!AvailableEntry())
                {
                    return "Too many people are already registered!";
                }
                if (!Validate()) return emessage;

                Send();
                emessage = "Successfully registered!";
                return emessage;
            }

            private bool Validate()
            {
                if (title.Length > 10)
                {
                    emessage = "Invalid personal title";
                    return false;
                }
                if (fname.Length > 64 || fname.Length < 1)
                {
                    emessage = "Invalid first name";
                    return false;
                }
                if (lname.Length > 64 || lname.Length < 1)
                {
                    emessage = "Invalid last name";
                    return false;
                }
                if (minit.Length > 2)
                {
                    emessage = "Middle initial is too long";
                    return false;
                }
                if (!validEmail())
                {
                    emessage = "Invalid email";
                    return false;
                }
                if (phone.Length != 10)
                {
                    emessage = "Invalid phone number";
                    return false;
                }
                if (color.Length > 64)
                {
                    emessage = "Invalid color - how did you even trigger this error? What were you trying to prove?";
                    return false;
                }
                if (role < 1 || role > 3)
                {
                    emessage = "No role selected";
                    return false;
                }
                if (tshirt > 4 || (tshirt < 1 && role == 1))
                {
                    emessage = "No role selected";
                    return false;
                }
                if (diet.Length > 500)
                {
                    emessage = "Your dietary restrictions may be too much for this form to handle.\n" +
                        "Please contact the event administrators separately.";
                    return false;
                }
                if (company.Length > 64 || (company.Length < 1 && role == 3))
                {
                    emessage = "Invalid company";
                    return false;
                }
                if (region > 3 || (region < 1 && role == 2))
                {
                    emessage = "Invalid region";
                    return false;
                }

                return CheckUname();
            }

            private bool validEmail()
            {
                try
                {
                    MailAddress m = new MailAddress(email);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            private bool CheckUname()
            {
                if (uname.Length > 24 || uname.Length < 3)
                {
                    emessage = "Invalid username length";
                    return false;
                }

                int count = 0;
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\N\\source\\repos\\WebApplication3\\WebApplication3\\App_Data\\Database1.mdf;Integrated Security=True";

                    con.Open();

                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE username = @uname;", con);
                    command.Parameters.AddWithValue("@uname", uname);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        count = dataReader.GetInt32(0);
                    }

                    con.Close();
                }
                if (count != 0)
                {
                    emessage = "Username is already in use.";
                    return false;
                }
                return true;
            }

            private bool Send()
            {
                string sql = "INSERT INTO [Table] VALUES (@username, @firstname, @lastname, @middleinitial, @title, @role, @reception, @tshirt, @diet, @sponsor, @region,@email,@phone,@color)";
                
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\N\\source\\repos\\WebApplication3\\WebApplication3\\App_Data\\Database1.mdf;Integrated Security=True";
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.AddWithValue("@username", uname);
                    command.Parameters.AddWithValue("@firstname", fname);
                    command.Parameters.AddWithValue("@lastname", lname);
                    command.Parameters.AddWithValue("@middleinitial", minit);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@reception", reception);
                    command.Parameters.AddWithValue("@tshirt", tshirt);
                    command.Parameters.AddWithValue("@diet", diet);
                    command.Parameters.AddWithValue("@sponsor", company);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@color", color);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        emessage = "Error inserting data. Username may be taken?";
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                return true;
            }

            private bool AvailableEntry()
            {
                int count = 0;
                //True if <20 entries, false else
                using(SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\N\\source\\repos\\WebApplication3\\WebApplication3\\App_Data\\Database1.mdf;Integrated Security=True";

                    con.Open();

                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table];", con);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        count = dataReader.GetInt32(0);
                    }

                    con.Close();
                }

                if (count > 19)
                    return false;

                return true;
            }
        }
    }
}