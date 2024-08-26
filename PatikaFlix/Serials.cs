using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaFlix
{
    public class Serials
    {
        public string SerialName { get; set; }
        public int YearOfProduction { get; set; }
        public string SerialKind { get; set; }
        public int YearOfLaunch { get; set; }
        public string Director { get; set; }
        public string FirstPlatform { get; set; }

        public Serials(string serialName, int yearOfProduction, string serialKind, int yearOfLaunch, string director, string firstPlatform)
        {
            SerialName = serialName;
            YearOfProduction = yearOfProduction;
            SerialKind = serialKind;
            YearOfLaunch = yearOfLaunch;
            Director = director;
            FirstPlatform = firstPlatform;
        }

        public override string ToString()
        {
            return $"Dizi Adı : {SerialName} (Yapım Yılı : {YearOfProduction}, Türü : {SerialKind}, Yayın : {YearOfLaunch}, Yönetmen : {Director}, Platform : {FirstPlatform})";
        }


    }
}
