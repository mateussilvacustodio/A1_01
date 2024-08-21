using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl2 : MonoBehaviour
{
    [Header("Recursos")]
    public float dinheiro;
    [SerializeField] RectTransform ponteiroTransform;
    Quaternion ponteiroRotacaoAlvo;
    [SerializeField] float velocidadeRotacao;
    [SerializeField] bool ponteiroEstaRodando;
    public float quantidadePedidos;
    public float dia;
    [Header("Personagens")]
    public GameObject[] personagens;
    public int personagemIndex;
    [Header("Balao")]
    public Text balaoTexto;
    [SerializeField] Text dinheiroTexto;
    [SerializeField] Text diaTexto;
    public Text nomeBalao;
    [Header("Botoes")]
    public Text botaoConfirmacaoTexto;
    public Button botaoConfirmacao;
    public Text botaoNegacaoTexto;
    public Button botaoNegacao;
    [Header("Lerp")]
    [SerializeField] float lerp;
    [SerializeField] float duracaoLerp;
    [Header("Controle Aleatoriedade")]
    public float controleAleatoriedade;



    // Start is called before the first frame update
    void Start()
    {
        
        nomeBalao.text = personagens[personagemIndex].name;
        balaoTexto.text = personagens[personagemIndex].GetComponent<Perso2>().pedido;
        botaoConfirmacaoTexto.text = personagens[personagemIndex].GetComponent<Perso2>().opcao1;
        botaoNegacaoTexto.text = personagens[personagemIndex].GetComponent<Perso2>().opcao2;

        ponteiroRotacaoAlvo = ponteiroTransform.rotation;
        botaoConfirmacao.onClick.AddListener(personagens[personagemIndex].GetComponent<Perso2>().Concordo);
        botaoNegacao.onClick.AddListener(personagens[personagemIndex].GetComponent<Perso2>().Discordo);
    }

    void Update()
    {

        diaTexto.text = "Dia " + dia.ToString();
        dinheiroTexto.text = dinheiro.ToString("F0");

        if(ponteiroEstaRodando) {

            ponteiroTransform.rotation = Quaternion.Lerp(ponteiroTransform.rotation, ponteiroRotacaoAlvo, Time.deltaTime * velocidadeRotacao);

            if(Quaternion.Angle(ponteiroTransform.rotation, ponteiroRotacaoAlvo) < 0.1f) {

                ponteiroTransform.rotation = ponteiroRotacaoAlvo;
                ponteiroEstaRodando = false;

            }

        }

    }

    public void comecarRodar(float quantidadeRotacaoP) {

        ponteiroRotacaoAlvo *= Quaternion.Euler(0,0,quantidadeRotacaoP);
        ponteiroEstaRodando = true;

    }

    IEnumerator lerpDinheiro(float mudador) {

        lerp = 0;
        float objetivoLerp = dinheiro + mudador;

        while(lerp < duracaoLerp) {

            lerp += Time.deltaTime;
            dinheiro = Mathf.Lerp(dinheiro, objetivoLerp, lerp / duracaoLerp);
            yield return null;

        }

        dinheiro = objetivoLerp;

    }

    public void lerparDinheiro(float mudador) {

        StartCoroutine(lerpDinheiro(mudador));

    }


}
