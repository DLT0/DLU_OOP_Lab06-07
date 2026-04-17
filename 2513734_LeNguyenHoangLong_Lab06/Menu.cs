using System;
using System.Collections.Generic;

namespace Lab06
{
    class Menu
    {
        enum ChucNang
        {
            Thoat,
            NhapCD,
            XuatDS,
            DocFile,
            TimPCGiaMax,
            TimDSCo2Thanh,
            HienThiTheoGia,
            TinhTongGia,
            SapGiamTheoTen,
            SapTangTheoTB,
            TimGiaRAMMax,
            NhapDanhSach
        }

        static void XuatMenu()
        {
            for (int i = 0; i <= (int)ChucNang.NhapDanhSach; i++)
            {
                Console.WriteLine("Nhap {0} de {1}", i, (ChucNang)i);
            }
        }

        static ChucNang ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("Chon chuc nang ({0}...{1}):", (int)ChucNang.Thoat, (int)ChucNang.NhapDanhSach);
                chon = int.Parse(Console.ReadLine());
                if ((int)ChucNang.Thoat <= chon && chon <= (int)ChucNang.NhapDanhSach)
                {
                    break;
                }
            } while (true);
            return (ChucNang)chon;
        }

        static void XuLyMenu(ChucNang chon, QuanLyMayTinh ql)
        {
            switch (chon)
            {
                case ChucNang.NhapCD:
                    ql.NhapCD();
                    Console.WriteLine("Da nhap du lieu co dinh!");
                    break;

                case ChucNang.XuatDS:
                    Console.WriteLine("Danh sach may tinh:");
                    Console.WriteLine(ql.ToString());
                    break;

                case ChucNang.DocFile:
                    Console.Write("Nhap ten file: ");
                    string tenFile = Console.ReadLine();
                    ql.DocTuFile(tenFile);
                    Console.WriteLine("Da doc file thanh cong!");
                    break;

                case ChucNang.TimPCGiaMax:
                    var mtMax = ql.TimMayTinhGiaLonNhat();
                    if (mtMax != null)
                    {
                        Console.WriteLine("May tinh co gia lon nhat:");
                        Console.WriteLine(mtMax);
                        Console.WriteLine("Gia: " + mtMax.TinhGia());
                    }
                    else
                    {
                        Console.WriteLine("Danh sach may tinh trong!");
                    }
                    break;

                case ChucNang.TimDSCo2Thanh:
                    var ds2Ram = ql.TimMayTinhCo2ThanhRam();
                    Console.WriteLine("Tim thay " + ds2Ram.Count + " may tinh co 2 thanh RAM:");
                    foreach (var mt in ds2Ram)
                    {
                        Console.WriteLine(mt);
                    }
                    break;

                case ChucNang.HienThiTheoGia:
                    ql.HienThiTheoGiaTangDan();
                    break;

                case ChucNang.TinhTongGia:
                    int tongGia = ql.TinhTongGia();
                    Console.WriteLine("Tong gia cua tat ca may tinh: " + tongGia);
                    break;

                case ChucNang.SapGiamTheoTen:
                    ql.SapXepGiamDanTheoTen();
                    Console.WriteLine("Da sap xep giam dan theo ten may tinh!");
                    break;

                case ChucNang.SapTangTheoTB:
                    ql.SapXepTangDanTheoSoThietBi();
                    Console.WriteLine("Da sap xep tang dan theo so thiet bi!");
                    break;

                case ChucNang.TimGiaRAMMax:
                    var ramMax = ql.TimRamGiaLonNhat();
                    if (ramMax != null)
                    {
                        Console.WriteLine("RAM co gia lon nhat:");
                        Console.WriteLine(ramMax);
                    }
                    else
                    {
                        Console.WriteLine("Khong co RAM nao!");
                    }
                    break;

                case ChucNang.NhapDanhSach:
                    ql.NhapDanhSach();
                    Console.WriteLine("Da nhap danh sach thanh cong!");
                    break;

                case ChucNang.Thoat:
                    Console.WriteLine("Tam biet!");
                    break;

                default:
                    Console.WriteLine("Chuc nang khong hop le!");
                    break;
            }
        }

        public static void ChayChuongTrinh()
        {
            QuanLyMayTinh qlmt = new QuanLyMayTinh();
            ChucNang cn;

            do
            {
                XuatMenu();
                cn = ChonMenu();
                XuLyMenu(cn, qlmt);

                if (cn != ChucNang.Thoat)
                {
                    Console.WriteLine("Nhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (cn != ChucNang.Thoat);
        }
    }
}