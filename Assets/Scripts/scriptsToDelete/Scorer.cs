using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scorer : MonoBehaviour
{
    private Text score;
    public static int have;
    public static int need;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        have = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Rats: " + have + " / " + need;
    }
}
