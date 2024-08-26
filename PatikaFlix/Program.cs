using PatikaFlix;
using System.Runtime.Serialization;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        //Lİstemizi oluşturuz
        List<Serials> serial = new List<Serials> ();
        //Başka biri dizi eklemek istersek bu değişkene göre do while çalıştırıyoruz
        string IsActive;
        do
        {
            //Liste için gerekli bilgileri kullanıcıdan alıyoruz
            Console.WriteLine("Dizi Oluşturma Programına Hoşgeldiniz");

            Console.WriteLine("Lütfen Dizi Adını Giriniz");
            string serialName = Console.ReadLine().ToUpper().Trim();
            //sayı harici birşey girerse sonsuz döngüye sokup tekrar girmesini istiyoruz
            Console.WriteLine("Lütfen Yapım Yılını Giriniz");
            int yearOfProduction;
            while (!int.TryParse(Console.ReadLine(), out yearOfProduction))
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz:");
            }

            Console.WriteLine("Lütfen Dizi Türünü Giriniz");
            string serialKind = Console.ReadLine();

            Console.WriteLine("Yayına Giriş Yılını Giriniz");
            int yearOfLaunch;
            while (!int.TryParse(Console.ReadLine(), out yearOfLaunch))
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz:");
            }

            Console.WriteLine("Yönetmen İsmini Giriniz");
            string director = Console.ReadLine().ToUpper().Trim();

            Console.WriteLine("Yayınlandığı İlk Platform İsmi");
            string firstPlatform = Console.ReadLine().ToUpper().Trim();

            serial.Add(new Serials(serialName, yearOfProduction, serialKind, yearOfLaunch, director, firstPlatform));

            Console.WriteLine("Başka Bir Dizi Oluşturmak İstermisin ?\n[E]\n[N]");
            IsActive = Console.ReadLine().ToUpper();
        } while (IsActive == "E");

        //değişken tanımlıyoruz . Tanımladıgımız listeyi OrderBy Dizi ismine göre ASC olarak sıralıyor.ThenBy ile de aynı dizi adı sahip diziler yönetmene göre listelenir.
        var showSerial = serial
            .OrderBy(s => s.SerialName)
            .ThenBy(s => s.Director)
            .ToList();
        //for ile filtreleme yaptıgımız değişkenin içinde dönüp ekrana basıyoruz.Dönüş Tipini class içerisinde belirlediğimiz için ekran formatını oradan ayarlıyabiliriz.
        foreach(var s in showSerial)
        {
            Console.WriteLine(s);
        }
        //komedi dizileri için oluşan dizimizin içine girerr where ile liste türünü kontrol ediyoruz. .Equals ile büyük küçük harf duyarlılığını kaldırıyoruz StringComparison ile
        //verilerimiz ekleyip sıralamayı yapıyoruz.
        List<ComedySerials> comedySerial = serial
            .Where(c => c.SerialKind.Equals("Komedi", StringComparison.OrdinalIgnoreCase))
            .Select(c => new ComedySerials(c.SerialName, c.SerialKind, c.Director))
            .OrderBy(c => c.SerialName)
            .ThenBy(c => c.Director)
            .ToList();
        //komedi türünde bir dizilerin olup olmadıgını kontrol edip ekrana basıyoruz
        if (comedySerial.Any())
        {
            Console.WriteLine("Komedi Türünde Diziler");
            foreach(var c in comedySerial)
            {
                Console.WriteLine(c);
            }
        }
        else
        {
            Console.WriteLine("Komedi Türünde Dizi Yok");
        }
        
        
    }
}