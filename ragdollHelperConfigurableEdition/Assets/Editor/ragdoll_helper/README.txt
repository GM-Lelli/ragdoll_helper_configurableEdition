# Documentazione del Sistema Ragdoll

## Panoramica
Questa documentazione fornisce una panoramica delle principali classi coinvolte nella configurazione e nel controllo del sistema ragdoll per un personaggio umanoide. Il progetto è diviso in diverse classi, ognuna delle quali è responsabile di specifici aspetti del comportamento del ragdoll. In questa documentazione, ci concentreremo sulle classi che consentono agli utenti di modificare le configurazioni dei giunti e calcolare la distribuzione del peso del ragdoll umanoide.

### Classi principali:
1. **JointController**: Gestisce le configurazioni dei giunti, consentendo la regolazione dei limiti dei giunti.
2. **WeightCalculator**: Calcola la distribuzione del peso per i componenti del ragdoll.

## Classe JointController
La classe `JointController` è responsabile del disegno dei controlli per i componenti dei giunti nella vista della scena, consentendo agli sviluppatori di manipolare visivamente le configurazioni dei giunti, inclusi i limiti di torsione e oscillazione.

- **Descrizione**: Questa classe fornisce metodi per disegnare i controlli e regolare i limiti per i giunti, come `highTwistLimit`, `lowTwistLimit` e `swingLimit`.
- **Metodo principale**: Il metodo `DrawControllers()` viene invocato per disegnare i controlli per i componenti `CharacterJoint`, e attraverso questi controlli gli utenti possono modificare visivamente i limiti dei giunti nell'editor di Unity.
- **Utilizzo**: Questa classe è essenziale per configurare il range di movimento di ogni giunto del ragdoll umanoide, garantendo un comportamento fisico realistico.

```csharp
public static void DrawControllers(BoneHelper boneHelper, Transform transform)
```
Questo metodo gestisce il disegno dei controlli dei giunti e interagisce con il `CharacterJoint` di Unity per impostare i limiti appropriati in base all'input dell'utente.

## Classe WeightCalculator
La classe `WeightCalculator` calcola la distribuzione del peso tra le diverse parti del ragdoll, come il bacino, il torace, le braccia e le gambe. Questo garantisce che il ragdoll si comporti in modo fisicamente accurato quando vengono applicate delle forze.

- **Descrizione**: Questa classe prende il peso totale del personaggio e lo distribuisce tra le diverse parti del corpo. La distribuzione è influenzata dalla scelta dell'utente di creare colliders aggiuntivi per le estremità (come mani e piedi).
- **Proprietà principali**:
  - `Pelvis`, `Chest`, `Head`, `Hip`, `Knee`, `Foot`, `Arm`, `Elbow`, `Hand`
  Queste proprietà rappresentano il peso assegnato a ciascuna parte del corpo.
- **Utilizzo**: Questa classe viene istanziata durante la creazione del ragdoll (`Ragdoller.ApplyRagdoll()`), fornendo valori di peso per ogni parte del corpo per garantire che il ragdoll risponda accuratamente alle interazioni fisiche.

```csharp
public WeightCalculator(float totalWeight, bool withTips)
```
Questo costruttore prende il peso totale del personaggio e un booleano per determinare se includere mani e piedi, distribuendo il peso di conseguenza.

## Classe RagdollController
La classe `RagdollController` è responsabile della creazione e della rimozione dei componenti ragdoll per un personaggio.

- **Descrizione**: Questa classe interagisce con il `Ragdoller` per aggiungere e configurare i componenti del ragdoll (ad esempio giunti, colliders) all'oggetto del personaggio.
- **Metodi principali**:
  - `CreateRagdoll()`: Applica i componenti ragdoll al personaggio, configurando giunti e colliders utilizzando `Ragdoller`.
  - `RemoveRagdoll()`: Rimuove tutti i colliders, giunti e rigid body dal personaggio.

```csharp
public void CreateRagdoll()
```
Questo metodo utilizza la classe `Ragdoller` per applicare l'effetto ragdoll al personaggio, utilizzando il peso calcolato da `WeightCalculator`.

## Classe Ragdoller
La classe `Ragdoller` è responsabile dell'applicazione e della configurazione delle proprietà del ragdoll per il personaggio umanoide.

- **Metodi principali**:
  - `ApplyRagdoll(float totalMass, RagdollProperties ragdollProperties)`: Applica l'effetto ragdoll alle varie parti del corpo del personaggio, utilizzando proprietà come massa, colliders e giunti.
  - `ConfigureJointLimits()`: Configura i limiti dei giunti per le diverse parti del corpo, garantendo movimenti realistici e stabilità.
- **Distribuzione del peso**: Utilizza la classe `WeightCalculator` per determinare la massa di ciascuna parte del corpo, consentendo un comportamento fisico più realistico.

## Classe RagdollProperties
La classe `RagdollProperties` definisce varie proprietà per i componenti del ragdoll, come se i rigid body siano cinematici o se debba essere utilizzata la gravità.

- **Proprietà principali**:
  - `asTrigger`, `isKinematic`, `useGravity`, `rigidDrag`, `rigidAngularDrag`, `cdMode` (modalità di rilevamento delle collisioni).
- **Utilizzo**: Queste proprietà vengono passate al `Ragdoller` durante la creazione del ragdoll, consentendo la personalizzazione delle proprietà fisiche del ragdoll.

## Sommario
- **Configurazione dei giunti**: Per modificare i limiti dei giunti, utilizzare la classe `JointController`. Questa classe fornisce strumenti visivi all'interno dell'editor di Unity per regolare le proprietà dei giunti come oscillazione e torsione.
- **Distribuzione del peso**: Per configurare il peso del ragdoll umanoide, viene utilizzata la classe `WeightCalculator`. Questa classe garantisce che il peso sia distribuito adeguatamente tra le diverse parti del ragdoll, contribuendo a interazioni fisiche realistiche.

Queste classi lavorano insieme per consentire la creazione, la configurazione e la messa a punto di un personaggio ragdoll all'interno di Unity, rendendo possibile la creazione di animazioni naturali e dinamiche guidate dalla fisica.