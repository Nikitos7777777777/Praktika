using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtogovuiP
{
    internal class JsonDes
    {
       
            public static d DeserializeObject<d>()
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == true)
                {
                    string jsonFile = File.ReadAllText(file.FileName);
                    d result = JsonConvert.DeserializeObject<d>(jsonFile);
                    return result;
                }
                else
                {
                    return default(d);
                }
            }
    }
}
