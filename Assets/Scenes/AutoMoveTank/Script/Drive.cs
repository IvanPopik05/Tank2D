using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject fuel;
    Vector3 direction;
    float stoppingFuel = 0.1f;

    private void Start()
    {
        direction = fuel.transform.position - transform.position;
        Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));
        direction = dirNormal.ToVector();
        transform.up = HolisticMath.LookAt2D(new Coords(transform.up),
                                                new Coords(transform.position),
                                                new Coords(fuel.transform.position)).ToVector();

        float angle = HolisticMath.Angle(new Coords(transform.up), new Coords(direction));
        bool clockWise = false;

        if (HolisticMath.Cross(new Coords(transform.up), dirNormal).Z < 0)
            clockWise = true;

        Coords newDir = HolisticMath.Rotate(new Coords(transform.up), angle, clockWise);
        transform.up = new Vector3(newDir.X, newDir.Y, newDir.Z);
    }
    private void Update()
    {
        if (HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stoppingFuel)
            transform.position += direction * speed * Time.deltaTime;
    }
}
