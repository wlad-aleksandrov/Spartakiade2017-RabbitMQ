# Request / Response (RPC)
- Sendet eine Nachricht und erwartet eine Antwort
- Matching über Typen der Anfrage und der Antwort
-  Exception, wenn Antwort nicht innerhalb Timeout 

## Response

    myBus.Respond<MyClass1,MyClass2>(DoSometingWithResult);
    myBus.RespondAsync<MyClass1,MyClass>(DoSometingAsyncWithResult);

## Request

    var req = new MyClass1{};                            
    var result = myBus.Request<MyClass1,MyClass2>(req);
    var result = await myBus.RequestAsync<MyClass1,MyClass2>(req);

## Beispiel
TBD: Beschreibung