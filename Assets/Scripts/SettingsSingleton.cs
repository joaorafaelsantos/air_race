using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Pattern
public class SettingsSingleton
{
    private static SettingsSingleton instance;

    private SettingsSingleton() { }

    public static SettingsSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SettingsSingleton();
            }
            return instance;
        }
    }

    public int sound { get; set; }

    public int plane { get; set; }


}
