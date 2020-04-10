using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D test)
    {
        if (test.CompareTag("MeleeEnemy"))
        {
            test.GetComponent<MeleeEnemy>().Damage();
        }
        
      /*  else if (test.CompareTag("RangeEnemy"))
        {
            test.GetComponent<RangeEnemy>().Damage();
        }
        */
    }


}
