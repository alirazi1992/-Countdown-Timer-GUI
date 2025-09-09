using System;
using System.Windows.Forms;

namespace CountdownTimerGUI
{
    public partial class Form1 : Form
    {
        private int _timeLeft; // in seconds

        public Form1()
        {
            InitializeComponent();
            lblTimer.Text = "00:00";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int minutes, seconds;

            if (!int.TryParse(txtMinutes.Text, out minutes)) minutes = 0;
            if (!int.TryParse(txtSeconds.Text, out seconds)) seconds = 0;

            _timeLeft = minutes * 60 + seconds;

            if (_timeLeft <= 0)
            {
                MessageBox.Show("Please enter a valid time.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            timer.Interval = 1000;
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            _timeLeft = 0;
            lblTimer.Text = "00:00";
            txtMinutes.Clear();
            txtSeconds.Clear();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft--;
                int minutes = _timeLeft / 60;
                int seconds = _timeLeft % 60;
                lblTimer.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                timer.Stop();
                lblTimer.Text = "00:00";
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("⏰ Time’s up!", "Countdown Finished",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
