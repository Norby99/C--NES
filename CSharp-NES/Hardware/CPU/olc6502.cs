using CSharp_NES.Hardware.BUS;

namespace CSharp_NES.Hardware.CPU
{
    internal class olc6502 : ACPU
    {
        private IBus? bus = null;
        public Opcodes Opcodes { get; private set; }

        public olc6502()
        {
            Opcodes = new Opcodes();
        }

        public override void ConnectBus(IBus n)
        {
            bus = n;
        }

        private void Write(ushort addr, byte data)
        {
            bus.Write(addr, data);
        }

        private byte Read(ushort addr)
        {
            return bus.Read(addr, false);
        }

        private byte GetFlag(FLAGS6502 flag)
        {
            throw new NotImplementedException();
        }

        private void SetFlag(FLAGS6502 flag)
        {
            throw new NotImplementedException();
        }
    }
}
