﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod_Winform_Use1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CommonMethod.Common_Web.HttpPost(textBox1.Text, textBox2.Text.Trim()));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "音频文件(*.wav)|*.wav|所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                MessageBox.Show(file);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strResult = CommonMethod.Common_Web.HttpGet("http://localhost:4827/SK3000WebServiceCore/api/DataBase/GetData?ExecSQL=SELECT * FROM 报警基本信息", "");
            SKWebDataInterFace.SKJsonResult result = JsonConvert.DeserializeObject<SKWebDataInterFace.SKJsonResult>(strResult);
            DataTable result1 = (DataTable)result.Content;
        }
    }
}
