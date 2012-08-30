using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestDirectX2.Core
{
    public static class CollisionChecker
    {
        public static Boolean BoundingCollisionDetection(Character character1, Character character2)
        {
            Rectangle rectBound1 = character1.Bound;
            Rectangle rectBound2 = character2.Bound;

            if (rectBound1.Left > rectBound2.Right)
            {
                 return false;
            }
            if (rectBound2.Right < rectBound2.Left)
            {
                return false;
            }
            if (rectBound1.Bottom < rectBound2.Top)
            {
                 return false;
            }
            if (rectBound1.Top > rectBound2.Bottom)
            {
                 return false;
            }
            return true;
        }

        public static Boolean PixelCollisionDetection(Character character1, Character character2)
        {
            //Bitmap a = new Bitmap(
            if (!BoundingCollisionDetection(character1,character2))
            {
                return false;
            }

            
            int minY = Math.Max(character1.Bound.Top, character2.Bound.Top);
            int maxY = Math.Min(character1.Bound.Bottom, character2.Bound.Bottom);

            int minX = Math.Max(character1.Bound.Left, character2.Bound.Left);
            int maxX = Math.Min(character1.Bound.Right, character2.Bound.Right);
            
            

            Color[,] _colorMap1 = character1.AniPlayer.Animation.Sprite.GetColorMapByFrame(character1.AniPlayer.Animation.CurrentFrame);
            Color[,] _colorMap2 = character2.AniPlayer.Animation.Sprite.GetColorMapByFrame(character2.AniPlayer.Animation.CurrentFrame);

            for (int i = minY; i < maxY; i++)
            {
                int yPixel1 = i - character1.Bound.Top;
                int yPixel2 = i - character2.Bound.Top;
                for (int j = minX; j < maxX; j++)
                {
                    int xPixel1 = j - character1.Bound.Left;
                    int xPixel2 = j - character2.Bound.Left;
                    if (_colorMap1[yPixel1, xPixel1] != Color.Transparent && _colorMap2[yPixel2, xPixel2] != Color.Transparent)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
