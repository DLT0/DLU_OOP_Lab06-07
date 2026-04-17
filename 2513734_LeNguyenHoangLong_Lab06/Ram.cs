using System;

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

        public override string ToString()
        {
            return String.Format("Ram gia={0}, dung luong={1}", Gia, DungLuong);
        }
    }
}
