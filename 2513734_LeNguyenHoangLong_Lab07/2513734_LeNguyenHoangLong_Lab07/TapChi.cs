using System.Formats.Tar;

namespace Lab07
{
    class TapChi : IAnPham
    {
        string diaChi;
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

        public TapChi()
        {

        }
        public TapChi(string line)
        {

        }

        public TapChi(string ten, string nhaXuatBan, float giaTien, string diaChi)
        {
            this.GiaTien = giaTien;
            this.Ten = ten;
            this.NhaXuatBan = nhaXuatBan;
            this.diaChi = diaChi;
        }

        public override string ToString()
        {
            return String.Format("{0, -25} {1,-20} {2,-10:0.000} {3,-25}", "Tap Chi " + Ten, NhaXuatBan, GiaTien, "Dia chi: " + diaChi);
        }
    }
}
