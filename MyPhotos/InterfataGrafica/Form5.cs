using MyPhotos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataGrafica
{
    public partial class Form5 : Form
    {
        public Form5(string path)
        {
            InitializeComponent();
            this.richTextBox1.Text = path;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.richTextBox2.Text != null )
            {
                ItemsServiceClient service = new ItemsServiceClient();
                service.Move(richTextBox1.Text, richTextBox2.Text);
            }
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
