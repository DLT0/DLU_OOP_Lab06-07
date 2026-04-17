using System;
using System.Globalization;

namespace Lab06
{
    class Ram : IThietBi
    {
        Single dungluong;
        int gia;
        public float DungLuong
        {
            get { return dungluong; }
            set { dungluong = value; }
        }
        public int Gia
        {
            get { return gia; }
        }

        public Ram()
        {

        }

        public Ram(int g, Single td)
        {
            this.gia = g;
            this.dungluong = td;
        }

        // Format: RAM*<dungluong>*<gia>
        public static implicit operator Ram(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new FormatException("Dong RAM rong");

            string[] parts = s.Trim().Split('*', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length < 3 || !parts[0].Equals("RAM", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("Sai dinh dang RAM");

            if (!float.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float dl))
                dl = float.Parse(parts[1], CultureInfo.GetCultureInfo("en-US"));

            if (!int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int g))
                g = int.Parse(parts[2], CultureInfo.InvariantCulture);

            return new Ram(g, dl);
        }

        public override string ToString()
        {
            return String.Format("Ram gia={0}, dung luong={1}", Gia, DungLuong);
        }
    }
}
