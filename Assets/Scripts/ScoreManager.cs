using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private double TotalSecond;

    // Start is called before the first frame update
    void Start()
    {
        TotalSecond = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TotalSecond += Time.deltaTime;
    }

    public double GetSeconds()
    {
        return TotalSecond;
    }
}
