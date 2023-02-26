// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string R = "AABBA"; 
int[] V= new int[5] {2,6,8,10,5};

var bigNumberIndex = V.ToList().IndexOf(V.Max());
var charValue = R[bigNumberIndex] ;
Console.WriteLine(new Solution().solution(R, V)[0]);
Console.WriteLine(new Solution().solution(R, V)[1]);

class Solution
{
    public int[] solution(string R, int[] V)
    {
        int sumA = 0;
        int sumB = 0;
        var intializeA = 0;
        var intializeB = 0;
        for (int i = 0; i < V.Length; i++)
        {
            var charBank = R[i];
            if (charBank == 'A')
            {
                sumA += V[i];
                sumB -= V[i];
                if (sumB < 0)
                {
                    intializeB = Math.Abs(sumB);
                }
            }
            else
            {
                intializeA = V[i];
                sumB += V[i];
                sumA -= V[i];
                if (sumA < intializeA)
                {
                    intializeA = Math.Abs(sumA); ;
                }
            }
        }
        return new int[] { Math.Abs(intializeA), Math.Abs(intializeB) };
    }

}

