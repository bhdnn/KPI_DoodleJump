using DoodleJump.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class Form1 : Form
    {
        Player player;
        Timer timer1;
        private Image manRight;
        private Image manLeft;
        private Image manShooting;
        private Image platformSprite;
        private Image fakePlatformSprite;
        private Image bulletSprite;

        public Form1(string selectedBackground)
        {
            InitializeComponent();
            Init();
            timer1 = new Timer();
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);

            SetBackground(selectedBackground);

            this.Height = 600;
            this.Width = 330;
            this.Paint += new PaintEventHandler(OnRepaint);
        }

        private void SetBackground(string selectedBackground)
        {
            switch (selectedBackground)
            {
                case "Default":
                    this.BackgroundImage = Properties.Resources.back;
                    player.sprite = Properties.Resources.man_left;
                    manRight = Properties.Resources.man_right;
                    manLeft = Properties.Resources.man_left;
                    manShooting = Properties.Resources.man_shooting;
                    platformSprite = Properties.Resources.default_platform;
                    fakePlatformSprite = Properties.Resources.fake_platform;
                    bulletSprite = Properties.Resources.bullet;
                    break;
                case "Soccer":
                    this.BackgroundImage = Properties.Resources.soccer;
                    player.sprite = Properties.Resources.soccer_left;
                    manRight = Properties.Resources.soccer_right;
                    manLeft = Properties.Resources.soccer_left;
                    manShooting = Properties.Resources.soccer_shooting;
                    platformSprite = Properties.Resources.soccer_platform;
                    fakePlatformSprite = Properties.Resources.fake_platform;
                    bulletSprite = Properties.Resources.soccer_bullet;
                    break;
                case "Ninja":
                    this.BackgroundImage = Properties.Resources.ninja;
                    player.sprite = Properties.Resources.ninja_left;
                    manRight = Properties.Resources.ninja_right;
                    manLeft = Properties.Resources.ninja_left;
                    manShooting = Properties.Resources.ninja_shooting;
                    platformSprite = Properties.Resources.ninja_platform;
                    fakePlatformSprite = Properties.Resources.ninja_fake;
                    bulletSprite = Properties.Resources.ninja_bullet;
                    break;
                case "Night-Ninja":
                    this.BackgroundImage = Properties.Resources.night_ninja_background;
                    player.sprite = Properties.Resources.ninja_left;
                    manRight = Properties.Resources.ninja_right;
                    manLeft = Properties.Resources.ninja_left;
                    manShooting = Properties.Resources.ninja_shooting;
                    platformSprite = Properties.Resources.ninja_platform;
                    fakePlatformSprite = Properties.Resources.ninja_fake;
                    bulletSprite = Properties.Resources.ninja_bullet;
                    break;
                default:
                    this.BackgroundImage = null;
                    player.sprite = Properties.Resources.man_left;
                    manRight = Properties.Resources.man_right;
                    manLeft = Properties.Resources.man_left;
                    manShooting = Properties.Resources.man_shooting;
                    platformSprite = Properties.Resources.default_platform;
                    fakePlatformSprite = Properties.Resources.fake_platform;
                    bulletSprite = Properties.Resources.bullet;
                    break;
            }
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Init()
        {
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 400));
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            PlatformController.bullets.Clear();
            PlatformController.bonuses.Clear();
            PlatformController.enemies.Clear();
            PlatformController.fakePlatforms.Clear();
            player = new Player();
        }

        private void CheckBounds()
        {
            if (player.physics.transform.position.X + player.physics.transform.size.Width < 0)
            {
                player.physics.transform.position.X = this.Width;
            }
            else if (player.physics.transform.position.X > this.Width)
            {
                player.physics.transform.position.X = -player.physics.transform.size.Width;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = "Кількість очок - " + PlatformController.score;

            if ((player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200) || player.physics.StandartCollidePlayerWithObjects(true, false))
            {
                GameOver();
                return;
            }

            player.physics.StandartCollidePlayerWithObjects(false, true);

            for (int i = PlatformController.bullets.Count - 1; i >= 0; i--)
            {
                if (Math.Abs(PlatformController.bullets[i].physics.transform.position.Y - player.physics.transform.position.Y) > 500)
                {
                    PlatformController.RemoveBullet(i);
                }
                else
                {
                    PlatformController.bullets[i].MoveUp();
                }
            }

            for (int i = PlatformController.enemies.Count - 1; i >= 0; i--)
            {
                if (PlatformController.enemies[i].physics.StandartCollide())
                {
                    PlatformController.RemoveEnemy(i);
                }
            }

            player.physics.ApplyPhysics();
            FollowPlayer();
            CheckBounds();

            Invalidate();
        }

        private void GameOver()
        {
            timer1.Stop();

            int earnedCoins = PlatformController.score / 100;  
            GameData gameData = SaveSystem.Load();

            gameData.coins += earnedCoins;  
            SaveSystem.Save(gameData);  

            MessageBox.Show($"Ви впали, набрав {PlatformController.score} очок.\nОтримано монет: {earnedCoins}\nВсього монет: {gameData.coins}",
                             "КІНЕЦЬ ГРИ",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

            this.Close();
            Application.Exit(); 
        }



        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;
            if (e.KeyCode == Keys.Space)
            {
                PlatformController.CreateBullet(new PointF(player.physics.transform.position.X + player.physics.transform.size.Width / 2, player.physics.transform.position.Y));
            }
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    player.physics.dx = 6;
                    player.sprite = manRight;
                    break;
                case Keys.Left:
                    player.physics.dx = -6;
                    player.sprite = manLeft;
                    break;
                case Keys.Space:
                    player.sprite = manShooting;
                    break;
            }
        }

        private void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;

            foreach (var platform in PlatformController.platforms)
                platform.transform.position.Y += offset;

            foreach (var bullet in PlatformController.bullets)
                bullet.physics.transform.position.Y += offset;

            foreach (var enemy in PlatformController.enemies)
                enemy.physics.transform.position.Y += offset;

            foreach (var bonus in PlatformController.bonuses)
                bonus.physics.transform.position.Y += offset;

            foreach (var fake in PlatformController.fakePlatforms)
                fake.transform.position.Y += offset;
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var platform in PlatformController.platforms)
                g.DrawImage(platformSprite, platform.transform.position);

            foreach (var bullet in PlatformController.bullets)
                g.DrawImage(bulletSprite, new RectangleF(bullet.physics.transform.position, new SizeF(15, 15)));

            foreach (var enemy in PlatformController.enemies)
                enemy.DrawSprite(g);

            foreach (var bonus in PlatformController.bonuses)
                bonus.DrawSprite(g);

            foreach (var fake in PlatformController.fakePlatforms)
                g.DrawImage(fakePlatformSprite, fake.transform.position);

            player.DrawSprite(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}
