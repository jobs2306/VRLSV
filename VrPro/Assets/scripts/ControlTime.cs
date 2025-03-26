using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    private float elapsedTime = 0; // Variable para almacenar el tiempo transcurrido
    private int Min = 9;
    private int Sec;
    private bool GameOver = false;

    [SerializeField] private GameObject GTime;
    private ControlInterface _controlInterface;

    private TextMeshProUGUI TextoTime;


    private void Start()
    {
        _controlInterface = GetComponent<ControlInterface>();
        TextoTime = GTime.GetComponent<TextMeshProUGUI>();
    }

    public bool GetGameOver()
    {
        return GameOver;
    }    

    public void ResetClock()
    {
        Min = 9;
        Sec = 0;
        elapsedTime = 0;
        GameOver = false;
    }

    void Update()
    {
        if (!GameOver)
        {
            elapsedTime += Time.deltaTime; // Suma los segundos en cada frame

            if (elapsedTime >= 60)
            {
                elapsedTime = 0;
                Min -= 1;

                if (Min < 0)
                {
                    GameOver = true;
                    _controlInterface.GameOver();
                }
            }

            Sec = 60 - Mathf.RoundToInt(elapsedTime);

            if (Sec == 60)
            {
                Sec = 0;
            }

            if (Sec < 10)
            {
                TextoTime.text = "Tiempo: " + Min + ":0" + Sec;
            }
            else
            {
                TextoTime.text = "Tiempo: " + Min + ":" + Sec;
            }
        }
        else
        {
            TextoTime.text = "Tiempo: 0:00";
        }
    }
}
