
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    float moveSpeed = 2f;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI HPText;

    public Slider Stamina;
    public float MaxStamina = 50f;
    public float CurrentStamina;

    public bool Running = false;

    public float score;
    public int coin;
    public int HP;



    public int cheatAmount = 100;

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
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentStamina = MaxStamina;
        HP = 2;
        UpdateStaminaUI();
    }

    // Update is called once per frame
   private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        coin = GameDataManager.Instance.playerData.Coin;

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
       
        if(HP<=0)
        {
            SceneManager.LoadScene("GameOver");
            GameDataManager.Instance.PlayerDead();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            coin += cheatAmount;
            GameDataManager.Instance.playerData.Coin = coin;  // 저장소 업데이트
            GameDataManager.Instance.SaveData();  // 저장
            Debug.Log("치트 적용! 코인 + " + cheatAmount + " 현재 코인: " + coin);
        }
        if (Running == false)
        {
            moveSpeed = 2f;
        }


        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 0)
        {
            Running = true;
            moveSpeed = 3f;
            CurrentStamina -= Time.deltaTime * 10f;  // 초당 10씩 감소
            CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
            UpdateStaminaUI();
        }
        else
        {
            Running = false;
            moveSpeed = 2f;

            // 가만히 있을 때 회복
            if (input == Vector2.zero && CurrentStamina < MaxStamina)
            {
                CurrentStamina += Time.deltaTime * 5f;
                CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
                UpdateStaminaUI();
            }
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

            GameDataManager.Instance.playerData.Coin = coin;

            GameDataManager.Instance.SaveData();
        }
        if (collision.CompareTag("Disaster"))
        {
            HP--;
        }
    }

    void UpdateStaminaUI()
    {
        if (Stamina != null)
            Stamina.value = CurrentStamina;
    }

    void GameOver()     //게임 오버 구현 필요
    {

    }

}
