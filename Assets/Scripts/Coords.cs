using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords
{

    public float X { get; set;}
    public float Y { get; set; }
    public float Z { get; set; }

    public Coords(float x, float y)
    {
        X = x;
        Y = y;
        Z = -1;
    }
    public Coords(float x, float y, float z) 
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Coords(Vector3 vecPos)
    {
        X = vecPos.x;
        Y = vecPos.y;
        Z = vecPos.z;
    }

    public override string ToString()
    {
        return $"{X}, {Y}, {Z}";
    }

    public Vector3 ToVector() 
    {
        return new Vector3(X, Y, Z);
    }
}
