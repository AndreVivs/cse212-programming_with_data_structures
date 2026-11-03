public static class Sorting {
    public static void Run() {
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };
        SortArray(numbers);
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); //int[]{1, 2, 3, 4, 6, 8, 9}
    }

// big O notation: O(n^2) Quadratic time complexity, where n is the number of elements in the array.
// This is because there are two nested loops: the outer loop runs n times, and for each iteration of the outer loop,
// the inner loop runs up to n times in the worst case.
    private static void SortArray(int[] data) {
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--) {
            for (var swapPos = 0; swapPos < sortPos; ++swapPos) {
                if (data[swapPos] > data[swapPos + 1]) {
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                }
            }
        }
    }
}