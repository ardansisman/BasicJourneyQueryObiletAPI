# Obilet

Proje .Net 5.0 projesidir. 

Obilet API kullanılarak,
1-)Lokasyonlar
2-)Kalkış-Varış lokasyon seçimi ve kalkış tarihi seçimine bağlı olarak da sefer verileri çekilmiştir.

Kullanıcıların sefer arama verileri Redis Cache'e yazılarak bir sonraki ziyaretinde son yaptığı aramayı görüntülemesi sağlanmıştır. Bunun için test işleminden önce aşağıdaki bağlantıdan 

-https://github.com/microsoftarchive/redis/releases

sisteminize uygun redis server kurulumunun yapılması gerekiyor. 

Kullanıcı giriş yaptığında IP adresi ile yaptığı arama verileri redis cache'e yazılır, sonraki girişte ise cache'den çekilerek veriler set kullanıcı arayüzünde gösterilir.
