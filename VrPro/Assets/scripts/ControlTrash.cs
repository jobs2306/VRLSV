using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrash : MonoBehaviour
{
    //Tipos de basura
    [SerializeField] private List<GameObject> TypeTrash = new List<GameObject>();
    
    //Transforms de basuras
    [SerializeField] private GameObject[] Trash;

    private List<GameObject> ListTrash = new List<GameObject>();
    
    private int RandInt = 0;

    private bool ControlRegenerate = false;
    [SerializeField] private float TimeRegeneration = 120f;
    
    private void Start()
    {
        StartCoroutine(RegenerateTrash());
    }

    private void Update()
    {
        if(!ControlRegenerate)
        {
            Regeneration();
            ControlRegenerate = true;
        }
    }

    private void Regeneration()
    {
        //Elimina las que se tengan en el momento
        foreach (GameObject t in ListTrash)
        {
            try
            {
                Destroy(t);
            }
            catch { }
        }

        ListTrash.Clear();

        //Generación de la basura
        foreach (GameObject t in Trash)
        {
            RandInt = Random.Range(0, TypeTrash.Count - 1);
            if (TypeTrash[RandInt] != null && t != null)
            {
                GameObject nuevoObjeto = Instantiate(TypeTrash[RandInt], t.transform.position, Quaternion.identity);
                ListTrash.Add(nuevoObjeto);
            }
            else
            {
                Debug.LogWarning("Prefab o punto de instancia o asignado.");
            }
        }
    }

    //Reiniciar variable de control
    private IEnumerator RegenerateTrash()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeRegeneration);
            ControlRegenerate = false;
        }
    }
}
