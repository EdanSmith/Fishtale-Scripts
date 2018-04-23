using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRecord {

    public string baseId;
    public int totalCaught;
    public double smallestCaught;
    public double biggestCaught;
    public int highestStar;

    public FishRecord() { }

    public FishRecord(string baseId, int totalCaught, double smallestCaught, double biggestCaught, int highestStar) // Used when first saving data from JSON to the GameManager List
    {
        this.baseId = baseId;
        this.totalCaught = totalCaught;
        this.smallestCaught = smallestCaught;
        this.biggestCaught = biggestCaught;
        this.highestStar = highestStar;
    }
}
