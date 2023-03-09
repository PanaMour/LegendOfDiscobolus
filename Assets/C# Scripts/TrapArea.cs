using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapArea : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject medicine;
    public bool cabbageGiven = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.SetActive(true);
            health.SetActive(true);
            spawner.SetActive(true);
            trigger.SetActive(false);
            if(cabbageGiven)
            {
                medicine.SetActive(true);
            }
        }
    }
}
