using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DonutDestroyScript : MonoBehaviour
{
    SFX_Script sfx;
    public TMP_Text counterText;
    public TMP_Text life;
    public GameObject Switch;
    public Toggle toggle;
    private int destroyedDonuts;
    private int Life = 3;
    public MissedDonutsScript missedDonutsScript;
 
    void Start()
    {
      sfx = FindFirstObjectByType<SFX_Script>();
    }
    public void timerPause()
    {
        if(toggle.isOn == false)
        {
            GetComponent<TimerScript>().StopStopwatch();
        }
        else if (toggle.isOn == true)
        {
            GetComponent<TimerScript>().ResetStopwatch();
            GetComponent<TimerScript>().StartStopwatch();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts++;
            sfx.PlaySFX(3);
            counterText.text = "Points: " + destroyedDonuts;
        }
        else if (collision.CompareTag("Danger"))
        {
            Destroy(collision.gameObject);
            Life--;
            sfx.PlaySFX(2);
            life.text = "Life: " + Life;
        }
        else if (collision.CompareTag("Special"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts = destroyedDonuts + 5;
            sfx.PlaySFX(3);
            counterText.text = "Points: " + destroyedDonuts;
        }

        if (Life == 0)
        {
            
            toggle.isOn = false;
            Life = 3;
            destroyedDonuts = 0;
            missedDonutsScript.missedDonuts = 0;
            life.text = "Life: " + Life;
            counterText.text = "Points: " + destroyedDonuts;
            missedDonutsScript.counterText.text = "Missed donuts: " + missedDonutsScript.missedDonuts;
            Switch.SetActive(true);
        }
    }
}
