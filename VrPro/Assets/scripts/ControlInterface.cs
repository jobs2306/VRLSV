using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlInterface : MonoBehaviour
{
    [SerializeField] private GameObject GPuntosText;
    [SerializeField] private GameObject GGameOver;
    [SerializeField] private GameObject GCorrectas;
    [SerializeField] private GameObject GIncorrectas;
    [SerializeField] private GameObject GTiempoReset;
    [SerializeField] private GameObject GMensajeInicial;

    [SerializeField] private GameObject FirstMessage;
    [SerializeField] private GameObject SecondMessage;
    [SerializeField] private GameObject TercerMessage;

    private TextMeshProUGUI PuntosText;
    private TextMeshProUGUI CorrectasText;
    private TextMeshProUGUI IncorrectasText;
    private TextMeshProUGUI TextTiempo;

    private ControlTime _controlTime;
    private ControlPuntos _controlPuntos;

    private float tiempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        PuntosText = GPuntosText.GetComponent<TextMeshProUGUI>();
        CorrectasText = GCorrectas.GetComponent<TextMeshProUGUI>();
        IncorrectasText = GIncorrectas.GetComponent<TextMeshProUGUI>();
        TextTiempo = GTiempoReset.GetComponent<TextMeshProUGUI>();

        _controlPuntos = GetComponent<ControlPuntos>();
        _controlTime = GetComponent<ControlTime>();

        StartCoroutine(MensajeInicial());
    }

    public void Update()
    {
        if(_controlTime.GetGameOver())
        {
            tiempo += Time.deltaTime; // Suma los segundos en cada frame
            int Tiempo = 10 - Mathf.RoundToInt(tiempo);
            TextTiempo.text = "Nuevo juego en: " + Tiempo;

            if(Tiempo < 0)
            {
                ResetGame();
            }
        }
    }

    public void GameOver()
    {
        GGameOver.SetActive(true);
        PuntosText.text = "Puntos: " + _controlPuntos.GetPuntos();
        CorrectasText.text = "Correctas: " + _controlPuntos.GetCorrectas();
        IncorrectasText.text = "Incorrectas" + _controlPuntos.GetIncorrectas();
    }

    public void ResetGame()
    {
        GGameOver.SetActive(false);
        tiempo = 0;
        tiempo = 0;
        _controlTime.ResetClock();
        _controlPuntos.ResetPuntos();
    }

    public IEnumerator MensajeInicial()
    {
        yield return new WaitForSeconds(10f);

        FirstMessage.SetActive(false);
        SecondMessage.SetActive(true);
        yield return new WaitForSeconds(12f);

        SecondMessage.SetActive(false);
        TercerMessage.SetActive(true);
        yield return new WaitForSeconds(12f);

        GMensajeInicial.SetActive(false);

    }
}
