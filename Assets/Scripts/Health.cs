using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maximum = 10;
    public float current = 10;
    public void Damage(float amount)
    {
        current -= amount;
        current = (current < 0) ? 0 : current;
        current = (current > maximum) ? maximum : current;
    }
}
