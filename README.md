# Design pattern en C# - ESGI AL 2021-2022

Sommaire :
- [Contract Manager]
- [Documentation technique]
- [Documentation fonctionnelle]
- [Utilisation de l'API]
- [Design patterns et explications]
  + [Builder]
  + [Singleton]
  + [State]
  + [Decorator - Specification]

## Contract Manager

Contract Manager est une solution développée en ASP .Net sur la base d'une API Rest. \
Son objectif est de faciliter la création de contrat pour les R.H. de notre client.

L'objectif derrière la création d'une telle architecture dans le cadre de la mise de design patterns est de pouvoir expérimenter l'application de ces derniers dans un cadre plus concret avec lequel je suis habitué à travailler. 
Nous avons l'habitude en cours de travailler sur des petits projets peu concret et la plupart des exemples de code d'implémentation de design patterns sont très vagues ou ne s'incrivent pas dans un environnement plus représentatif d'une solution. Ce qui est normal car ils ne présentent qu'un patron que l'on peut adapter au sein de notre code.

J'ai donc décidé de faire cet exercice moi-même dans cette solution.

## Documentation technique

SDK .Net : 6.0

Packages utilisés : 
- __MediatR__ pour l'implémentation du CQRS via un mediateur. 
- __EntityFrameworkCore__ ORM pour la configuration et intérogation de la base de données.
- __Swashbuckle__ pour la génération de la documentation swagger.

La solution est découpée en trois couches :
- __Présentation__ (*CM.API* / *CM.API.Models*) comprenant la partie configuration de l'API et controlleurs ainsi que les différents objets qu'elle retourne.
- __Application__ (*CM.Application*) comprenant nos différents services.
- __Infrastructure__ (*CM.Infrastructure*) comprenant les configurations liées à la base de données telles que les entités, les repositories, le mapping vers la base de données ou les migrations EntityFramework.

L'API s'appuie sur l'implémentation du CQRS via Mediator afin de gérer les requêtes qu'elle reçoit.
Les requêtes sont reçus dans les endpoints présents dans la partie présentation (CM.API), 
ces requêtes HTTP sont transformées en requête de type "Command" ou "Query" selon l'action souhaitée. \
Une requête de type "Command" représente un requête dont l'objectif est de créer, modifier ou supprimer une entité dans la base de données. \
Une requête de type "Query" quant à elle représente un requête simple de lecture dans la base de données.

Ces requêtes sont envoyés dans un bus géré par Mediator qui va les envoyer vers le handler correspondant. \
Un handler gère un seul type de requête et peut, ou non, retourner un objet. \
Si un résultat est retourné, ce dernier est récupéré au niveau de l'API puis retourné.

L'utilisation d'une base de données locale est optionel. Par défaut, l'API s'appuiera sur une base de données In Memory et ne nécessite donc pas de base de données locale. 
Pour modifier ce paramètre, il est nécessaire d'aller modifier la variable "useInMemoryDatabase" dans le fichier CM.API.Modules.DatabaseModule :
``` c# 
const bool useInMemoryDatabase = true; 
```

Afin de lancer l'API, placez-vous à la racine du projet CM.API et lancer la commande suivante :
```
> dotnet run 
```
Une page de documentation swagger sera disponible sur la page d'URL [https://localhost:7182/swagger](https://localhost:7182/swagger) ou [http://localhost:5182/swagger](http://localhost:5182/swagger). 
Attention : le port peut changer en fonction des services présents sur votre machine.


## Documentation fonctionnelle

L'API présente plusieurs endpoints permettant de travailler autour de la gestion de contrat.
On y comprend plusieurs fonctionnalités :
- Création d'un contrat
- Récupération d'un contrat via son identifiant
- Récupération de tous les contrats avec possibilité de filtrer par certains champs
- Suppression d'un contrat
- Modification de l'état d'un contrat.

L'objectif initial était également d'ajouter la possibilité de créer des collaborateurs et des entreprises clients. Il aurait été possible de créer et affecter un contrat à un collaborateur et de la lier se contrat à une entreprise cliente.

Demande métier :
- Concernant la création d'un contrat, notre client nous a indiqué qu'il souhaite pouvoir créer rapidement certains types de contrat via notre API : CDI, CDD, alternant, intérim. Certains champs du contrat sont pré-remplis selon le type de contrat et le taux journalier peut être modifié. 
- Quant à la récupération, notre client souhaite pouvoir filtrer sur plusieurs champs tels que le type de contrat ou le taux journalier.

## Utilisation de l'API

L'API est facilement utilisable via l'interface Swagger disponible au lancement de l'API.

Plusieurs endpoints sont mis à disposition :

- **GET : /api/contract** : un endpoint de récupération de tous les contrats auquel il est possible d'ajouter différents filtres  \
 Les différents filtres proposés sont :
  + Un filtre sur le type de contrat => Valeurs accéptées : 'PERMANENT' / 'TEMPORARY' / 'APPRENTICESHIP' / 'INTERIM'
  + Un filtre sur le taux journalier => Valeur numérique avec ou sans décimales
  + Un filtre de comparaison inférieur ou supérieur s'appuyant sur le taux journaliers => Valeurs accéptées : '>' ou '<'
- **POST : /api/contract** : un endpoint de création de nouveau contrat.
  + Prend en paramètres :
    + Un type de contrat => Valeurs accéptées : 'CDD' / 'CDI' / 'ALTERNANT' / 'INTERIM'
    + Un nombre d'heures journalières => Chaîne de caractère accèptant le format 'XX:XX:XX' représentant un temps entre 00:00:01 et 23:59:59
    + Une date de début => Format de date classique
    + Une date de fin => Format de date classique
    + Un taux journalier => Valeur numérique avec ou sans décimales
    + Une adresse comprenant :
      + Le numéro de rue => Format numérique
      + Le libellé de la rue => Chaîne de caractères
      + Le code postal => Chaîne de caractères
      + La ville => Chaîne de caractères
      + Le pays => Chaîne de caractères \
  + Exemple de corps de requête :
``` json
{
    "dailyWorkTime": "08:00:00",
    "startDate": "2022-07-08T09:28:58.367Z",
    "endDate": "2022-07-08T09:28:58.367Z",
    "dailyRate": 10,
    "address": {
        "number": 1,
        "label": "Rue",
        "zipCode": "69000",
        "city": "Lyon",
        "country": "France"
    }
}
```
- **GET : /api/contract/{contractId}** : endpoint de récupération d'un contrat existant.
  + Prend en paramètre l'identifiant (au format GUID) du contrat à récupérer.
- **DELETE : /api/contract/{contractId}** : endpoint de suppression d'un contrat existant.
  + Prend en paramètre l'identifiant (au format GUID) du contrat à supprimer.
- **PATCH : /api/contract/{contractId}** : endpoint de modification de l'état d'un contrat
  + Prend en paramètre :
    + L'identifiant du contract à modifier => Format GUID.
    + L'état vers lequel le contrat doit être passé => Valeurs accéptées : 'close' / 'deny' / 'send' / 'sign'.


## Design patterns et explications

Quatre design patterns ont été mis en place au sein de cette solution. Je vais détailler l'implémentation et mon choix pour chacun d'entre eux.

### Builder

>Référence dans le code : *CM.Application.Contracts.Builders* et *CM.Application.Contracts.CreateContract*

Le premier design pattern mis en place est le design pattern Builder.
L'une des problèmatiques fonctionnelles de la solution Contract Manager est la possibilité de générer des contrats ayant des paramètres prédéfinis qui dépendent du type de contrat souhaité. Un contrat peut être de type CDI, CDD ou itérimaire ou d'alternance. 
Nous souhaitons donc mettre à disposition un moyen efficace de générer chaque type de contrat via l'utilisation d'un unique endpoint et d'un seul service. \
L'utilisation d'un builder m'a donc paru le plus adapté à cette situation. Chaque builder de chaque type de contrats présentes des méthodes implémentées via une interface permettant de personnaliser la création de chaque type de contrat. 

Le handler permettant le traitement d'une requête de création peut facilement, en fonction du type de contrat souhaité, créer et générer le contract en appelant les étapes souhaitées. \
Par exemple un contrat de type CDI ne doit pas avoir de date de fin.

### Singleton

L'utilisation du design pattern builder a été couplé avec le design pattern Singleton. \
L'objectif est de garantir l'unicité des Builders au sein de notre application afin d'optimiser les performances et de garder une cohérence lors de la création de contrat. \
Il est par exemple possible dans le futur que la création d'un contrat nécessite l'intervention de services extérieurs que les builders devront appelés. 

### State

>Référence dans le code : *CM.Infrastructure.Entities.Contracts.ContractStates* et *CM.Application.Contracts.UpdateContractState*

Il est très fréquent au sein de projet de gestion de recrutement ou de personnel de devoir assurer la gestion d'un workflow. Cette gestion est omniprésente dans la gestion de contrat qui suit un workflow strict du point de vue légal (exemple : convention tripartite).

La plupart du temps, les méthodes utilisées afin de garantir la cohérence du workflow sont peu maintenable et lisible : enchainement de conditions dans un switch ou suite de If - Else If.
L'implémentation du design pattern state m'a donc parue très cohérente et applicable dans de nombreux cas.

Une interface IContractState expose des méthodes permettant de transiter vers un nouvel état et chaque sous-état implémente la méthode et le comportement attendu. Il est par exemple impossible de signer ou de fermer un contrat ayant été refusé par le client.

Suite à l'implémentation du pattern, notre service permettant de modifier l'état n'a qu'à appeler la bonne fonction dépendant de la requête effectuée. La gestion des erreurs est donc externalisés dans ces états et le service est fortement allégé. 

Une problématique est survenue dans l'implémentation de ce design pattern. Il s'agit de la persistence de ces états. En effet, en s'appuyant sur des objets représentant les états d'un contrat, il n'est pas possible, en l'état de persister l'état comme tel dans la base de données.
Plusieurs méthodes ont donc été mise en place afin de résoudre ce problème. 

Dans chaque objet état, une fonction *ToString()* permet de retourner la chaîne de caractère représentant l'état de l'objet. Une fonction *FromString* présente dans la classe abstraite prenant en paramètre une chaîne de caractère permet, elle, de retourner l'objet-état correspondant à la chaîne de caractère fournie.
Grâce à ces deux méthodes, il est facilement possible de créer un converteur (CF : *CM.Infrastructure.Mapping.Converters*) permettant de persister l'état sous forme de chaîne de caractère en base de données. Puis, lors de la récupération, cette chaîne de caractère est transformer en objet state et affectée au contrat.

### Decorator - Specification

>Référence dans le code : *CM.Application.Contracts.GetAllContracts.Filters*, *CM.Infrastructure.Repositories.Specifications* et *CM.Application.Contracts.GetAllContracts*

Il est très fréquent lors du développement d'API, de devoir implémenter une gestion de filtre afin de récupérer des entités depuis une partie front-end ou autre client.

L'idée d'implémenter le pattern decorator couplé au pattern spécification me semblait donc très cohérent.

Le pattern spécification permet d'implémenter des méthodes représentant un simple condition que l'on peut ensuite appliquer à une liste afin de la filtrer. Ces conditions peuvent s'accumuler et former un filtre puissant correspondant à nos besoins.

Le pattern Décorateur permet donc d'exposer des décorateurs qui sont chacun lié à une spécification et de pouvoir accumuler ces décorateurs afin d'en obtenir un ensemble représentant notre filtre.

Ces filtres se basent sur la classe *BaseFilterComponent* représentant un filtre "vide", ne comprenant aucune condition et qui peut être encapsuler par d'autre Décorateur.

Après implémentation du pattern decorator pour la création de filtre, je me suis rendu compte que l'utilisation d'un design pattern type builder aurait peut-être été plus adapté.