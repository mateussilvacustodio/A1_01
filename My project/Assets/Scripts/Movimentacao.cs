using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    
    [SerializeField] float velocidadeMover;
    [SerializeField] float velocidadeVirar;

   void Update()
    {
        float mover = Input.GetAxis("Vertical") * velocidadeMover * Time.deltaTime;
        float virar = Input.GetAxis("Horizontal") * velocidadeVirar * Time.deltaTime;

        transform.Translate(0, mover, 0);
        transform.Rotate(0, 0, -virar);

    }
}
