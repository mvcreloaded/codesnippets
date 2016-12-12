using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpenXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "test.xlsx";
            SpreadSheetHelper.Make(fileName);

           // Console.Read();
        }
    }
}
