using System.Formats.Tar;

namespace Lab07
{
    class Sach : IAnPham
    {
        int SoTrang;
        float giaTien;
        string nhaXuatBan;
        string ten;

        public float GiaTien
        {
            get { return this.giaTien; }
            set
            {
                this.giaTien = value;
            }
        }
        public string Ten
        {
            get { return this.ten; }
            set { this.ten = value; }
        }
        public string NhaXuatBan
        {
            get { return this.nhaXuatBan; }
            set { this.nhaXuatBan = value; }
        }

        public Sach()
        {

        }
        public Sach(string line) //Sach,Lap trinh HDT, Giao duc, 100, 60
        {
            string[] ss = line.Trim().Split(',');
            this.GiaTien = float.Parse(ss[3]);
            this.Ten = ss[1];
            this.NhaXuatBan = ss[2];
            this.SoTrang = int.Parse(ss[4]);
        }

        public Sach(string ten, string nhaXuatBan, float giaTien, int soTrang)
        {
            this.GiaTien = giaTien;
            this.Ten = ten;
            this.NhaXuatBan = nhaXuatBan;
            this.SoTrang = soTrang;
        }

        public override string ToString()
        {
            return String.Format("{0, -25} {1,-20} {2,-10:0.000} {3,-25}", "Sach " + Ten, NhaXuatBan, GiaTien, "So trang: " + SoTrang);
        }

        public static explicit operator Sach(string s)
        {
            string[] ss = s.Trim().Split(',');
            return new Sach(ss[1], ss[2], float.Parse(ss[3]), int.Parse(ss[4]));
        }
    }
}
