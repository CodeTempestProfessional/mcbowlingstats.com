```mermaid
flowchart LR;
    B([MAUI App]) <--> C(.Net 7 Simple API);
    A([MVC App]) <--> C;
		E([Blazor FrontEnd???]) <--> C;
    C <--> D[(FireStore Document Database)];
```