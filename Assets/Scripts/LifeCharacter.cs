using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCharacter : MonoBehaviour
{
    [SerializeField] private float vida;

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
    }
}
