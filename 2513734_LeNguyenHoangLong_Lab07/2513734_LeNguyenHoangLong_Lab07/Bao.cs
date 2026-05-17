using System.Formats.Tar;

namespace Lab07
{
    class Bao : IAnPham
    {
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

        public Bao()
        {

        }
        public Bao(string line)
        {
            string[] ss = line.Trim().Split(',');
            this.GiaTien = float.Parse(ss[3]);
            this.Ten = ss[1];
            this.NhaXuatBan = ss[2];
        }

        public Bao(string ten, string nhaXuatBan, float giaTien)
        {
            this.GiaTien = giaTien;
            this.Ten = ten;
            this.NhaXuatBan = nhaXuatBan;
        }

        public override string ToString()
        {
            return String.Format("{0, -25} {1,-20} {2,-10:0.000} {3,-25}", "Bao " + Ten, NhaXuatBan, GiaTien, "");
        }
    }
}
