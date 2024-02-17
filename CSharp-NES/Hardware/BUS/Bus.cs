using CSharp_NES.Hardware.CPU;

namespace CSharp_NES.Hardware.BUS
{
    internal class Bus : IBus
    {
        // DEVICES
        public ACPU CPU = new olc6502();
        public byte[] RAM { get; private set; } = new byte[1024 * 64];

        public Bus()
        {
            // Clearing the RAM
            Array.Clear(RAM, 0x00, RAM.Length);

            // Connecting the CPU to the BUS
            CPU.ConnectBus(this);
        }

        public void Write(ushort addr, byte data)
        {
            if (addr >= 0x0000 && addr <= 0xFFFF)
            {
                RAM[addr] = data;
            }
        }

        public byte Read(ushort addr, bool bReadOnly = false)
        {
            if (addr >= 0x0000 && addr <= 0xFFFF)
            {
                return RAM[addr];
            }

            return 0x00;
        }
    }
}
