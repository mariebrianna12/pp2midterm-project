using UnityEngine;

public class SymbolStoneInteraction : MonoBehaviour
{
    [SerializeField] private int currentSymbol = 0;

    private const int totalSymbols = 3;
    private bool playerInRange = false;

    public int CurrentSymbol => currentSymbol;

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CycleSymbol();
        }
    }

    private void CycleSymbol()
    {
        currentSymbol = (currentSymbol + 1) % totalSymbols;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            switch (currentSymbol)
            {
                case 0:
                    spriteRenderer.color = Color.gray;
                    break;

                case 1:
                    spriteRenderer.color = Color.cyan;
                    break;

                case 2:
                    spriteRenderer.color = Color.yellow;
                    break;
            }
        }

        Debug.Log(gameObject.name + " changed to symbol " + currentSymbol);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
