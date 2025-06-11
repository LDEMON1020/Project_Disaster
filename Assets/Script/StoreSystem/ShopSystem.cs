
using UnityEngine;


public class ShopSystem : MonoBehaviour
{
    public bool ShopOpened = false;

    public GameObject Shop;
    public GameObject ShopOpenButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ShopOpened)
        {
            ShopOpenedSystem();
        }
        if (!ShopOpened)
        {
            ShopOpenButton.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShopOpened = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShopOpened = false;
            ShopOpenButton.SetActive(false);
        }
    }

    void ShopOpenedSystem()
    {
        ShopOpenButton.SetActive(true);
    }
}
