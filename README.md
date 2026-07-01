<div align="center">

# 📺 AnimeList 🍥

### *Deine persönliche Anime-Watchlist, full-stack* 🎌

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405e?style=for-the-badge&logo=sqlite&logoColor=white)

*Blazor-Frontend, ASP.NET-API, SQLite — und ganz viel Anime.* 🌸

</div>

---

## 🍿 Worum geht's?

Eine Full-Stack-App, um den Überblick über deine Anime zu behalten. Ein **Blazor-Frontend** redet mit einer **ASP.NET Core REST-API**, die alles in **SQLite** speichert. Durchstöbern, ansehen, verwalten. 📚

## ✨ Features

- 📋 Anime-Liste durchstöbern
- 🔍 Details zu einzelnen Titeln
- ⚙️ Voll-CRUD API (Create, Read, Update, Delete)
- 🎨 Server-gerendertes Blazor-UI mit Bootstrap
- 💾 Persistente Speicherung via SQLite

## 🏗️ Architektur

Zwei Projekte im Team:

- 🔌 **`AnimeListAPI`** — ASP.NET Core Web API
  - `AnimeItemsController` mit REST-Endpoints
  - EF Core + SQLite (`anime.db`)
  - Schema via Migrations
- 🎨 **`AnimeListBlazor`** — Blazor-Frontend
  - Seiten für Liste, Detail & Home
  - Bootstrap-Layout

## 🛠️ Tech Stack

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=flat&logo=blazor&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405e?style=flat&logo=sqlite&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=flat&logo=bootstrap&logoColor=white)

## 🚀 Los geht's

```bash
git clone https://github.com/binmarkoo/AnimeList.git
cd AnimeList
```

**🔌 API starten:**
```bash
cd AnimeListAPI
dotnet run
```

**🎨 Blazor-Frontend starten (neues Terminal):**
```bash
cd AnimeListBlazor
dotnet run
```

> 💡 Check, dass die Blazor-App auf die richtige API-URL zeigt (`appsettings.json`).

## 🔌 API-Endpoints

| Methode | Endpoint | Was es macht |
|---------|----------|--------------|
| 🟢 `GET` | `/api/AnimeItems` | Alle Anime holen |
| 🟢 `GET` | `/api/AnimeItems/{id}` | Einen Anime holen |
| 🟡 `POST` | `/api/AnimeItems` | Neuen Anime anlegen |
| 🔵 `PUT` | `/api/AnimeItems/{id}` | Anime updaten |
| 🔴 `DELETE` | `/api/AnimeItems/{id}` | Anime löschen |
