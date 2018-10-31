/// <summary>
/// Denne klasse skal kunne lave og rette opgaver.
/// Den skal samtidig styre progressionen og sværhedsgraden i opgaverne
/// </summary>

using UnityEngine; // Fjern denne og nedarvningen, når koden er done

public class Assignment : MonoBehaviour {
    #region SHIT
    public int correctAnswers = 0;

    public void Create()
    {
        switch(diff)
        {
            case Difficulty.INTRODUCTION:
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
        correctAnswer = Differentiate("3x");
    }

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

    public enum Difficulty
    {
        INTRODUCTION,
        EASY,
        MEDIUM,
        HARD,
        INSANE
    };

    private Difficulty diff = Difficulty.INTRODUCTION;

    private int correctAnswersInARow = 0;

    private string correctAnswer;

    private void ChangeDifficulty(bool lowerDifficulty)
    {

    }
    #endregion
    private bool IsUserCorrect(string function) { return function == correctAnswer; }

    private string Differentiate(string function)
    {
        int[] pos = new int[9];
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

            if (i != count - 1)
            {
                answer += function[pos[i] + 3];
            }
        }
        return answer;
    }

    private void Start()
    {
        string testString = "32x^3+22x^2-11x^1+90x^0";
        Debug.Log(Differentiate(testString));
    }
}
