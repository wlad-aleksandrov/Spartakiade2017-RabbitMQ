# Publish / Subscribe
- Sendet eine Nachricht an beliebig viele Empfänger
- Wenn kein Empfänger definiert wurde, geht Nachricht verloren (keine Speicherung / Verarbeitung)
- Zieltypen der Bestellung müssen übereinstimmen
- Polymorphy ist möglich

## Subscribe
                       
    myBus.Subscribe<MyClass>("MySub",  msg => DoSomething(msg));
    myBus.SubscribeAsync<MyClas>("MySubAsync", msg => DoSomethingAsync(msg));

## Publish

    var msg = new MyClass{};                            
    myBus.Publish(msg);
    myBus.PublishAsync(msg);

## Beispiel
In diesem Beispiel sind sowohl ein einfaches Beispiel als auch ein Beispiel mit Polymorphy enthalten.
Zum Starten den Methodenaufruf  _SimpleSubscription_ bzw. _PolymorphicSubscription_ in der Main-Methode einkommentieren.

### SimpleSubscription
Ziel ist ein Objekt vom Typ _MyMessage_ vom Producer zum Consumer zu übertragen und auf der Konsole auszugeben.

### PolymorphicSubscription

Ziel ist ein Objekt, welches IVertrag implementiert, zu übertragen und die Vertragsnummer auf der Konsole auszugeben.

Wichtig: Das Routing wird an Hand des Typen vorgenommen d.h. aus dem vollständigen Typname wird der Routingkey.

Der Consumer reagiert nur auf das Interface IVertrag. Wenn nun der Producer nun ein Objekt vom Typ Handyvertrag überträgt wird dieses den Cosumer nicht erreichen. Nur durch den Hinweis, dass es als IVertrag übertragen werden soll kommt es an. Dabei wird das gesamte Objekt und nicht nur die Member des Interface übermittelt.