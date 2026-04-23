using System.Net.Quic;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;

namespace Lab07
{
    delegate int SoSanh(object a, object b);
    public enum KieuSapXep
    {
        TangTheoTen,
        TangTheoGia,
        GiamTheoNam
    }
    class DanhSachAnPham : IComparer<IAnPham>
    {
        private List<IAnPham> collection = new List<IAnPham>();
        private KieuSapXep kieu;

        public IAnPham this[int index]
        {
            get { return this.collection[index]; }
            set { this.collection[index] = value; }
        }

        public int Count
        {
            get { return this.collection.Count; }
        }
        public void Them(IAnPham ap)
        {
            collection.Add(ap);
        }

        /*public void DocDSTuFile(string tenfile)
        {
            this.collection.Clear();
            if (File.Exists(tenfile))
            {

            }
        }
        */
        public bool DocFile(string path)
        {

            /*
                        Them(new Sach("Lap Trinh HDT", "Giao duc", 100f, 60));
                        Them(new TapChi("May bay", "TPHCM", 100f, "Quan 10 - TP HCM"));
                        Them(new TapChi("Nguoi mau tap 1", "TPHCM", 100f, "Quan 1 - TP HCM"));
                        Them(new Bao("Nong dan", "Thanh nien", 50f));
                        Them(new TapChi("Ca si", "Ha Noi", 40f, "Quan Thanh Xuan - Ha Noi "));
                        Them(new Bao("Nhan dan tap 1", "Ha Noi", 20f));
                        Them(new Bao("Lao dong", "Ha Noi", 10f));
                        Them(new Sach("Cau truc DL&TG1", "Giao duc", 150f, 100));
                        Them(new Sach("Bao tri may tinh", "Da Nang", 130f, 200));
            */
            if (!File.Exists(path))
            {
                Console.WriteLine("File khong ton tai!");
                return false;
            }
            this.collection.Clear();
            string[] lines = File.ReadAllLines(path);
            IAnPham ap = null;
            foreach (var line in lines) //"MT*221*Sony 1*4/2/1999"
            {
                switch (line.Split(',')[0])
                {
                    case "Sach":
                        Them(new Sach(line));
                        break;

                    case "Tap chi":
                        Them(new TapChi(line));
                        break;

                    case "Bao":
                        Them(new Bao(line));
                        break;
                }
            }
            Console.WriteLine("Doc file thanh cong!");
            return true;
        }
        public override string ToString()

        {
            string s = "";
            Console.WriteLine("{0, -25} {1,-20} {2,-10:0.000} {3,-25}", "TEN", "NHA XUAT BAN", "GIA TIEN", "CHU THICH");
            foreach (var item in collection)
            {
                s += item + "\n";

            }
            return s;
        }
        public float GiaMax()
        {
            var max = this.collection[0].GiaTien;
            foreach (var item in collection)
            {
                if (item.GiaTien > max)
                    max = item.GiaTien;
            }
            return max;
        }
        public float GiaMin()
        {
            var min = this.collection[0].GiaTien;
            foreach (var item in collection)
            {
                if (item.GiaTien < min)
                    min = item.GiaTien;
            }
            return min;
        }
        public DanhSachAnPham TimKiemDelegate(SoSanh ss, object x)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            foreach (IAnPham ap in collection)
            {
                if (ss(ap, x) == 0)
                {
                    kq.Them(ap);
                }
            }
            return kq;
        }
        public void XuatDS()
        {
            if (Count == 0)
            {
                Console.WriteLine("Danh sach rong");
            }
            else
            {
                Console.WriteLine("\n\t====DANH SACH AN PHAM HIEN TAI ====");
                Console.WriteLine("{0, -25} {1,-20} {2,-10:0.000} {3,-25}", "TEN", "NHA XUAT BAN", "GIA TIEN", "CHU THICH");
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void HienThiTheoGia()
        {
            Console.WriteLine("{0, -25} {1,10:0.000}", "TEN", "GIA TIEN");
            foreach (var item in collection)
            {
                Console.WriteLine("{0, -25} {1,10:0.000}", item.Ten, item.GiaTien);
            }
        }
        public float TongGia()
        {
            float sum = 0;
            foreach (IAnPham ap in collection)
            {
                sum += ap.GiaTien;
            }
            return sum;
        }
        public void SapXepDelegate(SoSanh ss)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (ss(this[i], this[j]) > 0)
                    {
                        var temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }

        public int Compare(IAnPham x, IAnPham y)
        {
            switch (kieu)
            {
                case KieuSapXep.TangTheoTen:
                    {
                        int cmpTen = x.Ten.CompareTo(y.Ten);
                        if (cmpTen != 0)
                            return cmpTen;

                        // Neu trung ten thi tang dan theo gia
                        return x.GiaTien.CompareTo(y.GiaTien);
                    }
                case KieuSapXep.TangTheoGia:
                    {
                        int cmpGia = x.GiaTien.CompareTo(y.GiaTien);
                        if (cmpGia != 0)
                            return cmpGia;

                        return x.Ten.CompareTo(y.Ten);
                    }
                default:
                    return x.GiaTien.CompareTo(y.GiaTien);
            }
        }

        public void SapXep_IComparer()
        {
            this.collection.Sort(this);
        }

        public int TimMotAP()
        {
            int vt = -1;
            float max = GiaMax();
            for (int i = 0; i < Count; i++)
            {
                if (this.collection[i].GiaTien == max)
                {
                    vt = i;
                    break;
                }
            }
            return vt;
        }

        public void XoaAnPhamGiaMin()
        {
            float min = GiaMin();
            for (int i = Count; i > 0; i--)
            {
                this.collection.RemoveAll(a => a.GiaTien.CompareTo(min) == 0);
            }
        }

        enum LoaiAnPham
        {
            Sach = 1,
            Bao = 2,
            TapChi = 3,

        }

        public IAnPham Nhap1AnPham()
        {
            IAnPham ap = null;
            Console.WriteLine("Nhap Ten An Pham: ");
            string ten = Console.ReadLine();
            Console.WriteLine("Nhap Ten Nha Xuat Ban: ");
            string nxb = Console.ReadLine();
            Console.WriteLine("Nhap Gia Tien Cua An Pham: ");
            float giatien = float.Parse(Console.ReadLine());

            Console.WriteLine("Chon loai An Pham: ");
            Console.WriteLine("1. Sach");
            Console.WriteLine("2. Bao");
            Console.WriteLine("3. Tap Chi ");
            int loai = 0;
            do
            {
                Console.WriteLine("Chon : ");
                loai = int.Parse(Console.ReadLine());
                if ((int)LoaiAnPham.Bao <= loai && loai <= (int)LoaiAnPham.TapChi)
                {
                    break;
                }
            } while (true);
            switch (loai)
            {
                case 2:
                    ap = new Bao(ten, nxb, giatien);
                    break;
                case 1:
                    Console.WriteLine("Nhap so trang: ");
                    int soTrang = int.Parse(Console.ReadLine());
                    ap = new Sach(ten, nxb, giatien, soTrang);
                    break;
                case 3:
                    string diachi;
                    Console.WriteLine("Nhap dia chi: ");
                    diachi = Console.ReadLine();
                    ap = new TapChi(ten, nxb, giatien, diachi);
                    break;
                default:
                    ap = new Bao(ten, nxb, giatien);
                    break;
            }
            return ap;
        }

        public void Chen(int vt)
        {
            IAnPham them = Nhap1AnPham();
            this.collection.Insert(vt, them);
        }

    }
}

