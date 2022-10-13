using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado : MonoBehaviour
{
    public int vida = 100;
    public int velocidad = 5;
    public Vector3 direccion;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        movimientoJugador(velocidad,direccion);
    }

    int curarJugador(int vida)
    {
        int curacion = 10;
        return vida + curacion;
    }

    int dañarJugador(int vida)
    {
        int daño = 5;
        return vida - daño;
    }

    void movimientoJugador(int velocidad, Vector3 direccion)
    {
        transform.position += direccion * velocidad * Time.deltaTime;
        return;
    }
}
