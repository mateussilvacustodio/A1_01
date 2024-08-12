using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaoDeFala : MonoBehaviour
{
    [SerializeField] Animator balaoAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B)) {

            balaoAnim.SetBool("Apareca", true);

        } 

        if(Input.GetKey(KeyCode.C)) {
            balaoAnim.SetBool("Apareca", false);


        }
    }
}
