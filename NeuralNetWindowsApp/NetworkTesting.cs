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
    public partial class NetworkTesting : Form
    {
        Home homeForm;
        public NetworkTesting(Home home)
        {
            InitializeComponent();
            homeForm = home;
        }
    }
}
