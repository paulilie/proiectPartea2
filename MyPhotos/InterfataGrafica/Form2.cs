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
    public partial class Form2 : Form
    {
        public Form2(string path)
        {
            InitializeComponent();
            this.axWindowsMediaPlayer1.URL = path;
            this.axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.close();
            this.Close();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
