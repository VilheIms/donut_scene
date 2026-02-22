using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DonutDestroyScript : MonoBehaviour
{
    SFX_Script sfx;
    public TMP_Text counterText;
    public TMP_Text life;
    private int destroyedDonuts = 0;
    private int Life = 3;

   
    void Start()
    {
      sfx = FindFirstObjectByType<SFX_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts++;
            sfx.PlaySFX(3);
            counterText.text = "Points: " + destroyedDonuts;
        }else if (collision.CompareTag("Danger"))
        {
            Destroy(collision.gameObject);
            Life--;
            sfx.PlaySFX(2);
            life.text = "Life: " + Life;
        }
        else if (collision.CompareTag("Special"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts = destroyedDonuts+5;
            sfx.PlaySFX(3);
            counterText.text = "Points: " + destroyedDonuts;
        }

        if(Life == 0)
        {
            Life = 3;
            destroyedDonuts = 0;
            life.text = "Life: " + Life;
            counterText.text = "Points: " + destroyedDonuts;
        }
    }
}
