using TMPro;
using UnityEngine;

public class SpiritForceBehaviour : MonoBehaviour
{
    [SerializeField] public TMP_Text spiritForceCounter;
    [SerializeField] public GameObject slider;
    [SerializeField] public float currentForce = 100f;
    void Update()
    {
        currentForce -= Time.deltaTime;
        if (currentForce <= 90)
        {
            Destroy(gameObject);
        }
        if (currentForce > 110 )
        {
            Destroy(gameObject);
        }

        slider.transform.localPosition = new Vector3((currentForce -100) * 17, slider.transform.localPosition.y, slider.transform.localPosition.z);
        spiritForceCounter.text = Mathf.CeilToInt(currentForce).ToString();

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpiritForce"))
        {
            // Implement the desired behavior when colliding with SpiritForce
            Debug.Log("Collided with SpiritForce!");
            currentForce += 1;
        }
    } 
}
