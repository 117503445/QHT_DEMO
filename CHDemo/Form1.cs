using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Web1.Document.GetElementById("UserName").InnerText = "150101080204";
            Web1.Document.GetElementById("UserPwd").InnerText = "080204";
            //Web1.Document.GetElementById("Validate").InnerText = t.Text;
            //Web1.Document.InvokeScript("fLogin");
        }

        private void Btn2_Click(object sender, EventArgs e)
        {

        }

        private void Web1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Web2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Btn1_Back_Click(object sender, EventArgs e)
        {
            Web1.GoBack();
        }

        private void BtnSentCookie_Click(object sender, EventArgs e)
        {
            Web2.Document.Cookie = Web1.Document.Cookie;
        }
    }
}
