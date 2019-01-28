using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDiffTool.Models
{
    public class LineDiff
    {
        public int LineNum { get; set; }

        public string LineNumHex
        {
            get
            {
                return LineNum.ToString("X5");
            }
        }

        public string Change { get; set; }


    }
}
