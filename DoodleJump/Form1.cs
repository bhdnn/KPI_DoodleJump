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
                Init();

            player.physics.StandartCollidePlayerWithObjects(false, true);

            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    if (Math.Abs(PlatformController.bullets[i].physics.transform.position.Y - player.physics.transform.position.Y) > 500)
                    {
                        PlatformController.RemoveBullet(i);
                        continue;
                    }
                    PlatformController.bullets[i].MoveUp();
                }
            }
            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    if (PlatformController.enemies[i].physics.StandartCollide())
                    {
                        PlatformController.RemoveEnemy(i);
                        break;
                    }
                }
            }

            player.physics.ApplyPhysics();
            FollowPlayer();
            CheckBounds();

            if ((player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200) || player.physics.StandartCollidePlayerWithObjects(true, false))
            {
                timer1.Stop();
                MessageBox.Show("Game over! Ваш результат: " + PlatformController.score, "Кінець гри", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            Invalidate();
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;
            switch (e.KeyCode.ToString())
            {
                case "Space":
                    PlatformController.CreateBullet(new PointF(player.physics.transform.position.X + player.physics.transform.size.Width / 2, player.physics.transform.position.Y));
                    break;
            }
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.physics.dx = 6;
                    player.sprite = manRight;
                    break;
                case "Left":
                    player.physics.dx = -6;
                    player.sprite = manLeft;
                    break;
                case "Space":
                    player.sprite = manShooting;
                    break;
            }
        }

        private void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.bullets.Count; i++)
            {
                var bullet = PlatformController.bullets[i];
                bullet.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.enemies.Count; i++)
            {
                var enemy = PlatformController.enemies[i];
                enemy.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.bonuses.Count; i++)
            {
                var bonus = PlatformController.bonuses[i];
                bonus.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.fakePlatforms.Count; i++)
            {
                var fakePlatform = PlatformController.fakePlatforms[i];
                fakePlatform.transform.position.Y += offset;
            }
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                    g.DrawImage(platformSprite, PlatformController.platforms[i].transform.position);
            }
            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                    g.DrawImage(bulletSprite, new RectangleF(PlatformController.bullets[i].physics.transform.position, new SizeF(15, 15)));
            }
            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                    PlatformController.enemies[i].DrawSprite(g);
            }
            if (PlatformController.bonuses.Count > 0)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                    PlatformController.bonuses[i].DrawSprite(g);
            }
            if (PlatformController.fakePlatforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.fakePlatforms.Count; i++)
                    g.DrawImage(fakePlatformSprite, PlatformController.fakePlatforms[i].transform.position);
            }
            player.DrawSprite(g);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
