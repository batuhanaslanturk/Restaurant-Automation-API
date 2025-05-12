🍽️ Restoran-Kafe Otomasyon Sistemi – Back-End

Bu proje, restoran ve kafe işletmeleri için geliştirilen bir otomasyon sisteminin .NET 8 Web API (Back-End) tarafıdır. Sistem, müşterilerin veya garsonların verdiği siparişleri mutfağa ve kasaya dinamik olarak iletmeyi hedefler.

Modern bir yazılım mimarisi ile geliştirilmiş bu sistem, microservice mimarisi ve domain-driven design (DDD) prensiplerini temel alır. Gerçek zamanlı iletişim, mesajlaşma altyapısı ve ölçeklenebilirlik ön planda tutulmuştur.

🚀 Kullanılan Teknolojiler

    .NET 8.0

    Entity Framework Core

    SignalR (Gerçek zamanlı bildirimler)

    RabbitMQ (Mesajlaşma altyapısı)

    Microservice Architecture

    Domain-Driven Design (DDD)

🛠️ Kurulum
1. Bu repoyu klonlayın:

    git clone https://github.com/batuhanaslanturk/Restaurant-Automation-API.git

2. Connection String girin:
    appsettings.json içerisindeki "DefaultConnection" verisini kendi bağlantı bilgileriniz ile doldurun.

💻 Migration Komutları

    dotnet ef migrations add InitialCreate -p Infrastructure -s API
    dotnet ef database update -p Infrastructure -s API

