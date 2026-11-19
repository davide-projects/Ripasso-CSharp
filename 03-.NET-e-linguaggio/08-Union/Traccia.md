# Esito di una chiamata a un servizio

**File da creare:** `Program.cs`  
**Tipo consigliato:** Console, salvo diversa indicazione  
**Requisito:** C# 15 (.NET 11 SDK o Visual Studio 2026): la parola chiave `union` non esiste nelle versioni precedenti.

## Scenario

Un'applicazione riceve l'esito di una chiamata a un servizio esterno: può essere un successo con un importo oppure un fallimento con un motivo. Vuoi modellare questi due risultati in modo che il compilatore ti costringa a gestirli entrambi, senza ricorrere a un `object`, a un `enum` di stato o a eccezioni per il flusso normale.

## Traccia

- Dichiara due tipi caso distinti, ad esempio i record `OperazioneRiuscita(decimal Importo)` e `OperazioneFallita(string Motivo)`, e la union `union Esito(OperazioneRiuscita, OperazioneFallita)`.
- Crea un valore per ciascun caso assegnandolo a una variabile `Esito` tramite la conversione implicita della union, senza chiamare esplicitamente un costruttore.
- Scrivi `string Descrivi(Esito esito)` con uno `switch` expression esaustivo: una branca per ogni caso, con pattern tipizzati per leggere `Importo` e `Motivo`, e senza braccio `_`.
- Stampa la descrizione di entrambi i casi e verifica che, togliendo una branca, il compilatore segnali il caso mancante.

## Bonus

Aggiungi un terzo caso `TempoScaduto` alla union, aggiorna `Descrivi` per gestirlo e gestisci anche un `Esito` di default con una branca `null`, senza perdere l'esaustività.

## Criteri di completamento

- La soluzione rispetta i requisiti e usa nomi chiari.
- Gli input e i casi limite sono gestiti esplicitamente.
- La soluzione è stata provata con almeno un caso valido e uno non valido, dove applicabile.