using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] personagem;
    public int personagemIndex;
    public float ValorDinheiro;
    public float ValorImplantes;
    public float ValorDinheiroMax;
    public float ValorImplantesMax;
    [Header("Barras")]
    [SerializeField] Image barraVerde;
    [SerializeField] Image barraVermelha;
    
    [Header("Balão de falas")]
    public Text falaNoBalao;
    public Text nome;

    [Header("Botão de confirmação")]
    public GameObject botaoConfirmacao;
    public Text textoBotaoConfirmacao;

    [Header("Botão de negação")]
    public GameObject botaoNegacao;
    public Text textoBotaoNegacao;
    [Header("Lerp")]
    [SerializeField] float tempoLerp;
    [SerializeField] public float duracaoLerp;
    [Header("Aleatoriedade")]
    public float controleAleatoriedade;

    void Start()
    {
        falaNoBalao.text = personagem[personagemIndex].GetComponent<Personagem>().pedido;
        nome.text = personagem[personagemIndex].name;
        textoBotaoConfirmacao.text = personagem[personagemIndex].GetComponent<Personagem>().opcao1;
        textoBotaoNegacao.text = personagem[personagemIndex].GetComponent<Personagem>().opcao2;

        botaoConfirmacao.GetComponent<Button>().onClick.AddListener(personagem[personagemIndex].GetComponent<Personagem>().Concordo);
        botaoNegacao.GetComponent<Button>().onClick.AddListener(personagem[personagemIndex].GetComponent<Personagem>().Discordo);

        
    }

    void Update()
    {

        barraVerde.fillAmount = ValorDinheiro / ValorDinheiroMax;
        barraVermelha.fillAmount = ValorImplantes / ValorImplantesMax; 

    }

    public IEnumerator LerparDinheiro(float mudador) {

        tempoLerp = 0;
        float objetivoLerp = ValorDinheiro + mudador; 

        while(tempoLerp < duracaoLerp) {

            tempoLerp += Time.deltaTime;
            ValorDinheiro = Mathf.Lerp(ValorDinheiro, objetivoLerp, tempoLerp / duracaoLerp);
            yield return null;

        }

        ValorDinheiro = objetivoLerp;

    }

    public IEnumerator LerparImplantes(float mudador) {

        tempoLerp = 0;
        float objetivoLerp = ValorImplantes + mudador; 

        while(tempoLerp < duracaoLerp) {

            tempoLerp += Time.deltaTime;
            ValorImplantes = Mathf.Lerp(ValorImplantes, objetivoLerp, tempoLerp / duracaoLerp);
            yield return null;

        }

        ValorImplantes = objetivoLerp;

    }

    public void LerpadorDeVida(float mudador) {

        StartCoroutine(LerparDinheiro(mudador));

    }

    public void LerpadorDeImplantes(float mudador) {

        StartCoroutine(LerparImplantes(mudador));

    }

}
