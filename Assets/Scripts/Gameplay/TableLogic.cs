using UnityEngine;

public class TableLogic : MonoBehaviour
{
    public int maxDurability = 100;
    public int durability = 100;
    public float durabilityDecreaseRate = 1f;
    public float breakThreshold = 0f;
    public float durabilityDecreaseInterval = 0.1f;

    private Color originalColor;
    private Renderer tableRenderer;
    private bool ballOnTable = false;
    private float decreaseTimer = 0f;


    private void OnEnable()
    {
        EventManager.TableRepairCollected += RepairTable;
    }

    private void OnDisable()
    {
        EventManager.TableRepairCollected -= RepairTable;
    }

    void Start()
    {
        tableRenderer = GetComponent<Renderer>();
        originalColor = tableRenderer.material.color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballOnTable = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballOnTable = false;
        }
    }

    void Update()
    {
        if (ballOnTable)
        {
            decreaseTimer += Time.deltaTime;
            if (decreaseTimer >= durabilityDecreaseInterval)
            {
                decreaseTimer -= durabilityDecreaseInterval;
                DecreaseDurability();
            }
            UpdateTableColor();
        }
    }

    void DecreaseDurability()
    {
        durability -= (int)durabilityDecreaseRate;
        if (durability <= breakThreshold)
        {
            Destroy(gameObject);
        }
    }

    void UpdateTableColor()
    {
        float darknessFactor = 1f - ((float)durability / maxDurability);
        darknessFactor = Mathf.Clamp01(darknessFactor);
        Color lerpedColor = Color.Lerp(originalColor, Color.black, darknessFactor);
        tableRenderer.material.color = lerpedColor;
    }

    public void RepairTable()
    {
        durability = maxDurability;
        UpdateTableColor();
    }
}
