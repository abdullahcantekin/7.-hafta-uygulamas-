using System;
using System.Collections.Generic;

// IYayinci arayüzü - Yayıncı için gerekli metodları içeriyor
public interface IYayinci
{
    void AboneEkle(IAbone abone);  // Abone ekleme metodu
    void AboneCikar(IAbone abone);  // Abone çıkarma metodu
    void AboneListele();  // Aboneleri listeleme metodu
    void BildirimYap();  // Değişiklik olduğunda abonelere bildirim yapma metodu
}

// IAbone arayüzü - Abone için gerekli metod
public interface IAbone
{
    void BilgiAl(string mesaj);  // Aboneye gelen bilgiyi alıp ekrana yazdırma
}

// Yayinci sınıfı - IYayinci arayüzünü implement eder
public class Yayinci : IYayinci
{
    private List<IAbone> _aboneler = new List<IAbone>();  // Aboneleri tutan liste

    // Abone ekleme
    public void AboneEkle(IAbone abone)
    {
        _aboneler.Add(abone);
    }

    // Abone çıkarma
    public void AboneCikar(IAbone abone)
    {
        _aboneler.Remove(abone);
    }

    // Aboneleri listeleme
    public void AboneListele()
    {
        Console.WriteLine("Aboneler:");
        foreach (var abone in _aboneler)
        {
            Console.WriteLine(abone.GetType().Name);
        }
        Console.WriteLine();
    }

    // Yayıncı değişiklik yaptığında tüm abonelere bildirim gönderme
    public void BildirimYap()
    {
        foreach (var abone in _aboneler)
        {
            abone.BilgiAl("Yeni bir güncelleme var!");  // Her aboneye mesaj gönderiliyor
        }
    }
}

// Abone sınıfı - IAbone arayüzünü implement eder
public class Abone : IAbone
{
    private string _isim;  // Abonenin ismi

    // Constructor
    public Abone(string isim)
    {
        _isim = isim;
    }

    // Aboneye gelen bilgiyi ekrana yazdırma
    public void BilgiAl(string mesaj)
    {
        Console.WriteLine($"{_isim} - {mesaj}");  // Aboneye gelen mesajı yazdırır
    }
}

// Program sınıfı - Observer pattern'ı test etmek için kullanılır
public class Program
{
    public static void Main()
    {
        // Yayıncıyı oluşturuyoruz
        Yayinci yayinci = new Yayinci();

        // Aboneleri oluşturuyoruz
        Abone abone1 = new Abone("Ahmet");
        Abone abone2 = new Abone("Mehmet");
        Abone abone3 = new Abone("Ayşe");

        // Aboneleri yayıncıya ekliyoruz
        yayinci.AboneEkle(abone1);
        yayinci.AboneEkle(abone2);
        yayinci.AboneEkle(abone3);

        // Aboneleri listeleyelim
        yayinci.AboneListele();

        // Yayıncı bir değişiklik yapıyor ve abonelere bildiriyor
        Console.WriteLine("Yayıncı bir güncelleme yapıyor...\n");
        yayinci.BildirimYap();

        // Bir aboneyi çıkaralım
        yayinci.AboneCikar(abone2);

        // Aboneleri tekrar listeleyelim
        yayinci.AboneListele();

        // Yayıncı bir başka değişiklik yapıyor ve güncellemeyi abonelere bildiriyor
        Console.WriteLine("Yayıncı bir başka güncelleme yapıyor...\n");
        yayinci.BildirimYap();
    }
}
