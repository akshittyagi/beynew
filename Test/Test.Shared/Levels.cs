using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Test
{
    class Levels
    {
        public List<Board> StoryLevels;

        public Levels()
        {
            StoryLevels = new List<Board>();
        }

        public static int GetNumberOfLevels()
        {
            Levels t1 = new Levels();
            t1.MakeStoryLevels(100, 100);
            return t1.StoryLevels.Count;
        }

        // Type 0 -> Normal Ball
        // Type 1 -> 
        // Type 2 ->
        // Type 3-> Gravity Points
        // Type 4-> Safe Zone

        public void MakeStoryLevels(double dimx, double dimy)
        {
            StoryLevels = new List<Board>();
            //Add levels here
            ////LEVEL 1
            Ball ball = new Ball(dimx / 10, dimy / 10, 0, 0, 0);
            //Ball ball2 = new Ball(3*dimx / 5, 2 * dimy / 4, 0, 0, 3);
            Debug.WriteLine("Position hai x:" + ball.xpos + " y: " + ball.ypos);
            //ball.ax = dimx / 6;
            //ball.ay=
            Board board1 = new Board(dimx, dimy);
            //board1.gravpointx.Add(3*dimx / 5);
            //board1.gravpointy.Add(2 * dimy / 4);
            Ball ball3 = new Ball(dimx / 1.2, dimy / 1.2, 0, 0, 4);
            ball3.radius = 20;
            board1.AddBall(ball);
            //board1.AddBall(ball2);
            board1.AddBall(ball3);
            StoryLevels.Add(board1);
            Ball ball2;

            ////LEVEL 2
            ball = new Ball(dimx / 12, dimy / 2, 0, 0, 0);
            ball2 = new Ball(dimx / 3, dimy / 4, 0, 0, 3);
            Ball ball20 = new Ball(dimx / 2, 3 * dimy / 4, 0, 0, 3);
            Debug.WriteLine("Position hai x:" + ball.xpos + " y: " + ball.ypos);
            //ball.ax = dimx / 6;
            //ball.ay=
            board1 = new Board(dimx, dimy);
            board1.gravpointx.Add(dimx / 3);
            board1.gravpointy.Add(dimy / 4);
            board1.gravpointx.Add(dimx / 2);
            board1.gravpointy.Add(3 * dimy / 4);
            ball3 = new Ball(dimx / 1.2, dimy * 0.8, 0, 0, 4);
            ball3.radius = 20;
            board1.AddBall(ball);
            board1.AddBall(ball2);
            board1.AddBall(ball20);
            board1.AddBall(ball3);
            StoryLevels.Add(board1);

            ////LEVEL 3
            ball = new Ball(dimx / 12, dimy / 2, 0, 0, 0);
            ball2 = new Ball(dimx / 3, 2 * dimy / 3, 0, 0, 2);
            ball20 = new Ball(dimx / 3, dimy / 3, 0, 0, 2);
            Ball ball21 = new Ball(dimx / 2, 2 * dimy / 3, 0, 0, 3);
            Ball ball22 = new Ball(dimx / 2, dimy / 3, 0, 0, 3);
            Debug.WriteLine("Position hai x:" + ball.xpos + " y: " + ball.ypos);
            //ball.ax = dimx / 6;
            //ball.ay=
            board1 = new Board(dimx, dimy);
            board1.repulspointx.Add(dimx / 3);
            board1.repulspointy.Add(2 * dimy / 3);
            board1.repulspointx.Add(dimx / 3);
            board1.repulspointy.Add(dimy / 3);
            board1.gravpointx.Add(dimx / 2);
            board1.gravpointx.Add(dimx / 2);
            board1.gravpointy.Add(dimx / 3);
            board1.gravpointy.Add(2 * dimx / 3);
            ball3 = new Ball(dimx / 1.2, dimy / 2, 0, 0, 4);
            ball3.radius = 20;
            board1.AddBall(ball);
            board1.AddBall(ball2);
            board1.AddBall(ball20);
            board1.AddBall(ball21);
            board1.AddBall(ball22);
            board1.AddBall(ball3);
            StoryLevels.Add(board1);

            ///LEVEL 4

            ball = new Ball(dimx / 12, dimy / 2, 0, 0, 0);
            ball2 = new Ball(dimx / 3, dimy / 4, 0, 0, 2);
            ball20 = new Ball(dimx / 3, dimy * 0.75, 0, 0, 3);
            ball21 = new Ball(dimx * 0.65, dimy * 0.66, 0, 0, 2);
            //            Debug.WriteLine("Position hai x:" + ball.xpos + " y: " + ball.ypos);
            //ball.ax = dimx / 6;
            //ball.ay=
            board1 = new Board(dimx, dimy);
            board1.repulspointx.Add(dimx / 3);
            board1.repulspointy.Add(dimx / 4);
            board1.repulspointx.Add(dimx * 0.65);
            board1.repulspointy.Add(dimx * 0.66);
            board1.gravpointx.Add(dimx / 3);
            board1.gravpointy.Add(dimy * 0.75);
            ball3 = new Ball(dimx / 1.2, dimy / 12, 0, 0, 4);
            ball3.radius = 20;
            board1.AddBall(ball);
            board1.AddBall(ball2);
            board1.AddBall(ball20);
            board1.AddBall(ball21);
            board1.AddBall(ball3);
            StoryLevels.Add(board1);

            /////LEVEL 5
            ball = new Ball(dimx / 12, dimy / 2, 0, 0, 0);
            Ball ball00 = new Ball(dimx * 0.333 * 0.8, dimy * 0.25, 0, 0, 3);
            Ball ball01 = new Ball(dimx * 0.333 * 0.8, dimy * 0.75, 0, 0, 3);
            Ball ball10 = new Ball(dimx * 0.5 * 0.8, dimy * 0.2, 0, 0, 2);
            Ball ball11 = new Ball(dimx * 0.5 * 0.8, dimy * 0.4, 0, 0, 3);
            Ball ball12 = new Ball(dimx * 0.4, dimy * 0.6, 0, 0, 3);
            Ball ball13 = new Ball(dimx * 0.4, dimy * 0.8, 0, 0, 2);
            ball20 = new Ball(dimx * 0.666 * 0.8, dimy * 0.5, 0, 0, 2);
            Ball ball30 = new Ball(dimx * 0.6666, dimy * 0.333, 0, 0, 3);
            Ball ball31 = new Ball(dimx * 0.6666, dimy * 0.666, 0, 0, 3);

            Debug.WriteLine("Position hai x:" + ball.xpos + " y: " + ball.ypos);

            board1 = new Board(dimx, dimy);
            board1.repulspointx.Add(dimx * 0.4);
            board1.repulspointy.Add(dimy * 0.2);
            board1.repulspointx.Add(0.4 * dimx);
            board1.repulspointy.Add(0.8 * dimy);
            board1.repulspointx.Add(0.8 * 0.666 * dimx);
            board1.repulspointy.Add(0.5 * dimy);
            board1.gravpointx.Add(dimx * 0.333 * 0.8);
            board1.gravpointy.Add(dimy * 0.25);
            board1.gravpointx.Add(dimx * 0.333 * 0.8);
            board1.gravpointy.Add(dimy * 0.75);
            board1.gravpointx.Add(dimx * 0.4);
            board1.gravpointy.Add(dimy * 0.4);
            board1.gravpointx.Add(dimx * 0.4);
            board1.gravpointy.Add(dimy * 0.6);
            board1.gravpointx.Add(dimx * 0.666);
            board1.gravpointy.Add(dimy * 0.333);
            board1.gravpointx.Add(dimx * 0.666);
            board1.gravpointy.Add(dimy * 0.666);

            ball3 = new Ball(dimx * 0.8, dimy / 2, 0, 0, 4);
            ball3.radius = 20;
            board1.AddBall(ball);
            board1.AddBall(ball00);
            board1.AddBall(ball01);
            board1.AddBall(ball10);
            board1.AddBall(ball12);
            board1.AddBall(ball11);
            board1.AddBall(ball13);
            board1.AddBall(ball20);
            board1.AddBall(ball30);
            board1.AddBall(ball31);
            board1.AddBall(ball3);
            StoryLevels.Add(board1);

            //ball = new Ball(dimx / 2, dimy / 2, 0, 10);
            //board1 = new Board(dimx, dimy);
            //board1.AddBall(ball);
            //StoryLevels.Add(board1);

        }


    }
}