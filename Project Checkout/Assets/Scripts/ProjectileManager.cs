using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public Projectile proj;
    public Transform attackPoint;

    public void instantiateProjectile() {
        if (GetComponent<PlayerMovement>().right)
        {
            proj.right = true;
        }
        else if (!GetComponent<PlayerMovement>().right)
        {
            proj.right = false;
        }

        Instantiate(proj, attackPoint.position, attackPoint.rotation);
    }
}
