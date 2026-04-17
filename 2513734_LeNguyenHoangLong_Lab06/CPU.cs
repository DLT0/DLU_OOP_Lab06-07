using System;

namespace Lab06
{
    class CPU : IThietBi
    {
        int gia;
        float tocdo;
        public int Gia
        {
            get { return gia; }
        }
        public float TocDo
        {
            get { return tocdo; }
            set { tocdo = value; }
        }
        public CPU()
        {

        }
        public CPU(int g, float td)
        {
            this.gia = g;
            this.TocDo = td;
        }
        public override string ToString()
        {
            return String.Format("CPU gia={0}, tocdo={1}", Gia, TocDo);
        }
    }
}
