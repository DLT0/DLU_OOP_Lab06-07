using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;

namespace Lab07
{
    class Menu
    {
        enum ChucNang
        {
            ThoatChuongTrinh,
            DocDSTuFile,
            XuatDS,
            TimAnPhamCoGiaMax,
            TimDanhSachAnPhamThuocNXBX,
            HienThiCacAnPhamTheoGia,
            TinhTongGia,
            SapXepGiamTheoTen_GiamTheoGia, // SD Delegate
            SapXepAnPhamTangTheoTen_TangTheoGia, // IComparer
            TimCacAnPhamCoGiaThapNhat,
            XoaTatCaAnPhamCoGiaMin,
            ChenAnPhamVaoI, //End
        }

        static void XuatTieuDe()
        {
            for (int i = 0; i <= (int)ChucNang.ChenAnPhamVaoI; i++)
            {
                Console.WriteLine("Nhap {0} de {1}.", i, (ChucNang)i);
            }
        }
        static ChucNang ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("Chon chuc nang {0}...{1}: ", (int)ChucNang.ThoatChuongTrinh, (int)ChucNang.ChenAnPhamVaoI);
                chon = int.Parse(Console.ReadLine());
                if ((int)ChucNang.ThoatChuongTrinh <= chon && chon <= (int)ChucNang.ChenAnPhamVaoI)
                    break;
            } while (true);
            return (ChucNang)chon;
        }
        static void XuLyMenu(ChucNang chon, DanhSachAnPham ql)
        {
            DanhSachAnPham kq = new DanhSachAnPham();
            switch (chon)
            {
                case ChucNang.ThoatChuongTrinh:
                    break;
                case ChucNang.DocDSTuFile:
                    ql.DocFile("dsanpham.txt");
                    Console.WriteLine(ql);
                    break;
                case ChucNang.XuatDS:
                    ql.XuatDS();
                    break;
                case ChucNang.TimAnPhamCoGiaMax:
                    //Xuat DS AN PHAM CO GIA MAX
                    //float max = ql.GiaMax();
                    //kq = ql.TimKiemDelegate(SoSanhGia, max);
                    //Console.WriteLine("DS An Pham co gia Max = {0} la : ", max);
                    //Console.WriteLine(kq);

                    //XUAT MOT AN PHAM (DAUTIEN) CO GIA MAX
                    int vt = ql.TimMotAP();
                    Console.WriteLine(ql[vt]);

                    break;
                case ChucNang.TimDanhSachAnPhamThuocNXBX:
                    string nxbCanTim = "";

                    ql.XuatDS();
                    Console.WriteLine("\nNhap Ten NXB Can Tim");
                    nxbCanTim = Console.ReadLine();
                    kq = ql.TimKiemDelegate(SoSanhNXB, nxbCanTim.ToLower());

                    if (kq.Count == 0)
                    {
                        Console.WriteLine("Khong Co NXB {0} Can Tim.", nxbCanTim);

                    }
                    else
                    {
                        Console.WriteLine("\nDanh sach an pham tu NXB " + nxbCanTim);
                        Console.WriteLine(kq);
                    }
                    break;
                case ChucNang.HienThiCacAnPhamTheoGia:
                    ql.HienThiTheoGia();
                    break;
                case ChucNang.TinhTongGia:
                    float sum = ql.TongGia();
                    ql.HienThiTheoGia();
                    for (int i = 0; i <= 35; i++)
                        Console.Write("=");
                    Console.WriteLine("\n{0, -25} {1,10:0.000}", "Tong Gia", sum);
                    break;
                case ChucNang.SapXepGiamTheoTen_GiamTheoGia:
                    ql.SapXepDelegate(SapGiamTheoTen_GiamTheoGia);
                    ql.XuatDS();
                    break;
                case ChucNang.SapXepAnPhamTangTheoTen_TangTheoGia:
                    ql.SapXep_IComparer();
                    Console.WriteLine(ql);
                    break;
                case ChucNang.TimCacAnPhamCoGiaThapNhat:
                    float min = ql.GiaMin();
                    kq = ql.TimKiemDelegate(SoSanhGia, min);
                    Console.WriteLine("DS An Pham co gia Min = {0} la : ", min);
                    Console.WriteLine(kq);
                    break;
                case ChucNang.XoaTatCaAnPhamCoGiaMin:
                    ql.XuatDS();
                    ql.XoaAnPhamGiaMin();
                    Console.WriteLine("Danh sach sau khi xoa cac an pham co gia min la ");
                    ql.XuatDS();
                    break;
                case ChucNang.ChenAnPhamVaoI:
                    Console.WriteLine("Nhap vi tri can chen (0..{0}):", ql.Count);
                    int vitri;
                    while (!int.TryParse(Console.ReadLine(), out vitri) || vitri < 0 || vitri > ql.Count)
                    {
                        Console.WriteLine("Vi tri khong hop le. Vui long nhap lai (0..{0}):", ql.Count);
                    }
                    ql.Chen(vitri);
                    ql.XuatDS();
                    break;
                default:
                    break;
            }
        }
        public static void ChayChuongTrinh()
        {
            ChucNang chon;
            DanhSachAnPham ql = new DanhSachAnPham();
            do
            {
                Console.Clear();
                XuatTieuDe();
                chon = ChonMenu();
                if (chon == ChucNang.ThoatChuongTrinh)
                    break;
                XuLyMenu(chon, ql);
                Console.ReadKey();
            } while (true);
        }
        static int SoSanhGia(object x, object y)
        {
            return (x as IAnPham).GiaTien.CompareTo(y);
        }
        static int SoSanhNXB(object x, object y)
        {
            return (x as IAnPham).NhaXuatBan.ToLower().CompareTo((string)y);
        }
        static int SapGiamTheoTen_GiamTheoGia(object x, object y)
        {
            IAnPham ap1 = x as IAnPham;
            IAnPham ap2 = y as IAnPham;
            return ap2.Ten.CompareTo(ap1.Ten) != 0 ? ap2.Ten.CompareTo(ap1.Ten) : ap2.GiaTien.CompareTo(ap1.GiaTien);
        }
    }

}
