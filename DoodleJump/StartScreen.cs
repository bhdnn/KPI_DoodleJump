using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            bg.Items.Add("Default");
            bg.Items.Add("Soccer");
            bg.Items.Add("Ninja");
            bg.Items.Add("Night-Ninja");
            bg.SelectedIndex = 0;

            bg.SelectedIndexChanged += new EventHandler(bg_SelectedIndexChanged);
        }

        private void LoadGame(object sender, EventArgs e)
        {
            string selectedBackground = bg.SelectedItem.ToString();
            Form1 gameWindow = new Form1(selectedBackground);
            gameWindow.Show();
        }




        private void StartScreen_Load(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bg_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bg.SelectedItem.ToString())
            {
                case "Default":
                    this.BackgroundImage = Properties.Resources.doodlemenusolo;
                    Play.BackgroundImage = Properties.Resources.play; 
                    break;
                case "Soccer":
                    this.BackgroundImage = Properties.Resources.soccer_menu;
                    Play.BackgroundImage = Properties.Resources.soccer_button; 
                    break;
                case "Ninja":
                    this.BackgroundImage = Properties.Resources.ninja_menu;
                    Play.BackgroundImage = Properties.Resources.playpngpng;
                    break;
                case "Night-Ninja":
                    this.BackgroundImage = Properties.Resources.night_ninja;
                    Play.BackgroundImage = Properties.Resources.playpngpng;
                    break;
                default:
                    this.BackgroundImage = null;
                    Play.BackgroundImage = null; 
                    break;
            }

            this.BackgroundImageLayout = ImageLayout.Stretch;
            Play.BackgroundImageLayout = ImageLayout.Stretch; 
        }

    }
}
