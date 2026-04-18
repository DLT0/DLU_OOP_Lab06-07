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
        public Sach(string line)
        {

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
    }
}
