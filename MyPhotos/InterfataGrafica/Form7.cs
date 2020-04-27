using MyPhotos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataGrafica
{
    public partial class Form7 : Form
    {
        public List<MyItems> items;
        public Form7(List<MyItems> MyList)
        {
            InitializeComponent();
            items = MyList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemsServiceClient item = new ItemsServiceClient();

            string flag = "";

            if(checkBox1.Checked == true)
            {
                flag = "1";
            }
            else
                if( checkBox2.Checked == true)
            {
                flag = "2";
            }
            else
            {
                flag = "3";
            }

            this.items = item.SearchByProperty(flag, this.richTextBox1.Text).ToList();
            this.Close();


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
