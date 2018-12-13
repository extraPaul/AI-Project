using NeuralNetwok;
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
using System.Xml.Serialization;
using NAudio;
using NAudio.Wave;

namespace NeuralNetWindowsApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        float[] FFTResult;
        Network nn;
        float weightAdapt;
        float biasAdapt;
        int layers;
        // Recreate the network
        private void trainNetworkBtn_Click(object sender, EventArgs e)
        {
            int[] nodes = { 1, 3, 4, 7, 4, 8};
            weightAdapt = 0.2f;
            biasAdapt = 0.3f;


            if (FFTResult != null)
            {

            }

            // var permTestForm = new PermutationGeneratorTest(this);
            // permTestForm.Show();
            // nodes, weight, bias
            nn = new Network(nodes, weightAdapt, biasAdapt);
            // training here somewhere

            // Save the things after we teach the network that we want
            weightAdapt = nn.nabla;
            biasAdapt = nn.gamma;
            layers = nn.layers.Length;


            //this.Hide();
        }


        private void saveNetworkBtn_Click(object sender, EventArgs e)
        {
            string saveDirectory = @"SavedNetwork.xml";
            FileStream saveStream;
            if (!File.Exists(saveDirectory))
                saveStream = File.Create(saveDirectory);
            else 
                saveStream = File.Open(saveDirectory, FileMode.Open);

            nn.Save(saveStream);

        }

        private void loadNetworkBtn_Click(object sender, EventArgs e)
        {
            string saveDirectory = @"SavedNetwork.xml";
            FileStream saveStream;
            if (File.Exists(saveDirectory))
            {
                saveStream = File.Open(saveDirectory, FileMode.Open);
                Network n = new Network();
                n.Load(saveStream);
            }
        }

        private void loadSoundFileBtn_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                string filePath = fileDialog.FileName;
                AudioFileReader readertest = new AudioFileReader(filePath);
                int bytesnumber = (int)readertest.Length;
                var data = new float[bytesnumber];
                readertest.Read(data, 0, bytesnumber);
                double[] dData = Array.ConvertAll<float, double>(data, x => (double)x);
                NNFFT nfft = new NNFFT();
                nfft.FFT(dData, true);

                Console.WriteLine("DONE!");
               
            }
                

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }


    }
}
