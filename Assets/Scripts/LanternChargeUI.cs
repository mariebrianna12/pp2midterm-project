using UnityEngine;
using UnityEngine.UI;


public class LanternChargeUI : MonoBehaviour
{
    // Reference to the UI image that displays the lantern's charge.
    [Header("Lantern Charge Settings")]
    [SerializeField] private Image chargeFill;

    // Colors used to show the lantern's current charge level.
    [Header("Charge Colors")]
    [SerializeField]
    private Color fullChargeColor =
        new Color(1f, 0.78f, 0.24f);

    [SerializeField]
    private Color lowChargeColor =
        new Color(1f, 0.4f, 0.1f);

    [SerializeField] private Color depletedColor = Color.gray;

    // Maximum lantern charge and the point where the low-charge warning begins.
    [Header("Charge Levels")]
    [SerializeField] private float maxCharge = 100f;
    [SerializeField] private float lowChargeThreshold = 25f;

    // Stores the lantern's current charge.
    private float currentCharge = 100f;

    // Runs once when the game starts.
    private void Start()
    {
        // Check that the charge fill image is assigned in the Inspector.
        if (chargeFill == null)
        {
            Debug.LogError("Lantern Charge UI: Charge Fill is not assigned!");
            enabled = false;
            return;
        }

        // Make sure the maximum charge is greater than zero.
        if (maxCharge <= 0f)
        {
            Debug.LogError("Lantern Charge UI: Max Charge must be greater than zero!");
            enabled = false;
            return;
        }

        // Display the initial full-charge state.
        UpdateChargeUI();
    }

    // Checks for keyboard input during testing.
    private void Update()
    {
        // Press 1 to test full charge.
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetCharge(100f);

        // Press 2 to test half charge.
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetCharge(50f);

        // Press 3 to test low charge.
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetCharge(20f);

        // Press 4 to test depleted charge.
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetCharge(0f);
    }

    // Changes the current charge and updates the UI.
    public void SetCharge(float charge)
    {
        // Keeps the charge between zero and the maximum value.
        currentCharge = Mathf.Clamp(charge, 0f, maxCharge);

        // Displays the current charge in the Unity Console.
        Debug.Log("Lantern charge: " + currentCharge);

        // Refreshes the charge bar.
        UpdateChargeUI();
    }

    // Updates the fill amount and color of the charge indicator.
    private void UpdateChargeUI()
    {
        // Converts the current charge into a percentage.
        float chargePercentage = currentCharge / maxCharge;

        // Updates how much of the charge bar is filled.
        chargeFill.fillAmount = chargePercentage;

        // Changes the bar color based on the remaining charge.
        if (currentCharge <= 0f)
        {
            // Gray indicates that the lantern is depleted.
            chargeFill.color = depletedColor;
        }
        else if (currentCharge <= lowChargeThreshold)
        {
            // Orange warns the player that charge is running low.
            chargeFill.color = lowChargeColor;
        }
        else
        {
            // Golden yellow indicates normal charge.
            chargeFill.color = fullChargeColor;
        }
    }
}