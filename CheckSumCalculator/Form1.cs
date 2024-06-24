using System.IO;

namespace CheckSumCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "All (*.*)";
            
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                textBox1.Text = path;
                textBox1.Enabled = false;
                button2.Enabled = true;
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (File.Exists(textBox1.Text))
                {
                    button2.Enabled = true;
                    textBox1.Enabled=false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Checksum.CalcCRC32(textBox1.Text).ToString();
        }
    }
}