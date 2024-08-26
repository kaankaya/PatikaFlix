using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaFlix
{
    public class ComedySerials
    {
        public string SerialName { get; set; }
        public string SerialKind { get; set; }
        public string Director { get; set; }

        public ComedySerials(string serialName, string serialKind, string director)
        {
            SerialName = serialName;
            SerialKind = serialKind;
            Director = director;
        }
        public override string ToString()
        {
            return $"Dizi Adı : {SerialName} - Dizi Türü : {SerialKind} - Yönetmen : {Director}";
        }
    }
}
