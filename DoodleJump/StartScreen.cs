using System;
using System.Windows.Forms;
using DoodleJump.Classes;

namespace DoodleJump
{
    public partial class StartScreen : Form
    {
        private GameData gameData;

        public StartScreen()
        {
            InitializeComponent();
            gameData = SaveSystem.Load();  
            InitializeComboBox();
            UpdateCoinsLabel();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            gameData = SaveSystem.Load();
            UpdateCoinsLabel();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            bg.Items.Clear();
            bg.Items.Add("Default");

            if (gameData.soccerUnlocked)
                bg.Items.Add("Soccer");

            if (gameData.ninjaUnlocked)
                bg.Items.Add("Ninja");

            if (gameData.nightNinjaUnlocked)
                bg.Items.Add("Night-Ninja");

            bg.SelectedIndex = 0;
            bg.SelectedIndexChanged += new EventHandler(bg_SelectedIndexChanged);
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

        private void LoadGame(object sender, EventArgs e)
        {
            this.Hide();

            string selectedBackground = bg.SelectedItem.ToString();
            Form1 gameWindow = new Form1(selectedBackground)
            {
                Owner = this
            };

            gameWindow.Show();
        }

        private void buySoccerButton_Click(object sender, EventArgs e)
        {
            GameData gameData = SaveSystem.Load();

            if (gameData.coins >= 20 && !gameData.soccerUnlocked)
            {
                gameData.coins -= 20;
                gameData.soccerUnlocked = true;
                SaveSystem.Save(gameData);

                MessageBox.Show("Скін Soccer розблокований!", "Успішно");

                if (!bg.Items.Contains("Soccer"))
                    bg.Items.Add("Soccer");

                UpdateCoinsLabel();
            }
            else if (gameData.soccerUnlocked)
            {
                MessageBox.Show("Цей скін вже розблокований.", "Інфо");
            }
            else
            {
                MessageBox.Show("Недостатньо монет для купівлі.", "Помилка");
            }
        }

        private void buyNinja_Click(object sender, EventArgs e)
        {
            GameData gameData = SaveSystem.Load();

            if (gameData.coins >= 30 && !gameData.ninjaUnlocked)
            {
                gameData.coins -= 30;
                gameData.ninjaUnlocked = true;
                SaveSystem.Save(gameData);

                MessageBox.Show("Скін Ninja розблокований!", "Успішно");

                if (!bg.Items.Contains("Ninja"))
                    bg.Items.Add("Ninja");

                UpdateCoinsLabel();
            }
            else if (gameData.ninjaUnlocked)
            {
                MessageBox.Show("Цей скін вже розблокований.", "Інфо");
            }
            else
            {
                MessageBox.Show("Недостатньо монет для купівлі.", "Помилка");
            }
        }

        private void buyNightNinja_Click(object sender, EventArgs e)
        {
            GameData gameData = SaveSystem.Load();

            if (gameData.coins >= 50 && !gameData.nightNinjaUnlocked)
            {
                gameData.coins -= 50;
                gameData.nightNinjaUnlocked = true;
                SaveSystem.Save(gameData);

                MessageBox.Show("Скін Night-Ninja розблокований!", "Успішно");

                if (!bg.Items.Contains("Night-Ninja"))
                    bg.Items.Add("Night-Ninja");

                UpdateCoinsLabel();
            }
            else if (gameData.nightNinjaUnlocked)
            {
                MessageBox.Show("Цей скін вже розблокований.", "Інфо");
            }
            else
            {
                MessageBox.Show("Недостатньо монет для купівлі.", "Помилка");
            }
        }

        private void UpdateComboBox()
        {
            InitializeComboBox();
        }

        public void RefreshCoins()
        {
            gameData = SaveSystem.Load();
            UpdateCoinsLabel();
        }

        private void UpdateCoinsLabel()
        {
            gameData = SaveSystem.Load();
            labelCoins.Text = "Монети: " + gameData.coins.ToString();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}
