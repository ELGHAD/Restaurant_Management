# Restaurant Management System

Application de gestion de restaurant développée en ASP.NET Core MVC, illustrant la mise en place d'une architecture full-stack .NET avec Entity Framework Core, authentification sécurisée et modélisation de données relationnelle avancée.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-Core_9-68217A?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)
![Status](https://img.shields.io/badge/Status-Active_Development-orange?style=flat-square)

---

## Présentation du projet

Ce projet est une application web de gestion de restaurant construite avec **ASP.NET Core MVC** et **Entity Framework Core**. Il centralise la gestion des plats, des ingrédients, des commandes, des ventes, des réservations et des employés au sein d'une seule plateforme.

L'objectif technique était de concevoir un modèle de données relationnel réaliste (relations many-to-many, colonnes calculées côté base de données) tout en intégrant un système d'authentification robuste via ASP.NET Core Identity, dans le respect des conventions de l'architecture MVC.

Ce projet met en avant ma capacité à concevoir, structurer et livrer une application backend complète, de la modélisation de la base de données jusqu'à l'interface utilisateur.

---

## Fonctionnalités

- Gestion complète (CRUD) des plats, ingrédients, employés, réservations, commandes et ventes.
- Relation many-to-many entre Plats et Ingredients via une table de jonction dédiée (PlatsIngredients), avec gestion des quantités.
- Colonnes calculées au niveau base de données pour garantir la cohérence des totaux de commande et des montants de vente.
- Authentification et gestion des comptes via ASP.NET Core Identity (Razor Pages).
- Accès aux données entièrement piloté par Entity Framework Core, avec gestion des migrations.

---

## Stack technique

| Composant | Technologie |
|---|---|
| Framework | .NET 8 |
| Backend | ASP.NET Core MVC |
| ORM | Entity Framework Core 9 |
| Base de données | Microsoft SQL Server |
| Authentification | ASP.NET Core Identity |
| Frontend | Razor Views, Bootstrap, jQuery |
| Architecture | MVC (Model-View-Controller) |
| Gestion de schéma | EF Core Migrations |

---

## Installation et démarrage

### Prérequis

- .NET SDK 8.0 ou supérieur
- Microsoft SQL Server (local ou distant)
- Visual Studio 2022/2023 ou Visual Studio Code

### 1. Cloner le dépôt

```bash
git clone https://github.com/ELGHAD/Restaurant_Management.git
cd Restaurant_Management
```

### 2. Configurer la connexion à la base de données

Adapter la chaîne de connexion dans `appsettings.json` :

```json
"ConnectionStrings": {
  "BdNaamiContextConnection": "Server=VOTRE_SERVEUR;Database=bd_naami;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;",
  "Restaurant3ContextConnection": "Server=VOTRE_SERVEUR;Database=bd_naami;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
}
```

### 3. Restaurer les dépendances et compiler le projet

```bash
dotnet restore
dotnet build
```

### 4. Appliquer les migrations Entity Framework

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

### 5. Lancer l'application

```bash
dotnet run
```

L'application est accessible à l'adresse indiquée dans la console (généralement `https://localhost:5001`).

---

## Structure du projet
    Restaurant_Management/
    ├── Areas/
    │ └── Identity/ # Pages Razor pour l'authentification (ASP.NET Core Identity)
    ├── Controllers/ # Contrôleurs MVC (Commandes, Plats, Ingredients, Reservations, Ventes, Employes)
    ├── Models/ # DbContext (BdNaamiContext) et entités du domaine
    ├── Migrations/ # Historique des migrations Entity Framework Core
    ├── Views/ # Vues Razor associées aux contrôleurs
    ├── wwwroot/ # Fichiers statiques (CSS, JS, librairies front-end)
    ├── appsettings.json # Configuration de l'application
    ├── Program.cs # Point d'entrée de l'application
    └── restaurant3.csproj # Fichier projet .NET

---

## Sécurité et bonnes pratiques

- Authentification gérée via ASP.NET Core Identity.
- Accès aux données via un ORM (Entity Framework Core), limitant l'exposition aux injections SQL grâce aux requêtes paramétrées.
- Intégrité des totaux de commande et de vente assurée par des colonnes calculées au niveau base de données.

### Axes d'amélioration en cours

- Externalisation complète des chaînes de connexion via `IConfiguration` et variables d'environnement, en remplacement de la configuration codée en dur actuellement présente dans `Models/BdNaamiContext.cs`.
- Mise en place d'une autorisation basée sur les rôles (administrateur, personnel, client).
- Ajout d'une suite de tests automatisés couvrant la logique métier critique (calcul des totaux, flux de réservation).

---

Ouvert aux retours, questions techniques et opportunités professionnelles.
