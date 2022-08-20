## _Dotnet Case Study_
# Soru-1
8 uzunlukta unique 10.000.000 adet promosyone kodu üretilmek istenmektedir.

```sh

Get: https://localhost:44354/CouponCode/getall?count=10000000
```
yukarıdaki endpointe istek attığımızda 10.000.000 adet uniqe kodlar üretilir ve responseda sunulur.Dönen response aşağıdaki post isteğine gönderilir.

```sh

Post: https://localhost:44354/CouponCode/checkunique
```
Bu endpoint tüm kodların unique olduğunu kanıtlamak için true değer dönmektedir.

```sh

Post: https://localhost:44354/CouponCode/validate?code=MH-4T-K5-FX
```
Validate işlemi doğru ise responseda validate edilmiş kod geri döner.

# Soru-2

Bu soruda multi-language destekli bir haber ajansı tasarlanmak istenmektedir.
Temel olarak tasarlanan sistem Language,Localization,NewsAgency,NewsAgencyCategory modüllerinden oluşur.Tüm modüllerin asgari crud işlemleri projede yer almaktadır.

- Language:Sistemdeki temel dilleri barındırır.Temel Crud işlemleri yapılacak endpointler projede yer almaktadır.
- Localization: Sistem login butonu gibi ön tarafın ihtiyacı olan datalar için kullanılır.
- NewsAgency haberlerin bulunduğu temel modüldür.
- NewsAgencyCategory: Haber kategorilerini barındıran modüldür.
-

#Soru-3
Bu soruya OcrConsole adında yeni bir proje oluşturuldu.
Ocr response sonucunda yer alan json line parse işlemi gerçekleştirildi.
