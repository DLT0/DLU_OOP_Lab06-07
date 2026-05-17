using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;

namespace Lab06
{
    delegate int SoSanh(object x, object y);

    class QuanLyMayTinh
    {
        List<MayTinh> dsMayTinh;

        public int Count
        {
            get { return dsMayTinh.Count; }
        }

        public MayTinh this[int index]
        {
            get { return this.dsMayTinh[index]; }
            set { this.dsMayTinh[index] = value; }
        }

        public QuanLyMayTinh()
        {
            dsMayTinh = new List<MayTinh>();
        }

        public void Them(MayTinh mt)
        {
            this.dsMayTinh.Add(mt);
        }

        public override string ToString()
        {
            string s = "";
            foreach (var mt in dsMayTinh)
            {
                s += mt + "\n";
            }
            return s;
        }

        public void NhapCD()
        {
            dsMayTinh.Clear();

            MayTinh mt = new MayTinh("MT001", "HP 2024", new DateTime(2024, 1, 15));
            mt.Them(new CPU(8500, 3.4f));
            mt.Them(new Ram(3200, 16));
            mt.Them(new Ram(4500, 32));
            Them(mt);

            mt = new MayTinh("MT002", "Dell 2021", new DateTime(2021, 10, 5));
            mt.Them(new CPU(6200, 3.1f));
            mt.Them(new Ram(1800, 8));
            mt.Them(new Ram(2400, 16));
            Them(mt);

            mt = new MayTinh("MT003", "Asus 2022", new DateTime(2022, 6, 20));
            mt.Them(new CPU(7100, 3.7f));
            mt.Them(new Ram(2600, 16));
            Them(mt);

            mt = new MayTinh("MT004", "Lenovo 2023", new DateTime(2023, 3, 12));
            mt.Them(new CPU(9300, 4.0f));
            mt.Them(new Ram(3500, 16));
            Them(mt);

            mt = new MayTinh("MT005", "Acer 2020", new DateTime(2020, 11, 8));
            mt.Them(new CPU(5400, 2.9f));
            mt.Them(new CPU(9300, 4.0f));
            mt.Them(new Ram(1500, 8));
            mt.Them(new Ram(2100, 16));
            Them(mt);

        }
        private MayTinh Nhap1MayTinh()
        {
            Console.Write("Ma so: ");
            string maso = Console.ReadLine();
            Console.Write("Ten: ");
            string ten = Console.ReadLine();

            Console.Write("Ngay san xuat (mm/dd/yyyy): ");
            DateTime ngaysx = DateTime.Parse(Console.ReadLine());

            MayTinh mt = new MayTinh(maso, ten, ngaysx);

            Console.Write("So luong thiet bi muon them: ");
            int soLuong = int.Parse(Console.ReadLine());

            for (int j = 0; j < soLuong; j++)
            {
                Console.WriteLine("Thiet bi " + (j + 1) + ":");
                Console.WriteLine("1. RAM");
                Console.WriteLine("2. CPU");
                Console.Write("Chon loai thiet bi: ");
                int loai = int.Parse(Console.ReadLine());

                Console.Write("Gia: ");
                int gia = int.Parse(Console.ReadLine());

                if (loai == 1)
                {
                    Console.Write("Dung luong RAM (GB): ");
                    int dungLuong = int.Parse(Console.ReadLine());
                    mt.Them(new Ram(gia, dungLuong));
                }
                else if (loai == 2)
                {
                    Console.Write("Toc do CPU (GHz): ");
                    float tocDo = float.Parse(Console.ReadLine());
                    mt.Them(new CPU(gia, tocDo));
                }
            }
            return mt;
        }
        public void NhapDanhSach(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin may tinh thu " + (i + 1) + ":");
                MayTinh mt = Nhap1MayTinh();
                Them(mt);
            }
        }

        public void DocTuFile(string tenFile)
        {
            this.dsMayTinh.Clear();
            if (string.IsNullOrWhiteSpace(tenFile))
            {
                Console.WriteLine("Ten file khong hop le");
                return;
            }

            string duongDan = tenFile;
            if (!File.Exists(duongDan))
            {
                string duongDanThu2 = Path.Combine(Directory.GetCurrentDirectory(), tenFile);
                if (File.Exists(duongDanThu2))
                {
                    duongDan = duongDanThu2;
                }
            }

            if (!File.Exists(duongDan))
            {
                Console.WriteLine("File khong ton tai");
                return;
            }

            MayTinh mayHienTai = null;
            foreach (string raw in File.ReadLines(duongDan))
            {
                string line = raw.Trim();
                if (line.Length == 0) continue;

                if (line.StartsWith("MT", StringComparison.OrdinalIgnoreCase))
                {
                    MayTinh mt = line; // implicit string -> MayTinh
                    mayHienTai = mt;
                    Them(mt);
                    continue;
                }

                if (mayHienTai == null) continue;

                if (line.StartsWith("CPU", StringComparison.OrdinalIgnoreCase))
                {
                    CPU cpu = line; // implicit string -> CPU
                    mayHienTai.Them(cpu);
                }
                else if (line.StartsWith("RAM", StringComparison.OrdinalIgnoreCase))
                {
                    Ram ram = line; // implicit string -> Ram
                    mayHienTai.Them(ram);
                }
            }

            Console.WriteLine("Doc file thanh cong!");
        }

        // Tim may tinh co gia lon nhat
        public int TimGiaMax()
        {
            int max = 0;
            foreach (MayTinh item in dsMayTinh)
            {
                if (item.Gia > max)
                {
                    max = item.Gia;
                }
            }
            return max;
        }

        // Tim danh sach may tinh co 2 thanh Ram
        public QuanLyMayTinh TimKiem(SoSanh ss, object x)
        {
            QuanLyMayTinh kq = new QuanLyMayTinh();
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (ss(mt, x) == 0)
                {
                    kq.Them(mt);
                }
            }
            return kq;
        }

        public void HienThiTheoGia()
        {
            Console.WriteLine("{0,-20} {1,10}", "Ten May", "Gia");
            foreach (MayTinh item in this.dsMayTinh)
            {
                Console.WriteLine("{0,-20} {1,10}", item.Ten, item.Gia);
            }
        }

        public int TongGia()
        {
            int sum = 0;
            foreach (MayTinh item in this.dsMayTinh)
            {
                sum += item.Gia;
            }
            return sum;
        }

        public void SapGiamTheoTen()
        {
            this.dsMayTinh.Sort((a, b) => a.Ten.CompareTo(b.Ten));
        }

        public void SapXepDelegate(SoSanh ss)
        {
            for (int i = 0; i < this.dsMayTinh.Count - 1; i++)
            {
                for (int j = i + 1; j < this.dsMayTinh.Count; j++)
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

        public QuanLyMayTinh TimKiemNhat(SoSanh ss)
        {
            QuanLyMayTinh kq = new QuanLyMayTinh();
            if (this.dsMayTinh.Count == 0)
            {
                return kq;
            }

            MayTinh maxComputer = this.dsMayTinh[0];

            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (ss(mt, maxComputer) > 0)
                {
                    maxComputer = mt;
                }
            }

            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (ss(mt, maxComputer) == 0)
                {
                    kq.Them(mt);
                }
            }
            return kq;
        }

        public void XoaMayTinhSX_TruocNamX(int x)
        {
            for (int i = this.dsMayTinh.Count - 1; i >= 0; i--)
            {
                if (this.dsMayTinh[i].NamSX < x)
                {
                    this.dsMayTinh.Remove(this.dsMayTinh[i]);
                }
            }
        }

        public void SapXepRamTang_GiaTang(SoSanh ss1, SoSanh ss2)
        {
            for (int i = 0; i < this.dsMayTinh.Count - 1; i++)
                for (int j = i + 1; j < this.dsMayTinh.Count; j++)
                {
                    if (ss1(this[i], this[j]) > 0)
                    {
                        var t = this[i];
                        this[i] = this[j];
                        this[j] = t;
                    }
                    if ((ss1(this[i], this[j]) == 0) && ss2(this[i], this[j]) > 0)
                    {
                        var t = this[i];
                        this[i] = this[j];
                        this[j] = t;
                    }

                }
        }

        public void ChenVaoIndex(int index)
        {
            MayTinh mt = Nhap1MayTinh();
            this.dsMayTinh.Insert(index, mt);
        }

        public void XoaMayTinhCoItTB(SoSanh ss)
        {
            int minSoTB = this.dsMayTinh[0].SoTB;
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (ss(mt, minSoTB) < 0)
                {
                    minSoTB = mt.SoTB;
                }
            }

            for (int i = this.dsMayTinh.Count - 1; i >= 0; i--)
            {
                if (ss(this.dsMayTinh[i], minSoTB) == 0)
                {
                    this.dsMayTinh.RemoveAt(i);
                }
            }
        }
    }
}
