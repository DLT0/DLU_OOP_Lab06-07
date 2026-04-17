using System;
using System.Globalization;

namespace Lab06
{
    class CPU : IThietBi
    {
        int gia;
        float tocdo;
        public int Gia
        {
            get { return gia; }
        }
        public float TocDo
        {
            get { return tocdo; }
            set { tocdo = value; }
        }
        public CPU()
        {

        }
        public CPU(int g, float td)
        {
            this.gia = g;
            this.TocDo = td;
        }

        // Format: CPU*<tocdo>*<gia>
        public static implicit operator CPU(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new FormatException("Dong CPU rong");

            string[] parts = s.Trim().Split('*', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length < 3 || !parts[0].Equals("CPU", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("Sai dinh dang CPU");

            if (!float.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float td))
                td = float.Parse(parts[1], CultureInfo.GetCultureInfo("en-US"));

            if (!int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int g))
                g = int.Parse(parts[2], CultureInfo.InvariantCulture);

            return new CPU(g, td);
        }

        public override string ToString()
        {
            return String.Format("CPU gia={0}, tocdo={1}", Gia, TocDo);
        }
    }
}
