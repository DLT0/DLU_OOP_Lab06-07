using System;
using System.Collections.Generic;
using System.Globalization;

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
        private int DemSoRam()
        {
            int dem = 0;
            foreach (IThietBi item in dsThietBi)
            {
                if (item is Ram)
                {
                    dem++;
                }
            }
            return dem;
        }
        public int SoThanhRam
        {
            get { return DemSoRam(); }
        }

        public int GiaRamCaoNhat()
        {
            int maxGia = 0;
            foreach (IThietBi item in dsThietBi)
            {
                if (item is Ram && item.Gia > maxGia)
                {
                    maxGia = item.Gia;
                }
            }
            return maxGia;
        }

        public int GiaRamThapNhat()
        {
            int minGia = int.MaxValue;
            foreach (IThietBi item in dsThietBi)
            {
                if (item is Ram && item.Gia < minGia)
                {
                    minGia = item.Gia;
                }
            }
            return minGia == int.MaxValue ? 0 : minGia;
        }

        public int GiaCPUThapNhat()
        {
            int minGia = int.MaxValue;
            foreach (IThietBi item in dsThietBi)
            {
                if (item is CPU && item.Gia < minGia)
                {
                    minGia = item.Gia;
                }
            }
            return minGia == int.MaxValue ? 0 : minGia;
        }

        public int GiaCPUCaoNhat()
        {
            int maxGia = 0;
            foreach (IThietBi item in dsThietBi)
            {
                if (item is CPU && item.Gia > maxGia)
                {
                    maxGia = item.Gia;
                }
            }
            return maxGia;
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

        // Format: MT*<id>*<ten>*<ngay>
        public static implicit operator MayTinh(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new FormatException("Dong MT rong");

            string[] parts = s.Trim().Split('*', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length < 4 || !parts[0].StartsWith("MT", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("Sai dinh dang MT");

            string id = parts[1];
            string ms = id.StartsWith("MT", StringComparison.OrdinalIgnoreCase) ? id : "MT" + id;
            string ten = parts[2];

            string ngayStr = parts[3];
            string[] formats = { "M/d/yyyy", "MM/dd/yyyy", "d/M/yyyy", "dd/MM/yyyy" };
            if (!DateTime.TryParseExact(ngayStr, formats, CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out DateTime nsx)
                && !DateTime.TryParse(ngayStr, CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out nsx))
            {
                throw new FormatException("Sai dinh dang ngay san xuat");
            }

            return new MayTinh(ms, ten, nsx);
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


    }
}
