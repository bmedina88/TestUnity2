using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCharacter : MonoBehaviour
{
    [SerializeField] private float vida;

    public void TomarDaño(float daño)
    {
        vida -= daño;
    }
}
