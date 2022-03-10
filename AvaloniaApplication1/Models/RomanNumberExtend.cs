namespace AvaloniaApplication1
{
    internal class RomanNumberExtend : RomanNumber
    {
        ushort sum;
        ushort prev;
        public RomanNumberExtend(string str) : base(1)
        {
            ushort[] a = new ushort[] { 1, 5, 10, 50, 100, 500, 1000 };
            char[] b = new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            for (int j = 0; j < 7; ++j)
            {
                if (str[str.Length - 1] == b[j])
                {
                    sum = a[j];
                }   
            }
                    
            prev = sum;

            for (int i = str.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < 7; ++j)
                {
                    if (str[i] == b[j] && prev <= a[j])
                    {
                        sum += a[j];
                        prev = a[j];
                    }
                    else if (str[i] == b[j] && prev > a[j])
                    {
                        sum -= a[j];
                        prev = a[j];
                    }
                }
            }

            number = sum;
        }
    }

}