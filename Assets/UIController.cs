using UnityEngine;

using Extism.Sdk;

using System;

using System.Text;
using UnityEngine.UI;
using System.IO;
using Extism.Sdk.Native;

public class UIController : MonoBehaviour
{
    public Text label;
    public InputField input;

    public void CountVowels()
    {
        var bytes = File.ReadAllBytes("count_vowels.wasm");

        using var plugin = Plugin.Create(bytes, Array.Empty<HostFunction>(), withWasi: true);

        var output = plugin.CallFunction("count_vowels", Encoding.UTF8.GetBytes(input.text)).ToArray();

        label.text = Encoding.UTF8.GetString(output);
    }
}
