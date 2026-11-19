using UnityEngine;
using UnityEngine.UI;

public class LanternChargeUI : MonoBehaviour
{
    [Header("Lantern Charge Settings")]
    [SerializeField] private Image chargeFill;
    [SerializeField] private LanternLightDirection lanternController;

    [Header("Charge Colors")]
    [SerializeField]
    private Color fullChargeColor =
        new Color(1f, 0.78f, 0.24f);

    [SerializeField]
    private Color lowChargeColor =
        new Color(1f, 0.4f, 0.1f);

    [SerializeField] private Color depletedColor = Color.gray;

    [Header("Charge Levels")]
    [SerializeField] private float maxCharge = 100f;
    [SerializeField] private float lowChargeThreshold = 25f;

    [Header("Drain Settings")]
    [SerializeField] private float drainRate = 1f;

    private float currentCharge = 100f;

    public float CurrentCharge => currentCharge;

    private void Start()
    {
        if (chargeFill == null || lanternController == null)
        {
            Debug.LogError(
                "Lantern Charge UI: Assign the Charge Fill and Lantern Controller!"
            );
            enabled = false;
            return;
        }

        if (maxCharge <= 0f || drainRate < 0f)
        {
            Debug.LogError("Invalid lantern charge settings!");
            enabled = false;
            return;
        }

        currentCharge = maxCharge;
        UpdateChargeUI();
    }

    private void Update()
    {
        // Drain charge while the lantern is on.
        if (lanternController.IsLanternOn && currentCharge > 0f)
        {
            currentCharge -= drainRate * Time.deltaTime;
            currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);

            UpdateChargeUI();

            // Turn off the lantern when charge reaches zero.
            if (currentCharge <= 0f)
            {
                lanternController.TurnOffLantern();
                Debug.Log("Lantern charge depleted!");
            }
        }
    }

    // Allows other gameplay systems to change lantern charge.
    public void SetCharge(float charge)
    {
        currentCharge = Mathf.Clamp(charge, 0f, maxCharge);
        UpdateChargeUI();

        Debug.Log("Lantern charge: " + currentCharge);

        if (currentCharge <= 0f && lanternController.IsLanternOn)
        {
            lanternController.TurnOffLantern();
        }
    }

    private void UpdateChargeUI()
    {
        float chargePercentage = currentCharge / maxCharge;

        chargeFill.fillAmount = chargePercentage;

        if (currentCharge <= 0f)
        {
            chargeFill.color = depletedColor;
        }
        else if (currentCharge <= lowChargeThreshold)
        {
            chargeFill.color = lowChargeColor;
        }
        else
        {
            chargeFill.color = fullChargeColor;
        }
    }
}