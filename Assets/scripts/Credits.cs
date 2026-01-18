using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Endscreen : MonoBehaviour
{
    [SerializeField] private GameObject names;
    [SerializeField] private float scrollSpeed = 3f;

    [SerializeField] private GameObject thanks;
    [SerializeField] private GameObject gameTitle;
    private float _counter;

    private void Awake()
    {
        gameTitle.SetActive(false);
        _counter = 0;
  
    }
    void Update()
    {
        _counter += Time.deltaTime;
        ScrollingText();
        TextPlop();
    }
    void TextPlop()
    {
        if (_counter > 3f)
        {

            gameTitle.SetActive(true);
            thanks.SetActive(false);
        }    
    }
    void ScrollingText()
    {
        names.transform.position += new Vector3(0, scrollSpeed, 0);
    }
}
