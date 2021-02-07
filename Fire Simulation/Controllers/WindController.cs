using UnityEngine;
using UnityEngine.UI;

public class WindController : MonoBehaviour
{
    public static WindController instance;

    [SerializeField]
    private WindZone wind;
    [SerializeField]
    private Slider windStrengthSlider;
    [SerializeField]
    private Slider windDirectionSlider;
    [SerializeField]
    private Text windStrengthText;
    [SerializeField]
    private Text windDirectionText;

    public Slider WindStrengthSlider
    {
        get
        {
            return windStrengthSlider;
        }
    }

    public Slider WindDirectionSlider
    {
        get
        {
            return windDirectionSlider;
        }
    }

    float minWindStrength = 0f;
    float maxWindStrength = 100f;

    float minWindDirection = 0f;
    float maxWindDirection = 360f;

    void Awake()
    {
        instance = this;
    }

    public void ChangeWindStrength (float strength)
    {
        wind.windMain = strength;

        windStrengthText.text = strength.ToString();
    }

    public void ChangeWindDirection (float direction)
    {
        wind.gameObject.transform.rotation = Quaternion.Euler(0, direction, 0);

        windDirectionText.text = direction.ToString();
    }
}