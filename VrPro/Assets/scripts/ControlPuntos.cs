using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlPuntos : MonoBehaviour
{
    
    [SerializeField] private GameObject GPuntos;
    [SerializeField] private GameObject GFeedBack;
    [SerializeField] private Transform PosInitFeedBack;
    private int Puntos = 0;
    private TextMeshProUGUI FeedBack;
    private TextMeshProUGUI TextoPuntos;

    private int Correctas = 0;
    private int Incorrectas = 0;

    public float moveDistance = 300f; // Distancia del movimiento
    public float moveTime = 1f; // Tiempo de movimiento
    public float waitTime = 1f; // Tiempo de espera antes de desaparecer

    private void Start()
    {
        FeedBack = GFeedBack.GetComponent<TextMeshProUGUI>();
        FeedBack.text = "";
        TextoPuntos = GPuntos.GetComponent<TextMeshProUGUI>();
    }

    public int GetPuntos()
    {
        return Puntos;
    }

    void AnimateText()
    {
        Vector3 startPos = FeedBack.rectTransform.anchoredPosition;

        // Mueve a la derecha
        LeanTween.moveX(FeedBack.rectTransform, startPos.x + moveDistance, moveTime)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() =>
            {
                // Espera y mueve a la izquierda
                StartCoroutine(WaitAndMoveBack(startPos));
            });
    }

    IEnumerator WaitAndMoveBack(Vector3 startPos)
    {
        yield return new WaitForSeconds(waitTime);

        // Mueve a la izquierda (rebote)
        LeanTween.moveX(FeedBack.rectTransform, startPos.x - moveDistance, moveTime)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() =>
            {
            });
        FeedBack.text = "";
    }


    public void AumentaPuntos()
    {
        Puntos += 10;
        Correctas++;
        TextoPuntos.text = "Puntos: " + Puntos;
        FeedBack.text = "¡Bien Hecho!";
        FeedBack.transform.position = PosInitFeedBack.position;
        AnimateText();
    }

    public void DisminuyePuntos()
    {
        Incorrectas++;
        Puntos -= 10;
        FeedBack.text = "Clasificación incorrecta";
        TextoPuntos.text = "Puntos: " + Puntos;
        FeedBack.transform.position = PosInitFeedBack.position;
        AnimateText();
    }

    public int GetCorrectas()
        { return Correctas; }

    public int GetIncorrectas()
        { return Incorrectas; }

    public void ResetPuntos()
        { 
        Puntos = 0; Correctas = 0; Incorrectas = 0;
        TextoPuntos.text = "Puntos: " + Puntos;

    }

}
