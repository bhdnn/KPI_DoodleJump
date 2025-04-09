using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Policy;

namespace DoodleJump.Classes
{
    public class FakePlatform : Platform
    {
        public FakePlatform(PointF pos) : base(pos)
        {
            sprite = Properties.Resources.fake_platform; 
        }

        public override void DrawSprite(Graphics g)
        {
            base.DrawSprite(g);
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = 0.5f;
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            g.DrawImage(sprite, new Rectangle((int)transform.position.X, (int)transform.position.Y, transform.size.Width, transform.size.Height), 0, 0, sprite.Width, sprite.Height, GraphicsUnit.Pixel, imageAttributes);
            
        }
    }
}
