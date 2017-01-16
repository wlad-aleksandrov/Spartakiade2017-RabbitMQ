# Verbindungsaufbau
Im Beispiel geht es darum eine Verbindung zu RabbitMQ aufzubauen. Bei EasyNetQ wird dafür die Factory _RabbitHutch_ verwendet. Die instanzspezifischen Informationen werden im Connectionstring angegeben.

    var myBus = RabbitHutch.CreateBus("host=myRabbitMQ");

## Verbindungsoptionen
Option | Standardwert | Bemerkung 
------------ | ------------- | -------------
host | 5672 | DNS-Name/IP[:Port]
username | guest |
passwort | guest |
prefetchcount | 50 | Anzahl der Nachrichten, die gleichzeitig abgerufen werden
timeout | 10 | timeout in Sekunden
publisherConfirms | false | Erzwingt eine Annahmebestätigung
