using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pancake_order
{
    public class file
    {
        private string fileName;
        public file(string fileName)
        {
            this.fileName = fileName;
        }
        public void WriteOneLine(pancakes onePancake)
        {
            using (StreamWriter write = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                write.Write($"\n{onePancake.number};{onePancake.doughtype};{onePancake.fillingtype}");
            }
        }

    }
}
