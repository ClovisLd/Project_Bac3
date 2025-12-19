# Rapport de Projet : Gestionnaire de Compétitions - Project_Bac3

**Auteur :** [Votre Nom]  
**Cours :** [Nom du Cours / Professeur]  
**Date :** 19 Décembre 2025

---


## 1. Introduction et Mise en contexte

Le projet **Project_Bac3** est une application de bureau développée en C# avec le framework **Avalonia**, utilisant l'architecture **MVVM (Model-View-ViewModel)**.

L'objectif principal est de fournir un outil de gestion pour des fédérations sportives ou de jeux compétitifs. L'application permet de gérer une liste de joueurs, de suivre leurs statistiques, d'organiser des compétitions et d'enregistrer des matchs. Dans un monde où l'e-sport et les compétitions locales sont en pleine expansion, cet outil vise à simplifier l'administration des tournois tout en garantissant un classement équitable des participants.

## 2. Fonctionnalité supplémentaire choisie

Pour enrichir l'expérience utilisateur et la pertinence technique du projet, j'ai choisi d'implémenter :  
**Le Système de Classement Elo Dynamique avec Persistance de Données JSON.**

- **Système Elo :** Contrairement à un simple compteur de victoires/défaites, le système Elo calcule la probabilité de victoire entre deux joueurs. À la fin d'un match, le gain ou la perte de points est ajusté en fonction du niveau relatif de l'adversaire (algorithme mathématique implémenté dans le `MatchService`).
- **Persistance JSON :** L'application sauvegarde automatiquement l'état complet (joueurs, matchs, compétitions) dans un fichier JSON local à la fermeture, et le restaure au démarrage, garantissant ainsi qu'aucune donnée n'est perdue entre deux sessions.

## 3. Diagramme de classes

Ce diagramme présente la structure de nos modèles (`Player`, `Match`, `Competition`), nos ViewModels et la couche de services.

<img width="1330" height="1070" alt="new" src="https://github.com/user-attachments/assets/ba007ec0-907e-4ee9-8d42-f705e23005ec" />
On y voit la séparation claire entre les données (Models) et la logique de présentation (ViewModels).

## 4. Diagramme de séquences

Le diagramme suivant illustre le processus de création d'un match, de la mise à jour des scores Elo jusqu'à l'enregistrement dans la liste globale.

<img width="1093" height="543" alt="image" src="https://github.com/user-attachments/assets/28226b97-0f2c-4ba1-9dde-45f340f7774a" />

## 5. Diagramme d’activité

Ce diagramme décrit le cycle de vie de l'application, incluant le chargement des données au démarrage et la sauvegarde lors de la fermeture.

> ![Diagramme d'Activité](chemin/vers/votre/image_activite.png)

## 6. Justification des qualités d’adaptabilité

Le projet a été conçu pour être facilement adaptable à n'importe quelle fédération (échecs, football, tennis de table, jeux vidéo) pour les raisons suivantes :

1.  **Abstraction du "Joueur" :** Le modèle `Player` est générique. Il contient des informations de base (Nom, Age, Contact) et un score Elo qui est universel pour tout sport compétitif.
2.  **Modularité des Services :** Le système de calcul des points est centralisé dans le `MatchService`. Si une fédération utilise un système de points différent (ex: 3 pts victoire / 1 pt nul), il suffit de modifier une seule méthode sans impacter l'interface utilisateur.
3.  **Indépendance de la Plateforme :** Grâce à l'utilisation d'`AppDomain.CurrentDomain.BaseDirectory` pour la gestion des fichiers, l'application et sa base de données portable fonctionnent identiquement sur Windows, macOS et Linux.

## 7. Principes SOLID utilisés

L'architecture du projet s'appuie sur plusieurs principes SOLID pour garantir un code propre et maintenable :

### A. Single Responsibility Principle (SRP - Principe de Responsabilité Unique)

Chaque classe possède une responsabilité unique et bien définie :

- **`PersistenceService`** : S'occupe exclusivement de transformer les objets en JSON et de gérer les fichiers sur le disque. Il ne connaît rien aux règles du score Elo.
- **`PlayerService`** : Gère uniquement la collection de joueurs (ajout, suppression, recherche).
- **Justification :** Cette séparation facilite le débogage. Si un problème survient lors de la sauvegarde, on sait exactement que le problème se situe dans le service de persistance et non dans la logique métier.

### B. Dependency Inversion Principle (DIP - Principe d'Inversion de Dépendance)

Bien que nous utilisions le pattern Singleton pour simplifier l'accès, les **ViewModels** ne manipulent jamais directement les données brutes des **Models**. Ils passent par une couche intermédiaire (les **Services**).

- **Justification :** Cela permet de découpler l'interface utilisateur de la logique de stockage. Si demain nous décidons d'utiliser une base de données SQL au lieu d'un fichier JSON, seul le `PersistenceService` devra être modifié. Le reste de l'application (UI et ViewModels) restera inchangé.

## 8. Conclusion

Ce projet m'a permis de mettre en pratique les concepts avancés de la programmation orientée objet et de l'architecture logicielle moderne. L'implémentation du pattern MVVM couplée à une gestion de services Singletons offre une base robuste pour une application évolutive. L'ajout du système Elo et de la persistance automatique transforme ce qui aurait pu être une simple liste de noms en un véritable outil de gestion compétitive prêt à l'emploi.
