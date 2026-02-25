using TMPro;
using UnityEngine;

public class MissedDonutsScript : MonoBehaviour
{
    SFX_Script sfx;
    public TMP_Text counterText;
    public int missedDonuts = 0;


    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            Destroy(collision.gameObject);
            missedDonuts++;
            sfx.PlaySFX(4);
            counterText.text = "Donuts missed:\n" + missedDonuts;
        }
    }
}
