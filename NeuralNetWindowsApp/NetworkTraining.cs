//using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetWindowsApp
{
    public partial class NetworkTraining : Form
    {
        Home homeForm;
        public NetworkTraining(Home home)
        {
            InitializeComponent();
            homeForm = home;
        }

        private void pickFileBtn_Click(object sender, EventArgs e)
        {
            SoundPlayer soundPlayer;
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                
                
                // From example online
                //System.IO.FileInfo File = new FileInfo(FD.FileName);
                //OR
                //System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);

               // var reader = new WaveFileReader(FD.FileName);
                
            }
        }

        private void NetworkTraining_FormClosing(object sender, FormClosingEventArgs e)
        {
            homeForm.Show();
        }
    }
}
