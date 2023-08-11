# CubeCats
 CubeCats Android Game. KKSLAB

 # U83-Bootcamp-OUA

# **Takım İsmi**

Takım U-83

# Ürün İle İlgili Bilgiler

## Takım Elemanları

- Onuralp Yılkın: Product Owner/Team Member/Developer
- Gülce Çapak: Scrum Master/Team Member/Developer
- Berkay Köksal: Team Member/Developer
- Mustafa Uğur Yanardağ: Team Member/Developer
- Veysel Enes Yiğitoğlu: Team Member/Developer

## Ürün İsmi

 UNKNOWN-83

## Ürün Açıklaması

Saf hack and slash aksiyonunu hissedeceğiniz bu oyunda bir yandan düşmanlarla mücadele ederken bir yandan amacınızı keşfedin. Kimsin, neden buradasın? Sorularına cevap bulabilecek misin? Sürükleyici hikayesi, stilistik grafik tarzı ve hızlı mekanikleriyle UNKNOWN 83 karşınızda.

## Ürün Özellikleri

- 3D
- Hack and Slash türü
- Third-Person görüş açılı
- Single Player 
- Cel Shading'e sahip grafik sistemi
- Klavye ve gamepad desteği
- Çizgi roman tarzı hikaye anlatımı


## Hedef Kitle

- 16 yaş ve üzeri oyun oynamayı seven herkes
- Hack and Slash tarzı dinamik oyunları oynamaktan keyif alanlar
- Third Person görüş açılı oyunları sevenler


## Jüriye Not
  
- Oyunda kullanılan shaderlar toon shading ve cel shading tasarımı elde etmek amacıyla ekibimizden biri tarafından oluşturuldu.  Bu amaç doğrultusunda Shader Graph'ler oluşturuldu ve Shader Graph Custom Function Node özelliği ile beraber HLSL kodları yazıldı.
Outline efektini verebilmek için URP'nin Full Screen Pass Renderer Feature özelliği ile beraber Depth ve Normal Buffer üzerinde sobel filtresi uygulayan bir Shader Graph oluşturuldu.
- Oyunda kullanılan görsel efektler VFX Graph kullanılarak sıfırdan oluşturuldu. VFX'ler için gereken mesh, texture ve flipbooklar yine ekip tarafından yapıldı.
- Ana karakterin tüm animasyonları Cascadeur programı üzerinden yapıldı.
- Ticarileştirme mekaniği olarak oyunun bir oyun satış platformunda(Steam) yayınlanması kararlaştırıldı.
- Oyuncunun belli bir combo başarısına ulaştığında Firebase ve Telegram üzerinden raporlanabileceği bir sistem oluşturuldu. (Ek görüntüler kısmında görülebilir.)
- Oyunun günlük kullanıcı sayısını takip etmek için unitynin Game Analitycs sistemi kullanıldı.(Ek görüntüler kısmında görülebilir.)
  
 ## Kullanılan Assetler


  <details>
  <summary>Kullanılan Assetler</summary>
    
  - [Ana Karakter](https://readyplayer.me/) (CC 4.0 Kullanımı Serbest)
    
  - [Ana Karakter Animasyonları](https://cascadeur.com/)
    
  - [Flying Enemy](https://poly.pizza/m/TX8r9WBXpe)
    
  - [Flying Enemy](https://poly.pizza/m/Iip30bDHmu)
    
  - [Kılıç Sesleri](https://opengameart.org/content/swishes-sound-pack)
    
  - [Enemy Clown](https://www.mixamo.com/#/?page=1&query=Whiteclown+N+Hallin&type=Character)
    
  - [Enemy Metalon ](https://assetstore.unity.com/packages/3d/characters/creatures/meshtint-free-polygonal-metalon-151383)
    
  - [Level Müziği](https://www.youtube.com/watch?v=Sd0dqgEYnqk)
    
  - [TimeLine Müziği](https://pixabay.com/music/build-up-scenes-neon-eyes-of-utopia-epic-sci-fi-dark-trailer-intro-145899/)
    
  - [Menu Müziği](https://pixabay.com/music/ambient-dark-cinematic-ambient-title-sequence-125216/)
    
  - [Yürüme-Koşma Sesleri](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879#content)
    
  - [Menu Buton Sesleri](https://ellr.itch.io/universal-ui-soundpack)
    
  - [Kılıç Modeli](https://www.cgtrader.com/free-3d-models/various/various-models/glow-katana)
    
  - [Işıldayan Küp Texture](https://www.texturecan.com/details/106/)
    
  - [Meşale Modeli](https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeons-lite-177937)

  - [DoTween-Free](http://dotween.demigiant.com/getstarted.php)
    
</details>


  NOT: Yukarıda belirtilen assetler dışındaki her şey ekibimiz tarafından tasarlanmıştır. Level tasarımlarında kullanılan küpler ve textureları, EnemyBall, Oyun içi UI elementleri (Healthbar, Dash göstergesi, Enerji barı, Combo sayacı), Menu UI tasarımı(Butonlar, Loading-Game Over sahneleri), Hikayeleştirme için kullanılan Storyboardlar, Shaderlar, Görsel efektler, Ana karakterin tüm animasyonları ekibimiz tarafından yapılmıştır.

## Product Backlog URL
[Miro Backlog Board](https://miro.com/app/board/uXjVMCbtpUA=/)
# Sprint 1

- **Sprint Notları**: User Story'ler product backlog'ların içine yazılmıştır. Product backlog item'lara tıklandığında hikayelerin detayları okunabilir. Toplantı notlarına MiroBoard üzerinden ulaşılabilir.

- **Sprint içinde tamamlanması tahmin edilen puan**: 150 Puan

- **Puan tamamlama mantığı**: Toplamda proje boyunca tamamlanması gereken 350 puanlık backlog bulunmaktadır. İlk sprint'in 150 ile başlaması gerektiğine karar verildi.

- **Backlog düzeni ve Story seçimleri**: Backlog'umuz ilk yapılacak story'lere göre düzenlenmiştir. Sprint başına tahmin edilen puan sayısını geçmeyecek şekilde sıradan seçimler yapılmaktadır. Story başına çıkan tahmin puanı, toplam puanın yarısından az tutulmuştur. 

Story'ler yapılacak işlere (task'lere) bölünmüştür. Miro Board'da gözüken kırmızı item'lar yapılacak işleri (task) gösterirken, mavi item'lar story'leri temsil etmektedir.

- **Daily Scrum**: Daily Scrum toplantılarının zamansal sebeplerden ötürü Discord üzerinden yapılmasına karar verilmiştir. Daily Scrum toplantısı word dosyaı olarak Readme'de tarafımızdan paylaşılmaktadır:
  
    [Daily Scrum Görselleri.docx](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/files/11780078/Daily.Scrum.Gorselleri.docx)

- **Sprint board update**: Sprint board screenshotları:

  -Sprint 1-1 
![Sprint 1 Backlog 1](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/f88f0c7d-0b6f-41e3-a71c-0a708c7532c0)

  -Sprint 1-2
![Sprint 1 Backlog 2](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/0f0e749f-765c-452a-8714-a44c6a1fc42d)

  -Sprint 1-3
![Sprint 1 Backlog 3](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/552c905b-3dcd-4472-a773-3c36ea68c74f)



- **Ürün Durumu**: Ekran görüntüleri:
  
  ![image](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/948532d5-4aa7-41a8-907e-173a7972db5c)

  ![2](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/0e773c53-3e07-44a0-a0d7-6c1c63828c68)

  ![3](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/832768e4-33d2-45fd-931d-c9b424f05bad)

  ![4](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/0e5bab11-5542-4bcd-88e9-ee2999f411c3)

  ![5](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/f1558c65-4cc7-4b37-b10b-f8e59ccce763)
  
  ![6](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/0b6725b7-e33b-429d-8f61-d3b844d48abf)

  ![7](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/ebef8704-10e8-4d21-aedd-5978d5651eba)

  - Oyun içi görüntüsü için tek bir branchten alınan videonun linki: [Oyun İçi Video Linki](https://www.youtube.com/watch?v=VxGKRcb2G5U)

- **Sprint Review**: 

    Alınan kararlar:

  - Oyunun temel hikayesi kararlaştırıldı ve bu hikayeye uyularak oyun mekanikleri belirlendi.
  - Ana karakter ve düşmanların genel mekanikleri tamamlandı.
  - Animasyon gibi ek özelliklerinin bir sonraki sprintte eklenebileceğine karar verildi.
  - Temel kamera kontrol sistemi oluşturuldu.
  - Grafik tarzına karar verildi ve uygun shaderlar kodlandı.
  - Planladığımız şekilde oyunun temel mekaniklerinin yüzde 80'lik kısmı tamamlandı.

Sprint Review katılımcıları:
Onuralp Yılkın - Gülce Çapak - Berkay Köksal -  Mustafa Uğur Yanardağ - Veysel Enes Yiğitoğlu

- **Sprint Retrospective:**
  - Ekip içinde karar verme süreci sorunsuz gerçekleştirildi.
  - Ekip içi iletişimde sorun yaşanmadı.
  - İkinci sprint için daily scrumların daha sık yapılmasına karar verildi.
  - Hikaye ve oyun mekaniklerinin ikinci sprintte daha fazla detaylandırılmasına karar verildi.
  - Ekip içinde yeterli modelleme bilgisi olmadığı göz önünde bulundurularak ikinci sprintte hazır assetlere yönelmeye karar verildi.
    


---

# Sprint 2
- **Sprint Notları**: User Story'ler product backlog'ların içine yazılmıştır. Product backlog item'lara tıklandığında hikayelerin detayları okunabilir. Toplantı notlarına MiroBoard üzerinden ulaşılabilir.

- **Sprint içinde tamamlanması tahmin edilen puan**: 100 Puan

- **Puan tamamlama mantığı**: Toplamda proje boyunca tamamlanması gereken 350 puanlık backlog bulunmaktadır. İkinci sprint'in 100 puan olması gerektiğine karar verildi.

- **Backlog düzeni ve Story seçimleri**: Backlog'umuz ilk yapılacak story'lere göre düzenlenmiştir. Sprint başına tahmin edilen puan sayısını geçmeyecek şekilde sıradan seçimler yapılmaktadır. Story başına çıkan tahmin puanı, toplam puanın yarısından az tutulmuştur. 

Story'ler yapılacak işlere (task'lere) bölünmüştür. Miro Board'da gözüken kırmızı item'lar yapılacak işleri (task) gösterirken, mavi item'lar story'leri temsil etmektedir.

- **Daily Scrum**: Daily Scrum toplantılarının zamansal sebeplerden ötürü Discord üzerinden yapılmasına karar verilmiştir. Daily Scrum toplantısı word dosyası olarak Readme'de tarafımızdan paylaşılmaktadır:
  
  [Daily Scrum Görselleri-Sprint2.docx](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/files/11931152/Daily.Scrum.Gorselleri-Sprint2.docx)

- **Sprint board update**: Sprint board screenshotları:

  -Sprint 2-1
  ![Sprint 2 Backlog 1](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/3065dfe7-b796-4647-8b03-e9fb11705d74)
  
  -Sprint 2-2
  ![Sprint 2 Backlog 2](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/960e1df2-1090-4512-9ba5-6a9dd2843890)
  
  -Sprint 2-3
  ![Sprint 2 Backlog 3](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/9d04c00c-fdbf-4b74-8590-7f3b31dc8e59)



- **Ürün Durumu**: Ekran görüntüleri:
  
  ![image1](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/91dcb310-95f0-44c4-b392-9407bfe65559)
  
  ![image2](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/06def37b-1b2d-4aec-8447-c4e9aa08c123)
  
  ![image3](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/a6b39f9e-6509-4b1e-bbb5-26a47ca141f3)

   - Oyun içi görüntüsü için tek bir branchten alınan videonun linki: [Oyun İçi Video Linki](https://www.youtube.com/watch?v=1Iw-_UvhbsE)

- **Sprint Review**: 

    Alınan kararlar:

  - İlk sprintte yapılanlar birleştirildi.
  - Level temasına karar verildi ve uygun assetler hazırlanıp, leveller tasarlanmaya başlandı.
  - UI tasarımına karar verilip oyun içi UI tamamlandı.
  - Kılıç efektlerine ait görsel efektler oluşturuldu ve ses efektlerine ait dosyalar eklendi.
  - Player scriptinde iyileştirmeler yapıldı.
  - Dodge mekaniği tasarlandı ve gerekli animasyon ile eklendi.
  - Ana menü ve pause menüsünün bir sonraki sprintte yapılmasına karar verildi.


Sprint Review katılımcıları:
Onuralp Yılkın - Gülce Çapak - Mustafa Uğur Yanardağ

- **Sprint Retrospective:**
  - Ekip içi iletişimde sorun yaşanmadı.
  - Bir önceki sprinte kıyasla daha yavaş ilerlendiği tespit edildi.
  - Bir sonraki sprintte daha hızlı ilerlenmesi gerektiğine karar verildi.
  - Oyunu özgünleştirecek mekanik detaylandırılarak belirlendi ve 3. sprintte tamamlanmasına karar verildi.





---

# Sprint 3
- **Sprint Notları**: User Story'ler product backlog'ların içine yazılmıştır. Product backlog item'lara tıklandığında hikayelerin detayları okunabilir. Toplantı notlarına MiroBoard üzerinden ulaşılabilir.
  
- **Sprint içinde tamamlanması tahmin edilen puan**: 100 Puan

- **Puan tamamlama mantığı**: Toplamda proje boyunca tamamlanması gereken 350 puanlık backlog bulunmaktadır. Üçüncü sprint'in 100 puan olması gerektiğine karar verildi.

- **Backlog düzeni ve Story seçimleri**: Backlog'umuz ilk yapılacak story'lere göre düzenlenmiştir. Sprint başına tahmin edilen puan sayısını geçmeyecek şekilde sıradan seçimler yapılmaktadır. Story başına çıkan tahmin puanı, toplam puanın yarısından az tutulmuştur. 

Story'ler yapılacak işlere (task'lere) bölünmüştür. Miro Board'da gözüken kırmızı item'lar yapılacak işleri (task) gösterirken, mavi item'lar story'leri temsil etmektedir.

- **Daily Scrum**: Daily Scrum toplantılarının zamansal sebeplerden ötürü Discord üzerinden yapılmasına karar verilmiştir. Daily Scrum toplantısı  word dosyası olarak Readme'de tarafımızdan paylaşılmaktadır:
  
  [Daily Scrum Görselleri Sprint-3.docx](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/files/12065034/Daily.Scrum.Gorselleri.3.docx)

  - **Sprint board update**: Sprint board screenshotları:

  -Sprint 3-1
  ![Sprint 3 Backlog 1](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/49e5af71-9872-44f6-a123-2cc23c6d94c9)
  
   -Sprint 3-2
  ![Sprint 3 Backlog 2](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/a0a99501-8f66-4831-a9eb-9e3dfe52d60a)
  
  -Sprint 3-3
  ![Sprint 3 Backlog 3](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/c06fa346-e9d9-4558-a665-1a508457ecaa)
  


- **Ürün Durumu**: Ekran görüntüleri:
  
  ![image1](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/f1f1a7f7-9420-43cb-ac3c-a6c727c143cf)
  
  ![image2](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/7cee868d-73a7-4592-bba3-1e5611b39310)
  
  ![image3](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/7a629442-aa44-4691-b14e-38e5196bc583)


   - Oyun içi görüntüsü için video linki:  [Oyun İçi Video Linki](https://www.youtube.com/watch?v=_dOIJwuMfK8)

- **Ek Görüntüler**:
  
  -Oyuncunun belli bir combo başarısına ulaştığında Firebase ve Telegram üzerinden raporlanabileceği sistem
  
     - Firebase
  ![image5](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/c64009d4-a683-4025-b48d-09f02a4da2f1)

     - Telegram
  ![image6](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/828b1fa4-4536-4dfe-b9ff-d27b08653f25)



  -Oyunun günlük kullanıcı sayısını takip etmek için Game Analitycs sistemi
  
  ![image7](https://github.com/onuralpyilkin/U83-Bootcamp-OUA/assets/122224556/a57a9547-d547-411c-8698-a80b8f65baff)
  
 
- **Sprint Review**: 

    Alınan kararlar:

  - Menü sistemleri ve tasarımları son sürümüne ulaştırıldı.
  - Hikaye anlatımı için görseller oluşturulup gerekli geçiş sistemi oluşturuldu.
  - Firebase ve Telegram Api' ları kullanılarak kullanıcı verilerini raporlayacak sistem geliştirildi.
  - Günlük oyuncu sayılarını raporlamak amacı ile Game Analytics sistemi kuruldu.
  - Oyun içi müzikler ve menü müzikleri kararlaştırılarak projeye eklendi.
  - Karakterin kılıç modeli güncellendi.
  - Verilen hasarı gösteren görsel efekt eklendi.
  - Önceki sprintlerde hazırlanan sistemler birleştirildi.
  - Level tasarımları ve levelların kurguları tamamlandı.
  
Sprint Review katılımcıları:
Onuralp Yılkın - Gülce Çapak - Berkay Köksal -  Mustafa Uğur Yanardağ - Veysel Enes Yiğitoğlu

- **Sprint Retrospective:**
  - Ekip içi iletişimde sorun yaşanmadı.
  - Sonraki projelerde görevlerin tüm sprintler boyunca daha dengeli dağıtılmasına dikkat edilmesi gerektiği konuşuldu.




---


