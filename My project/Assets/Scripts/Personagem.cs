using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    //
    [Header("Textos")]
    public string pedido;
    public string opcao1;
    public string opcao2;
    //
    [Header("Recursos")]
    [SerializeField] GameObject barraVerde;
    [SerializeField] GameObject barraVermelha;
    [SerializeField] GameController gameController;
    public float mudadorDinheiro;
    public float mudadorImplantes;
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Concordo() {

        
        if(barraVerde != null) {

            gameController.LerpadorDeVida(mudadorDinheiro);

        }

        if(barraVermelha != null) {

            gameController.LerpadorDeImplantes(mudadorImplantes);

        }

        gameController.controleAleatoriedade = gameController.personagemIndex;
        while(gameController.controleAleatoriedade == gameController.personagemIndex) {

            gameController.personagemIndex = Random.Range(0,3);

        }

        gameController.falaNoBalao.text = gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().pedido;
        gameController.nome.text = gameController.personagem[gameController.personagemIndex].name;
        gameController.textoBotaoConfirmacao.text = gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().opcao1;
        gameController.textoBotaoNegacao.text = gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().opcao2;
        gameController.botaoConfirmacao.GetComponent<Button>().onClick.RemoveAllListeners();
        gameController.botaoNegacao.GetComponent<Button>().onClick.RemoveAllListeners();
        gameController.botaoConfirmacao.GetComponent<Button>().onClick.AddListener(gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().Concordo);
        gameController.botaoNegacao.GetComponent<Button>().onClick.AddListener(gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().Discordo);

    }

    public void Discordo() {

        if(barraVerde != null) {

            gameController.LerpadorDeVida(-mudadorDinheiro);

        }

        if(barraVermelha != null) {

            gameController.LerpadorDeImplantes(-mudadorImplantes);

        }
        
        gameController.controleAleatoriedade = gameController.personagemIndex;
        while(gameController.controleAleatoriedade == gameController.personagemIndex) {

            gameController.personagemIndex = Random.Range(0,3);

        }

        gameController.falaNoBalao.text = gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().pedido;
        gameController.nome.text = gameController.personagem[gameController.personagemIndex].name;
        gameController.textoBotaoConfirmacao.text = gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().opcao1;
        gameController.textoBotaoNegacao.text = gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().opcao2;
        gameController.botaoConfirmacao.GetComponent<Button>().onClick.RemoveAllListeners();
        gameController.botaoNegacao.GetComponent<Button>().onClick.RemoveAllListeners();
        gameController.botaoConfirmacao.GetComponent<Button>().onClick.AddListener(gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().Concordo);
        gameController.botaoNegacao.GetComponent<Button>().onClick.AddListener(gameController.personagem[gameController.personagemIndex].GetComponent<Personagem>().Discordo);

    }
}
