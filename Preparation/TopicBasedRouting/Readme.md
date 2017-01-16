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
In diesem Beispiel wird wieder ein Objekt des Typs MyMessage übertragen. Diesemal wird allerdings zusätzlich ein Topic angegeben. So ergeben sich zwei Comsumer die auf den gleich Typ achten aber jeweils verschiedene Topic ('Red' oder 'Blue') berücksichtigen. Beide Customer ändern je nach Topic die Textfarbe der Konsole auf rot oder blau. Durch dieses Vorgehen können Objekte gleiches Typ unterschiedlich verteilt werden.