using System.Collections;
using UnityEngine;

public class Latte : ICoffee
{
    public int Cost()
    {
        return 5000;
    }

    public string Description()
    {
        return "Latte";
    }
}