using System;

namespace BankaSistemi
{
    // Temel Hesap Sınıfı
    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public string HesapSahibi { get; set; }
        public double Bakiye { get; set; }

        // Para yatırma işlemi - Virtual metod
        public virtual void ParaYatir(double miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni Bakiye: {Bakiye} TL");
        }

        // Para çekme işlemi - Virtual metod
        public virtual void ParaCek(double miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Kalan Bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        // Bilgi Yazdırma Metodu
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap Numarası: {HesapNumarasi}");
            Console.WriteLine($"Hesap Sahibi: {HesapSahibi}");
            Console.WriteLine($"Bakiye: {Bakiye} TL");
        }
    }

    // Vadesiz Hesap Sınıfı
    class VadesizHesap : Hesap
    {
        public double EkHesapLimiti { get; set; }

        // Para çekme işlemi - Override
        public override void ParaCek(double miktar)
        {
            double toplamLimit = Bakiye + EkHesapLimiti;

            if (toplamLimit >= miktar)
            {
                double fark = miktar - Bakiye;
                if (fark > 0)
                {
                    EkHesapLimiti -= fark;
                    Bakiye = 0;
                }
                else
                {
                    Bakiye -= miktar;
                }
                Console.WriteLine($"{miktar} TL çekildi. Kalan Bakiye: {Bakiye} TL, Ek Hesap Limiti: {EkHesapLimiti} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
            }
        }

        // Bilgi Yazdırma - Override
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
        }
    }

    // Vadeli Hesap Sınıfı
    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public double FaizOrani { get; set; }
        private bool VadeDolduMu { get; set; } = false;

        // Para çekme işlemi - Override
        public override void ParaCek(double miktar)
        {
            if (VadeDolduMu)
            {
                base.ParaCek(miktar);
            }
            else
            {
                Console.WriteLine("Vade süresi dolmadan para çekemezsiniz!");
            }
        }

        // Bilgi Yazdırma - Override
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} gün, Faiz Oranı: %{FaizOrani}");
        }

        // Vade Süresini Doldur
        public void VadeDoldur()
        {
            VadeDolduMu = true;
            double faizGetirisi = Bakiye * (FaizOrani / 100);
            Bakiye += faizGetirisi;
            Console.WriteLine($"Vade süresi doldu. Faiz getirisi: {faizGetirisi} TL. Yeni Bakiye: {Bakiye} TL");
        }
    }

    // Program Sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçiniz (1: Vadesiz Hesap, 2: Vadeli Hesap): ");
            int secim = int.Parse(Console.ReadLine());

            Hesap hesap; // Polimorfizm için temel sınıf referansı

            if (secim == 1) // Vadesiz Hesap
            {
                hesap = new VadesizHesap();

                // Bilgileri al
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();

                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();

                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());

                Console.Write("Ek Hesap Limiti: ");
                ((VadesizHesap)hesap).EkHesapLimiti = double.Parse(Console.ReadLine());
            }
            else if (secim == 2) // Vadeli Hesap
            {
                hesap = new VadeliHesap();

                // Bilgileri al
                Console.Write("Hesap Numarası: ");
                hesap.HesapNumarasi = Console.ReadLine();

                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();

                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());

                Console.Write("Vade Süresi (gün): ");
                ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());

                Console.Write("Faiz Oranı (%): ");
                ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }

            // Hesap Bilgilerini Yazdır
            Console.WriteLine("\nHesap Bilgileri:");
            hesap.BilgiYazdir();

            // İşlem Seçenekleri
            Console.Write("\nPara yatırmak istediğiniz miktarı giriniz: ");
            double yatirilanMiktar = double.Parse(Console.ReadLine());
            hesap.ParaYatir(yatirilanMiktar);

            Console.Write("\nPara çekmek istediğiniz miktarı giriniz: ");
            double cekilenMiktar = double.Parse(Console.ReadLine());
            hesap.ParaCek(cekilenMiktar);

            // Vadeli Hesapta vade süresini doldurma
            if (hesap is VadeliHesap vadeliHesap)
            {
                Console.Write("\nVade süresini doldurmak ister misiniz? (Evet/Hayır): ");
                if (Console.ReadLine().ToLower() == "evet")
                {
                    vadeliHesap.VadeDoldur();
                }
            }

            // Son Hesap Bilgileri
            Console.WriteLine("\nGüncel Hesap Bilgileri:");
            hesap.BilgiYazdir();
        }
    }
}
