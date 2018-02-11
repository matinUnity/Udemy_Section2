using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hacker_2 : MonoBehaviour {

    int level;
    enum Screen { MainMenu, CheckWord, Win };
    Screen currentScreen;
    const string menuHint = "(Type R to Return to main menu.)";
    const string QuitGame = "Pres CTRL+p to quit the game.";
    string[] Planets = {"Mercury","Venus" ,"Mars","Jupiter", "Saturn", "Uranus", "Neptune" };
    string[] Dinosaurs = { "Abelisaurus", "Albertosaurus", "Allosaurus", "Ankylosaurus" , "Apatosaurus", "Minmi" };
    string pass;

    //public TextAsset imageTA;
    Texture2D myTexture;

   

    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();
	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Type 1 for Planets / easy");
        Terminal.WriteLine("Type 2 for Dinosaurs / difficult");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "R" || input =="r") // we can always go back to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.CheckWord)
        {
            CheckWord(input);
        }
    }

    void CheckWord(string input)
    {
        if (input == pass)
        {
            DisplayWinScreen();
        }
        else
        {
            DisplayFailScreen();
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2");
        if (isValidNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Sorry! You can just press 1 Or 2");
            //Terminal.WriteLine("To quit at any level press CTRL+P");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.CheckWord;
        Terminal.ClearScreen();
        SetRandomWord();
        Terminal.WriteLine("Enter the correct word, Hint: " + pass.Anagram());
        Terminal.WriteLine(menuHint);

    }

    private void SetRandomWord()
    {
        switch (level)
        {
            case 1:
                pass = Planets[Random.Range(0, Planets.Length)];
                break;
            case 2:
                pass = Dinosaurs[Random.Range(0, Dinosaurs.Length)];
                break;
            default:
                Debug.LogError("You did not choose a valid area!");
                break;
        }
    }

    void DisplayWinScreen()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Well Done!");
                //Texture2D text = new Texture2D(4, 4);

                myTexture = Resources.Load("mars") as Texture2D;
                GameObject rawImage = GameObject.Find("RawImage");
                rawImage.GetComponent<RawImage>().texture = myTexture;
                
               // print("Load the image");
                //text.LoadImage(imageTA.bytes);
                //Renderer renderer = GetComponent<Renderer>();
                //renderer.material.mainTexture = text; 
                break;

            case 2:
                Terminal.WriteLine("Well Done!");
                break;

            default:
                Debug.LogError("Invalid!");
                break; 
        }

    }
  

    void DisplayFailScreen()
    {
        Terminal.WriteLine("Sorry! incorrect word.");
        Terminal.WriteLine("Try again Or Type R to go back to the menu");
        //Terminal.WriteLine(menuHint);
    }

   

}
