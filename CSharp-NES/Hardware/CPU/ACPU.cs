using CSharp_NES.Hardware.BUS;

namespace CSharp_NES.Hardware.CPU
{
    internal struct Registers
    {
        public byte A;          // Accumulator Register
        public byte X;          // X Register
        public byte Y;          // Y Register
        public byte STKP;       // Stack Pointer (points to a location on the BUS)
        public ushort PC;       // Program Counter
        public byte Status;     // Status Register

        public Registers()
        {
            A = 0x00;
            X = 0x00;
            Y = 0x00;
            STKP = 0x00;
            PC = 0x0000;
            Status = 0x00;
        }
    }

    internal struct InternalVar
    {
        public byte Fetched;    // Represents the working input value to the ALU
        public UInt16 AddrAbs;
        public UInt16 AddrRel;
        public byte Cycles;     // cicles left for the duration of the current instruction
        public byte Opcode;

        public InternalVar()
        {
            Fetched = 0x00;
            AddrAbs = 0x0000;
            AddrRel = 0x0000;
            Cycles = 0;
            Opcode = 0x00;
        }
    }

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

        public abstract void Clock();

        // Interrupts
        public abstract void Reset();
        public abstract void IRQ();
        public abstract void NMI();

        public abstract byte Fetch();

        public abstract void Write(ushort addr, byte data);
        public abstract byte Read(ushort addr);
    }
}
