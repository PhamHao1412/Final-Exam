using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2011064226_PhamAnhHao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void LoadData()
        {
            this.employersTableAdapter.Fill(this.employerDataSet1.Employers);
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                employersBindingSource.DataSource = db.Emplist.ToList();
            }
            txtID.Enabled = false;
            panel1.Enabled = false;

        }
        void check()
        {
            int age = int.Parse(txtbirh.Text);
            if(age <=18)
            {
                MessageBox.Show("Bạn phải đủ 18 tuổi trở lên");
            }    
        }    
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            picImage.Image = null;
            panel1.Enabled = true;
            employersBindingSource.Add(new Employer());
            employersBindingSource.MoveLast();
            txtName.Focus();
        }
        private void ValidateEmail()
        {
            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                label4.Text = email + " is Valid Email Address";
            else
                label4.Text = email + " is Invalid Email Address";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            ValidateEmail();
            int age =int.Parse(txtbirh.Text);
            if (age < 18)
            {
                MessageBox.Show("Bạn phải đủ 18 tuổi trở lên");
            }
            else
            {
                using (ApplicationDBContext db = new ApplicationDBContext())
                {
                    Employer stu = employersBindingSource.Current as Employer;
                    if (stu != null)
                    {
                        if (db.Entry<Employer>(stu).State == System.Data.Entity.EntityState.Detached)
                        {
                            db.Set<Employer>().Attach(stu);
                        }
                        if (stu.id == 0)
                        {
                            db.Entry<Employer>(stu).State = System.Data.Entity.EntityState.Added;
                        }
                        else
                        {
                            db.Entry<Employer>(stu).State = System.Data.Entity.EntityState.Modified;
                        }
                        db.SaveChanges();
                        MessageBox.Show(this, "Lưu thành công");
                        dtgvData.Refresh();
                        LoadData();
                        txtID.Enabled = false;
                        btnAdd.Enabled = false;
                        btnDel.Enabled = false;
                        btnEdit.Enabled = false;
                        panel1.Enabled = false;
                    }

                }

            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Imagefile | *.* "
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picImage.Image = Image.FromFile(ofd.FileName);

                    Employer obj = employersBindingSource.Current as Employer;

                    if (obj != null)
                    {
                        obj.image = ofd.FileName;
                    }

                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa dòng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (ApplicationDBContext db = new ApplicationDBContext())
                {
                    Employer stu = employersBindingSource.Current as Employer;
                    if (stu != null)
                    {
                        if (db.Entry<Employer>(stu).State == System.Data.Entity.EntityState.Detached)
                        {
                            db.Set<Employer>().Attach(stu);
                        }
                        db.Entry<Employer>(stu).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        MessageBox.Show(this, "Xóa thành công");
                       employersBindingSource.RemoveCurrent();
                    }
                }
                LoadData();
            }
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employer stu = employerDataSetBindingSource.Current as Employer;
            if (stu != null)
            {
                txtID.Text = dtgvData.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txtName.Text = dtgvData.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txtEmail.Text = dtgvData.Rows[e.RowIndex].Cells[2].Value?.ToString();
                txtPhone.Text = dtgvData.Rows[e.RowIndex].Cells[3].Value?.ToString();
                txtbirh.Text = dtgvData.Rows[e.RowIndex].Cells[5    ].Value?.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtName.Focus();
            Employer stu =employersBindingSource.Current as Employer;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            btnEdit.Enabled = true;
            employersBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
        }
        
    }
}
        
   
            