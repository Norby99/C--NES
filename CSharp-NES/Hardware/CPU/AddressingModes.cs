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
            throw new NotImplementedException();
        }

        public byte IMM()
        {
            throw new NotImplementedException();
        }

        public byte ZP0()
        {
            throw new NotImplementedException();
        }

        public byte ZPX()
        {
            throw new NotImplementedException();
        }

        public byte ZPY()
        {
            throw new NotImplementedException();
        }

        public byte REL()
        {
            throw new NotImplementedException();
        }

        public byte ABS()
        {
            throw new NotImplementedException();
        }

        public byte ABX()
        {
            throw new NotImplementedException();
        }

        public byte ABY()
        {
            throw new NotImplementedException();
        }

        public byte IND()
        {
            throw new NotImplementedException();
        }

        public byte IZX()
        {
            throw new NotImplementedException();
        }

        public byte IZY()
        {
            throw new NotImplementedException();
        }
    }
}
