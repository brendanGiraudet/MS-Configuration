# Ce que fait ce `README.md` :

- **Caractéristiques** : Décrit ce que fait le microservice `ms-configuration`.
- **Prérequis** : Énumère les outils nécessaires pour construire et exécuter le service.
- **Installation** : Fournit des instructions pour cloner le dépôt et accéder au répertoire.
- **Configuration** : Explique que le microservice utilise une base de données en mémoire pour la configuration par défaut.
- **Construire et Exécuter le Microservice** : Explique comment construire et exécuter le service localement et via Docker.
- **Utilisation** : Explique comment utiliser les points de terminaison OData pour interagir avec le service.
- **Exemples de Requêtes avec Postman** : Fournit des exemples concrets de requêtes pour tester le service.
- **Contribuer** : Encouragement à contribuer au projet.
- **License** : Décrit la licence sous laquelle le projet est distribué.

## Caractéristiques
`ms-configuration` est un microservice basé sur .NET Minimal APIs et OData qui sert de point central pour gérer les configurations tel que RabbitMQ dans une architecture orientée événements (Event-Driven Architecture). Ce microservice permet de gérer et de récupérer les configurations pour différents microservices à travers une API REST OData.

- **OData API** : Fournit une API RESTful utilisant OData pour gérer les configurations.
- **Minimal APIs** : Utilise le modèle léger de Minimal APIs de .NET pour une configuration plus simple.
- **SQlite Database** : Utilise une base de données SQLite pour stocker les configurations.
- **Containerisation** : Conteneurisé à l'aide de Docker pour un déploiement facile.

## Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)

## Installation

Clonez ce dépôt et accédez au répertoire du projet :

```bash
git clone https://github.com/brendanGiraudet/ms-configuration.git
cd ms-configuration
```

## Configuration
Il n'y a pas de configuration nécessaire pour le développement, car le microservice utilise la migration de base de donnée. Les configurations RabbitMQ sont configurées par défaut et peuvent être modifiées via les points de terminaison OData.

Construire et Exécuter le Microservice

1. Construire le Projet
Assurez-vous que vous avez le .NET 8 SDK installé, puis construisez le projet :

```bash
Copier le code
dotnet build
```

2. Exécuter le Projet Localement
Exécutez le microservice localement pour le tester :

```bash
Copier le code
dotnet run
```

Le microservice sera disponible à l'adresse http://localhost:5000 (port specifié dans le fichier appsettings).

3. Utiliser Docker
Construire l'Image Docker et/ou l'éxécuter
Pour construire l'image Docker du microservice, utilisez la commande suivante :

```bash
Copier le code
docker compose -f .\docker-compose-debug.yml up
```

Le service sera disponible à http://localhost:1717 (port specifié dans le fichier docker-compose-debug).

## Utilisation
Points de Terminaison OData
Le microservice expose plusieurs points de terminaison OData pour gérer les configurations.

GET /odata/RabbitMqConfigs : Récupère toutes les configurations RabbitMQ.
GET /odata/RabbitMqConfigs({key}) : Récupère une configuration RabbitMQ spécifique par ID.
POST /odata/RabbitMqConfigs : Ajoute une nouvelle configuration RabbitMQ.
PUT /odata/RabbitMqConfigs({key}) : Met à jour une configuration RabbitMQ existante.
DELETE /odata/RabbitMqConfigs({key}) : Supprime une configuration RabbitMQ spécifique.

## Exemples de Requêtes avec Postman
Récupérer toutes les configurations RabbitMQ

Méthode : GET
URL : http://localhost:8080/odata/RabbitMqConfigs
Ajouter une nouvelle configuration RabbitMQ

Méthode : POST
URL : http://localhost:8080/odata/RabbitMqConfigs
Corps (JSON) :
json
Copier le code
{
  "Id": 2,
  "Hostname": "localhost",
  "Port": 5672,
  "Username": "newuser",
  "Password": "newpassword",
  "Exchange": "new-exchange",
  "RoutingKeys": {
    "create-recip": "ms-recette-queue",
    "create-recip-result": "ms-log-queue"
  }
}

## Contribuer
Les contributions sont les bienvenues ! Veuillez soumettre une issue ou une pull request pour toute amélioration ou problème.

## License
Aucune licence

