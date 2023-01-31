internal class Program
{
    private static void Main(string[] args)
    {
        //Fibonacci sphere using .cs?
        // the current fibonacci numbers
        int current = 1;
        int previous = 0;

        // the current bounding box
        int left = 0;
        int right = 1;
        int top = 0;
        int bottom = 0;

        // the number of boxes you want to draw
        const int N = 10;

        for (int i = 0; i < N; i++)
        {
            switch (i % 4)
            {
                case 0: // attach to bottom of current rectangle
                    drawRectangle(g, left, right, bottom, bottom + current);
                    bottom += current;
                    break;
                case 1: // attach to right of current rectangle
                    drawRectangle(g, right, right + current, top, bottom);
                    right += current;
                    break;
                case 2: // attach to top of current rectangle
                    drawRectangle(g, left, right, top - current, top);
                    top -= current;
                    break;
                case 3: // attach to left of current rectangle
                    drawRectangle(g, left - current, left, top, bottom);
                    left -= current;
                    break;
            }

            // update fibonacci number
            int temp = current;
            current += previous;
            previous = temp;
        }


        const int SCALE = 5;
        const int OFFSET = 150;
    }

    private static void drawRectangle(Graphics g, int left, int right, int top, int bottom)
    {
        g.DrawRectangle(Pens.Red, new Rectangle(SCALE * left + OFFSET,
                                                SCALE * top + OFFSET,
                                                SCALE * (right - left),
                                                SCALE * (bottom - top)));
    }
}