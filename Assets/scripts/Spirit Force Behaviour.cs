using Microsoft.Win32.SafeHandles;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpiritForceBehaviour : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] public TMP_Text spiritForceCounter;
    [SerializeField] public GameObject slider;
    [SerializeField] public float currentForce = 100f;
    PlayerMovement playerMovement;
    
    public string Level = "";
    public string Level1 = "Snow";
    public string Level2 = "Mountain";
    public string Level3 = "Forest";
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        
        currentForce -= Time.deltaTime;

        if((playerMovement.shouldZoom) && (playerMovement.zoomed == false))
            {
            audioManager.PlayMusic(audioManager.SnowStage2, 0f);
            audioManager.PlayMusic(audioManager.SnowStage3, 0f);
            audioManager.PlayMusic(audioManager.SnowStage1, 0f);
             if (currentForce >= 95 && currentForce <= 105)
            {
            audioManager.PlayMusic(audioManager.ForrestStage2, 1f);
            audioManager.PlayMusic(audioManager.ForrestStage3, 0f);
            audioManager.PlayMusic(audioManager.ForrestStage1, 0f);
            }
            if (currentForce < 95)
            {
                audioManager.PlayMusic(audioManager.ForrestStage2, 0f);
            audioManager.PlayMusic(audioManager.ForrestStage3, 1f);
            audioManager.PlayMusic(audioManager.ForrestStage1, 0f);
            }
            if (currentForce > 105)
            {
                audioManager.PlayMusic(audioManager.ForrestStage2, 0f);
            audioManager.PlayMusic(audioManager.ForrestStage3, 0f);
            audioManager.PlayMusic(audioManager.ForrestStage1, 1f);
                }
            }
        if ((playerMovement.zoomed) && (playerMovement.shouldZoom == true))
            {
                audioManager.PlayMusic(audioManager.ForrestStage2, 0f);
                audioManager.PlayMusic(audioManager.ForrestStage3, 0f);
                audioManager.PlayMusic(audioManager.ForrestStage1, 0f);
                if (currentForce >= 95 && currentForce <= 105)
                    {
                    audioManager.PlayMusic(audioManager.MountainStage2, 1f);
                    audioManager.PlayMusic(audioManager.MountainStage3, 0f);
                    audioManager.PlayMusic(audioManager.MountainStage1, 0f);
                }
                if (currentForce < 95)
                {
                    audioManager.PlayMusic(audioManager.MountainStage2, 0f);
                    audioManager.PlayMusic(audioManager.MountainStage3, 1f);
                    audioManager.PlayMusic(audioManager.MountainStage1, 0f);
                }
                if (currentForce > 105)
                {
                    audioManager.PlayMusic(audioManager.MountainStage2, 0f);
                    audioManager.PlayMusic(audioManager.MountainStage3, 0f);
                    audioManager.PlayMusic(audioManager.MountainStage1, 1f);
                    }            
            }
        else
            {
                if (currentForce >= 95 && currentForce <= 105)
                {
                    audioManager.PlayMusic(audioManager.SnowStage2, 1f);
                    audioManager.PlayMusic(audioManager.SnowStage3, 0f);
                    audioManager.PlayMusic(audioManager.SnowStage1, 0f);
                }
                if (currentForce < 95)
                {
                    audioManager.PlayMusic(audioManager.SnowStage2, 0f);
                    audioManager.PlayMusic(audioManager.SnowStage3, 1f);
                    audioManager.PlayMusic(audioManager.SnowStage1, 0f);
                }
                if (currentForce > 105)
                {
                    audioManager.PlayMusic(audioManager.SnowStage2, 0f);
                    audioManager.PlayMusic(audioManager.SnowStage3, 0f);
                    audioManager.PlayMusic(audioManager.SnowStage1, 1f);
                }
        }   
    
    if (currentForce <= 90)
        {
           SceneManager.LoadScene(3);
        }
        if (currentForce > 110 )
        {
            SceneManager.LoadScene(3);
        }

        slider.transform.localPosition = new Vector3((currentForce -100) * 17, slider.transform.localPosition.y, slider.transform.localPosition.z);
        spiritForceCounter.text = Mathf.CeilToInt(currentForce).ToString();

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Destroy(collision.gameObject);
            currentForce += 2.5f;

        }
    }
}

