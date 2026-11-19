using UnityEngine;

public class LanternLightDirection : MonoBehaviour
{
    [Header("Lantern Settings")]
    [SerializeField] private GameObject lanternLight;
    [SerializeField] private LanternChargeUI chargeUI;
    [SerializeField] private KeyCode toggleKey = KeyCode.F;

    private bool lanternIsOn = true;

    public bool IsLanternOn => lanternIsOn;

    private void Start()
    {
        if (lanternLight == null || chargeUI == null)
        {
            Debug.LogError("Assign the Lantern Light and Charge UI!");
            enabled = false;
            return;
        }

        lanternLight.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleLantern();
        }

        if (Input.GetKeyDown(KeyCode.W))
            lanternLight.transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.S))
            lanternLight.transform.localRotation = Quaternion.Euler(0, 0, 180);

        if (Input.GetKeyDown(KeyCode.A))
            lanternLight.transform.localRotation = Quaternion.Euler(0, 0, 90);

        if (Input.GetKeyDown(KeyCode.D))
            lanternLight.transform.localRotation = Quaternion.Euler(0, 0, 270);
    }

    public void ToggleLantern()
    {
        // Prevent the lantern from turning on with zero charge.
        if (!lanternIsOn && chargeUI.CurrentCharge <= 0f)
        {
            Debug.Log("Cannot turn on lantern: No charge remaining!");
            return;
        }

        lanternIsOn = !lanternIsOn;
        lanternLight.SetActive(lanternIsOn);

        Debug.Log("Lantern is " + (lanternIsOn ? "ON" : "OFF"));
    }

    public void TurnOffLantern()
    {
        lanternIsOn = false;
        lanternLight.SetActive(false);

        Debug.Log("Lantern turned off.");
    }
}