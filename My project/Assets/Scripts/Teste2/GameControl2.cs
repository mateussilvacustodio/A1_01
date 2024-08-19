using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl2 : MonoBehaviour
{
    [Header("Recursos")]
    public float dinheiro;
    [SerializeField] RectTransform ponteiroTransform;
    public float anguloPonteiro;
    [Header("Personagens")]
    [SerializeField] GameObject[] personagens;
    [SerializeField] int personagemIndex;
    [Header("Balao")]
    [SerializeField] Text balaoTexto;
    [SerializeField] Text dinheiroTexto;
    [Header("Botoes")]
    [SerializeField] Text botaoConfirmacaoTexto;
    [SerializeField] Button botaoConfirmacao;
    [SerializeField] Text botaoNegacaoTexto;
    [SerializeField] Button botaoNegacao;
    [Header("Lerp")]
    [SerializeField] float lerp;
    [SerializeField] float duracaoLerp;

    // Start is called before the first frame update
    void Start()
    {
        balaoTexto.text = personagens[personagemIndex].GetComponent<Perso2>().pedido;
        botaoConfirmacaoTexto.text = personagens[personagemIndex].GetComponent<Perso2>().opcao1;
        botaoNegacaoTexto.text = personagens[personagemIndex].GetComponent<Perso2>().opcao2;

        botaoConfirmacao.onClick.AddListener(personagens[personagemIndex].GetComponent<Perso2>().Concordo);
        botaoNegacao.onClick.AddListener(personagens[personagemIndex].GetComponent<Perso2>().Discordo);
    }

    // Update is called once per frame
    void Update()
    {
        ponteiroTransform.rotation = Quaternion.Euler(0,0,anguloPonteiro);
        dinheiroTexto.text = dinheiro.ToString();

        if(Input.GetKey(KeyCode.A)) {

            anguloPonteiro = anguloPonteiro + Time.deltaTime * 10;

        }
    }

    IEnumerator lerpReputacao(float mudador) {

        lerp = 0;
        float objetivoLerp = anguloPonteiro + mudador;

        while(lerp < duracaoLerp) {

            lerp += Time.deltaTime;
            anguloPonteiro = Mathf.Lerp(anguloPonteiro, objetivoLerp, lerp / duracaoLerp);
            yield return null;

        }

        anguloPonteiro = objetivoLerp;

    }

    public void lerparReputacao(float mudador) {

        StartCoroutine(lerpReputacao(mudador));

    }


}
