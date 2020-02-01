using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int playerMax = 4;
    private static int playerMin = 2;

    private static int maxCountBal = 2;

    public static int PlayerCount { get; set; }
    public static int PlayerMax => playerMax;
    public static int PlayerMin => playerMin;
    public static int MaxCountBal => maxCountBal;
}
