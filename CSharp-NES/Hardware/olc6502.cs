namespace CSharp_NES.Hardware
{
    internal class olc6502: ACPU
    {
        private Bus bus = null;

        public override void ConnectBus(Bus n)
        {
            bus = n;
        }

        private void Write(UInt16 addr, byte data)
        {
            bus.Write(addr, data);
        }

        private byte Read(UInt16 addr)
        {
            return bus.Read(addr, false);
        }

        private byte GetFlag(FLAGS6502 flag)
        {
            throw new NotImplementedException();
        }

        private SetFlag(FLAGS6502 flag)
        {
            throw new NotImplementedException();
        }
    }
}
