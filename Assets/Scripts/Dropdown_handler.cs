using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dropdown_handler : MonoBehaviour
{
    public Text TextBox;
    public Text Solution;
    public Dropdown dropdown;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
    public Dropdown dropdown4;

    int DropdownItemSelected(Dropdown dropd)
    {
        int index = dropd.value;
        //TextBox.text = dropd.options[index].text;

        //if (dropd.options[index].text == "Ted (the son)")
        //{
        //    Solution.text = "Correct killer";
        //}

        //else if (dropd.options[index].text == "box cutter")
        //{
        //    Solution.text = "Correct weapon";
        //}

        if ((dropd.options[index].text == "Who?" || dropd.options[index].text == "What weapon?") ||
            (dropd.options[index].text == "What time?" || dropd.options[index].text == "Why?"))
        {
            Solution.text = "Select option (when all options are selected the message will be automatically sent).";
            TextBox.text = "Who is the killer?";
        }

        //else
        //{
        //    Solution.text = "Try again...";
        //}
        return index;
    }


    // Start is called before the first frame update
    void Update()
    {
        //var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();
        dropdown2.options.Clear();
        dropdown3.options.Clear();
        dropdown4.options.Clear();
        List<string> items = new List<string>() { "Who?", "Ted (the son)", "Mr. Strauss (the dad)", "Lucia (the housekeper)" };
        List<string> weapons = new List<string>() { "What weapon?", "knife", "broken bottle", "box cutter", "hammer", "gun" };
        List<string> times = new List<string>() { "what time?", "15:30", "16:30", "17:30", "18:30", "19:30", "20:30", "21:30", "22:30" };
        List<string> reasons = new List<string>() {  "Why?", 
            "He/She wanted something she had", 
            "He/she wanted to take over the family's company", 
            "He/She didn´t want to be discovered",
            "He/She despised her",
            "He/She didn't want to kill her. It was an accident" };

        //Fill dropdown with options
        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        foreach (var item in weapons)
        {
            dropdown2.options.Add(new Dropdown.OptionData() { text = item });
        }

        foreach (var item in times)
        {
            dropdown3.options.Add(new Dropdown.OptionData() { text = item });
        }

        foreach (var item in reasons)
        {
            dropdown4.options.Add(new Dropdown.OptionData() { text = item });
        }

        int name = DropdownItemSelected(dropdown);
        int weapon = DropdownItemSelected(dropdown2);
        int time = DropdownItemSelected(dropdown3);
        int reason = DropdownItemSelected(dropdown4);

        //Adds a listener to the main input field and invokes a method when the value changes.
        //dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
        //dropdown2.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown2); });

        Debug.Log(name);
        Debug.Log(weapon);
        Debug.Log(time);
        Debug.Log(reason);

        if (name != 0 && weapon != 0 && time != 0 && reason != 0)
        {
            if (name == 1 && weapon == 3 && time == 4 && reason == 4)
            {
                TextBox.text = "";
                Solution.text = "This is correct! You have caught the killer"; // Instead change to new screen
            }
            else
            {
                TextBox.text = "";
                Solution.text = "The killer got away, you have lost";
            }
        }

        //dropdown.onValueChanged.AddListener( new UnityAction<int>(indexer =>
        //{
        //       PlayerPrefs.SentInt(PrefName, dropdown.value);
        //       PlayerPrefs.Save();
        //}));

        //dropdown2.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        //{
        //    PlayerPrefs.SentInt(PrefName2, dropdown2.value);
        //    PlayerPrefs.Save();
        //}));

        //void Start()
        //{
        //    dropdown.value = PlayerPrefs.GetInt(PrefName);
        //    dropdown2.value = PlayerPrefs.GetInt(PrefName2);
        //    Debug.Log(dropdown.value, dropdown2.value);
        //}

    }
}
    
