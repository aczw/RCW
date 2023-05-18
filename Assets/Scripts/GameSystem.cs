using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }
    
    public RoundTimer Timer { get; private set; }
    public RoundProperty Property { get; private set; }
    
    public ColorData CurrText { get; private set; }
    public ColorData CurrColor { get; private set; }
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;
    
    public bool Reverse { get; private set; } = false;

    private void WinRound()
    {
        Score += 100;
        PrepareNextRound();
    }

    private void LoseRound()
    {
        Score -= 100;
        Lives -= 1;
        PrepareNextRound();
    }

    private void PrepareNextRound()
    {
        (CurrText, CurrColor) = Property.ChooseColors();
        Timer.Reset();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Timer = GetComponent<RoundTimer>();
        Property = new RoundProperty();
    }

    private void Start()
    {
        //(CurrText, CurrColor) = RoundProperty.ChooseColors();
        
        PrepareNextRound();
        var correct = 0;
        var incorrect = 0;
        
        for (var i = 0; i < 100000; i++)
        {
            var match = CurrText.Equals(CurrColor);
            
            
            // always press right key (color matches text)
            if (match)
            {
                WinRound();
                correct += 1;
            }
            else
            {
                LoseRound();
                incorrect += 1;
            }
        }
        
        Debug.Log("correct: " + correct);
        Debug.Log("incorrect: " + incorrect);
    }

    private void Update()
    {
        var match = CurrText.Equals(CurrColor);

        if (Timer.CurrTime <= 0.0f)
        {
            LoseRound();
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (match)
            {
                WinRound();
            }
            else
            {
                LoseRound();
            }
        } else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (match)
            {
                LoseRound();
            }
            else
            {
                WinRound();
            }
        }
    }
}
