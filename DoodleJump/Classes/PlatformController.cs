using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DoodleJump.Classes
{
    public static class PlatformController
    {
        public static List<Platform> platforms;
        public static List<Platform> fakePlatforms = new List<Platform>(); 
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Bonus> bonuses = new List<Bonus>();
        public static int startPlatformPosY = 400;
        public static int score = 0;
        public static Image platformTexture;
        public static Image platformSprite;

        public static void DrawPlatforms(Graphics g)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                g.DrawImage(platformSprite, platforms[i].transform.position);
            }
            for (int i = 0; i < fakePlatforms.Count; i++)
            {
                g.DrawImage(platformSprite, fakePlatforms[i].transform.position);
            }
        }

        public static void AddPlatform(PointF position, bool isFake = false)
        {
            Platform platform = new Platform(position, isFake);
            if (isFake)
                fakePlatforms.Add(platform);
            else
                platforms.Add(platform);
        }

        public static void GenerateStartSequence()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = r.Next(0, 270);
                int y = r.Next(50, 60);
                startPlatformPosY -= y;
                PointF position = new PointF(x, startPlatformPosY);
                AddPlatform(position);
            }
        }

        public static void GenerateRandomPlatform()
        {
            ClearPlatforms();
            Random r = new Random();
            int xNormal = r.Next(0, 270);
            int yNormal = startPlatformPosY;
            PointF normalPosition = new PointF(xNormal, yNormal);
            AddPlatform(normalPosition, false);

            if (r.NextDouble() < 0.5)
            {
                int xFake;
                int attempts = 0;

                do
                {
                    xFake = r.Next(0, 270);
                    attempts++;
                }
                while (Math.Abs(xFake - xNormal) < 60 && attempts < 10);

                if (attempts < 10)
                {
                    PointF fakePosition = new PointF(xFake, yNormal);
                    AddPlatform(fakePosition, true);
                }
            }

            int c = r.Next(1, 3);
            switch (c)
            {
                case 1:
                    c = r.Next(1, 10);
                    if (c == 1)
                        CreateEnemy(platforms.Last());
                    break;

                case 2:
                    c = r.Next(1, 10);
                    if (c == 1)
                        CreateBonus(platforms.Last());
                    break;
            }
        }

        public static void GeneratePlatformAfterSpringBounce(Platform lastPlatform)
        {
            Random r = new Random();

            int xNormal = r.Next(0, 270);
            int yNormal = (int)(lastPlatform.transform.position.Y - 100); 

            while (Math.Abs(xNormal - lastPlatform.transform.position.X) < 60)
            {
                xNormal = r.Next(0, 270);
            }

            PointF normalPosition = new PointF(xNormal, yNormal);
            AddPlatform(normalPosition, false);

            if (r.NextDouble() < 0.5)
            {
                int xFake;
                int attempts = 0;

                do
                {
                    xFake = r.Next(0, 270);
                    attempts++;
                }
                while (Math.Abs(xFake - xNormal) < 60 && attempts < 10);

                if (attempts < 10)
                {
                    PointF fakePosition = new PointF(xFake, yNormal);
                    AddPlatform(fakePosition, true);
                }
            }
        }


        public static void CreateBonus(Platform platform)
        {
            Random r = new Random();
            int bonusType = r.Next(1, 2); 

            if (platform.isFake)
            {
                int newX = r.Next(0, 270);
                PointF newPosition = new PointF(newX, platform.transform.position.Y - 100);
                platform = platforms.Find(p => !p.isFake && Math.Abs(p.transform.position.X - newX) > 60);
                if (platform == null)
                    return;
            }

            switch (bonusType)
            {
                case 1:
                    Bonus bonus = new Bonus(new PointF(platform.transform.position.X + (platform.sizeX / 2) - 7, platform.transform.position.Y - 15), bonusType);
                    bonuses.Add(bonus);
                    break;
            }
        }


        public static void CreateEnemy(Platform platform)
        {
            Random r = new Random();
            int enemyType = r.Next(1, 4);

            Size monsterSize; 

            if (platform.isFake)
                return;

            switch (enemyType)
            {
                case 1:
                    monsterSize = new Size(40, 40); 
                    break;
                case 2:
                    monsterSize = new Size(70, 50); 
                    break;
                case 3:
                    monsterSize = new Size(70, 60);
                    break;
                default:
                    monsterSize = new Size(40, 40); 
                    break;
            }

            PointF monsterPosition = new PointF(platform.transform.position.X + (platform.sizeX / 2) - (monsterSize.Width / 2), platform.transform.position.Y - monsterSize.Height);
            Enemy enemy = new Enemy(monsterPosition, enemyType);
            enemy.physics = new Physics(monsterPosition, monsterSize); 
            enemies.Add(enemy);
        }



        public static void RemoveEnemy(int i)
        {
            enemies.RemoveAt(i);
        }

        public static void CreateBullet(PointF position)
        {
            Bullet bullet = new Bullet(position);
            bullets.Add(bullet);
        }

        public static void RemoveBullet(int i)
        {
            bullets.RemoveAt(i);
        }

        public static void ClearPlatforms()
        {
            platforms.RemoveAll(platform => platform.transform.position.Y >= 700);
            bonuses.RemoveAll(bonus => bonus.physics.transform.position.Y >= 700);
            enemies.RemoveAll(enemy => enemy.physics.transform.position.Y >= 700);
            fakePlatforms.RemoveAll(platform => platform.transform.position.Y >= 700); 
        }

        public static void SetPlatformTexture(Image texture)
        {
            platformTexture = texture;
        }

    }
}
