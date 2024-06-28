using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YuGiOh.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YuGiOh
{
    public partial class register : Form
    {
        MySQLHandler handler;
        public register()
        {
            InitializeComponent();
            handler = new MySQLHandler();
        }

        private void bt_enter_Click(object sender, EventArgs e)
        {
            if (rd_agreed.Checked)
            {
                string id = tb_Id1.Text;
                string name = tb_name1.Text;
                string password = tb_Id2.Text;
                string email = tb_mail1.Text + cb_mail.Text;
                string phone = tb_phone.Text;

                if (IsInput(id, name, password, email, phone))
                {
                    handler.RegisterMember(id, password, name, phone, email);
                    MessageBox.Show("회원가입에 성공하셨습니다.");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("입력된 정보가 유효하지 않거나 빠진 항목이 있습니다.");
                }
            }
            else
            {
                MessageBox.Show("회원가입에 동의하지 않으셨습니다.");
                MessageBox.Show("응모해주세요.");
            }
        }

        private bool IsInput(string id, string name, string password, string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("모든 항목을 입력해주세요.");
                return false;
            }

            if (id.Length < 2 || id.Length > 8)
                return false;
            if (name.Length < 2)
                return false;
            if (password.Length < 4 || password.Length > 12)
                return false;

            // 이메일에 특수 기호가 있는지 확인
            foreach (char c in email)
            {
                if (!char.IsLetterOrDigit(c) && c != '@' && c != '.')
                {
                    MessageBox.Show("이메일에 특수 기호를 사용할 수 없습니다.");
                    return false;
                }
            }

            // 이메일 콤보박스 선택 확인
            if (cb_mail.SelectedIndex == -1)
            {
                MessageBox.Show("이메일 도메인을 선택해주세요.");
                return false;
            }

            return true;
        }

        private void bt_enter2_Click(object sender, EventArgs e)
        {
            if (rd_agreed2.Checked)
            {
                MessageBox.Show("정보이용 동의에 동의하셨습니다.");
            }
            else if (rd_noagreed2.Checked)
            {
                MessageBox.Show("정보이용 동의에 동의하지 않으셨습니다.");
            }
            else
            {
                MessageBox.Show("정보이용 동의 여부를 선택해주세요.");
            }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

