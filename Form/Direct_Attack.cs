using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh.Service;

namespace YuGiOh
{
    public partial class Direct_Attack : Form
    {
        BGM bgm = new BGM();
        public Direct_Attack()
        {
            InitializeComponent();
        }

        async private void Direct_Attack_Load(object sender, EventArgs e)
        {
            bgm.StopBGM();
            bgm.PlayEffect("YuGiOh_Life_Point_Mimi");

            await Task.Delay(3000);
            bgm.PlayBGM("BGM05_InGame");
            this.Close();
        }
    }
}
