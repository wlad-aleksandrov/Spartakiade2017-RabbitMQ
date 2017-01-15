# Topic Based Routing

- Sonderform des Publish / Subscribe
- Neben dem Zieltyp muss auch das Thema (Topic) passen
- Im Thema sind Platzhalter möglich

## Subscribe

    myBus.Subscribe<MyClass>("MyTopicSub", msg => DoSomething(msg), x => x.WithTopic("MyTopic"));

## Publish

    var msg = new MyClass{};                            
    myBus.Publish(msg, "MyTopic");

## Beispiel
TBD: Beschreibung