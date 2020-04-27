using MyPhotos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace InterfataGrafica
{
    public partial class Form3 : Form
    {
        private bool IsPhoto;
        private string Location;
        private string Event;
        private string Description;
        private string path;
        private ItemsServiceClient context;



        public Form3()
        {
            InitializeComponent();
           
            context = new ItemsServiceClient();

            var codecs = ImageCodecInfo.GetImageEncoders();
            var codecFilter = "Image Files|";
            foreach (var codec in codecs)
            {
                codecFilter += codec.FilenameExtension + ";";
            }
        
                // and video
                openFileDialog1.Filter = codecFilter + "| All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
                if (path == null)
                {
                    return;
                }

            
            
                
                textBox2.Text = path;
            
        }

        public Form3(string path)
        {
            InitializeComponent();
            context = new ItemsServiceClient();
            this.path = path;
            textBox2.Text = path;
            context.RemoveWithPath(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                this.IsPhoto = true;
            }
            else
            {
                this.IsPhoto = false;
            }

            if (textBox1.Text != null)
            {
                this.Event = textBox1.Text;
            }
            else
            {
                this.Event = "";
            }

            if (textBox3.Text != null)
            {
                this.Location = textBox3.Text;
            }
            else
            {
                this.Location = "";
            }

            if (richTextBox1.Text != null)
            {
                this.Description = richTextBox1.Text;
            }
            else
            {
                this.Description = "";
            }

            MyItems item = new MyItems();

            item.IDescription = this.Description;
            if (IsPhoto == true)
            {
                item.IIsPhoto = "true";
            }
            else
            {
                item.IIsPhoto = "false";
            }
            item.IMark = "false";
            item.IDelete = "false";
            item.IDate = DateTime.Now.ToString();



            item.IPath = path;

            string[] directories = path.Split(System.IO.Path.DirectorySeparatorChar);
            item.IName = directories[directories.Length - 1];

            item.IType = System.IO.Path.GetExtension(path);

            context.AddItems(item, this.Event, this.Location);
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
