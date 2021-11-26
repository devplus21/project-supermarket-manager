﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.DAO;

namespace WindowsFormsApp
{
    public partial class FormDoiMatKhauMoi : Form
    {
        private string tk;
        public FormDoiMatKhauMoi(string tk)
        {
            InitializeComponent();
            this.tk = tk;
            txTentaikhoan.Text = tk;
        }

        private bool check_data()
        {
            if (string.IsNullOrEmpty(txtmkMoi.Text))
            {
                return false;
            }
            return true;
        }



        bool Login(string userName, string passWord)
        {
            return QuanLyNhanVien.Intance.Login(userName, passWord);
        }

        bool Doimkmoi(string userName, string passWord)
        {
            return QuanLyNhanVien.Intance.capnhatmk1(userName, passWord);
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check_data() == true)
            {
                string tenDangNhap = txTentaikhoan.Text;
                string passWord = txtMKcu.Text;
                if (Login(tenDangNhap, passWord))
                {
                    string mkmoi = txtmkMoi.Text;
                    string tentk = txTentaikhoan.Text;
                    if (txtmkMoi.Text == txtXacnhan.Text)
                    {
                        Doimkmoi(mkmoi, tentk);
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Mật khẩu xác nhận không đúng", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo");
                }

            }
            else
            {
                MessageBox.Show("Mật khẩu mới không được trống", "Thông báo");
            }
        }

        private void chkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThiMK.Checked == true)
            {
                txtMKcu.PasswordChar = '\0';
                txtmkMoi.PasswordChar = '\0';
                txtXacnhan.PasswordChar = '\0';
            }
            else
            {
                txtMKcu.PasswordChar = '*';
                txtmkMoi.PasswordChar = '*';
                txtXacnhan.PasswordChar = '*';
            }

        }
    }
}