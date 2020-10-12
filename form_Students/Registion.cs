using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace form_Students
{
    public partial class Registion : Form
    {
        SqlConnection sqlconn = new SqlConnection("Data Source=DESKTOP-AQDKBLN;Initial Catalog=Class_Online_V1;Integrated Security=True");
        SqlCommand cmd;
        string imageLocation = "";
        public Registion()
        {
            InitializeComponent();
            SqlDataAdapter SDA = new SqlDataAdapter("select * from [dbo].[tb_class]", sqlconn);
            sqlconn.Open();
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            //comboBox1.Items.Add("Seclect Class ID");
            foreach (DataRow row in dt.Rows)
            {
               class_comBox.Items.Add(row["id_class"].ToString());
            }
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files (*.png)|*.png | jpg files (*.jpg)|*jpg| All files (*.*) | *.*";
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image_picBox.Image = Image.FromFile(imageLocation);
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            byte[] image = null;
            FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brd = new BinaryReader(stream);
            image = brd.ReadBytes((int)stream.Length);
            string sqlQuery = "insert into tb_SV(id_SV, pass_SV, name_SV, image_SV, phoneNum_SV, id_class) values ('" + id_btn.Text + "', '" + pass_btn.Text + "', '" + name_btn.Text + "', @image, '" + phone_btn.Text + "', '" + class_comBox.Text + "')";
            cmd = new SqlCommand(sqlQuery, sqlconn);
            cmd.Parameters.Add(new SqlParameter("@image", image));
            int n = cmd.ExecuteNonQuery();
            MessageBox.Show("ĐĂNG KÝ THÀNH CÔNG");
        }
    }
}
