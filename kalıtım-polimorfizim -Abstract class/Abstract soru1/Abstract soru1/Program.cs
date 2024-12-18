using System;

// Soyut Hesap Sınıfı
public abstract class Hesap
{
    public string HesapNo { get; set; }
    public decimal Bakiye { get; set; }

    // Para yatırma metodu (soyut olarak tanımlandı, türetilmiş sınıflarda implement edilecek)
    public abstract void ParaYatir(decimal miktar);

    // Para çekme metodu (soyut olarak tanımlandı, türetilmiş sınıflarda implement edilecek)
    public abstract void ParaCek(decimal miktar);
}

// IBankaHesabi Arayüzü
public interface IBankaHesabi
{
    DateTime HesapAcilisTarihi { get; set; }

    // Hesap özeti metodu
    void HesapOzeti();
}

// Birikim Hesabı Sınıfı (Hesap sınıfından türetilmiş)
public class BirikimHesabi : Hesap, IBankaHesabi
{
    public decimal FaizOrani { get; set; }
    public DateTime HesapAcilisTarihi { get; set; }

    public BirikimHesabi(string hesapNo, decimal bakiye, decimal faizOrani, DateTime acilisTarihi)
    {
        HesapNo = hesapNo;
        Bakiye = bakiye;
        FaizOrani = faizOrani;
        HesapAcilisTarihi = acilisTarihi;
    }

    // Para Yatırma metodu, faizi ekler
    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        decimal faiz = Bakiye * FaizOrani / 100;
        Bakiye += faiz; // Faiz ekleniyor
        Console.WriteLine($"{miktar} TL yatırıldı. Faiz: {faiz} TL, Yeni Bakiye: {Bakiye} TL.");
    }

    // Para Çekme metodu
    public override void ParaCek(decimal miktar)
    {
        if (Bakiye >= miktar)
        {
            Bakiye -= miktar;
            Console.WriteLine($"{miktar} TL çekildi. Kalan Bakiye: {Bakiye} TL.");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    // Hesap özeti yazdırma
    public void HesapOzeti()
    {
        Console.WriteLine($"Birikim Hesabı - Hesap Numarası: {HesapNo}, Bakiye: {Bakiye} TL, Faiz Oranı: {FaizOrani}%, Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
    }
}

// Vadesiz Hesap Sınıfı (Hesap sınıfından türetilmiş)
public class VadesizHesap : Hesap, IBankaHesabi
{
    public decimal IslemUcreti { get; set; }
    public DateTime HesapAcilisTarihi { get; set; }

    public VadesizHesap(string hesapNo, decimal bakiye, decimal islemUcreti, DateTime acilisTarihi)
    {
        HesapNo = hesapNo;
        Bakiye = bakiye;
        IslemUcreti = islemUcreti;
        HesapAcilisTarihi = acilisTarihi;
    }

    // Para Yatırma metodu
    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        Console.WriteLine($"{miktar} TL yatırıldı. Yeni Bakiye: {Bakiye} TL.");
    }

    // Para Çekme metodu, işlem ücreti uygular
    public override void ParaCek(decimal miktar)
    {
        if (Bakiye >= miktar + IslemUcreti)
        {
            Bakiye -= (miktar + IslemUcreti);
            Console.WriteLine($"{miktar} TL çekildi. İşlem Ücreti: {IslemUcreti} TL. Kalan Bakiye: {Bakiye} TL.");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    // Hesap özeti yazdırma
    public void HesapOzeti()
    {
        Console.WriteLine($"Vadesiz Hesap - Hesap Numarası: {HesapNo}, Bakiye: {Bakiye} TL, İşlem Ücreti: {IslemUcreti} TL, Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
    }
}

// Program sınıfı
public class Program
{
    public static void Main()
    {
        // Hesapları oluşturuyoruz
        BirikimHesabi birikimHesabi = new BirikimHesabi("123456", 1000, 5, new DateTime(2023, 1, 1));
        VadesizHesap vadesizHesap = new VadesizHesap("654321", 2000, 10, new DateTime(2023, 5, 15));

        // Hesap işlemleri
        birikimHesabi.ParaYatir(500);
        birikimHesabi.ParaCek(300);
        birikimHesabi.HesapOzeti();

        Console.WriteLine();

        vadesizHesap.ParaYatir(200);
        vadesizHesap.ParaCek(1500);
        vadesizHesap.HesapOzeti();
    }
}
