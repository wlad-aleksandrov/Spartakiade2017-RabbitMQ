# Vorbereitung

Für den Workshop werden Grundkenntnisse im Umgang mit RabbitMQ und der .NET-Bibliothek EasyNetQ vorausgesetzt.
Auf dieser Seite und den verknüpften Beispielprojekt könnt ihr diese Kenntnisse erhalten oder auffrischen.

# RabbitMQ
## Was ist RabbitMQ?
- Message Broker / Queue Manager
    - System um Queues zu verwalten
    - Nachrichten von Systemen empfangen
    - Nachrichten zwischenspeichern
    - Nachrichten nach Regeln an Systeme zustellen
- Erstellt in <a href="https://de.wikipedia.org/w/index.php?title=Erlang_(Programmiersprache)" target="_blank"> Erlang / OTP</a>
- Erlaubt Entkopplung von unterschiedlichen und unabhängigen Anwendungen

## Begriffe

Bezeichnung | Beschreibung
------------ | -------------
AMQP (Advanced Message Queuing Protocol) | Protokoll zur Kommunikation über Systemgrenzen
Produzent (Producer) | Anwendung, die eine Nachricht erstellt
Konsument (Consumer) | Anwendung, die eine Nachricht empfängt
Nachricht (Message) | Information, die zwischen Produzent und Konsument ausgetauscht wird
Warteschlange (Queue) | Speichert die Nachrichten zwischen
Verbindung (Connection) | TCP Netzwerkverbindung zwischen Anwendung und RabbitMQ Broker
Channel | Virtuelle Verbindung innerhalb der TCP-Verbindung
Exchange | Nimmt eine Nachricht an und leitet sie in keine, eine oder mehrere Warteschlagen
Binding | Verknüpfung zwischen Queue und Exchange
Routing key | "Adresse", nach welcher der Exchange entscheidet, in welche Queue er die Nachricht leitet.
Benutzer (User) | - Zugangsdaten (Benutzername / Password) für RabbitMQ <br/>- Zuordnung von Rechten (Lesen, Schreiben, Konfigurieren etc.) <br/>- Definition global oder für einen spezifischen virtuellen Host
Vhost (virtual host) | Erlaubt, Anwendung auf einer RabbitMQ Instanz zu isolieren


## Exchanges
Je nach Anwendungsfall kommen verschiedene Exchange-Typen zum Einsatz.
- Fanout Exchange
    - Eingehende Nachrichten werden an alle verbunden Queues gesendet
    - Keine Beachtung der Binding-Konfiguration
- Direct Exchange
    - Producer erstellt Routing Key
    - Binding Key der Queue muss exakt passen
- Topic
    - Ähnlich dem Direct Exchange
    - Einsatz von Platzhaltern, z.B. Wort (*) / mehrere Worte (#)
- Header Exchange
    - Routing anhand von Headerinformationen der Nachricht

## Nachrichtentransport

<img src="../images/MessageFlow.png" alt="Übersicht Nachrichtentransport" />
 
# EasyNetQ
