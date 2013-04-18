using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fogus.saru
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = rtbMain.Font;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                rtbMain.Font = fontDialog.Font;
                fogus.saru.Properties.Settings.Default.font = rtbMain.Font;
                fogus.saru.Properties.Settings.Default.Save();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = rtbMain.ForeColor;
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                rtbMain.ForeColor = colorDialog.Color;
                fogus.saru.Properties.Settings.Default.foreground = rtbMain.ForeColor;
                fogus.saru.Properties.Settings.Default.Save();
            }
        }

        private void backgroundcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = rtbMain.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                rtbMain.BackColor = colorDialog.Color;
                this.BackColor = colorDialog.Color;
                fogus.saru.Properties.Settings.Default.background = rtbMain.BackColor;
                fogus.saru.Properties.Settings.Default.Save();
            }
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Text = "";
            rtbMain.Tag = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtbMain.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    rtbMain.Tag = openFileDialog.FileName.ToString();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Open failed; \n".Insert(14, Ex.ToString()), "Open failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbMain.Tag.ToString().Length == 0)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        rtbMain.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                        rtbMain.Tag = saveFileDialog.FileName.ToString();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Saving failed; \n".Insert(16, Ex.ToString()), "Saving failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                try
                {
                    rtbMain.SaveFile(rtbMain.Tag.ToString(), RichTextBoxStreamType.PlainText);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Saving failed; \n".Insert(16, Ex.ToString()), "Saving failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtbMain.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    rtbMain.Tag = saveFileDialog.FileName.ToString();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Saving failed; \n".Insert(16, Ex.ToString()), "Saving failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            int iX = this.Size.Width;
            int iY = this.Size.Height;

            int xMarginSize = ((iX / 100) * 25) / 2;

            rtbMain.Location = new Point(xMarginSize, 20);
            rtbMain.Width = iX - (xMarginSize * 2);
            rtbMain.Height = iY - 30;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox dlgAbout = new AboutBox();
            dlgAbout.ShowDialog();
        }
    }
}