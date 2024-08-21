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
    
    [SerializeField] float quantidadeRotacao;
    [SerializeField] float quantidadeDinheiro;
     
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

            gameControl2.lerparDinheiro(quantidadeDinheiro);

        }

        if(ponteiro != null) {

            gameControl2.comecarRodar(quantidadeRotacao);

        }

        gameControl2.controleAleatoriedade = gameControl2.personagemIndex;
        while(gameControl2.controleAleatoriedade == gameControl2.personagemIndex) {
            gameControl2.personagemIndex = Random.Range(0,gameControl2.personagens.Length);
        }

        gameControl2.nomeBalao.text = gameControl2.personagens[gameControl2.personagemIndex].name;
        gameControl2.balaoTexto.text = gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().pedido;
        gameControl2.botaoConfirmacaoTexto.text = gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().opcao1;
        gameControl2.botaoNegacaoTexto.text = gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().opcao2;

        gameControl2.botaoConfirmacao.onClick.RemoveAllListeners();
        gameControl2.botaoNegacao.onClick.RemoveAllListeners();
        gameControl2.botaoConfirmacao.onClick.AddListener(gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().Concordo);
        gameControl2.botaoNegacao.onClick.AddListener(gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().Discordo);

        gameControl2.quantidadePedidos ++;

        if(gameControl2.quantidadePedidos >= 10) {

            gameControl2.dia ++;
            gameControl2.quantidadePedidos = 0;

        }

    }

    public void Discordo() {

        if(dinheiro != null) {

            gameControl2.lerparDinheiro(-quantidadeDinheiro);

        }

        if(ponteiro != null) {

            gameControl2.comecarRodar(-quantidadeRotacao);

        }

        gameControl2.controleAleatoriedade = gameControl2.personagemIndex;
        while(gameControl2.controleAleatoriedade == gameControl2.personagemIndex) {
            gameControl2.personagemIndex = Random.Range(0,gameControl2.personagens.Length);
        }

        gameControl2.personagemIndex = Random.Range(0,gameControl2.personagens.Length);
        gameControl2.nomeBalao.text = gameControl2.personagens[gameControl2.personagemIndex].name;
        gameControl2.balaoTexto.text = gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().pedido;
        gameControl2.botaoConfirmacaoTexto.text = gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().opcao1;
        gameControl2.botaoNegacaoTexto.text = gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().opcao2;

        gameControl2.botaoConfirmacao.onClick.RemoveAllListeners();
        gameControl2.botaoNegacao.onClick.RemoveAllListeners();
        gameControl2.botaoConfirmacao.onClick.AddListener(gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().Concordo);
        gameControl2.botaoNegacao.onClick.AddListener(gameControl2.personagens[gameControl2.personagemIndex].GetComponent<Perso2>().Discordo);

        gameControl2.quantidadePedidos ++;

        if(gameControl2.quantidadePedidos >= 10) {

            gameControl2.dia ++;
            gameControl2.quantidadePedidos = 0;

        }

    }
}
