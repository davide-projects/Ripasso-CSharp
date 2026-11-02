# Elaborazione asincrona di ordini

**File da creare:** `Program.cs`  
**Tipo consigliato:** Console, salvo diversa indicazione

## Scenario

Un programma simula il caricamento di più ordini da un servizio lento e deve restare reattivo durante l'attesa.

## Traccia

- Crea metodi asincroni che restituiscono Task o Task<T>.
- Usa async/await e attende correttamente tutte le operazioni.
- Gestisci gli errori delle operazioni asincrone.

## Bonus

Confronta l'esecuzione sequenziale con Task.WhenAll.

## Criteri di completamento

- La soluzione rispetta i requisiti e usa nomi chiari.
- Gli input e i casi limite sono gestiti esplicitamente.
- La soluzione è stata provata con almeno un caso valido e uno non valido, dove applicabile.
