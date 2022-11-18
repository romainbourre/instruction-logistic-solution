# Instruction Logistic Solution

Ce sujet a pour but de servir de base pour une présentation. Les projets réalisés pourront être ainsi analysés et alimenteront la présentation.

Par conséquent, **ne changez pas vos habitudes de développement pour l'exercice**, sinon les résultats pourraient être faussés et cela rendrait les résultats inintéressants.

# Sujet

## Contexte

Monsieur Duchemin est le PDG LampCity. Il s'agit d'une entreprise spécialisé dans la pose et la maintenance de lampadaire public.

Chaque matin, son chef de chantier Thibault et ses collègues du bureau, contact par téléphone les différentes équipes d'intervention afin de leur communiquer les interventions à effectuer pour le jour même. De cette façon, les équipes n'ont pas besoin de se déplacer jusqu'au bureau.

Il faut savoir qu'il y a une rotation des équipes tous les jours à 12:00PM.

Monsieur Duchemin étant un PDG visionnaire, il trouve dommage de passer par une conversation téléphonique pour communiquer des informations. Il souhaiterait donc avoir un système permettant de passer ses instructions, de savoir quand une équipe en prend une en compte et savoir quand une instruction est traitée.

Il commande donc à votre entreprise *MLG Computing*  un *MVC (Most Valuable Product)* qui devra répondre à des besoins minimums sans pour autant rogner sur la qualité.

## Votre travail

Votre entreprise vous confie une tâche (la plus importante) qui consiste à développer le code métier de cette solution (pas d'interface, pas d'API, ...).

Un projet a été initialisé, et des interfaces ont été conçues en atelier de conception en amont.

Vous allez donc devoir développer les fonctionnalités demandées et vous aller devoir écrire les tests afin que vos collègues puissent se servir de votre travail pour la suite des développements.

**Vous ne devez pas modifier ce qui a été décidé en atelier de conception !**

Pour tout le reste, vous êtes libre de développer comme vous le voulez.

## Les besoins fonctionnels

Étant donné que la solution sera un *MVC*, il n'y aura pas de système d'identification (pas de login, pas de rôle, ...). Pour les rôles évoqués ci-dessous (agent de bureau, équipe d'intervention, ...) on considère que l'accès est libre à tous et que chacun est de bonne volonté.

### En tant qu'utilisateur, je veux pouvoir créer une instruction

- Un agent de bureau (Thibault et ses collègues) nommé doit pouvoir créer une instruction destiné à une équipe nommée, à une date donnée. Une description obligatoire et courte (maximum 160 caractère) permettra d'indiquer à l'équipe le lieu et les modalités de l'intervention (ex: le lieu, les particularités, ...).
- Si un des champs est manquant ou contient une erreur, alors une erreur devra être indiquée.

### En tant qu'utilisateur, je veux pouvoir confirmer une instruction

- Une équipe pourra *Confirmer* une instruction pour dire qu'elle la prise en compte. La date et l'heure de confirmation devront être affichées.
- Si l'instruction est déjà confirmée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.
- Si l'instruction est terminée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.
- Si l'instruction est annulée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.

### En tant qu'utilisateur, je veux pouvoir terminer une instruction

- Une équipe pourra *Terminer* une instruction pour dire que l'intervention est terminée. La date et l'heure à laquelle l'instruction est terminée devront être affichées.
- Si l'instruction n'est pas confirmée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.
- Si l'instruction est déjà terminée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.
- Si l'instruction est annulée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.

### En tant qu'utilisateur, je veux pouvoir annuler une instruction

- Un agent de bureau pourra *Annuler* une instruction. La date et l'heure d'annulation devront être affichées.
- Si l'instruction est confirmée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.
- Si l'instruction est terminée, alors un erreur précisant que l'opération n'est pas permise devra être indiquée.


### En tant qu'utilisateur, je veux pouvoir consulter les instructions

- Chacun pourra afficher la liste des instructions pour une date et heure donnée avec les informations suivantes :
	- Nom de l'agent de bureau
	- Date et heure prévues de l'intervention
	- Description de l'intervention
	- Nom de l'équipe concernée par l'intervention
	- La date et l'heure de la confirmation si l'instruction est confirmée
	- La date et l'heure de la clôture si l'instruction est terminée
	- La date et l'heure de l'annulation si l'instruction est terminée
- Les instructions non terminées et non annulées doivent être affiché à partir du début de leur cycle.
- Les instructions terminées ou annulées ne doivent être affichée que pour leur cycle (determiné en fonction de la date d'intervention prévue) 

Quelques exemples :

- Si une instruction est en cours et est prévue pour le 12/06/2022 à 11:00AM, alors elle devra être affiché à partir de du 11/06/2022 à 12:00PM (inclus)
- Si une instruction est en cours et est prévue le 14/07/2022 à 13:10PM, alors elle devra être affiché à partir du  14/07/2022 12:00PM (inclus)
- Si une instruction qui était prévu pour le 24/12/2022 à 16:42PM et qui est terminée ou annulée, alors elle ne devra s'afficher que si la date donnée est entre le 24/12/2022 à 12:00PM (inclus) et le 25/12/2022 à 12:00 (exclus)

## Conception technique

Lors de la phase de conception technique de la couche métier, l'équipe s'est mis d'accord sur un ensemble de ports sur lesquels les autres couches pourront se brancher. Ce qui permettra de faciliter la collaboration entre les équipes.

Ses ports sont composé de requête (les données en entrée fournit par la couche appelante), les *use case* (qui vont implementer la fonctionnalité attendu) et les réponses (ce qui sera renvoyé à la couche appelante).

Le dévelopeur chargé d'implémenter les fonctionnalités, pourra les implémenters commebon lui semble tant qu'elles respectent ces ports et sont testées.

A cela s'ajoute deux exceptions qui seront soulevées en cas d'erreur métier dans les *use cases*. Deux type d'exceptions pourront être soulevée `NotAllowedException` pour les opérations non permises, et `ValidationException` pour toute saisie incorrect de l'utilisateur.

### En tant qu'utilisateur, je veux pouvoir créer une instruction

La requête :

```C#
public record CreateInstructionRequest
(
    string AgentName,
    string InterventionDescription,
    DateTime InterventionDateAndHour,
    string RecipientTeamName
);
```

L'appel :

```C#
public CreatedInstructionResponse Handle(CreateInstructionRequest request);
```

La réponse :

```C#
public record CreatedInstructionResponse(string InstructionId);

```

### En tant qu'utilisateur, je veux pouvoir confirmer une instruction

La requête :

```C#
public record ConfirmInstructionRequest(string InstructionId);
```

L'appel :

```C#
public VoidResponse Handle(ConfirmInstructionRequest request);
```

La réponse :

```C#
public record VoidResponse;
```

### En tant qu'utilisateur, je veux pouvoir terminer une instruction

La requête :

```C#
public record FinishInstructionRequest(string InstructionId);
```

L'appel :

```C#
public VoidResponse Handle(FinishInstructionRequest request);
```

La réponse :

```C#
public record VoidResponse;
```

### En tant qu'utilisateur, je veux pouvoir annuler une instruction

La requête :

```C#
public record CancelInstructionRequest(string InstructionId);
```

L'appel :

```C#
public VoidResponse Handle(CancelInstructionRequest request);
```

La réponse :

```C#
public record VoidResponse;
```

### En tant qu'utilisateur, je veux pouvoir consulter les instructions

La requête :

```C#
public record GetInstructionsForDateAndHourRequest(DateTime DateAndHourOfView);
```

L'appel :

```C#
public GetInstructionsForDateAndHourResponse Handle(GetInstructionsForDateAndHourRequest request);
```

La réponse :

```C#
public class GetInstructionsForDateAndHourResponse : List<InstructionView>;
```

```C#
public record InstructionView(string Id, string AgentName, DateTime InterventionDateAndHour, string InterventionDescription, InstructionStateView[] States);
```

```C#
public record InstructionStateView(string State, DateTime DoneAt);
```

