using System.Collections;
using UnityEngine;

public class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;
    
    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }
    public virtual int Cost()
    {
        return coffee.Cost();
    }

    public virtual string Description()
    {
        return coffee.Description();
    }
}