using UnityEngine;
using UnityEngine.UI;

public class EmptyImage : MonoBehaviour
{
    [SerializeField]
    private Image Image;
    [SerializeField]
    private Sprite sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Image.sprite == null)
        {
            Image.sprite = sprite;
            Image.enabled = true;
        }
    }
}
