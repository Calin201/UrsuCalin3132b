using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
namespace UrsuCalin3132b
{
    public class Laborator3 : GameWindow
    {
        private KeyboardState prev;
        private MouseState prevM;
        private Random r = new Random();
        Axes axes;
        Camera cam;
        private Triangle tri = new Triangle("Triangle.txt");
        private List<Object> rainofObject;
        public Laborator3() : base(1280,768, new OpenTK.Graphics.GraphicsMode(32,24,0,8))
        {
            
            VSync = VSyncMode.On;
            axes = new Axes();
            cam = new Camera(30,30,30,0,0,0,0,1,0);
            rainofObject = new List<Object>();
        }
        // Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
        // fundal a ferestrei 3D.
        // Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Gray);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
         
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        // Inițierea afișării și setarea viewport-ului grafic. Metoda este invocată la redimensionarea
        // ferestrei. Va fi invocată o dată și imediat după metoda ONLOAD!
        // Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
        // diferite). 
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);
          
            //setare proiectie 
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver3, (float)Width/(float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            //setare ochi
            cam.SetCamera();
           

        }

        // Secțiunea pentru "game logic"/"business logic". Tot ce se execută în această secțiune va fi randat
        // automat pe ecran în pasul următor - control utilizator, actualizarea poziției obiectelor, etc.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Momentan aplicația nu face nimic!
            // glfwSetMouseButtonCallback(window, mouse_button_callback);
            base.OnUpdateFrame(e);
            axes.Show();
            //////////grid.Show();
            KeyboardState currentState = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();
            if (currentState[Key.Escape])
            {
                Exit();
            }
            if(currentState[Key.H] && !prev[Key.H])
            {
                DisplayHelp();
            }
            if(currentState[Key.A])
            {
                cam.MoveLeft();
            }
            if (currentState[Key.D])
            {
               cam.MoveRight();
            }
            if(currentState[Key.W])
            {
                cam.MoveForward();
            }
            if (currentState[Key.S])
            {
                cam.MoveBackward();
            }
            if (currentState[Key.E])
            {
                cam.MoveUp();
            }
            if (currentState[Key.Q])
            {
                cam.MoveDown();
            }
            if (currentState[Key.Number1])
            {
                tri.SetColors(new Color[] {Color.Blue, Color.Yellow, Color.Red });
            }
            if (currentState[Key.Number2])
            {
                tri.SetColors(new Color[] { Color.Black, Color.Red, Color.Yellow });
            }
            if (currentState[Key.Number3])
            {
                tri.SetColors(new Color[] { Color.Red, Color.White, Color.Blue });
            }
            if (currentState[Key.Number4])
            {
                tri.SetRandomColors();
            }
            if (currentState[Key.Number5]&& !prev[Key.Number5])
            {
                tri.SetColor1( Color.FromArgb(r.Next(0,255),r.Next(0,255),r.Next(0,255)));
            }
            if (currentState[Key.Number6]&& !prev[Key.Number6])
            {
                tri.SetColor2( Color.FromArgb(r.Next(0,255),r.Next(0,255),r.Next(0,255)));
            }
            if (currentState[Key.Number7]&& !prev[Key.Number7])
            {
                tri.SetColor3( Color.FromArgb(r.Next(0,255),r.Next(0,255),r.Next(0,255)));
            }
            
            
            cam.MouseMovement( new Vector3((currentMouse.X - Width / 2f) / (Width / 16f), (currentMouse.Y - Height / 2f) / (Height / 16f), 35));
            prev = currentState;
            prevM = currentMouse;
            
        }

        // Secțiunea pentru randarea scenei 3D. Controlată de modulul logic din metoda ONUPDATEFRAME.
        // Parametrul de intrare "e" conține informatii de timing pentru randare.
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            axes.Draw();
            tri.Draw();
            SwapBuffers();
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n     MENU");
            Console.WriteLine(" H - meniu ajutor");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" [1,2,3,4,5,6,7] - modifica mod de desenare triunghi");
            Console.WriteLine(" [W,A,S,D+Q,E] - Miscare");
            Console.WriteLine(" [Mouse] Schimbare unghi de privire");
        }
    }
}