/// <summary>
/// Assignment-klasse
/// Denne klasse skal kunne lave og rette opgaver.
/// Den skal samtidig styre progressionen og sværhedsgraden i opgaverne
/// </summary>

using UnityEngine; // TODO: Fjern denne og nedarvningen, når koden er done

public class Assignment : MonoBehaviour {
    // TODO: Slet region
    #region SHIT
    
    // Constructor med en given sværhedsgrad til opgaverne
    Assignment(Difficulty difficulty)
    {
        correctAnswers = 0;
        correctAnswersInARow = 0;
        diff = difficulty;
    }

    // Default constructor
    Assignment()
    {
        correctAnswers = 0;
        correctAnswersInARow = 0;
        diff = Difficulty.INTRODUCTION;
    }

    // Angiver antal korrekte svar
    public int correctAnswers;

    // Angiver hvilken orden, som funktioner er, fx en 2. ordens ligning, dvs. en parabel
    private int orderOfFunc;

    // Angiver brugerens nuværende ekspertiseniveau
    private Difficulty diff;

    // Antal rigtige svar i streg
    private int correctAnswersInARow;

    // Det korrekte svar til den nuværende opgave
    private string correctAnswer;

    private bool HasExtrema()
    {
        switch (orderOfFunc)
        {
            // Case 0 er en nultegradsligning, fx f(x)=5x^0=5, dvs. en ret linje uden hældning
            case 0:
                break;
            // Case 1 er en 1. grads ligning, fx f(x)=3x^1-5x^0, dvs. en ret linje med en hældning
            case 1:
                break;
            // Case 2 er en 2. grads ligning, fx f(x)=x^2-3x^1-5x^0, dvs. en parabel
            case 2:
                return true;
            // Case 3 er en 3. grads ligning, fx f(x)=4x^3-x^2-3x^1-5x^0. Måske slet, fordi return type er en float...
            case 3:
                return true;
        }
        return false;
    }

    // Kan beregne ekstremumspunktet, dvs. top- eller minimumspunkt
    // string function er den givne funktion
    private float CalculateExtrema(string function, char axis)
    {
        int[] pos = new int[9];
        DetermineVarPos(function, ref pos);
        string ledA = "";
        string ledB = "";
        string ledC = "";
        string fortegnA = "";
        string fortegnB = "";
        string fortegnC = "";

        if (HasExtrema())
        {
            // Starter med en 2. grads funktion
            if (axis == 'x')
            {
                if (function[0] == '+' || function[0] == '-')
                {
                    fortegnA = function[0].ToString();
                }
                for (int i = 0; i < pos[0]; i++)
                {
                    ledA += function[i];
                }
                fortegnB = function[pos[0] + 3].ToString();
                for (int i = pos[0]/*2*/; i < pos[1]/*8*/ - 4; i++)
                {
                    ledB += function[i + 4];
                }
                float a = System.Int32.Parse(fortegnA + ledA);
                float b = System.Int32.Parse(fortegnB + ledB);
                float res = (-b) / (2 * a);
                return res;
            }
            else if (axis == 'y')
            {
                if (function[0] == '+' || function[0] == '-')
                {
                    fortegnA = function[0].ToString();
                }
                for (int i = 0; i < pos[0]; i++)
                {
                    ledA += function[i];
                }
                for (int i = pos[0]/*2*/; i < pos[1]/*8*/ - 4; i++)
                {
                    ledB += function[i + 4];
                }
                fortegnB = function[pos[0] + 3].ToString();
                for (int i = pos[1]/*2*/; i < pos[2]/*8*/ - 4; i++)
                {
                    ledC += function[i + 4];
                }
                fortegnC = function[pos[1] + 3].ToString();
                float a = System.Int32.Parse(fortegnA + ledA);
                float b = System.Int32.Parse(fortegnB + ledB);
                float c = System.Int32.Parse(fortegnC + ledC);
                float disk = -(b * b - 4 * a * c);
                float res = disk / (4 * a);
                return res;
            }
        }
        return -1.0003f;
    }

    // Funktion, der kan opstille de forudinstillede opgaver, som brugeren
    // vil møde i repetitionsniveauet i spillet, dvs. det er undervisnings-
    // forløbet
    public void Introduction()
    {

        int tasksComplete = 0;
        string task = "";
        switch (tasksComplete)
        {
            case 0:
                correctAnswer = Differentiate(task);
                Correct("User input");
                break;
            case 1:
                correctAnswer = Differentiate("5x^0");
                Correct("User input");
                break;
            case 2:
                break;
            case 3:
                correctAnswer = Differentiate("2x^1+3x^0");
                Correct("User input");
                break;
            case 4:
                correctAnswer = Differentiate("x^2+3x^1-4x^0");
                Correct("User input");
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
        }
    }

    // Kan generere opgaver til brugeren, og opgaverne kan stige/falde i sværhedsgrad afhængig
    // af brugerens ekspertise
    public void Create()
    {
        switch(diff)
        {
            case Difficulty.INTRODUCTION:
                Introduction();
                break;
            case Difficulty.EASY:
                break;
            case Difficulty.MEDIUM:
                break;
            case Difficulty.HARD:
                break;
            case Difficulty.INSANE:
                break;
        }
    }

    // Retter brugerens opgave og kan ændre i visse parametre, som kan ændre
    // i sværhedsgraden i opgaverne
    public void Correct(string function)
    {
        if (IsUserCorrect(function))
        {
            correctAnswers++;
            correctAnswersInARow++;
        }
        else
        {
            correctAnswersInARow = 0;
        }
    }

    // Angiver forskellige sværhedsgrader i opgaverne
    public enum Difficulty
    {
        INTRODUCTION,
        EASY,
        MEDIUM,
        HARD,
        INSANE
    };

    // Kan hæve/sænke opgavernes sværhedsgrad
    // bool lowerDifficulty angiver, hvor vidt sværhedsgraden skal hæves eller sænkes
    private void ChangeDifficulty(bool lowerDifficulty)
    {
        if(lowerDifficulty)
        {
            DecreaseDifficulty(diff);
        }
        else
        {
            IncreaseDifficulty(diff);
        }
    }

    // Hæver sværhedsgraden af opgaverne
    private void IncreaseDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.INTRODUCTION:
                diff = Difficulty.EASY;
                break;
            case Difficulty.EASY:
                diff = Difficulty.MEDIUM;
                break;
            case Difficulty.MEDIUM:
                diff = Difficulty.HARD;
                break;
            case Difficulty.HARD:
                diff = Difficulty.INSANE;
                break;
            case Difficulty.INSANE:
                diff = Difficulty.INSANE;
                break;
        }
    }

    // Sænker sværhedsgraden af opgaverne
    private void DecreaseDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.INTRODUCTION:
                diff = Difficulty.INTRODUCTION;
                break;
            case Difficulty.EASY:
                diff = Difficulty.EASY;
                break;
            case Difficulty.MEDIUM:
                diff = Difficulty.EASY;
                break;
            case Difficulty.HARD:
                diff = Difficulty.MEDIUM;
                break;
            case Difficulty.INSANE:
                diff = Difficulty.HARD;
                break;
        }
    }

    // Tjekker, om brugerens svar er korrekt
    // string function er brugerens svar
    private bool IsUserCorrect(string function) { return function == correctAnswer; }

    // Bestemmer de indeks, som indeholder 'x' i en tekststreng og gemmer det i et array
    // string function er den givne tekststreng / funktion
    // ref int[] pos er array, og det er givet som reference, dvs. man ændrer i den værdi, man giver ind i funktionen
    // ref int count er antallet af gange, 'x' blev fundet i tekststrengen
    private void DetermineVarPos(string function, ref int[] pos, ref int count)
    {
        // Gør, så array har størrelse på 9 ints
        pos = new int[9];
        orderOfFunc = -1;

        // Søg efter bogstavet 'x' i funktionsforskriften og gem i pos-array
        for (int i = 0; i < function.Length; i++)
        {
            if (function[i] == 'x')
            {
                pos[count] = i;
                count++;
            }
        }
        // Sætter klassevariablen orderOfFunc lig antallet af x'er fundet.
        // Det gør, at man igennem hele klassen kan se, hvilken orden, funktionen er i
        // TODO: Er det her nødvendigt?
        orderOfFunc = count;
    }

    // Bestemmer de indeks, som indeholder 'x' i en tekststreng og gemmer det i et array
    // string function er den givne tekststreng / funktion
    // ref int[] pos er array, og det er givet som reference, dvs. man ændrer i den værdi, man giver ind i funktionen
    // ref int count er antallet af gange, 'x' blev fundet i tekststrengen
    private void DetermineVarPos(string function, ref int[] pos)
    {
        // Gør, så array har størrelse på 9 ints
        pos = new int[9];
        int count = 0;

        // Søg efter bogstavet 'x' i funktionsforskriften og gem i pos-array
        for (int i = 0; i < function.Length; i++)
        {
            if (function[i] == 'x')
            {
                pos[count] = i;
                count++;
            }
        }
    }
    #endregion

    // Differentierer en given funktion af brugeren.
    // Virker kun på polynomier
    // string function er den givne funktion, der skal differentieres
    private string Differentiate(string function)
    {
        int[] pos = new int[9];
        int count = 0;

        DetermineVarPos(function, ref pos, ref count);

        string answer = "";

        // Loop igennem alle de fundne 'x'-er fundet i funktionsforskrift og bestem leddet foran x-værdien
        for (int i = 0; i < count; i++)
        {
            string led = ""; // Angiver tallet foran den nuværende x-værdi
            // Første led ( dvs. 32x^3)
            if (i == 0)
            {
                for (int j = 0; j < pos[i]; j++)
                {
                    led += function[j];
                }
            }
            // alt andet
            else
            {
                // 4-tallet forklares bedst ved et eksempel
                // Tag funktionen f(x)=3x^3+7x^2
                // Ved i = 1 er man ved det 2. x med indeks pos[i], og i dette tilfælde indeks 6
                // samtidig har man den tidligere x ved indeks pos[i - 1], og i dette tilfælde indeks 1
                // Da der i funktionsudtrykket er afstanden 4 (man går gennem følgende ting: "^3+")
                // inden man når leddet, så skal man bruge 4.
                for (int j = pos[i - 1]; j < pos[i] - 4; j++)
                {
                    led += function[j + 4];
                }
            }

            // System.Int32.Parse()- og ToString()-funktionerne skal desværre benyttes, som det er ulogisk
            // at konvertere fra int til string tilbage til int igen og igen, men det returnerer det rigtige svar
            int gammelEksponent = System.Int32.Parse(function[pos[i] + 2].ToString());
            int gammelLed = System.Int32.Parse(led);
            int nyEksponent = System.Int32.Parse(function[pos[i] + 2].ToString()) - 1;

            answer += (gammelEksponent * gammelLed).ToString() + "x^" + nyEksponent.ToString();

            // Så længe man ikke er ved slutiterationen, så skal man sætte '+'
            // eller '-' i sit nye funktionsudtryk
            if (i != count - 1)
            {
                // Sepererer leddene i funktionsudtrykket, dvs man sætter enten '+' eller '-'
                answer += function[pos[i] + 3];
            }
        }
        return answer;
    }

    // TODO: Slet
    private void Start()
    {
        string TredjeGradsLigning = "32x^3+22x^2-11x^1+90x^0";
        string andenGradsLigning = "5x^2+3x^1-3x^0";
        Differentiate(andenGradsLigning);

        Debug.Log("Original ligning: " + andenGradsLigning);

        Debug.Log("X: " + CalculateExtrema(andenGradsLigning, 'x'));

        Debug.Log("Y: " + CalculateExtrema(andenGradsLigning, 'y'));

        Debug.Log("Differentieret ligning: " + Differentiate(andenGradsLigning));
    }
}