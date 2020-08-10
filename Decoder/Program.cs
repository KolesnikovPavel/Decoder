using System;

namespace Decoder
{
    class Program
    {
        static void SumMn(int[] M1, int[] M2, int[] M3, int N)
        {
            int i;
            for (i = 0; i < N; i++)
            {
                if (M1[i] == M2[i])
                    M3[i] = 0;
                else
                    M3[i] = 1;
            }
        }

        static void MultMn(int[] M1, int St, int[] M2, int N)
        {
            int i;
            for (i = 0; i < St; i++)
                M2[i] = 0;
            for (i = St; i < N; i++)
                M2[i] = M1[i - St];
        }

        static int St(int[] M1, int N)
        {
            int i, Res = -1;
            for (i = 0; i < N; i++)
            {
                if (M1[i] == 1)
                    Res = i;
            }
            return Res;
        }

        static void CopyMn(int[] M1, int[] M2, int N)
        {
            int i;
            for (i = 0; i < N; i++)
                M2[i] = M1[i];
        }

        static void DivMn(int[] Delim, int[] Delit, int[] Res, int N)
        {
            int k;
            int[] Tempmass = new int[15];
            int[] Tempmass2 = new int[15];
            while (St(Delim, N) >= St(Delit, N))
            {
                k = St(Delim, N) - St(Delit, N);
                MultMn(Delit, k, Tempmass, N);
                SumMn(Delim, Tempmass, Tempmass2, N);
                CopyMn(Tempmass2, Delim, N);
            }
            CopyMn(Delim, Res, N);
        }

        static void Main(string[] args)
        {
            int n = 15, k = 5, i, j;
            int[] V = { 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 };
            int[] G = { 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 };
            int[] E = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[,] S = new int[15, 15];
            int[] R = new int[15];
            int[] R1 = new int[15];
            int[] P = new int[15];
            bool IsNull = true;
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    E[j] = 0;
                    P[i] = S[j, i];
                }
                E[i] = 1;
                DivMn(E, G, R, n);
                CopyMn(R, P, n);
            }
            Console.WriteLine("Syndroms: ");
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                    Console.Write($"{S[i, j]} ");
                Console.WriteLine("");
            }
            DivMn(V, G, R1, n);
            for (i = 0; i < 15; i++)
            {
                if (R1[i] == 1)
                {
                    IsNull = false;
                    break;
                }
            }
            if (IsNull == true)
            {
                Console.WriteLine("No error");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error");
                Console.WriteLine("");
            }
            if (IsNull == false)
            {
                for (i = 0; i < 15; i++)
                {
                    bool IsMatch = true;
                    for (j = 0; j < 15; j++)
                    {
                        if (S[i, j] != R1[j])
                            IsMatch = false;
                    }
                    if (IsMatch == true)
                        Console.WriteLine($"Error in {i} bit");
                }
            }
            Console.WriteLine("");
        }
    }
}
