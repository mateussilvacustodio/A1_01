using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perso2 : MonoBehaviour
{
    [Header("Textos")]
    public string pedido;
    public string opcao1;
    public string opcao2;
    [Header("Recursos")]
    [SerializeField] Text dinheiro;
    [SerializeField] GameObject ponteiro;
    [SerializeField] GameControl2 gameControl2;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Concordo() {

        if(dinheiro != null) {

            gameControl2.dinheiro += 10;

        }

        if(ponteiro != null) {

            gameControl2.lerparReputacao(-10);

        }
        

    }

    public void Discordo() {

        if(dinheiro != null) {

            gameControl2.dinheiro -= 10;

        }

        if(ponteiro != null) {

            gameControl2.lerparReputacao(10);

        }

    }
}
