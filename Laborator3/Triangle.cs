using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace UrsuCalin3132b
{
    class Triangle
    {
        private float[] p1 = new float[] { 0, 0, 0 };
        private float[] p2 = new float[] { 0, 0, 0 };
        private float[] p3 = new float[] { 0, 0, 0 };
        private Color color1=Color.Red;
        private Color color2=Color.Yellow;
        private Color color3=Color.Blue;
        public Triangle(string nume_fisier)
        {
            string[] lines = System.IO.File.ReadAllLines(nume_fisier);
            for (int i = 0; i <= 2; i++)
            {
                string[] coords = lines[i].Split(' ');
                if (coords.Length != 0)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (i == 0)
                        {
                            p1[j] = float.Parse(coords[j]);
                        }
                        else if (i == 1)
                        {
                            p2[j] = float.Parse(coords[j]);
                        }
                        else
                        {
                            p3[j] = float.Parse(coords[j]);
                        }

                    }
                }
            }
        }

        public void SetRandomColors()
        {
            Random randomnr = new Random();
            color1 = Color.FromArgb(randomnr.Next(0,255),randomnr.Next(0,255),randomnr.Next(0,255));
            Console.WriteLine("Vertex #" + 1+ ": (" + color1.R + ", " + color1.G + ", " + color1.B + ")");
            color2 = Color.FromArgb(randomnr.Next(0,255),randomnr.Next(0,255),randomnr.Next(0,255));
            Console.WriteLine("Vertex #" + 2+ ": (" + color2.R + ", " + color2.G + ", " + color2.B + ")");
            color3 = Color.FromArgb(randomnr.Next(0,255),randomnr.Next(0,255),randomnr.Next(0,255));
            Console.WriteLine("Vertex #" + 3+ ": (" + color2.R + ", " + color2.G + ", " + color2.B + ")");
        }
        public void SetColors(Color[] new_colors)
        {
            color1 = new_colors[0];
            Console.WriteLine("Vertex #" + 1+ ": (" + new_colors[0].R + ", " + new_colors[0].G + ", " + new_colors[0].B + ")");
            color2 = new_colors[1];
            Console.WriteLine("Vertex #" + 2+ ": (" + new_colors[1].R + ", " + new_colors[1].G + ", " + new_colors[1].B + ")");
            color3 = new_colors[2];
            Console.WriteLine("Vertex #" + 3+ ": (" + new_colors[2].R + ", " + new_colors[2].G + ", " + new_colors[2].B + ")");
        }

        public void SetColor1(Color new_color)
        {
            color1 = new_color;
        }
        public void SetColor2(Color new_color)
        {
            color2 = new_color;
        }
        public void SetColor3(Color new_color)
        {
            color3 = new_color;
        }
        
        public Color[] GetColors()
        {
            return new Color[] {color1,color2,color3};
        }

        public float[] GetPoint(int number)
        {
            if (number == 1)
            {
                return p1;
            }
            else if (number == 2)
            {
                return p2;
            }
            else
            {
                return p3;
            }
        }
        public Color GetColor(int number)
        {
            if (number == 1)
            {
                return color1;
            }
            else if (number == 2)
            {
                return color2;
            }
            else
            {
                return color3;
            }
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Triangles);

            float[] point;
            Color color;
            for (int i = 1; i <= 3; i++)
            {
                point = GetPoint(i);
                color = GetColor(i);
                GL.Color3(color);
                GL.Vertex3(point[0], point[1], point[2]);
            }

            GL.End();
        }
    }
}