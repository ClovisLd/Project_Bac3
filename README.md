# Rapport de Projet : Gestionnaire de Compétitions - Project_Bac3

---

## 1. Introduction et Mise en contexte

Le projet **Project_Bac3** est une application de bureau développée en C# avec le framework **Avalonia**, utilisant l'architecture **MVVM (Model-View-ViewModel)**.

L'objectif est de fournir un outil robuste pour les organisateurs de compétitions. L'application permet de gérer des membres, d'organiser des tournois et d'enregistrer des résultats en temps réel. Grâce à une séparation nette entre la logique métier et l'interface graphique, l'outil offre une base stable pour l'administration de n'importe quel sport ou jeu compétitif.

## 2. Fonctionnalités supplémentaires choisies

Pour enrichir le projet, j'ai implémenté trois fonctionnalités majeures :  

- **Le Système de Classement Elo Dynamique :** L'application intègre un algorithme (implémenté dans `MatchService`) qui calcule l'évolution du niveau des joueurs en fonction du résultat des matchs et de la difficulté de l'adversaire (facteur K=64).
- **Persistance de Données JSON :** Un service de persistance automatique sauvegarde l'intégralité du système (Joueurs, Matchs, Compétitions) dans un fichier JSON à la fermeture et restaure l'état au démarrage.
- **Navigation ViewModel-First :** L'interface utilise un `MainWindowViewModel` qui orchestre l'affichage dynamique des différentes vues (`Home`, `AddPlayer`, `Match`, `Competition`) sans multiplication de fenêtres système.

## 3. Diagramme de classes

Ce diagramme présente la structure statique de l'application. On y observe la séparation entre les **Models** (données pures), les **ViewModels** (logique d'interface) et les **Services** (logique métier et persistance).

<div align="center">
  <img width="90%" alt="Diagramme de Classes" src="https://github.com/user-attachments/assets/ba007ec0-907e-4ee9-8d42-f705e23005ec" />
  <br><em>Figure 1 : Architecture globale, héritage Person/Player et Services Singletons</em>
</div>

## 4. Diagramme de séquences

Ce diagramme illustre la dynamique de la **navigation**. Il montre comment le `MainWindowViewModel` intercepte une commande utilisateur pour instancier un nouveau sous-ViewModel et mettre à jour l'affichage via le mécanisme de *Data Binding*.

<div align="center">
  <img width="80%" alt="Diagramme de Séquences" src="https://github.com/user-attachments/assets/28226b97-0f2c-4ba1-9dde-45f340f7774a" />
  <br><em>Figure 2 : Flux de navigation ViewModel-First (PlantUML)</em>
</div>

## 5. Diagramme d’activité

Ce diagramme décrit le comportement logique de l'application, incluant le chargement initial, la gestion des erreurs de saisie (ex: joueur inexistant) et la sauvegarde finale lors de l'événement `Exit`.

<div align="center">
  <img width="50%" alt="Diagramme d'Activité" src="https://github.com/user-attachments/assets/c5e80033-026a-4799-ac58-d14a50a5e285" />
  <br><em>Figure 3 : Cycle de vie des données et validation des matchs</em>
</div>

## 6. Justification des qualités d’adaptabilité

Le projet a été conçu pour être facilement adaptable à n'importe quelle fédération pour les raisons suivantes :

1.  **Héritage et Extension :** Grâce à l'utilisation de la classe de base `Person`, l'application peut être étendue pour gérer des arbitres ou des coachs sans modifier la structure existante.
2.  **Généricité du Match :** La capture des coups joués (`plays`) sous forme de liste de chaînes de caractères permet d'utiliser l'application pour des jeux très différents (échecs, sports de combat, etc.).
3.  **Localisation des données :** Le stockage JSON est relatif au répertoire d'exécution (`BaseDirectory`), rendant l'application totalement portable entre Windows et macOS sans modification de code.

## 7. Principes SOLID utilisés

### A. Single Responsibility Principle (SRP)
Chaque classe possède une responsabilité unique. Par exemple :
- **`PersistenceService`** : Gère uniquement la sérialisation JSON.
- **`MatchWindowViewModel`** : Gère uniquement la capture des entrées utilisateur et les erreurs d'interface.
- **`MatchService`** : Contient l'unique logique mathématique du calcul Elo.
**Justification :** Cette séparation permet de modifier l'algorithme de calcul sans jamais risquer de casser l'interface utilisateur.
  
### B. Open/Closed Principle (OCP)
Le modèle est "ouvert à l'extension mais fermé à la modification". L'introduction de la classe `Person` dont dérive `Player` illustre ce principe. On peut ajouter de nouveaux types de participants sans modifier le code de `PlayerService`.

### C. Dependency Inversion Principle (DIP)
Les ViewModels ne gèrent pas le stockage des données. Ils dépendent des Services (Singletons) qui exposent des `ObservableCollection`. 
**Justification :** Cela permet une synchronisation instantanée : un joueur ajouté dans une vue apparaît immédiatement dans les listes de recherche des autres vues car elles partagent toutes la même source de données centralisée.

## 8. Conclusion

Ce projet m'a permis de consolider ma compréhension de l'architecture logicielle moderne. L'utilisation rigoureuse du pattern MVVM et des principes SOLID a permis de transformer un simple gestionnaire de listes en une application professionnelle capable de gérer la complexité d'un système de classement Elo. La mise en place de la persistance JSON assure une continuité d'utilisation indispensable pour un outil de gestion de fédération réel.
