using UnityEngine;

public class Habit
{
    string name;
    int interval;


    public Habit(string name, int interval)
    {
        this.name = name;
        this.interval = interval;
    }


    public string GetName()
    {
        return name;
    }

    public int GetInterval()
    {
        return interval;
    }
}
