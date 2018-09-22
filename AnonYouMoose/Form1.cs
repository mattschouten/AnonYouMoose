using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonYouMoose
{
    public partial class Form1 : Form
    {
        String[] paths = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop)) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            paths = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                paths = (String[])e.Data.GetData(DataFormats.FileDrop);
                RefreshState();
                
            }
        }

        private void RefreshState()
        {
            SetTargetText();
            SetButtonEnabled();
        }

        private void SetTargetText()
        {
            if (paths == null || paths.Length == 0) {
                txtPath.Text = "";
                return; 
            }

            String targetText = paths[0];
            if (paths.Length > 1)
            {
                targetText = string.Format("{0} (+ {1} others)", targetText, paths.Length - 1);
            }

            txtPath.Text = targetText;
        }

        private void SetButtonEnabled()
        {
            btnAnonymize.Enabled = (paths != null && paths.Length > 0);
        }

        private void btnAnonymize_Click(object sender, EventArgs e)
        {
            WordAnonymizer w = new WordAnonymizer();
            w.Anonymize(paths);
        }
    }
}
