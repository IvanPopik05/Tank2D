using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{
    static public Coords GetNormal(Coords vector)
    {
        float length = Distance(new Coords(0, 0, 0), vector);
        vector.X /= length;
        vector.Y /= length;
        vector.Z /= length;

        return vector;
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquared = Square(point1.X - point2.X) +
                            Square(point1.Y - point2.Y) +
                            Square(point1.Z - point2.Z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float Square(float value)
    {
        return value * value;
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        float dot = (vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z);
        return dot;
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) /
            (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); // radians. For degrees * 180/Mathf.PI;
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) // in radians
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.X * Mathf.Cos(angle) - vector.Y * Mathf.Sin(angle);
        float yVal = vector.X * Mathf.Sin(angle) + vector.Y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }
    
    static public Coords Translate(Coords position,Coords tankFace, Coords vector) 
    {
        if (Distance(new Coords(0, 0, 0), vector) <= 0)
            return position;
        float angle = Angle(vector,tankFace);
        float worldAngle = Angle(vector, new Coords(0, 1, 0));
        bool clockWise = false;
        if (Cross(vector,tankFace).Z < 0)
            clockWise = true;

        vector = Rotate(vector,angle + worldAngle,clockWise);

        float xVal = position.X + vector.X;
        float yVal = position.Y + vector.Y;
        float zVal = position.Z + vector.Z;

        return new Coords(xVal,yVal,zVal);
    }
    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.X - position.X, focusPoint.Y - position.Y, position.Z);
        float angle = Angle(forwardVector, direction);
        bool clockwise = false;
        if (Cross(forwardVector, direction).Z < 0)
            clockwise = true;
        Coords newDir = Rotate(forwardVector, angle, clockwise);
        return newDir;
    }


    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float xVal = vector1.Y * vector2.Z - vector1.Z * vector2.Y;
        float yVal = vector1.Z * vector2.X - vector1.X * vector2.Z;
        float zVal = vector1.X * vector2.Y - vector1.Y * vector2.X;

        return new Coords(xVal, yVal, zVal);
    }

    

}
