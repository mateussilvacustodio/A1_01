using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimentacao : MonoBehaviour
{
    
    [SerializeField] float velocidadeMover;
    [SerializeField] float velocidadeVirar;
    bool isDead;
    [SerializeField] AudioClip audioBatida;
    [SerializeField] AudioClip audioMorte;
    [SerializeField] float delayTime;

   void Update()
    {
        
        if(!isDead) {

            float mover = Input.GetAxis("Vertical") * velocidadeMover * Time.deltaTime;
            float virar = Input.GetAxis("Horizontal") * velocidadeVirar * Time.deltaTime;

            transform.Translate(0, mover, 0);
            transform.Rotate(0, 0, -virar);

        }

    }

    public void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "Parede") {

            GetComponent<AudioSource>().PlayOneShot(audioBatida);

        }

    }

    public void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Proibido") {

            isDead = true;
            GetComponent<AudioSource>().PlayOneShot(audioMorte);
            Invoke("GameOver", delayTime);
            

        }

    }

    public void GameOver() {

        SceneManager.LoadScene("SampleScene");

    }
}
