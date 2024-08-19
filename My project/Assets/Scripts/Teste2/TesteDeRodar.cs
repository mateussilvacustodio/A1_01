using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TesteDeRodar : MonoBehaviour
{
    [SerializeField] Transform hexaT;
    [SerializeField] Button botaoDeRodar;
    [SerializeField] bool estaRodando;
    [SerializeField] Quaternion rotacaoAlvo;
    [SerializeField] float velocidadeRotacao;
    // Start is called before the first frame update
    void Start()
    {   
        rotacaoAlvo = hexaT.rotation;
        botaoDeRodar.onClick.AddListener(rodar);
    }

    // Update is called once per frame
    void Update()
    {
        if(estaRodando) {

            hexaT.rotation = Quaternion.Lerp(hexaT.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);

            if(Quaternion.Angle(hexaT.rotation, rotacaoAlvo) < 0.1f) {

                hexaT.rotation = rotacaoAlvo;
                estaRodando = false;

            }

        }
    }

    void rodar() {

        rotacaoAlvo = rotacaoAlvo * Quaternion.Euler(0,0,45);
        estaRodando = true;

    }
}
