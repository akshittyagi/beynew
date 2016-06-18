using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Test
{
    class Wall
    {
        public double xpos;
        public double ypos;
        public double angle;
        public double length;
        public double width;

        public Wall()
        {
            xpos = ypos = angle = 0.0; length = 30.0; width = 5.0;
        }

        public Wall(double x, double y, double ang)
        {
            xpos = x;
            ypos = y;
            angle = ang;
            length = 30.0;
            width = 5.0;
        }
        public Wall(double x, double y, double ang, double l, double w)
        {
            xpos = x;
            ypos = y;
            angle = ang;
            length = l;
            width = w;
        }

    }
    class Ball
    {
        public double xpos;
        public double ypos;
        public double velx;
        public double vely;
        public double ax;
        public double ay;
        public int type = 0;
        //public List<double> pointx;
        //public List<double> pointy;
        public int radius;
        public double scalingf;

        public double afactor = 10000/2;
        public double safea = 10;

       public void setzero()
        {
            velx = 0;
            vely = 0;
            ax = 0;
            ay = 0;
        }

        public Ball()
        {
            xpos = 0.0;
            ypos = 0.0;
            velx = 0.0;
            vely = 0.0;
            radius = 0;
            ax = 0;
            ay = 0;
            type = 0;
            scalingf = 1.0;
        }

        public Ball(double x, double y, double vx, double vy, int t)
        {
            xpos = x;
            ypos = y;
            velx = vx;
            vely = vy;
            radius = 0;
            ax = 0;
            ay = 0;
            type = t;
            scalingf = 1.0;
        }



        public static double RadiusFunction(int rvalue)

        {
            return (10.0 + rvalue);
        }

        public double GetActualRadius()
        {
            return (Ball.RadiusFunction(radius)) * scalingf;
        }

        public double getAccelerationx(List<double> x, List<double> y)
        {
            if (type == 3 || type == 4 || type == 2)
            {
                return 0;
            }
            double answer = ax;
            for (int i = 0; i < x.Count; i++)
            {
                //answer += (100 / Math.Sqrt(((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos)))) * (x[i] - xpos) / Math.Sqrt(((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos)));
                //answer += 100 / getacc(x[i], xpos, y[i], ypos);
                double a = (((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos)))*Math.Sqrt(((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) / (x[i] - xpos);
                //if(a)
                a = afactor / (1 * a);

                if (Math.Abs(a)>safea)
                {
                    return 0;
                }

                else
                {
                    answer= answer+a;
                }
            }
            return answer;
        }

        public double getAccelerationx2(List<double> x, List<double> y)
        {
            if (type == 3 || type == 4 || type == 2)
            {
                return 0;
            }
            double answer = ax;
            for (int i = 0; i < x.Count; i++)
            {
                double a = (((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) * Math.Sqrt(((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) / (x[i] - xpos);
                //if(a)
                a = afactor / (1 * a);

                if (Math.Abs(a)>safea)
                {
                    return 0;
                }

                else
                {
                    answer = answer - a;
                }
            }
            return answer;
        }
        public double getAccelerationy2(List<double> x, List<double> y)
        {
            if (type == 3 || type == 4 || type == 2)
            {
                return 0;
            }
            double answer = ay;
            for (int i = 0; i < y.Count; i++)
            {
                double a = (((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) * Math.Sqrt(((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) / (y[i] - ypos);
                //if(a)
                a = afactor / (1 * a);

                if (Math.Abs(a)>safea)
                {
                    return 0;
                }

                else
                {
                    answer = answer - a;

                }
            }
            return answer;
        }

        public double getAccelerationy(List<double> x, List<double> y)
        {
            if (type == 3 || type == 4 || type == 2)
            {
                return 0;
            }
            double answer = ay;
            for (int i = 0; i < y.Count; i++)
            {
                double a = (((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) * Math.Sqrt(((x[i] - xpos) * (x[i] - xpos)) + ((y[i] - ypos) * (y[i] - ypos))) / (y[i] - ypos);
                //if(a)
                a = afactor / (1 * a);

                Debug.WriteLine("Valuse of a: " + a);

                if (Math.Abs(a)>safea)
                {
                    return 0;
                }

                else
                {
                    answer = answer + a;
                }
            }
            return answer;
        }

        public void updatespeed()
        {
            velx = velx * (1.5);
            vely = vely * (1.5);
        }

        public void setvelocity(double xposheld, double yposheld, double xposrelease, double yposrelease)
        {
            double c = 10;
            velx = (xposheld - xposrelease) / c;
            vely = (yposheld - yposrelease) / c;

            if (Math.Abs(velx) > 20)
            {
                vely = vely * 20 / Math.Abs(velx);
                velx = velx * 20 / Math.Abs(velx);
                //velx = vely = 1;
            }
            if (Math.Abs(vely) > 20)
            {
                velx = velx * 20 / Math.Abs(vely);
                vely = vely * 20 / Math.Abs(vely);
                // velx = vely = 1;
            }

            checkvelocity();
        }

        public void checkvelocity()
        {
            double velmax = 40;
            double vel = velx * velx + vely * vely;
            vel = Math.Sqrt(vel);
            if (vel > velmax)
            {
                velx = velmax * velx / vel;
                vely = velmax * vely / vel;
            }
            //Debug.WriteLine("Velocity X"+velx + "Velocity Y"+vely);
        }
    }

    class Board
    {
        public double dimensionx;
        public double dimensiony;
        public bool ispaused;
        public List<Ball> AllBalls;
        public List<Wall> AllWalls;
        public double scf;
        public Boolean gamestart;
        public List<double> gravpointx;
        public List<double> gravpointy;
        public List<double> repulspointx;
        public List<double> repulspointy;
        public double force;
        public Boolean levelfinished;
        //public 
        //public Ball Ballcons;

        public void setzero()
        {
            gamestart = false;
            levelfinished = false;

            dimensionx = 0.0;
            dimensiony = 0.0;
            for(int i = 0; i < AllBalls.Count; i++)
            {
                AllBalls[i].setzero();
            }
        }

        public Board()
        {
            gamestart = false;
            levelfinished = false;

            dimensionx = 0.0;
            dimensiony = 0.0;
            ispaused = false;
            AllBalls = new List<Ball>();
            AllWalls = new List<Wall>();
            scf = 1.0;
            //tickx = 0;
            //ticky = 0;
            gravpointx = new List<double>();
            gravpointy = new List<double>();
            repulspointx = new List<double>();
            repulspointy = new List<double>();
            force = 0;
        }

        public Board(double dimx, double dimy)
        {
            gamestart = false;

            dimensionx = dimx;
            dimensiony = dimy;
            AllBalls = new List<Ball>();
            AllWalls = new List<Wall>();
            gravpointx = new List<double>();
            gravpointy = new List<double>();
            repulspointx = new List<double>();
            repulspointy = new List<double>();
            //rndgen = new Random(new System.DateTime().Millisecond);
            scf = dimy / (2.25 * Ball.RadiusFunction(99));
        }

        public void AddBall(Ball b)
        {
            b.scalingf = scf;
            b.velx *= (dimensiony / 1080);
            b.vely *= (dimensiony / 1080);
            AllBalls.Add(b);
        }

        public void AddWall(Wall w)
        {
            AllWalls.Add(w);
        }
        public void moveballs()
        {

            for (int i = 0; i < AllBalls.Count; i++)
            {
                Ball Ballcons = AllBalls[i];
                double radius = Ballcons.GetActualRadius();
                double newvelx = Ballcons.velx + Ballcons.getAccelerationx(gravpointx, gravpointy) + Ballcons.getAccelerationx2(repulspointx, repulspointy);
                double newvely = Ballcons.vely + Ballcons.getAccelerationy(gravpointx, gravpointy) + Ballcons.getAccelerationy2(repulspointx, repulspointy);
                //Debug.WriteLine("accelerationy: "+Ballcons.returnaccelerationy(Ballcons.pointy)+"Vely:"+Ballcons.vely);
                double newposx = Ballcons.xpos + newvelx;
                double newposy = Ballcons.ypos + newvely;
                //Debug.WriteLine("Vely:" + newvely);
                //Debug.WriteLine("Velx:" + Ballcons.velx);

                Ballcons.xpos = newposx;
                Ballcons.ypos = newposy;
                Ballcons.velx = newvelx;
                Ballcons.vely = newvely;

                if (newposx + radius > dimensionx)
                {
                    Ballcons.velx = -Math.Abs(Ballcons.velx);
                    //tickx = 2000 * pi + tickx;
                    //Debug.WriteLine("Collision 1 ");
                }
                if (newposx - radius < 0)
                {
                    Ballcons.velx = Math.Abs(Ballcons.velx);
                    //tickx = 2000 * pi + tickx;
                    //Debug.WriteLine("Collision 2 ");
                }

                if (newposy + radius > dimensiony)
                {
                    Ballcons.vely = -Math.Abs(Ballcons.vely);

                    //ticky = 1000 * pi - ticky;
                    //Debug.WriteLine("Collision 3");

                }
                if (newposy - radius < 0)
                {
                    Ballcons.vely = Math.Abs(Ballcons.vely);

                }
                AllBalls[i] = Ballcons;
                checksafezone(Ballcons);
                //for (int j = i + 1; j < AllBalls.Count; j++)
                //{
                //    Ball Ballcons2 = AllBalls[j];
                //    if (Ballcons.type == 0)
                //    {
                //        if (Ballcons2.type == 0)
                //        {
                //            HandleCollision(i, j);
                //        }
                //        else if (Ballcons2.type == 1)
                //        {
                //            HandleCollision(i, j);
                //        }
                //        else if (Ballcons2.type == 2)
                //        {
                //            HandleCollision(i, j);
                //        }
                //        else if (Ballcons2.type == 3)
                //        {
                //            HandleCollision2(i, j); //infinite mass case
                //        }
                //    }
                //    else if (Ballcons.type == 1 || Ballcons.type == 2)
                //    {
                //        if (Ballcons2.type == 0)
                //        {
                //            HandleCollision(j, i);
                //        }
                //        else if (Ballcons2.type == 1)
                //        {
                //            HandleCollision(i, j);
                //        }
                //        else if (Ballcons2.type == 2)
                //        {
                //            HandleCollision(i, j);
                //        }
                //        else if (Ballcons2.type == 3)
                //        {
                //            HandleCollision2(i, j); //infinite mass case
                //        }
                //    }
                //    else if (Ballcons.type == 3)
                //    {
                //        if (Ballcons2.type == 0)
                //        {
                //            HandleCollision2(j, i);
                //        }
                //        else if (Ballcons2.type == 1)
                //        {
                //            HandleCollision2(j, i);
                //        }
                //        else if (Ballcons2.type == 2)
                //        {
                //            HandleCollision2(j, i);
                //        }
                //        else if (Ballcons2.type == 3)
                //        {
                //        }
                //    }
                //    Debug.WriteLine("Position " + Ballcons.xpos + " y: " + Ballcons.ypos);
                //}


                //if (Overlapping(AllBalls[i]))
                //{
                //    AllBalls[i].
                //}
            }
        }

        public void checksafezone(Ball b)
        {
            int safeball = -1;
            for (int i = 0; i < AllBalls.Count; i++)
            {
                if (AllBalls[i].type == 4)
                {
                    safeball = i;
                    break;
                }
            }
            if ((calcballdistance(AllBalls[0], AllBalls[safeball])) <= -AllBalls[0].GetActualRadius() + AllBalls[safeball].GetActualRadius())
            {
                levelfinished = true;
            }
        }

        public void HandleCollision(int i, int j) //normal mass
        {
            Ball Ballcons = AllBalls[i];

            Ball Ballcons2 = AllBalls[j];

            double ux1 = Ballcons.velx;
            double uy1 = Ballcons.vely;

            double dx = Ballcons2.xpos - Ballcons.xpos;
            double dy = Ballcons2.ypos - Ballcons.ypos;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (Ballcons.GetActualRadius() + Ballcons2.GetActualRadius() >= distance)
            {
                double l = (Ballcons.GetActualRadius() + Ballcons2.GetActualRadius() - distance);

                double mass1 = MassFunction(Ballcons.GetActualRadius());
                double mass2 = MassFunction(Ballcons2.GetActualRadius());

                double ux2 = Ballcons2.velx;
                double uy2 = Ballcons2.vely;

                // Along radial
                double u1 = (ux1 * dx + uy1 * dy) / distance;
                double u2 = (ux2 * dx + uy2 * dy) / distance;

                //After collision radial
                double v1 = (mass1 * u1 + 2 * mass2 * u2 - mass2 * u1) / (mass1 + mass2);
                double v2 = (mass2 * u2 + 2 * mass1 * u1 - mass1 * u2) / (mass1 + mass2);

                //Along XYZ unchanged (tangential)
                double vx1 = ux1 + ((v1 - u1) * dx) / distance;
                double vy1 = uy1 + ((v1 - u1) * dy) / distance;
                double vx2 = ux2 + ((v2 - u2) * dx) / distance;
                double vy2 = uy2 + ((v2 - u2) * dy) / distance;

                //Ballcons.xpos = Ballcons.xpos - (l * dx) / distance;
                //Ballcons.ypos = Ballcons.ypos - (l * dy) / distance;

                //Ballcons2.xpos = Ballcons2.xpos + (l * dx) / distance;
                //Ballcons2.ypos = Ballcons2.ypos + (l * dy) / distance;

                Ballcons.velx = vx1;
                Ballcons.vely = vy1;

                Ballcons2.velx = vx2;
                Ballcons2.vely = vy2;


                if (Ballcons2.type == 1 && Ballcons.type == 0)
                {
                    Ballcons.radius = 0;
                }
                else if (Ballcons2.type == 2 && Ballcons.type == 0)
                {
                    Ballcons.velx = 0;
                    Ballcons.vely = 0;
                    Ballcons2.type = 4;
                }

                AllBalls[i] = Ballcons;
                AllBalls[j] = Ballcons2;

            }


        }

        public void HandleCollision2(int i, int j) // j->infinite mass
        {
            Ball Ballcons = AllBalls[i];

            Ball Ballcons2 = AllBalls[j];

            double ux1 = Ballcons.velx;
            double uy1 = Ballcons.vely;

            double dx = Ballcons2.xpos - Ballcons.xpos;
            double dy = Ballcons2.ypos - Ballcons.ypos;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (Ballcons.GetActualRadius() + Ballcons2.GetActualRadius() >= distance)
            {
                double l = (Ballcons.GetActualRadius() + Ballcons2.GetActualRadius() - distance);

                // Along radial
                double u1 = (ux1 * dx + uy1 * dy) / distance;
                double u2 = 0;

                //After collision radial
                double v1 = (2 * u2 - u1);
                double v2 = (u2);

                //Along XYZ unchanged (tangential)
                double vx1 = ux1 + ((v1 - u1) * dx) / distance;
                double vy1 = uy1 + ((v1 - u1) * dy) / distance;

                //Ballcons.xpos = Ballcons.xpos - (l * dx) / distance;
                //Ballcons.ypos = Ballcons.ypos - (l * dy) / distance;

                Ballcons.velx = vx1;
                Ballcons.vely = vy1;

                AllBalls[i] = Ballcons;

            }
        }
        public double MassFunction(double r)
        {
            //if()
            return r;
        }

        public bool Overlapping(Ball b)
        {
            bool presetly = false;

            for (int i = 0; i < AllBalls.Count; i++)
            {
                if (calcballdistance(b, AllBalls[i]) < AllBalls[i].GetActualRadius() + scf * Ball.RadiusFunction(b.radius))
                {
                    presetly = true;
                    break;
                }
            }

            return presetly;
        }

        public static double calcballdistance(Ball b1, Ball b2)
        {
            return Math.Sqrt(Math.Pow(b1.xpos - b2.xpos, 2) + Math.Pow(b1.ypos - b2.ypos, 2));
        }

        //    public int CheckOverLap(int ballid, int newr)
        //    {
        //        //bool sofar = false;
        //        int ballidfound = -1;
        //        for (int i = 0; i < AllBalls.Count; i++)
        //        {
        //            if (i != ballid)
        //            {
        //                if (GetBallDistance(i, ballid) < AllBalls[i].GetActualRadius() + scf * Ball.RadiusFunction(newr))
        //                {
        //                    //sofar = true;
        //                    ballidfound = i;
        //                    break;
        //                }
        //            }
        //        }
        //        return ballidfound;
        //    }

        //    public double GetBallDistance(int bid1, int bid2)
        //    {
        //        return GetDistance(AllBalls[bid1].xpos, AllBalls[bid1].ypos, AllBalls[bid2].xpos, AllBalls[bid2].ypos);
        //    }

        //    public double GetDistance(double x1, double y1, double x2, double y2)
        //    {
        //        double a1 = (x1 - x2);
        //        double a2 = (y1 - y2);
        //        return Math.Sqrt((a1 * a1) + (a2 * a2));
        //    }
    }


}
