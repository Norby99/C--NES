using CSharp_NES.Hardware.BUS;

namespace CSharp_NES.Hardware.CPU
{
    internal abstract class ACPU
    {
        public abstract void ConnectBus(IBus n);

        public enum FLAGS6502
        {
            C = 1 << 0,   // Carry bit
            Z = 1 << 1,   // Zero
            I = 1 << 2,   // Disable Interrupts
            D = 1 << 3,   // Decimal Mode (Not used)
            B = 1 << 4,   // Break
            U = 1 << 5,   // Unused
            V = 1 << 6,   // Overflow
            N = 1 << 7,   // Negative
        }

        //TODO: Maybe in the future change this to be private set
        public byte a = 0x00;       // Accumulator Register
        public byte x = 0x00;       // X Register
        public byte y = 0x00;       // Y Register
        public byte stkp = 0x00;    // Stack Pointer (points to a location on the BUS)
        public ushort pc = 0x0000;  // Program Counter
        public byte status = 0x00;  // Status Register

        public abstract void Clock();

        // Interrupts
        public abstract void Reset();
        public abstract void IRQ();
        public abstract void NMI();

        public abstract byte Fetch();
        public byte Fetched { get; private set; } = 0x00;

        public UInt16 AddrAbs { get; private set; } = 0x0000;
        public UInt16 AddrRel { get; private set; } = 0x0000;
        public byte Cycles { get; private set; } = 0;   // cicles left for the duration of the current instruction
        public byte Opcode { get; private set; } = 0x00;
    }
}
