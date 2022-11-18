# Instruction Logistic Solution

Ce sujet a pour but de servir de base pour une présentation. Les projets réalisés pourront être ainsi analysés et alimenteront la présentation.

Par conséquent, **ne changez pas vos habitudes de développement pour l'exercice**, sinon les résultats pourraient être faussés et cela rendrait les résultats inintéressants.

## Sujet

### Contexte

Monsieur Duchemin est le PDG LampCity. Il s'agit d'une entreprise spécialisé dans la pose et la maintenance de lampadaire public.

Chaque matin, son chef de chantier Thibault et ses collègues du bureau, contact par téléphone les différentes équipes d'intervention afin de leur communiquer les interventions à effectuer pour le jour même. De cette façon, les équipes n'ont pas besoin de se déplacer jusqu'au bureau.

Il faut savoir qu'il y a une rotation des équipes tous les jours à 12:00PM.

Monsieur Duchemin étant un PDF visionnaire, il trouve dommage de passer par une conversation téléphonique pour communiquer des informations. Il souhaiterait donc avoir un système permettant de passer ses instructions et d'avoir confirmation quand une équipe à terminé son chantier.

Il commande donc à votre entreprise *MLG Computing*  un *MVC (Most Valuable Product)* qui devra répondre à des besoins minimums sans pour autant rogner sur la qualité.

### Votre travail

Votre entreprise vous confie une tâche (la plus importante) qui consiste à développer le code métier de cette solution (pas d'interface, pas d'API, ...).

Un projet a été initialisé, et des interfaces ont été conçues en atelier de conception en amont.

Vous allez donc devoir développer les fonctionnalités demandées et vous aller devoir écrire les tests afin que vos collègues puissent se servir de votre travail pour la suite des développements.

**Vous ne devez pas modifier ce qui a été décidé en atelier de conception !**

Pour tout le reste, vous êtes libre de développer comme vous le voulez.

### Les besoins

Étant donné que la solution sera un *MVC*, il n'y aura pas de système d'identification (pas de login, pas de rôle, ...). Pour les rôles évoqués ci-dessous (agent de bureau, équipe d'intervention, ...) on considère que l'accès est libre à tous et que chacun est de bonne volonté.

- Un agent de bureau (Thibault et ses collègues) nommé doit pouvoir créer une instruction déstiné à une équipe nommée, à une date donnée. Une description courte (max 160 caractère) permettra d'indiquer à l'équipe le lieu et les modalités de l'intervention (ils ont des abréviations pour aller plus vite).
- Les instructions sont attribuées à une plage horaire en fonction de leur date de création : si une instruction est 
- Une équipe pourra *Confirmer* une instruction pour dire qu'elle la prise en compte. La date et l'heure de confirmation devront être affichées.
- Une équipe pourra *Terminer* une instruction pour dire que l'intervention est terminée à condition que celle-ci soit confirmée. La date et l'heure à laquelle l'instruction est terminée devront être affichées.
- Un agent de bureau pourra *Annuler* une instruction à condition que celle-ci ne soit pas terminée ou confirmée. La date et l'heure d'annulation devront être affichées.
- Chacun pourra afficher la liste des instructions pour une date et heure donnée avec les informations suivantes :
	- Nom de l'agent de bureau
	- Date et heure prévues de l'intervention
	- Description de l'intervention
	- Nom de l'équipe concernée par l'intervention
	- La date et l'heure de la confirmation si l'instruction est confirmée
	- La date et l'heure de la clôture si l'instruction est terminée
	- La date et l'heure de l'annulation si l'instruction est terminée
- Les instructions non terminées et non annulées doivent toujours être affichées.
- Les instructions terminées ou annulées ne doivent être affichée que pour la date et l'heure précisé si leur cela correspond à leur date de création :
	- Si une instruction est créée le 12/06/2022 à 11:00AM, alors elle devra être affiché que si la date et l'heure précisé est entre le 11/06/2022 12:00PM (inclus) et le 12/06/2022 12:00PM (exclus)
	- Si une instruction est créée le 14/07/2022 à 13:10PM, alors elle devra être affiché que si la date et l'heure précisé est entre le 14/07/2022 12:00PM (inclus) et le 15/07/2022 12:00PM (exclus)


  