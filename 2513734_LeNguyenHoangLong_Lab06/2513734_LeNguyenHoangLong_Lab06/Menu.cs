using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace Lab06
{
    class Menu
    {
        enum ChucNang
        {
            Thoat,
            NhapCDDS5MayTinh,
            NhapDanhSach,
            XuatDS,
            DocFile,
            TimPCGiaMax,
            TimDSCo2ThanhRam,
            HienThiTheoGia,
            TinhTongGia,
            SapGiamTheoTen,
            SapTangTheoTB,
            TimRAMMaxMin,
            TimCPUMaxMin,
            TimTheoTB,
            XoaMayTruocNamX,
            SapXepRamTang_GiaTang,
            ChenPCVaoIndex,
            XoaMayTinhCoItTB, // End
        }

        static void XuatMenu()
        {
            for (int i = 0; i <= (int)ChucNang.XoaMayTinhCoItTB; i++)
            {
                Console.WriteLine("Nhap {0} de {1}", i, (ChucNang)i);
            }
        }

        static ChucNang ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("Chon chuc nang ({0}...{1}):", (int)ChucNang.Thoat, (int)ChucNang.XoaMayTinhCoItTB);
                chon = int.Parse(Console.ReadLine());
                if ((int)ChucNang.Thoat <= chon && chon <= (int)ChucNang.XoaMayTinhCoItTB)
                {
                    break;
                }
            } while (true);
            return (ChucNang)chon;
        }

        static void XuLyMenu(ChucNang chon, QuanLyMayTinh ql)
        {
            QuanLyMayTinh kq = new QuanLyMayTinh();
            switch (chon)
            {
                case ChucNang.NhapCDDS5MayTinh:
                    ql.NhapCD();
                    Console.WriteLine("Da nhap danh sach gom 5 may tinh");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.XuatDS:
                    Console.WriteLine("\nDanh sach may tinh:");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.DocFile:
                    ql.DocTuFile("dsmaytinh.txt");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.TimPCGiaMax:
                    int max = 0;
                    kq = ql.TimKiem(SoSanhGia, max);
                    Console.WriteLine("\nDanh sach PC co gia max la:", max);
                    Console.WriteLine(kq);
                    break;
                case ChucNang.TimDSCo2ThanhRam:
                    kq = ql.TimKiem(SoSanhRam, 2);
                    Console.WriteLine("\nDanh sach PC co 2 thanh RAM la:");
                    Console.WriteLine(kq);
                    break;
                case ChucNang.HienThiTheoGia:
                    ql.HienThiTheoGia();
                    break;
                case ChucNang.TinhTongGia:
                    ql.HienThiTheoGia();
                    int sum = ql.TongGia();
                    for (int i = 0; i <= 30; i++)
                        Console.Write("=");
                    Console.WriteLine("\n{0,-20} {1,10}", "Tong gia", sum);
                    break;
                case ChucNang.SapGiamTheoTen:
                    Console.WriteLine("\nDanh sach may tinh truoc khi sap xep:");
                    Console.WriteLine(ql);
                    ql.SapGiamTheoTen();
                    Console.WriteLine("======================================");
                    Console.WriteLine("\nDanh sach may tinh sau khi sap xep:");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.SapTangTheoTB:
                    Console.WriteLine("\nDanh sach may tinh truoc khi sap xep:");
                    Console.WriteLine(ql);
                    ql.SapXepDelegate(SoSanhTB);
                    Console.WriteLine("======================================");
                    Console.WriteLine("\nDanh sach may tinh sau khi sap xep:");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.TimRAMMaxMin:
                    Console.WriteLine("\nDanh sach may tinh:");
                    Console.WriteLine(ql);
                    kq = ql.TimKiemNhat(SoSanhGiaRAMMax);
                    Console.WriteLine("\nCac may tinh co gia RAM cao nhat:");
                    Console.WriteLine(kq);

                    kq = ql.TimKiemNhat(SoSanhGiaRAMMin);
                    Console.WriteLine("\nCac may tinh co gia RAM thap nhat:");
                    Console.WriteLine(kq);
                    break;

                case ChucNang.TimCPUMaxMin:
                    Console.WriteLine("\nDanh sach may tinh:");
                    Console.WriteLine(ql);
                    kq = ql.TimKiemNhat(SoSanhGiaCPUMax);
                    Console.WriteLine("\nCac may tinh co gia CPU cao nhat:");
                    Console.WriteLine(kq);

                    kq = ql.TimKiemNhat(SoSanhGiaCPUMin);
                    Console.WriteLine("\nCac may tinh co gia CPU thap nhat:");
                    Console.WriteLine(kq);
                    break;
                case ChucNang.TimTheoTB:
                    kq = ql.TimKiemNhat(SoSanhSoTB);
                    Console.WriteLine("Danh sach may tinh co nhieu linh kien nhat: ");
                    Console.WriteLine(kq);
                    break;
                case ChucNang.XoaMayTruocNamX:
                    Console.WriteLine(ql);
                    Console.WriteLine("Nhap so nam muon xoa:");
                    int x = int.Parse(Console.ReadLine());
                    ql.XoaMayTinhSX_TruocNamX(x);
                    Console.WriteLine(ql);
                    break;
                case ChucNang.NhapDanhSach:
                    Console.WriteLine("Nhap so luong may tinh can them: ");
                    int n = int.Parse(Console.ReadLine());
                    ql.NhapDanhSach(n);
                    Console.WriteLine(ql);
                    break;

                case ChucNang.SapXepRamTang_GiaTang:
                    ql.SapXepDelegate(SapXepRamTang_GiaTang);
                    Console.WriteLine(ql);
                    break;

                case ChucNang.ChenPCVaoIndex:
                    Console.WriteLine("\nNhap vi tri can chen (0...{0})", ql.Count - 1);
                    int vt = int.Parse(Console.ReadLine());
                    ql.ChenVaoIndex(vt);

                    Console.WriteLine("\nDanh sach may tinh sau khi chen tai {0} la ", vt);
                    Console.WriteLine(ql);
                    break;
                case ChucNang.XoaMayTinhCoItTB:
                    ql.XoaMayTinhCoItTB(SoSanhSoTB);
                    Console.WriteLine("\nDanh sach may tinh sau khi xoa la:");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.Thoat:
                    break;
                default:
                    break;
            }
        }

        public static void ChayChuongTrinh()
        {
            QuanLyMayTinh ql = new QuanLyMayTinh();
            ChucNang chon;

            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == ChucNang.Thoat)
                {
                    break;
                }
                XuLyMenu(chon, ql);
                Console.ReadKey();
            } while (true);

        }
        static int SoSanhRam(object x, object y)
        {
            return (x as MayTinh).SoThanhRam.CompareTo((int)y);
        }
        static int SapXepRamTang_GiaTang(object x, object y)
        {
            MayTinh mt1 = x as MayTinh;
            MayTinh mt2 = y as MayTinh;
            return mt1.SoThanhRam.CompareTo(mt2.SoThanhRam) != 0 ? mt1.SoThanhRam.CompareTo(mt2.SoThanhRam) : mt1.Gia.CompareTo(mt2.Gia);
        }
        static int SoSanhGia(object x, object y)
        {
            return (x as MayTinh).Gia.CompareTo(y);
        }
        static int SoSanhTen(object x, object y)
        {
            return -(x as MayTinh).Ten.CompareTo((y as MayTinh).Ten);
        }
        static int SoSanhTB(object x, object y)
        {
            return (x as MayTinh).SoTB.CompareTo((y as MayTinh).SoTB);
        }

        static int SoSanhGiaRAMMax(object x, object y)
        {
            return (x as MayTinh).GiaRamCaoNhat().CompareTo((y as MayTinh).GiaRamCaoNhat());
        }
        static int SoSanhGiaRAMMin(object x, object y)
        {
            return -(x as MayTinh).GiaRamThapNhat().CompareTo((y as MayTinh).GiaRamThapNhat());
        }

        static int SoSanhGiaCPUMin(object x, object y)
        {
            return -(x as MayTinh).GiaCPUThapNhat().CompareTo((y as MayTinh).GiaCPUThapNhat());
        }

        static int SoSanhGiaCPUMax(object x, object y)
        {
            return (x as MayTinh).GiaCPUCaoNhat().CompareTo((y as MayTinh).GiaCPUCaoNhat());
        }

        static int SoSanhSoTB(object x, object y)
        {
            return (x as MayTinh).SoTB.CompareTo((y as MayTinh).SoTB);
        }

    }
}

