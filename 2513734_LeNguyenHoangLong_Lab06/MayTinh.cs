using System;
using System.Collections.Generic;

namespace Lab06
{
    class MayTinh
    {
        private List<IThietBi> dsThietBi;
        private string ten;
        private string maso;
        private DateTime ngaysx;

        public int SoTB
        {
            get { return dsThietBi.Count; }
        }
        public string MaSo
        {
            get { return maso; }
            set { maso = value; }
        }
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        public List<IThietBi> DsThietBi
        {
            get { return dsThietBi; }
        }
        public int NamSX
        {
            get { return ngaysx.Year; }
        }
        public int Gia
        {
            get
            {
                return TongGia();
            }
        }
        private int TongGia()
        {
            int gia = 0;
            for (int i = 0; i < SoTB; i++)
            {
                gia += dsThietBi[i].Gia;
            }
            return gia;
        }
        public int TinhGia()
        {
            return TongGia();
        }
        public MayTinh()
        {
            dsThietBi = new List<IThietBi>();
        }
        public MayTinh(string ms, string t, DateTime nsx, List<IThietBi> dstb)
        {
            dsThietBi = dstb;
            this.MaSo = ms;
            this.ten = t;
            this.ngaysx = nsx;
        }
        public MayTinh(string ms, string t, DateTime nsx)
        {
            this.MaSo = ms;
            this.ten = t;
            this.ngaysx = nsx;
            dsThietBi = new List<IThietBi>();
        }
        public IThietBi this[int index]
        {
            get { return dsThietBi[index]; }
            set { dsThietBi[index] = value; }
        }
        public void Them(IThietBi tb)
        {
            dsThietBi.Add(tb);
        }
        public override string ToString()
        {
            String s = "";
            s += String.Format("May tinh ({0}, {1}, {2}, {3})",
                this.maso, this.ten, this.ngaysx.ToShortDateString(), this.Gia);
            s += "\n\tDanh sach thiet bi:";
            for (int i = 0; i < this.SoTB; i++)
            {
                s += "\n\t" + this[i].ToString();
            }
            return s;
        }

        //1. Tim gia max: phuong thuc/dong goi thuoc tinh
        public int GiaMaxTB
        {
            get
            {
                int max = dsThietBi[0].Gia;
                /*foreach (IThietBi tb in dsThietBi)
                {
                    if (tb.Gia > max)
                        max = tb.Gia;
                }*/
                for (int i = 1; i < SoTB; i++)
                {
                    if (dsThietBi[i].Gia > max)
                        max = dsThietBi[i].Gia;
                }
                return max;
            }
        }

        //2. Tim ds tb co gia MAX
        public List<IThietBi> TimDSTBMax()
        {
            int max = this.GiaMaxTB;
            List<IThietBi> dstbGiaMax = new List<IThietBi>();
            foreach (IThietBi tb in dsThietBi)
            {
                if (tb.Gia == max)
                    dstbGiaMax.Add(tb);
            }
            return dstbGiaMax;
        }

    }
}
