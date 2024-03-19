using System.Runtime.CompilerServices;

namespace CSharp_NES.Hardware.CPU
{
    internal class AddressingModes
    {
        private ACPU CPU;
        private Registers RG;
        private InternalVar IV;

        public AddressingModes(ACPU cpu, Registers rg, InternalVar iv)
        {
            CPU = cpu;
            RG = rg;
            IV = iv;
        }

        // Addressing Modes
        public byte IMP()
        {
            IV.Fetched = RG.A;
            return 0;
        }

        public byte IMM()
        {
            IV.AddrAbs = RG.PC++;
            return 0;
        }

        public byte ZP0()
        {
            IV.AddrAbs = CPU.Read(RG.PC);
            RG.PC++;
            IV.AddrAbs &= 0x00FF;
            return 0;
        }

        public byte ZPX()
        {
            IV.AddrAbs = (ushort)(CPU.Read(RG.PC) + RG.X);
            RG.PC++;
            IV.AddrAbs &= 0x00FF;
            return 0;
        }

        public byte ZPY()
        {
            IV.AddrAbs = (ushort)(CPU.Read(RG.PC) + RG.Y);
            RG.PC++;
            IV.AddrAbs &= 0x00FF;
            return 0;
        }

        public byte REL()
        {
            IV.AddrRel = CPU.Read(RG.PC);
            RG.PC++;

            if ((IV.AddrRel & 0x80) != 0)
            {
                IV.AddrRel |= 0xFF00;
            }

            return 0;
        }

        public byte ABS()
        {
            UInt16 lo = CPU.Read(RG.PC);
            RG.PC++;
            UInt16 hi = CPU.Read(RG.PC);
            RG.PC++;

            IV.AddrAbs = (ushort)((hi << 8) | lo);

            return 0;
        }

        public byte ABX()
        {
            UInt16 lo = CPU.Read(RG.PC);
            RG.PC++;
            UInt16 hi = CPU.Read(RG.PC);
            RG.PC++;

            IV.AddrAbs = (ushort)((hi << 8) | lo);
            IV.AddrAbs += RG.X;

            // returns 1 if it occured an overflow and an other clock cycle is required
            return (byte)((IV.AddrAbs & 0xFF00) != (hi << 8) ? 1 : 0);  
        }

        public byte ABY()
        {
            UInt16 lo = CPU.Read(RG.PC);
            RG.PC++;
            UInt16 hi = CPU.Read(RG.PC);
            RG.PC++;

            IV.AddrAbs = (ushort)((hi << 8) | lo);
            IV.AddrAbs += RG.Y;

            // returns 1 if it occured an overflow and an other clock cycle is required
            return (byte)((IV.AddrAbs & 0xFF00) != (hi << 8) ? 1 : 0);
        }


        // same as above but using indicators

        public byte IND()
        {
            UInt16 ptrLo = CPU.Read(RG.PC);
            RG.PC++;
            UInt16 ptrHi = CPU.Read(RG.PC);
            RG.PC++;

            UInt16 ptr = (UInt16)((ptrHi << 8) | ptrLo);

            if (ptrLo == 0x00FF)    // Simulate page boundary hardware bug
            {
                IV.AddrAbs = (ushort)((CPU.Read((ushort)(ptr & 0xFF00)) << 8) | CPU.Read((ushort)(ptr + 0)));
            }
            else    // Normal behaviour
            {
                IV.AddrAbs = (ushort)(CPU.Read((ushort)((ptr + 1) << 8)) | CPU.Read((ushort)(ptr + 0)));
            }

            return 0;
        }

        public byte IZX()
        {
            UInt16 t = CPU.Read(RG.PC);
            RG.PC++;

            UInt16 lo = CPU.Read((ushort)((UInt16)(t + (UInt16)RG.X) & 0x00FF));
            UInt16 hi = CPU.Read((ushort)((UInt16)(t + (UInt16)RG.X + 1) & 0x00FF));

            IV.AddrAbs = (ushort)((hi << 8) | lo);

            return 0;
        }

        public byte IZY()
        {
            UInt16 t = CPU.Read(RG.PC);
            RG.PC++;

            UInt16 lo = CPU.Read((ushort)(t & 0x00FF));
            UInt16 hi = CPU.Read((ushort)((t + 1) & 0x00FF));

            IV.AddrAbs = (ushort)((hi << 8) | lo);
            IV.AddrAbs += RG.Y;

            // returns 1 if it occured an overflow and an other clock cycle is required
            return (byte)((IV.AddrAbs & 0xFF00) != (hi << 8) ? 1 : 0);
        }
    }
}
