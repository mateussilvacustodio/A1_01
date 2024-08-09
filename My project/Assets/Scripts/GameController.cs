using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
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

}
