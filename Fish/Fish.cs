using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish {

    public string id;
    public FishData fishData;

    public Fish()
    {

    }

    public Fish(FishData fishData)
    {
        this.fishData = fishData;
        this.id = fishData.id;
    }
}
