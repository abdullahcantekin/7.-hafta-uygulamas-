using System;

namespace HayvanatBahcesi
{
    // Temel Hayvan Sınıfı
    class Hayvan
    {
        // Ortak özellikler: Ad, Tür ve Yaş
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        // SesCikar metodu - türetilmiş sınıflarda override edilebilsin diye virtual olarak tanımlandı
        public virtual void SesCikar()
        {
            Console.WriteLine("Bu hayvan bir ses çıkarıyor.");
        }

        // Bilgi yazdırma metodu
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Tür: {Tur}, Yaş: {Yas}");
        }
    }

    // Memeli Sınıfı - Hayvan sınıfından türetiliyor
    class Memeli : Hayvan
    {
        // Memeliye özel ek özellik: Tüy Rengi
        public string TuyRengi { get; set; }

        // SesCikar metodunu memeliye özgü şekilde override ediyor
        public override void SesCikar()
        {
            Console.WriteLine("Memeli: Mırıldanma veya hırıltı sesi çıkarıyor.");
        }

        // Bilgi yazdırma metodunu override ederek memeliye özgü bilgileri ekliyor
        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Temel sınıfın bilgilerini yazdırır
            Console.WriteLine($"Tüy Rengi: {TuyRengi}");
        }
    }

    // Kuş Sınıfı - Hayvan sınıfından türetiliyor
    class Kus : Hayvan
    {
        // Kuşa özel ek özellik: Kanat Genişliği
        public double KanatGenisligi { get; set; }

        // SesCikar metodunu kuşa özgü şekilde override ediyor
        public override void SesCikar()
        {
            Console.WriteLine("Kuş: Cik cik sesi çıkarıyor.");
        }

        // Bilgi yazdırma metodunu override ederek kuşa özgü bilgileri ekliyor
        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Temel sınıfın bilgilerini yazdırır
            Console.WriteLine($"Kanat Genişliği: {KanatGenisligi} cm");
        }
    }

    // Program Sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçiniz (1: Memeli, 2: Kuş): ");
            int secim = int.Parse(Console.ReadLine()); // Kullanıcıdan tür seçimi alınır

            Hayvan hayvan; // Polimorfizm için temel sınıf referansı

            // Kullanıcının seçimine göre memeli veya kuş nesnesi oluşturulur
            if (secim == 1) // Kullanıcı Memeli seçerse
            {
                hayvan = new Memeli(); // Memeli nesnesi oluşturulur

                // Kullanıcıdan Memeli bilgileri alınır
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();

                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();

                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());

                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).TuyRengi = Console.ReadLine(); // Casting ile türe özgü özellik atanır
            }
            else if (secim == 2) // Kullanıcı Kuş seçerse
            {
                hayvan = new Kus(); // Kuş nesnesi oluşturulur

                // Kullanıcıdan Kuş bilgileri alınır
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();

                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();

                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());

                Console.Write("Kanat Genişliği (cm): ");
                ((Kus)hayvan).KanatGenisligi = double.Parse(Console.ReadLine()); // Casting ile türe özgü özellik atanır
            }
            else
            {
                // Geçersiz seçim durumunda program sonlandırılır
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }

            // Seçilen hayvanın bilgileri ekrana yazdırılır
            Console.WriteLine("\nHayvan Bilgileri:");
            hayvan.BilgiYazdir();

            // Hayvanın ses çıkarma durumu ekrana yazdırılır
            Console.WriteLine("\nHayvanın Sesi:");
            hayvan.SesCikar();

            Console.WriteLine("\nProgram Sonlandı. Çıkmak için bir tuşa basınız...");
            Console.ReadKey(); // Programın kapanmasını bekler
        }
    }
}

