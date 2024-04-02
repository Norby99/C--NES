namespace CSharp_NES.Hardware.CPU
{
    internal class Opcodes
    {
        private ICPU CPU;
        private Registers RG;
        private InternalVar IV;

        public Opcodes(ICPU cpu, Registers rg, InternalVar iv)
        {
            CPU = cpu;
            RG = rg;
            IV = iv;
        }

        // OpcodesFN
        public byte ADC()
        {
            throw new NotImplementedException();
        }

        public byte AND()
        {
            CPU.Fetch();
            RG.A = (byte)(RG.A & IV.Fetched);
            CPU.SetFlag(FLAGS6502.Z, RG.A == 0x00);
            CPU.SetFlag(FLAGS6502.N, (RG.A & 0x80) != 0);   // it checks if the 7th bit is a 1. The conversion to bool must be done in this fancy way (TODO: check if it can be done with a bool cast)
            return 1;
        }

        public byte ASL()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Branch if Carry clear
        /// </summary>
        public byte BCC()
        {
            if (CPU.GetFlag(FLAGS6502.C) == 0)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        /// <summary>
        /// Branch if Carry is set
        /// </summary>
        public byte BCS()
        {
            if (CPU.GetFlag(FLAGS6502.C) == 1)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        /// <summary>
        /// Branch if equal
        /// </summary>
        public byte BEQ()
        {
            if (CPU.GetFlag(FLAGS6502.Z) == 1)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        public byte BIT()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Branch if negative
        /// </summary>
        public byte BMI()
        {
            if (CPU.GetFlag(FLAGS6502.N) == 1)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        /// <summary>
        /// Branch if not equal
        /// </summary>
        public byte BNE()
        {
            if (CPU.GetFlag(FLAGS6502.Z) == 0)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        /// <summary>
        /// Branch if positive
        /// </summary>
        public byte BPL()
        {
            if (CPU.GetFlag(FLAGS6502.N) == 0)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        public byte BRK()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Branch if overflow
        /// </summary>
        public byte BVC()
        {
            if (CPU.GetFlag(FLAGS6502.V) == 0)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        /// <summary>
        /// Branch if not overflowed
        /// </summary>
        public byte BVS()
        {
            if (CPU.GetFlag(FLAGS6502.V) == 1)
            {
                IV.Cycles++;
                IV.AddrAbs = (ushort)(RG.PC + IV.AddrRel);

                if ((IV.AddrAbs & 0xFF00) != (RG.PC & 0xFF00))
                {
                    IV.Cycles++;
                }

                RG.PC = IV.AddrAbs;
            }

            return 0;
        }

        /// <summary>
        /// Clear the Carry bit
        /// </summary>
        public byte CLC()
        {
            CPU.SetFlag(FLAGS6502.C, false);
            return 0;
        }

        public byte CLD()
        {
            CPU.SetFlag(FLAGS6502.D, false);
            return 0;
        }

        public byte CLI()
        {
            throw new NotImplementedException();
        }

        public byte CLV()
        {
            throw new NotImplementedException();
        }

        public byte CMP()
        {
            throw new NotImplementedException();
        }

        public byte CPX()
        {
            throw new NotImplementedException();
        }

        public byte CPY()
        {
            throw new NotImplementedException();
        }

        public byte DEC()
        {
            throw new NotImplementedException();
        }

        public byte DEX()
        {
            throw new NotImplementedException();
        }

        public byte DEY()
        {
            throw new NotImplementedException();
        }

        public byte EOR()
        {
            throw new NotImplementedException();
        }

        public byte INC()
        {
            throw new NotImplementedException();
        }

        public byte INX()
        {
            throw new NotImplementedException();
        }

        public byte INY()
        {
            throw new NotImplementedException();
        }

        public byte JMP()
        {
            throw new NotImplementedException();
        }

        public byte JSR()
        {
            throw new NotImplementedException();
        }

        public byte LDA()
        {
            throw new NotImplementedException();
        }

        public byte LDX()
        {
            throw new NotImplementedException();
        }

        public byte LDY()
        {
            throw new NotImplementedException();
        }

        public byte LSR()
        {
            throw new NotImplementedException();
        }

        public byte NOP()
        {
            throw new NotImplementedException();
        }

        public byte ORA()
        {
            throw new NotImplementedException();
        }

        public byte PHA()
        {
            throw new NotImplementedException();
        }

        public byte PHP()
        {
            throw new NotImplementedException();
        }

        public byte PLA()
        {
            throw new NotImplementedException();
        }

        public byte PLP()
        {
            throw new NotImplementedException();
        }

        public byte ROL()
        {
            throw new NotImplementedException();
        }

        public byte ROR()
        {
            throw new NotImplementedException();
        }

        public byte RTI()
        {
            throw new NotImplementedException();
        }

        public byte RTS()
        {
            throw new NotImplementedException();
        }

        public byte SBC()
        {
            throw new NotImplementedException();
        }

        public byte SEC()
        {
            throw new NotImplementedException();
        }

        public byte SED()
        {
            throw new NotImplementedException();
        }

        public byte SEI()
        {
            throw new NotImplementedException();
        }

        public byte STA()
        {
            throw new NotImplementedException();
        }

        public byte STX()
        {
            throw new NotImplementedException();
        }

        public byte STY()
        {
            throw new NotImplementedException();
        }

        public byte TAX()
        {
            throw new NotImplementedException();
        }

        public byte TAY()
        {
            throw new NotImplementedException();
        }

        public byte TSX()
        {
            throw new NotImplementedException();
        }

        public byte TXA()
        {
            throw new NotImplementedException();
        }

        public byte TXS()
        {
            throw new NotImplementedException();
        }

        public byte TYA()
        {
            throw new NotImplementedException();
        }

        // Illigal OpcodesFN
        public byte XXX()
        {
            throw new NotImplementedException();
        }
    }
}
