using NeuralNetwok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetWindowsApp
{
    public partial class PermutationGeneratorTest : Form
    {
        // Keeps the same instance of the home form, instead of constantly deleting and recreating it.
        Home homeForm;
        public PermutationGeneratorTest(Home home)
        {
            InitializeComponent();
            this.homeForm = home;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            var permGenerator = new PermutationGenerator(100, 5, 10, 1, 1, new float[] { 2, 4, 6, 8, 10 });

            resultTxtBox.Lines = permGenerator.iterate(1, (float)0.1, 1, (float)0.1);
        }

        private void PermutationGeneratorTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.homeForm.Show();
        }

        private void PermutationGeneratorTest_Load(object sender, EventArgs e)
        {

        }
    }
}
