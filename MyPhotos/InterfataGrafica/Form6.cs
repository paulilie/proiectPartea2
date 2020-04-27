using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyPhotos;

namespace InterfataGrafica
{
    public partial class Form6 : Form
    {
        public Form6(MyItems CurentItem)
        {
            InitializeComponent();
            this.textBox1.Text = CurentItem.IPath;
            this.textBox2.Text = CurentItem.IName;
            if (CurentItem.IIsPhoto == "true")
            {
                this.textBox3.Text = "Foto";
            }
            else
            {
                this.textBox3.Text = " Video";
            }
            this.textBox4.Text = CurentItem.IDate;
            this.textBox6.Text = CurentItem.IType;
            ItemsServiceClient service=new ItemsServiceClient();
            var PlaceItem = service.getPlaceByItem(CurentItem.IPath);
            var EventItem= service.getEventByItem(CurentItem.IPath);
            if (EventItem != null)
            {
                this.textBox7.Text = EventItem.EName;
            }
            if (PlaceItem != null)
            {
                this.textBox5.Text = PlaceItem.PName;
            }
            this.richTextBox1.Text = CurentItem.IDescription;

            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
