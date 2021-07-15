using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public TMP_Text tankPosText;
    public TMP_Text fuelPosText;
    public TMP_Text EnergyTankText;
    public TMP_InputField inputRotateText;
    public GameObject GameOverPanel;
    [SerializeField] private GameObject tank;
    [SerializeField] private Image tankImage;

    private void Start()
    {
        FindingLengthOfObjects();
    }

    public void FindingLengthOfObjects()
    {
        float newDir = HolisticMath.Distance(new Coords(ObjectManager.obj.transform.position), new Coords(tank.transform.position));
        Debug.Log($"Гипотенуза: {newDir}");
        EnergyTankText.text = $"{newDir + 10}";
    }
    public void InputFieldText() 
    {
        float a;
        if (float.TryParse(inputRotateText.text,out a)) 
        {     
            Vector3 vec = HolisticMath.Rotate(new Coords(tank.transform.up), a, false).ToVector();
            tank.transform.up = vec;
            tankImage.transform.up = vec;
        }
    }
    private void Update()
    {
        tankPosText.text = $"{tank.transform.position}";
        fuelPosText.text = $"{ObjectManager.obj.transform.position}";

    }

    public void BtnRepeat() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BtnMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
