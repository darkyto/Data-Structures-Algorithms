# Data Structures, Algorithms and Complexity


**1.**
------
What is the expected running time of the following C# code? 
Explain why.
Assume the array's size is n.

    long Compute(int[] arr)
    {
        long count = 0;
        for (int i=0; i<arr.Length; i++)
        {
            int start = 0, end = arr.Length-1;
            while (start < end)
                if (arr[start] < arr[end])
                    { start++; count++; }
                else 
                    end--;
        }
        return count;
    }
**Answer**
Algorithm complexity:  **O(n)**
Why:  becasuse we are searching a linear array structure


**2.**
------
What is the expected running time of the following C# code?
Explain why.
Assume the input matrix has size of n * m.

    long CalcCount(int[,] matrix)
    {
        long count = 0;
        for (int row=0; row<matrix.GetLength(0); row++)
            if (matrix[row, 0] % 2 == 0)
                for (int col=0; col<matrix.GetLength(1); col++)
                    if (matrix[row,col] > 0)
                        count++;
        return count;
    }

**Answer**
Algorithm complexity:  **O(n * m)**
Why:  becasuse we are searching a two-dimmensional matrix (2x arrays with linear size)    

**3.**
------
What is the expected running time of the following C# code?

Explain why using Markdown.
Assume the input matrix has size of n * m.

    long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        for (int col = 0; col < matrix.GetLength(0); col++) 
            sum += matrix[row, col];
        if (row + 1 < matrix.GetLength(1)) 
            sum += CalcSum(matrix, row + 1);
        return sum;
    }
    
    Console.WriteLine(CalcSum(matrix, 0));

**Answer**
Algorithm complexity:  **O(n*n)**  (n to the power of two)
Why:  becasuse we are searching a two-dimmensional matrix (2x arrays with linear size)   