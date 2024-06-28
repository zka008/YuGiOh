using System.Runtime.CompilerServices;
using YuGiOh.Properties;
using System.Media;
using YuGiOh.Service;

namespace YuGiOh
{
    public partial class Init : Form
    {
        BGM bgm;
        public Init()
        {
            InitializeComponent();
            bgm = new BGM();
        }
        private async void Init_Click(object sender, EventArgs e)
        {
           
            Loading loadingForm = new Loading();
            loadingForm.StartPosition = FormStartPosition.CenterScreen;   
            loadingForm.Show();
       
            await Task.Delay(2500);
    
            loadingForm.Close();
            
            this.Close();
            //Login login = new Login();  
            //login.Show();
        }
        private void Init_Load(object sender, EventArgs e)
        {

            bgm.PlayBGM("BGM01_Init");
        }
    }
}
