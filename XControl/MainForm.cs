using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MccDaq;

namespace XControl
{
    public partial class MainForm : Form
    {

        PortControl Board = new PortControl();




        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            lblBoardStatus.Text = Board.IsCorrectCreate;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Board.DigitConfiguration();
            lblDigitResult.Text=( Board.DigitInput(int.Parse(tbPortNum.Text))).ToString();
        }
    }
}
