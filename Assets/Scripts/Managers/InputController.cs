using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class InputController
{
    private static Dictionary<GameInputs, KeyCode> inputs;

    public static void Initialize()
    {
        inputs = new Dictionary<GameInputs, KeyCode>();
        TextAsset jsonInputs = Resources.Load<TextAsset>(JsonPath.INPUT_PATH);
        Dictionary<string, string> dictionaryInputs = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonInputs.text);

        foreach (KeyValuePair<string, string> input in dictionaryInputs)
        {
            GameInputs gameInput = (GameInputs) Enum.Parse(typeof(GameInputs), input.Key);
            KeyCode keyCode = (KeyCode) Enum.Parse(typeof(KeyCode), input.Value);
            inputs.Add( gameInput, keyCode);
        }
    }

    public static bool GetKeyDown(GameInputs gameInput)
    {
        return Input.GetKeyDown(inputs[gameInput]);
    }
    
    public static bool GetKeyUp(GameInputs gameInput)
    {
        return Input.GetKeyUp(inputs[gameInput]);
    }
    
    public static bool GetKey(GameInputs gameInput)
    {
        return Input.GetKey(inputs[gameInput]);
    }
}

public enum GameInputs
{
    Forward,
    Backward,
    Left,
    Right,
    Fire
}