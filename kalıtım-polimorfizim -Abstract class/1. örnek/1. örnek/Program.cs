using System;

namespace CalisanYonetimSistemi
{
    // Temel Calisan Sınıfı
    class Calisan
    {
        // Çalışanların ortak özellikleri
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double Maas { get; set; }
        public string Pozisyon { get; set; }

        // Sanal BilgiYazdir() metodu - Polimorfizm için
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas} TL, Pozisyon: {Pozisyon}");
        }
    }

    // Yazilimci Sınıfı - Calisan sınıfından türetiliyor
    class Yazilimci : Calisan
    {
        // Yazılım dili özelliği
        public string YazilimDili { get; set; }

        // BilgiYazdir() metodunu override ederek özelleştiriyoruz
        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Temel sınıfın BilgiYazdir metodunu çağır
            Console.WriteLine($"Yazılım Dili: {YazilimDili}"); // Ek bilgi yazdır
        }
    }

    // Muhasebeci Sınıfı - Calisan sınıfından türetiliyor
    class Muhasebeci : Calisan
    {
        // Muhasebe yazılımı özelliği
        public string MuhasebeYazilimi { get; set; }

        // BilgiYazdir() metodunu override ederek özelleştiriyoruz
        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Temel sınıfın BilgiYazdir metodunu çağır
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}"); // Ek bilgi yazdır
        }
    }

    // Ana Program Sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçiniz (1: Yazılımcı, 2: Muhasebeci): ");
            int secim = int.Parse(Console.ReadLine()); // Kullanıcıdan seçim alınıyor

            Calisan calisan; // Polimorfizm için temel sınıf referansı kullanılıyor

            // Kullanıcı Yazılımcı seçerse
            if (secim == 1)
            {
                calisan = new Yazilimci(); // Yazilimci nesnesi oluşturuluyor

                // Kullanıcıdan Yazılımcı bilgileri alınıyor
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();

                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();

                Console.Write("Maaş: ");
                calisan.Maas = double.Parse(Console.ReadLine());

                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();

                Console.Write("Yazılım Dili: ");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine(); // Casting kullanılarak YazilimDili set ediliyor
            }
            // Kullanıcı Muhasebeci seçerse
            else if (secim == 2)
            {
                calisan = new Muhasebeci(); // Muhasebeci nesnesi oluşturuluyor

                // Kullanıcıdan Muhasebeci bilgileri alınıyor
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();

                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();

                Console.Write("Maaş: ");
                calisan.Maas = double.Parse(Console.ReadLine());

                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();

                Console.Write("Muhasebe Yazılımı: ");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine(); // Casting kullanılarak MuhasebeYazilimi set ediliyor
            }
            else
            {
                // Geçersiz seçim durumunda program sonlandırılır
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }

            // Çalışan bilgileri ekrana yazdırılıyor
            Console.WriteLine("\nÇalışan Bilgileri:");
            calisan.BilgiYazdir(); // Polimorfizm kullanılarak doğru sınıfın BilgiYazdir metodu çağrılır

            // Program sonu
            Console.WriteLine("\nProgram Sonlandı. Çıkmak için bir tuşa basınız...");
            Console.ReadKey();
        }
    }
}
