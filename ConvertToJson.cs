using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace pharmaShop
{
    internal class ConvertToJson
    {
        public static T DeserializeObject<T>()
        {
            OpenFileDialog diawind = new OpenFileDialog();
            if (diawind.ShowDialog() == true)
            {
                string json = File.ReadAllText(diawind.FileName);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }
    }
}
