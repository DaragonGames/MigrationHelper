using System;

[Serializable]
public class Response {
    public string line;    
    public string wantedItem;
    public string givenItem;
    public float patienceCostFactor = 1.0f;

    public Response(string line, string wantedItem, string givenItem) {
        this.line = line;
        this.wantedItem = wantedItem;
        this.givenItem = givenItem;
    }
}


/*
Introduction Line


Demand Line(s)
Good Line(s)
Response Lines

Goodbye Line


*/