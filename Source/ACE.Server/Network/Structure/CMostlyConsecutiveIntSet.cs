using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.Server.Network.Structure
{
    public class CMostlyConsecutiveIntSet
    {
        public int DatFileType;
        public int DatFileId;
        public int Iterations;
        public List<int> Ints = new();

        public CMostlyConsecutiveIntSet() { }

        public override string ToString()
        {
            var str = "";

            str += $"DatFileType: {DatFileType}" + Environment.NewLine;
            str += $"DatFileId:   {DatFileId}" + Environment.NewLine;
            str += $"Iterations:  {Iterations}" + Environment.NewLine;
            str += "Ints:" + Environment.NewLine;

            foreach (var i in Ints)
                str += $"  |   {i}" + Environment.NewLine;

            return str;
        }
    }

    public static class CMostlyConsecutiveIntSetExtensions
    {
        public static CMostlyConsecutiveIntSet ReadCMostlyConsecutiveIntSet(this BinaryReader reader)
        {
            var newObj = new CMostlyConsecutiveIntSet();
            newObj.DatFileType = reader.ReadInt32();
            newObj.DatFileId = reader.ReadInt32();
            newObj.Iterations = reader.ReadInt32();
            var iterations = 0;
            while (iterations != newObj.Iterations)
            {
                var x = reader.ReadInt32();
                if (x < 0)
                {
                    var xAbs = Math.Abs(x);
                    iterations += xAbs - 1;
                }
                else
                {
                    iterations++;
                }

                newObj.Ints.Add(x);
            }
            return newObj;
        }
    }
}
