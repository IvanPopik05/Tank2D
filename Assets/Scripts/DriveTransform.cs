using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DriveTransform : MonoBehaviour
{
    public TMP_Text energyTankText;
    public UiManager uiManager;
    float speed = 10;
    float rotationSpeed = 100f;
    float translation;
    Vector3 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fuel"))
        {
            ObjectManager.obj.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), -2);
            Debug.Log("Дотронулось");
            uiManager.FindingLengthOfObjects();
        }
    }
    private void Update()
    {
        if (float.Parse(energyTankText.text) <= 0) 
        {
            uiManager.GameOverPanel.SetActive(true);
            return;
        }

        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.up = HolisticMath.Rotate(new Coords(transform.up),rotation * Mathf.Deg2Rad, true).ToVector();

        transform.position = HolisticMath.Translate(new Coords(transform.position),new Coords(transform.up),new Coords(0,translation,0)).ToVector();
        
        energyTankText.text = $"{float.Parse(energyTankText.text) - HolisticMath.Distance(new Coords(currentPosition), new Coords(transform.position))}";
        currentPosition = transform.position;


    }

    //private void OnDrawGizmos() {


    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawLine(new Vector3(0,translation,0), transform);
    //    Gizmos.color = Color.red;

    //}
}
