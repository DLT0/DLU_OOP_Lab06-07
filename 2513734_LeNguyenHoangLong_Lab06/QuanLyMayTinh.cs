using System;
using System.Collections.Generic;
using System.IO;

namespace Lab06
{
    class QuanLyMayTinh
    {
        List<MayTinh> dsMayTinh;

        public int SoMT
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
            MayTinh mt = new MayTinh("MT001", "HP 2025", new DateTime(2024, 1, 15));
            mt.Them(new Ram(10000, 32));
            mt.Them(new Ram(5000, 64));
            mt.Them(new CPU(10000, 3.6f));
            Them(mt);

            mt = new MayTinh("MT01", "Dell 2025", new DateTime(2021, 10, 5));
            mt.Them(new CPU(200, 3.5f));
            mt.Them(new CPU(500, 5.0f));
            mt.Them(new Ram(30, 32));
            mt.Them(new Ram(100, 128));
            mt.Them(new Ram(50, 32));
            Them(mt);
        }

        // Nhap danh sach 5 may tinh tu ban phim
        public void NhapDanhSach()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nhap thong tin may tinh thu " + (i + 1) + ":");
                Console.Write("Ma so: ");
                string maso = Console.ReadLine();
                Console.Write("Ten: ");
                string ten = Console.ReadLine();
                Console.Write("Ngay mua (dd/mm/yyyy): ");
                DateTime ngayMua = DateTime.Parse(Console.ReadLine());

                MayTinh mt = new MayTinh(maso, ten, ngayMua);

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

                Them(mt);
            }
        }

        // Doc du lieu tu file
        public void DocTuFile(string tenFile)
        {

        }

        // Tim may tinh co gia lon nhat
        public MayTinh TimMayTinhGiaLonNhat()
        {
            if (dsMayTinh.Count == 0) return null;

            MayTinh maxMT = dsMayTinh[0];
            int maxGia = maxMT.TinhGia();

            foreach (var mt in dsMayTinh)
            {
                int gia = mt.TinhGia();
                if (gia > maxGia)
                {
                    maxGia = gia;
                    maxMT = mt;
                }
            }

            return maxMT;
        }

        // Tim danh sach may tinh co 2 thanh Ram
        public List<MayTinh> TimMayTinhCo2ThanhRam()
        {
            List<MayTinh> ketQua = new List<MayTinh>();

            foreach (var mt in dsMayTinh)
            {
                int countRam = 0;
                foreach (var tb in mt.DsThietBi)
                {
                    if (tb is Ram)
                        countRam++;
                }

                if (countRam == 2)
                    ketQua.Add(mt);
            }

            return ketQua;
        }

        // Hien thi may tinh theo gia tang dan
        public void HienThiTheoGiaTangDan()
        {
            List<MayTinh> sorted = new List<MayTinh>(dsMayTinh);

            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[i].TinhGia() > sorted[j].TinhGia())
                    {
                        MayTinh temp = sorted[i];
                        sorted[i] = sorted[j];
                        sorted[j] = temp;
                    }
                }
            }

            Console.WriteLine("Danh sach may tinh theo gia tang dan:");
            foreach (var mt in sorted)
            {
                Console.WriteLine(mt + " - Gia: " + mt.TinhGia());
            }
        }

        // Tinh tong gia cua tat ca may tinh
        public int TinhTongGia()
        {
            int tongGia = 0;
            foreach (var mt in dsMayTinh)
            {
                tongGia += mt.TinhGia();
            }
            return tongGia;
        }

        // Sap xep danh sach giam dan theo ten
        public void SapXepGiamDanTheoTen()
        {
            for (int i = 0; i < dsMayTinh.Count - 1; i++)
            {
                for (int j = i + 1; j < dsMayTinh.Count; j++)
                {
                    if (string.Compare(dsMayTinh[i].Ten, dsMayTinh[j].Ten) < 0)
                    {
                        MayTinh temp = dsMayTinh[i];
                        dsMayTinh[i] = dsMayTinh[j];
                        dsMayTinh[j] = temp;
                    }
                }
            }
        }

        // Sap xep tang dan theo so luong thiet bi
        public void SapXepTangDanTheoSoThietBi()
        {
            for (int i = 0; i < dsMayTinh.Count - 1; i++)
            {
                for (int j = i + 1; j < dsMayTinh.Count; j++)
                {
                    if (dsMayTinh[i].DsThietBi.Count > dsMayTinh[j].DsThietBi.Count)
                    {
                        MayTinh temp = dsMayTinh[i];
                        dsMayTinh[i] = dsMayTinh[j];
                        dsMayTinh[j] = temp;
                    }
                }
            }
        }

        // Tim RAM co gia lon nhat
        public Ram TimRamGiaLonNhat()
        {
            Ram maxRam = null;
            int maxGia = 0;

            foreach (var mt in dsMayTinh)
            {
                foreach (var tb in mt.DsThietBi)
                {
                    if (tb is Ram ram)
                    {
                        if (ram.Gia > maxGia)
                        {
                            maxGia = ram.Gia;
                            maxRam = ram;
                        }
                    }
                }
            }

            return maxRam;
        }
    }
}
