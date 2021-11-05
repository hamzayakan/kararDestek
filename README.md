Microsoft Visual Studio kurulu bir bilgisayarda [Solution Dosyası](https://github.com/hamzayakan/kararDestek/blob/main/kararDestek.sln) ile programımızı başlatabilirsiniz. Kodlama C# ile yapılmıştır.<br/>

[Hasta ekle](https://github.com/hamzayakan/kararDestek/blob/main/resim/HastaKayit.PNG), [hasta listesi](https://github.com/hamzayakan/kararDestek/blob/main/resim/HastaListesi.PNG) ve diğer tüm resimleri  [burdan](https://github.com/hamzayakan/kararDestek/tree/main/resim)  görebilirsiniz. Önemli olan TOPSİS algoritmasını kullandığımız kısımları anlattık.<br/>

# Anasayfa

![](https://github.com/hamzayakan/kararDestek/blob/main/resim/Anasayfa.PNG)
## İlaç Seçimi ve Risk Tablosu
Doktor hastayı analiz ettikten sonra listemizde bulanan 7 tane antidiyabetik ilaçtan hangilerini kullanabileceğini seçiyor. <br/><br/>
![](https://github.com/hamzayakan/kararDestek/blob/main/resim/RiskDeger.PNG)
## Kritik Ağırlık Belirleme
Antidiyabetik ilaçların 8 tane özelliği var. Bu özellikler doktor tarafından ağırlıklandırılması istenmiştir. Örnek hastamızda Ödem var CHF'yi 2'ye ayarlıyoruz. (Başlangıç değerleri "1" dir.)  <br/><br/>
![](https://github.com/hamzayakan/kararDestek/blob/main/resim/Kritik%20A%C4%9F%C4%B1rl%C4%B1k%20Belirleme.PNG)
## TOPSİS Sonuç Tablosu
Seçilen ilaçlar ve girilen ağırlıklara göre ilaçların hangi sırayla kullanılması gerektiği sonucu verilmiştir. Sonuçlar MET'in ideal çözümü C1*'in 0.775 olduğunu, DPP-4'ün ideal çözümü C2*'nin 0.540 olduğunu, SU'nun ideal çözümünün C3*'ün 0.270 olduğunu ve İnsülinin ideal çözümünün C4* olduğunu göstermektedir. 0.384. C1*> C2*> C4*> C3* olduğundan 
antidiyabetik ilaçların öneri önceliği MET>DPP-4>İnsülin>SU <br/><br/>
![](https://github.com/hamzayakan/kararDestek/blob/main/resim/TopsisSonucTablosu.PNG)

<br/><br/><br/>
# TEORİK KISIM
<br/><br/>
## -Klinik Karar Destek Sistemiyle alakalı bilgi ve TOPSİS algoritmasının nasıl çalıştığını projemize uygun bir örnek eşliğinde açıkladık.

# Klinik Karar Destek Sistemi
Bazı araştırmacılar Klinik Karar Destek Sisteminin (KKDS) olumlu potansiyelini 
düşünmüş olsa da aktif tedavi stratejilerine veya HbA1c hedeflerine götüren hastaların 
tutumunu dikkate almadılar. Hastalar için bir HbA1c hedefi ve antidiyabetik ilaç öneri 
sistemi önermek için yayınlanan Amerikan Diyabet Derneği (ADA) ve Avrupa 
Diyabet Çalışmaları Derneği'ni (EASD) dikkate aldık. Amerikan Klinik 
Endokrinologlar Birliği (AACE) ve Amerikan Endokrinoloji Koleji (ACE) tarafından 
sunulan antidiyabetik ilaç profillerine dayanarak, antidiyabetik ilaçların sıralamasını 
hesaplamak için TOPSIS(Çok Kriterli Karar Verme Sistemi)
kullanıyoruz. Endokrinolog, bir karar destek sistemini değerlendirmek için on sanal 
hastanın tıbbi verilerini oluşturdu. Klinik Karar Destek Sisteminin iyi performans 
gösterdiğini ve öneri sisteminin ayakta tedavi gören hastalar için uygun olduğunu 
göstermektedir. Antidiyabetik ilaçların değerlendirme sonuçları, sistemin 
antidiyabetik ilaçları seçerken klinisyenlerin T2DM'yi yönetmesine yardımcı 
olabilecek yüksek oranda memnuniyet derecesine sahip olduğunu 
göstermektedir. Sonuç olarak Klinik Karar Destek Sistemi, doktorların klinik teşhisine 
yardımcı olmanın yanı sıra uzman hekimlere rehberlik etmekle kalmaz, aynı zamanda 
uzman olmayan doktorlara ve genç doktorlara ilaç reçeteleri konusunda yardımcı 
olabilir.

## TOPSIS Çok Kriterli Karar Analizi 
### İdeal Çözüm Benzerliğine göre Tekniklerin Sıralanması
The Technique for Order of Preference by Similarity to Ideal Solution (TOPSIS) 
Antidiyabetik ilaçların riski bilindiğinde, bunu antidiyabetik ilaçların tavsiye edilen 
önceliğini hesaplamak için kullanabiliriz. İdeal Çözüme Benzerlik Yoluyla Tercih 
Sıralaması Tekniği (TOPSIS), 1981'de Hwang ve Yoon tarafından geliştirilen çok
kriterli bir kararı uygulamaktadır. Antidiyabetik ilaçların sıralamasına 
karar vermek için TOPSIS kullanıldı.
Önceki hesaplamalarda, sistem hasta için MET (Biguanides), DPP-4, SU 
(Sülfonilüreler) ve İnsülin önermiştir. Tablo antidiyabetik ilaçların riskini ve hasta
için maliyeti göstermektedir. TOPSIS yöntemini açıklamak için Tablodaki risk
verilerini örnek olarak kullanacağız.

### Tablo
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/IlacRiskVeMaliyet.PNG)<br/>
## 1. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/1_adim.PNG)<br/>
## 2. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/2_adim.PNG)<br/>
## 3. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/3_adim.PNG)<br/>
## 4. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/4_adim.PNG)<br/>
## 5. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/5_adim.PNG)<br/>
## 6. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/6_adim.PNG)<br/>
## 7. Adım
![resim](https://github.com/hamzayakan/kararDestek/blob/main/resim/7_adim.PNG)<br/>

### Bütün adımların programımızda görebilirsiniz.  
