﻿using System.Drawing;

namespace FreeLive
{
    public struct L2Color
    {
        public L2Color(int color, bool useAlpha)
        {
            if (!useAlpha)
            {
                color |= -16777216; //unchecked((int) 0xFF000000)
            }
            this.Value = color;
        }

        public int Value { get; set; }

        public static implicit operator Color(L2Color color)
        {
            return Color.FromArgb(color.Value);
        }
    }
}
