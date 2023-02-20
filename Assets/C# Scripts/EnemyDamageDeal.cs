using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDeal : MonoBehaviour
{
    [SerializeField] GameObject damageDealer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateDamageDealer()
    {
        damageDealer.SetActive(true);
    }

    public void DeactivateDamageDealer()
    {
        damageDealer.SetActive(false);
    }
}