using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDiffTool.Models
{
    public class BinaryFileComparer
    {
         public static IEnumerable<LineDiff> GetDifferences(string file1, string file2)
        {
            var diffs = new List<LineDiff>();
            LineDiff diffFound;
            byte[] file1Bytes;
            byte[] file2Bytes;

            file1Bytes = File.ReadAllBytes(file1);
            file2Bytes = File.ReadAllBytes(file2);

            if(file2Bytes.Count() >= file1Bytes.Count())
            {
                for(int i = 0; i < file1Bytes.Count(); i++)
                {
                    if(file1Bytes[i] != file2Bytes[i])
                    {
                        diffFound = new LineDiff();
                        diffFound.LineNum = i;
                        diffFound.Change = $" {file1Bytes[i]:X2} -> {file2Bytes[i]:X2}";
                        diffs.Add(diffFound);
                    }
                }
                for(int i = file1Bytes.Count(); i < file2Bytes.Count(); i++)
                {
                    diffFound = new LineDiff();
                    diffFound.LineNum = i;
                    diffFound.Change = $" added -> {file2Bytes[i]}";
                    diffs.Add(diffFound);
                }
            }

            return diffs.AsEnumerable();
        }
    }
}
