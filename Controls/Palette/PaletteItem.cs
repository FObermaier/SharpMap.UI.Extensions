using System;

namespace SharpMap.Forms.Controls.Palette
{
    [Serializable]
    internal struct PaletteItem : IComparable, IComparable<PaletteItem>, IEquatable<PaletteItem>
    {
        public System.Drawing.Color Color
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }

        public PaletteItem(double value, System.Drawing.Color color)
            :this()
        {
            Color = color;
            Value = value;
        }

        public int CompareTo(PaletteItem other)
        {
            if (Value < other.Value) return -1;
            if (Value > other.Value) return 1;
            return 0;
        }

        public bool Equals(PaletteItem other)
        {
            if (Value == other.Value && Color == other.Color) return true;

            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is PaletteItem)
                return CompareTo((PaletteItem) obj);
            return -1;
        }
    }
}