using System.Collections;
using System.Collections.Generic;

public class ScoreManager
{
    private static int score;
   public ScoreManager()
   {

   }

    public static void setScore(int nScore)
    {
        score = nScore;
    }

    public static int getScore()
    {
        return score;
    }

}
