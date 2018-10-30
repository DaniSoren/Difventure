/// <summary>
/// Denne klasse skal kunne lave og rette opgaver.
/// Den skal samtidig styre progressionen og sværhedsgraden i opgaverne
/// </summary>

using UnityEngine; // Fjern denne og nedarvningen, når koden er done

public class Assignment : MonoBehaviour {

    public int correctAnswers = 0;

    public void Create()
    {

    }

    public void Correct(string function)
    {

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

    private bool IsUserCorrect()
    {
        return false;
    }

    private string Differentiate(string function)
    {

        string answer = "";

        int[] order = new int[9];
        int count = 0;

        for (int i = 0; i < function.Length; i++)
        {
            if (function[i] == 'x')
            {
                order[count] = i;
                count++;
            }
        }

        for (int i = 0; i < count; i++)
        {
            if (i == 0)
            {
                string x = "";
                for (int j = 0; j < order[i]; j++)
                {
                    x += function[j];
                }
                answer = (System.Int32.Parse(function[order[i] + 2].ToString()) * System.Int32.Parse(x)).ToString()
                + "x^" + (System.Int32.Parse(function[order[i] + 2].ToString()) - 1) + function[order[i] + 3];
            }
            else if (i == count - 1)
            {
                string x = "";
                for (int j = 0; j < order[i] - (order[i - 1] + 3) - 1; j++)
                {
                    x += function[j];
                }
                answer += (System.Int32.Parse(function[order[i] + 2].ToString()) * System.Int32.Parse(x)).ToString()
                + "x^" + (System.Int32.Parse(function[order[i] + 2].ToString()) - 1);
            }
            else
            {
                string x = "";
                for (int j = order[i - 1]; j < order[i] - 4; j++)
                {
                    x += function[j + 4];
                }
                answer += (System.Int32.Parse(function[order[i] + 2].ToString()) * System.Int32.Parse(x)).ToString()
                + "x^" + (System.Int32.Parse(function[order[i] + 2].ToString()) - 1) + function[order[i] + 3];
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
