using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private string Id;
    private GameObject Control;
    private ControlPuntos _controlPuntos = new ControlPuntos();

    private string[] Ids = {"papel", "vidrio", "bateria", "plastico"};

    private void Start()
    {
        Control = GameObject.Find("Control");
        _controlPuntos = Control.GetComponent<ControlPuntos>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Choca con un colisionador de caneca
        if(other.CompareTag("papel") || other.CompareTag("vidrio") || other.CompareTag("bateria") || other.CompareTag("plastico"))
        {
            //Lo tiró a la caneca correcta
            if(other.CompareTag(Id))
            {
                _controlPuntos.AumentaPuntos();
            }
            //Caneca incorrecta
            else
            {
                _controlPuntos.DisminuyePuntos();
            }
        }
    }
}
