using Projeto_SIGMA.Telas.TelasDeLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SIGMA
{
    public partial class frmCarregar : Form
    {
        public frmCarregar()
        {
            InitializeComponent();
            timerProgress.Start();
        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timerProgress.Stop();
                frmLogin tela = new frmLogin();
                tela.Show();
                this.Hide();
            }
        }
    }
}
