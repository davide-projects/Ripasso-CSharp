# Client per API clienti

**File da creare:** `CustomerApiClient.cs`  
**Tipo consigliato:** Console, salvo diversa indicazione

## Scenario

Un'applicazione aziendale deve leggere e aggiornare clienti tramite un servizio REST di test.

## Traccia

- Incapsula le chiamate HTTP in un client dedicato e usa metodi asincroni.
- Definisci DTO tipizzati per le richieste e le risposte.
- Gestisci codici HTTP non riusciti, timeout e cancellazione senza nascondere gli errori.

## Bonus

Aggiungi test del client usando un HttpMessageHandler finto, senza chiamare una rete reale.

## Criteri di completamento

- La soluzione rispetta i requisiti e usa nomi chiari.
- Gli input e i casi limite sono gestiti esplicitamente.
- La soluzione è stata provata con almeno un caso valido e uno non valido, dove applicabile.
