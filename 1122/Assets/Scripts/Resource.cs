using UnityEngine;

[CreateAssetMenu(fileName = "NewGoldData", menuName = "Gold Data")]
public class Resource : ScriptableObject
{
    private int currentAmount = 1000;
    public int CurrentAmount {
        get { return currentAmount; }
        set { currentAmount = value; 
        onGoldAmountChanged.RaiseEvent(); 
        }
    }
    public GameEvent onGoldAmountChanged;

    public void ReduceAmount(int amountToReduce)
    {
        if (currentAmount >= amountToReduce)
        {
            currentAmount -= amountToReduce;
            CurrentAmount = currentAmount; 
        }
    }
    public void IncreaseAmount(int amountToAdd)
    {
        currentAmount += amountToAdd;
        CurrentAmount = currentAmount; 
    }
}