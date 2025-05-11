using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;

    // Start is called before the first frame update
    void Start()
    {
        this.yasuoStats.ResetStats();
    }

    // Update is called once per frame
    void Update()
    {
    }
}