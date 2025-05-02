using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DoodleJump.Classes
{
    public class FakePlatform : Platform
    {
        private float alpha = 0.5f;
        private float alphaDirection = 1f;

        private float offsetY = 0;
        private float offsetPhase = 0;

        public FakePlatform(PointF pos) : base(pos)
        {
            sprite = Properties.Resources.fake_platform;
        }

        public override void DrawSprite(Graphics g)
        {
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = alpha;

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            g.DrawImage(
                sprite,
                new Rectangle(
                    (int)transform.position.X,
                    (int)(transform.position.Y + offsetY),
                    (int)transform.size.Width,
                    (int)transform.size.Height),
                0, 0, sprite.Width, sprite.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
        }
    }
}
