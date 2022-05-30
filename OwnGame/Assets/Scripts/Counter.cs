using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int ScoreCounter = 0;
    public GameObject ScoreText;

    public void Count()
    {
        ScoreCounter++;
        ScoreText.GetComponent<Text>().text = " " + ScoreCounter.ToString();
    }
}
