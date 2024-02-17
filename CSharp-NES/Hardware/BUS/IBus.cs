namespace CSharp_NES.Hardware.BUS
{
    internal interface IBus
    {
        public void Write(ushort addr, byte data);

        public byte Read(ushort addr, bool bReadOnly = false);
    }
}
