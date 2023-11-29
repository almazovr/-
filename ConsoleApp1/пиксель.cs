using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public readonly struct пиксель
    {
        private const char PixelsChar = '█';

        public пиксель(int x, int y, ConsoleColor color, int pixelsSize = 3)
        {
            X = x;
            Y = y;
            Color = color;
            PixelsSize = pixelsSize;
        }

        public int X { get; }

        public int Y { get; }

        public ConsoleColor Color { get; }

        public int PixelsSize { get; }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < PixelsSize; x++)
            {
                for (int y = 0; y < PixelsSize; y++)
                {
                    Console.SetCursorPosition(X * PixelsSize + x, Y * PixelsSize + y);
                    Console.Write(PixelsChar);
                }
            }
        }

        public void Clear()
        {
            for (int x = 0; x < PixelsSize; x++)
            {
                for (int y = 0; y < PixelsSize; y++)
                {
                    Console.SetCursorPosition(X * PixelsSize + x, Y * PixelsSize + y);
                    Console.Write(' ');
                }
            }
        }
    }
}
