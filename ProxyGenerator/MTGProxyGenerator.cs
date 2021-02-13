using ProxyGenerator.Models;
using ProxyGenerator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyGenerator
{
    public partial class MTGProxyGenerator : Form
    {
        public MTGProxyGenerator()
        {
            InitializeComponent();
            SetMessage();
        }

        public List<CardRecord> Cards { get; set; }
        public string SavePath { get; set; }
        private void importButton_Click(object sender, EventArgs e)
        {
        }

        private void SetMessage()
        {
            messageLabel.ForeColor = Color.Black;
            if(string.IsNullOrEmpty(SavePath))
            {
                messageLabel.Text = "Awaiting save path";
            }
            else if (string.IsNullOrEmpty(decklistTextBox.Text))
            {
                messageLabel.Text = "Enter decklist and press go";
            }
            else
            {
                messageLabel.Text = "Ready to go";
            }
        }

        private void destinationButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SavePath = fbd.SelectedPath;
                    SetMessage();
                }
            }
        }

        private async void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                var text = decklistTextBox.Text;
                Cards = ProxyService.ParseImport(text);
                messageLabel.Text = "Running";
                loadingBox.Visible = true;
                await ProxyService.RunAsync(Cards, SavePath);
                loadingBox.Visible = false;
                messageLabel.Text = "Finished";
                messageLabel.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                messageLabel.Text = $"Error";
                messageLabel.ForeColor = Color.Red;
                loadingBox.Visible = false;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cards = null;
            }
        }
    }
}
