using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private static int total_Star = 0;

    public static int Total_Star
    {
        get
        {
            return total_Star;
        }
        set
        {
            if (total_Star >= 42)
            {
                total_Star = 42;
            }
            else
            {
                total_Star = value;
            }
        }
    }

    /// <summary>
    /// 用來判斷給予星號的數量，用語音辨識準確度來判斷
    /// </summary>
    public static int JudgePerformance_ReturnStar(float performance)
    {
        int star = 0;
        if (performance >= 95)
        {
            star = 3;
        }
        else if (performance >= 85 && performance < 95)
        {
            star = 2;
        }
        else if(performance>=80 && performance<85)
        {
            star = 1;
        }
        return star;
    }
}
