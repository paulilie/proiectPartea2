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
using MyPhotos;

namespace InterfataGrafica
{
    public partial class Form1 : Form
    {
        private readonly ItemsService Service;
        

        public Form1()
        {
            InitializeComponent();
            Service = new ItemsService();
            this.dataGridView1.DataSource = Service.GetItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 NewSlide = new Form3();
            NewSlide.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = Service.GetItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyItems item = (MyItems)this.dataGridView1.CurrentRow.DataBoundItem;
            if (File.Exists(item.IPath))
            {
                if (item.IIsPhoto == "true")
                {
                    Form4 NewSlide = new Form4(item.IPath);
                    NewSlide.ShowDialog();
                }
                else
                {
                    Form2 NewSlide = new Form2(item.IPath);
                    NewSlide.ShowDialog();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             MyItems move= new MyItems();
            move = (MyItems)this.dataGridView1.CurrentRow.DataBoundItem;
            Form5 NewSlide = new Form5( move.IPath);
            NewSlide.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form6 NewSlide = new Form6((MyItems)this.dataGridView1.CurrentRow.DataBoundItem);
            NewSlide.ShowDialog();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            MyItems delete = (MyItems)this.dataGridView1.CurrentRow.DataBoundItem;
            Service.MarkToDelete(delete.IPath);
            this.dataGridView1.DataSource = Service.GetItems();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyItems delete = (MyItems)this.dataGridView1.CurrentRow.DataBoundItem;
            if ( delete.IMark == "true")
            {
                Service.Remove(delete);
            }
            this.dataGridView1.DataSource = Service.GetItems();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 NewSlide = new Form7((List<MyItems>)dataGridView1.DataSource);
            
            if(NewSlide.ShowDialog() != DialogResult.OK)
            {
                this.dataGridView1.DataSource = NewSlide.items;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyItems item = (MyItems)this.dataGridView1.CurrentRow.DataBoundItem;
            Form3 NewSlide = new Form3(item.IPath);
            NewSlide.ShowDialog();

        }
    }
}
