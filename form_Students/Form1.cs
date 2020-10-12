using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace form_Students
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AQDKBLN;Initial Catalog=Class_Online_V1;Integrated Security=True");

            try
            {
                conn.Open();
                string tk = id_SV_txt.Text;
                string mk = pass_txt.Text;
                String sql = "select id_SV, pass_SV from tb_SV where id_SV= '" + tk + "' and pass_SV= '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sqlData = cmd.ExecuteReader();
                if (sqlData.Read() == true)
                {
                    FaceDetection open = new FaceDetection();
                    open.Show();
                    Login close = new Login();
                    close.Close();
                    MessageBox.Show("Dang nhap thanh cong");
                }
                else
                {
                    MessageBox.Show("Dang nhap that bai");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connect fail");
            }

            
        }

        private void res_btn_Click(object sender, EventArgs e)
        {
            Registion rg = new Registion();
            rg.Show();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}
