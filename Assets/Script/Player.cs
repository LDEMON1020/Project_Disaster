
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    float moveSpeed = 2f;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI HPText;
    public GameObject GameOverPanel;

    public float score;
    public float coin;
    public int HP;

    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;

    Rigidbody2D rb;
    SpriteRenderer sR;

    Vector2 input;
    Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        score = 0f;
        coin = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        HP = 2;
    }

    // Update is called once per frame
   private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        velocity = input.normalized * moveSpeed;

        if(input.sqrMagnitude > .01f)
        {
            if(Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                    sR.sprite = spriteRight;
                else if (input.x < 0)
                    sR.sprite = spriteLeft;
            }
            else
            {
                if (input.y > 0)
                    sR.sprite = spriteUp;
                else
                    sR.sprite = spriteDown;
            }
        }
        ScoreText.text = "Score : " + score;
        CoinText.text = "Coin : " + coin;
        HPText.text = "HP : " + HP;
       
        if(HP==0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            ItemObject item = collision.GetComponent<ItemObject>();


            score += collision.GetComponent<ItemObject>().GetPoint();
            coin += collision.GetComponent<ItemObject>().GetCoin();

            ScoreText.text = score.ToString();
            Destroy(collision.gameObject);

            //GameDataManager.Instance.SaveData(GameDataManager.Instance.playerData);
        }
        if (collision.CompareTag("Disaster"))
        {
            HP--;
        }
    }

    void GameOver()     //게임 오버 구현 필요
    {

    }

}
