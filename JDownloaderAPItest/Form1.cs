﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using jDownloaderRemoteControlAPI;

namespace JDownloaderAPItest
{
    public partial class Form1 : Form
    {
        jDownloaderRemoteControlAPI.jDownloaderRemoteControlAPI jd;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sHost = txtHost.Text;
            int iPort = 10025;
            try { iPort = int.Parse(txtPort.Text); }
            catch (Exception) { }
            jd = new jDownloaderRemoteControlAPI.jDownloaderRemoteControlAPI(sHost, iPort);
            jDownloaderRemoteControlAPI.DownloadStatus status = jd.DownloadStatus;
            lblStatus.Text = status.ToString();

            int i = jd.CountAllDownloads;
            addLog("All download count = " + i.ToString());
            List<String> sd = jd.AllDownloads;
            string sXml="";
            foreach (string s in sd)
            {
                sXml += s;
//                addLog(s);
            }
            jdownloaderPackage jp;
            jp = (jdownloaderPackage) jdownloaderPackage.DeserializeFromXmlString(sXml, typeof(jdownloaderPackage));
            foreach (jDownloaderRemoteControlAPI.package p in jp.package)
            {
                addLog("package: " + p.package_name+ "("+p.package_percent.ToString()+")");
                foreach (jDownloaderRemoteControlAPI.file f in p.file)
                {
                    addLog("\t" + f.file_name);
                }
            }
        }
        delegate void SetTextCallback(string text);
        public void addLog(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //if (txtLog.Text.Length > 2000) txtLog.Text = "";
                txtLog.Text += text + "\r\n";
                txtLog.SelectionLength = 0;
                txtLog.SelectionStart = txtLog.Text.Length - 1;
                txtLog.ScrollToCaret();
            }
        }
    }
}