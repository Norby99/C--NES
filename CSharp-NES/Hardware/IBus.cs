namespace CSharp_NES.Hardware
{
    internal interface IBus
    {
        public void Write(UInt16 addr, byte data);

        public byte Read(UInt16 addr, bool bReadOnly = false);
    }
}
