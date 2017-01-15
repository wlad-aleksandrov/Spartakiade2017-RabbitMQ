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
TBD: Beschreibung