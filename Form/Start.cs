using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YuGiOh
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }
        private async void start_Load(object sender, EventArgs e)
        {
            await Task.Delay(3000);
           
            this.Close();
        }
    }
}

