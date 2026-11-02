# Importazione e validazione di un CSV

**File da creare:** `CsvImportService.cs`  
**Tipo consigliato:** Console, salvo diversa indicazione

## Scenario

L'ufficio riceve un file CSV di clienti; alcune righe possono essere incomplete o contenere dati non validi.

## Traccia

- Leggi il file senza caricarne necessariamente tutto il contenuto in memoria.
- Converti le righe valide in oggetti Cliente.
- Raccogli gli errori con numero di riga e motivo, continuando l'importazione quando possibile.

## Bonus

Scrivi un report degli errori in un file separato.

## Criteri di completamento

- La soluzione rispetta i requisiti e usa nomi chiari.
- Gli input e i casi limite sono gestiti esplicitamente.
- La soluzione è stata provata con almeno un caso valido e uno non valido, dove applicabile.
