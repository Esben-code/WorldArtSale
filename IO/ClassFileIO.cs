using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class ClassFileIO
    {

        public ClassFileIO()
        {

        }

        public Dictionary<string, string> ReadDataFromCurrencyFile()
        {
            Dictionary<string, string> kodeValuta = new Dictionary<string, string>(); // read line by line, colon seperate 

                                                                                                              //ValutaKoderOgNavne.csv                              
            using (StreamReader reader = new StreamReader(@"C:\VS-codes\S\WPF\WorldArtSale\Repository\DataFiles\CurrencyIdName.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(';');
                    kodeValuta.Add(values[0], values[1]);
                }
            }

            return kodeValuta;
            

        }

    }
}
