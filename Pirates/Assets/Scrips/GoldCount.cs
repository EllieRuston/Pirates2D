using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GoldCount : MonoBehaviour
{
    // count gold
    private int gold = 0;
    [SerializeField] private Text goldCount;
    [SerializeField] private AudioSource sGetGold;

    // event when we collide with gold
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            // sound effect
            sGetGold.Play();
            // increase gold count
            gold++;
            Debug.Log("Gold: " + gold);
            goldCount.text = "Gold : " + gold;
        }

        
    }
}
