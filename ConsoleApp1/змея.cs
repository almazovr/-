using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Snake
    {
        private readonly ConsoleColor _golovaColor;

        private readonly ConsoleColor _teloColor;

        public Snake(int initialX,
            int initialY,
            ConsoleColor headColor,
            ConsoleColor bodyColor,
            int bodyLength = 3)
        {
            _golovaColor = headColor;
            _teloColor = bodyColor;

            Head = new пиксель(initialX, initialY, headColor);

            for (int i = bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new пиксель(Head.X - i - 1, initialY, _teloColor));
            }

            Draw();
        }

        public пиксель Head { get; private set; }

        public Queue<пиксель> Body { get; } = new Queue<пиксель>();

        public void Move(Direction direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new пиксель(Head.X, Head.Y, _teloColor));
            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new пиксель(Head.X + 1, Head.Y, _golovaColor),
                Direction.Left => new пиксель(Head.X - 1, Head.Y, _golovaColor),
                Direction.Up => new пиксель(Head.X, Head.Y - 1, _golovaColor),
                Direction.Down => new пиксель(Head.X, Head.Y + 1, _golovaColor),
                _ => Head
            };

            Draw();
        }

        public void Draw()
        {
            Head.Draw();

            foreach (пиксель pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (пиксель pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
