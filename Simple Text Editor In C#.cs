using System;
using System.Windows.Forms;
using System.IO;

namespace SimpleTextEditor
{
    public partial class MainForm : Form
    {
        private string currentFilePath;

        public MainForm()
        {
            InitializeComponent();
            currentFilePath = null;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            currentFilePath = null;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    textBox.Text = File.ReadAllText(currentFilePath);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath == null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        File.WriteAllText(currentFilePath, textBox.Text);
                    }
                }
            }
            else
            {
                File.WriteAllText(currentFilePath, textBox.Text);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
