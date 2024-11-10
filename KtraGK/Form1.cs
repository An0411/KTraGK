using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtraGK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text;
            string name = txtName.Text;
            string studentClass = txtClass.Text;

            
            if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Mã sinh viên và Họ tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.Cells["studentIDColumn"].Value?.ToString() == studentID)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

           
            dataGridViewStudents.Rows.Add(studentID, name, studentClass);

            
            txtStudentID.Clear();
            txtName.Clear();
            txtClass.Clear();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                dataGridViewStudents.Rows.RemoveAt(dataGridViewStudents.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            
            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                row.Visible = true;
            }

            
            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.Cells["nameColumn"].Value != null && !row.Cells["nameColumn"].Value.ToString().ToLower().Contains(keyword))
                {
                    row.Visible = false;
                }
            }
        }
    }
}
