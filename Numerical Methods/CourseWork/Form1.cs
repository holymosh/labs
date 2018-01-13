using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public MatrixManager MatrixManager = new MatrixManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void SolveClick(object sender, System.EventArgs e)
        {
            var text = MatrixTextBox.Text;
            eigenValuesTextBox.Text = MatrixManager.ParseAndSolve(text);

        }
    }
}