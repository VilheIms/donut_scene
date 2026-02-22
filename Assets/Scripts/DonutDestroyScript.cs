using TMPro;
using UnityEngine;

public class DonutDestroyScript : MonoBehaviour
{
    SFX_Script sfx;
    public TMP_Text counterText;
    private int destroyedDonuts = 0;

   
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
            counterText.text = "Points:\n" + destroyedDonuts;
        }else if (collision.CompareTag("Danger"))
        {
            Destroy(collision.gameObject);

        }
        else
        {
            Destroy(collision.gameObject);
            destroyedDonuts++;

            counterText.text = "Points:\n " + (destroyedDonuts+5);
        }
    }
}
