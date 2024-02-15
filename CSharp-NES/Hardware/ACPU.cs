namespace CSharp_NES.Hardware
{
    internal abstract class ACPU
    {
        public abstract void ConnectBus(Bus n);

        public enum FLAGS6502
        {
            C = (1 << 0),   // Carry bit
            Z = (1 << 1),   // Zero
            I = (1 << 2),   // Disable Interrupts
            D = (1 << 3),   // Decimal Mode (Not used)
            B = (1 << 4),   // Break
            U = (1 << 5),   // Unused
            V = (1 << 6),   // Overflow
            N = (1 << 7),   // Negative
        }

        public byte a = 0x00;       // Accumulator Register
        public byte x = 0x00;       // X Register
        public byte y = 0x00;       // Y Register
        public byte stkp = 0x00;    // Stack Pointer (points to a location on the BUS)
        public UInt16 pc = 0x0000;  // Program Counter
        public byte status = 0x00;  // Status Register
    }
}
