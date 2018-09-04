﻿
using System;
using System.Windows.Forms;

namespace ServiceHost
{
    public partial class HostController : Form
    {
        private static ServiceMethods serviceMethods { set; get; }
        public HostController()
        {
            InitializeComponent();
        }
        private void btnOpenHost_Click(object sender, EventArgs e)
        {
            serviceMethods = new ServiceMethods();
            serviceMethods.start(btnOpenHost);//开启服务
            txtOrder.Text= "已启动服务";
            //&btnOpenHost	    0x04c0a7d0	    System.Windows.Forms.Button&*
            //&f	                        0x0963e4cc	    System.Windows.Forms.Button&*
            //serviceMethods对象中start方法用于接收一个Button对象，但是此处btnOpenHost的地址和start方法接收的对象地址不一样。          
        }

        private void txtOrder_TextChanged(object sender, EventArgs e)
        {
            if (txtOrder.Text != null & serviceMethods != null)
            {
                serviceMethods.refresh(txtOrder.Text);//文字更改后，自动更新命令。
            }
        }

        private void btnTestWriteIn_Click(object sender, EventArgs e)
        {
            if (serviceMethods == null)
            {
                serviceMethods = new ServiceMethods();
                serviceMethods.start(btnOpenHost);//开启服务
                serviceMethods.ParallelTest();
            }
        }
    }
}
