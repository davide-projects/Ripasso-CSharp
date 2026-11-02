# Client di un servizio HTTP

**File da creare:** `Program.cs`  
**Tipo consigliato:** Console, salvo diversa indicazione

## Scenario

Un client interroga un endpoint pubblico di test, legge una risposta JSON e la trasforma in oggetti C#.

## Traccia

- Usa HttpClient con richieste asincrone.
- Verifica lo stato HTTP e segnala gli errori di rete o risposta.
- Deserializza il JSON in tipi espliciti e gestisci una risposta vuota.

## Bonus

Usa CancellationToken e un timeout appropriato.

## Criteri di completamento

- La soluzione rispetta i requisiti e usa nomi chiari.
- Gli input e i casi limite sono gestiti esplicitamente.
- La soluzione è stata provata con almeno un caso valido e uno non valido, dove applicabile.
