using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    [SerializeField] Transform characterTransform;
    
    void Update()
    {
        
        if (characterTransform.position.x > 11) {

            if(characterTransform.position.y > 5) {

                transform.position = new Vector3(11f, 5, -10);

            } else if (characterTransform.position.y < -8) {

                transform.position = new Vector3(11f, -8, -10);

            } else {

                transform.position = new Vector3(11f, characterTransform.position.y, -10);

            }

        } else if (characterTransform.position.x < -3) {

            if(characterTransform.position.y > 5) {

                transform.position = new Vector3(-3f, 5, -10);

            } else if (characterTransform.position.y < -8) {

                transform.position = new Vector3(-3f, -8, -10);

            } else {

                transform.position = new Vector3(-3f, characterTransform.position.y, -10);

            }

        } else {

            if(characterTransform.position.y > 5) {

                transform.position = new Vector3(characterTransform.position.x, 5, -10);

            } else if (characterTransform.position.y < -8) {

                transform.position = new Vector3(characterTransform.position.x, -8, -10);

            } else {

                transform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, -10);

            }
            
            

        }        

    }
}
