using System;
using System.Collections.Generic;

// Soyut Urun sınıfı - Ortak özellikler ve soyut metod
public abstract class Urun
{
    public string Ad { get; set; }  // Ürün adı
    public decimal Fiyat { get; set; }  // Ürün fiyatı

    // Soyut metod: Ürün türüne göre ödeme hesaplaması yapılacak
    public abstract decimal HesaplaOdeme();

    // Ürün bilgilerini yazdıran metod
    public void BilgiYazdir()
    {
        // Ürün adı ve fiyatı yazdırılıyor
        Console.WriteLine($"Ürün Adı: {Ad}");
        Console.WriteLine($"Fiyat: {Fiyat} TL");
        // Ödenecek tutar hesaplanıp yazdırılıyor
        Console.WriteLine($"Ödenecek Tutar: {HesaplaOdeme()} TL");
        Console.WriteLine();
    }
}

// Kitap sınıfı, Urun sınıfından türetilmiştir
public class Kitap : Urun
{
    public string Yazar { get; set; }  // Kitap yazarı

    // Kitap için ödeme hesaplama metodunun implementasyonu (%10 vergi ekleme)
    public override decimal HesaplaOdeme()
    {
        // Fiyatın üzerine %10 vergi ekleniyor
        return Fiyat + (Fiyat * 0.10m);  // %10 vergi
    }

    // Kitap bilgilerini yazdıran metod
    public new void BilgiYazdir()
    {
        // Ana sınıfın metodunu çağırarak temel bilgileri yazdırıyoruz
        base.BilgiYazdir();
        // Kitapla ilgili ek bilgileri yazdırıyoruz
        Console.WriteLine($"Yazar: {Yazar}");
    }
}

// Elektronik sınıfı, Urun sınıfından türetilmiştir
public class Elektronik : Urun
{
    public string Marka { get; set; }  // Elektronik ürünün markası

    // Elektronik ürün için ödeme hesaplama metodunun implementasyonu (%25 vergi ekleme)
    public override decimal HesaplaOdeme()
    {
        // Fiyatın üzerine %25 vergi ekleniyor
        return Fiyat + (Fiyat * 0.25m);  // %25 vergi
    }

    // Elektronik ürün bilgilerini yazdıran metod
    public new void BilgiYazdir()
    {
        // Ana sınıfın metodunu çağırarak temel bilgileri yazdırıyoruz
        base.BilgiYazdir();
        // Elektronik ürünle ilgili ek bilgileri yazdırıyoruz
        Console.WriteLine($"Marka: {Marka}");
    }
}

// Program sınıfı - Hesaplama işlemlerini ve ürün bilgilerini test ediyoruz
public class Program
{
    public static void Main()
    {
        // Ürün listesi oluşturuluyor
        List<Urun> urunler = new List<Urun>();

        // Ürünler koleksiyona ekleniyor
        urunler.Add(new Kitap { Ad = "C# Programlama", Fiyat = 100m, Yazar = "Ahmet Yılmaz" });
        urunler.Add(new Elektronik { Ad = "Telefon", Fiyat = 2000m, Marka = "Samsung" });
        urunler.Add(new Kitap { Ad = "Veritabanı Yönetimi", Fiyat = 120m, Yazar = "Mehmet Kaya" });
        urunler.Add(new Elektronik { Ad = "Laptop", Fiyat = 5000m, Marka = "Dell" });

        // Ürün bilgilerini ve ödeme tutarlarını yazdırıyoruz
        foreach (var urun in urunler)
        {
            urun.BilgiYazdir();  // Her ürünün bilgilerini yazdırıyoruz
        }
    }
}
