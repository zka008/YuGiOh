using System;
using System.Media;
using System.Windows.Forms;

namespace YuGiOh.Service
{
    public class BGM
    {
        public SoundPlayer BackGroundMusic;

        public BGM()
        {
            BackGroundMusic = new SoundPlayer();
        }

        public void PlayBGM(string fileName) //음악 재생 메서드
        {
            try
            {
                var stream = Properties.Resources.ResourceManager.GetStream(fileName);
                BackGroundMusic.Stream = stream;
                BackGroundMusic.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while playing background music: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void StopBGM() //음악 중지 메서드
        {
            try
            {
                BackGroundMusic.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while stopping background music: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PlayEffect(string fileName) //음악 재생 메서드
        {
            try
            {
                var stream = Properties.Resources.ResourceManager.GetStream(fileName);
                BackGroundMusic.Stream = stream;
                BackGroundMusic.Play();  // PlayLooping 대신 Play 사용
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while playing background music: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
