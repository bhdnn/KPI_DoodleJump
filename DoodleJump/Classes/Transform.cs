using System.Drawing;

namespace DoodleJump.Classes
{
    public class Transform
    {
        public PointF position;
        public SizeF size;

        public Transform(PointF position, SizeF size)
        {
            this.position = position;
            this.size = size;
        }
    }
}
