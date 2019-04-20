using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Be.IO;

namespace FreeLive
{
    public class L2BinaryReader : BeBinaryReader
    {
        public int FormatVersion { get; set; }

        public L2BinaryReader(Stream s) : base(s)
        {
        }

        public L2BinaryReader(Stream s, Encoding e) : base(s, e)
        {
        }

        public L2BinaryReader(Stream s, Encoding e, bool leaveOpen) : base(s, e, leaveOpen)
        {
        }

        public int[] ReadIntArray()
        {
            var len = ReadNumber();
            int[] array = new int[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = ReadInt32();
            }

            return array;
        }

        public float[] ReadFloatArray()
        {
            var len = ReadNumber();
            float[] array = new float[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = ReadSingle();
            }

            return array;
        }

        public double[] ReadDoubleArray()
        {
            var len = ReadNumber();
            double[] array = new double[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = ReadSingle();
            }

            return array;
        }

        public int ReadNumber()
        {
            var b1 = ReadByte();
            if ((b1 & 0b10000000) == 0)
            {
                return b1 & 0b11111111;
            }

            var b2 = ReadByte();
            if ((b2 & 0b10000000) == 0)
            {
                return (b1 & 0b01111111) << 7 | (b2 & 0b01111111);
            }

            var b3 = ReadByte();
            if ((b3 & 0b10000000) == 0)
            {
                return (b1 & 0b01111111) << 14 | (b2 & 0b01111111) << 7 | (b3 & 0b11111111);
            }
            int b4 = ReadByte();
            if ((b4 & 0b10000000) != 0)
            {
                throw new ArgumentOutOfRangeException("", "Only support 32bit number.");
            }
            return (b1 & 0b01111111) << 21 | (b2 & 0b01111111) << 14 | (b3 & 0b01111111) << 7 | (b4 & 0b11111111);
        }

        public string ReadUTF8String()
        {
            var len = ReadNumber();
            return Encoding.UTF8.GetString(ReadBytes(len));
        }

        public long ReadLongNumber()
        {
            long result = 0;
            byte b;
            do
            {
                b = ReadByte();
                result = (result << 7) + (b & 0x7F);
            } while (b >= 0x80);
            return result;
        }
    }
}
