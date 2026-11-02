# Servizio applicativo con EF Core

**File da creare:** `ProductService.cs`  
**Tipo consigliato:** ASP.NET Core con Entity Framework Core

## Scenario

Le operazioni sul catalogo devono essere separate dal controller e persistere i dati tramite un DbContext iniettato.

## Traccia

- Implementa metodi asincroni per elenco, dettaglio, creazione e aggiornamento dei prodotti.
- Usa query EF Core e salva le modifiche con SaveChangesAsync.
- Gestisci l'assenza di prodotti e non esporre il DbContext al controller.

## Bonus

Aggiungi paginazione all'elenco e usa AsNoTracking per le letture appropriate.

## Criteri di completamento

- La soluzione rispetta i requisiti e usa nomi chiari.
- Gli input e i casi limite sono gestiti esplicitamente.
- La soluzione è stata provata con almeno un caso valido e uno non valido, dove applicabile.
