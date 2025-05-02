using System.Drawing;
using System.Windows.Forms;

namespace DoodleJump.Classes
{
    public class Platform
    {
        protected Image sprite;
        public Transform transform;
        public int sizeX;
        public int sizeY;
        public bool isTouchedByPlayer;
        public bool isFake;

        public virtual void Update()
        {
        }


        public Platform(PointF pos, bool isFake = false)
        {
            this.isFake = isFake;
            sprite = isFake ? DoodleJump.Properties.Resources.fake_platform : DoodleJump.Properties.Resources.default_platform; 
            sizeX = 60;
            sizeY = 12;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouchedByPlayer = false;
        }

        public virtual void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
