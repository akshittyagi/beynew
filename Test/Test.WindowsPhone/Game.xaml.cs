using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using System.Threading;
using Windows.UI.Xaml.Media.Animation;
using Windows.Storage;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        double screendimx, screendimy;
        DispatcherTimer time;
        Board board,boardcopy;
        Levels AllLevels;
        int ispressed;
        double point;
        bool mute;
        int level;
        Boolean ispaused;
        double xposheld, yposheld, xposrelease, yposrelease, xpos, ypos;
        double trailx, traily;
        Boolean pressed;
        int Trail;
        Ellipse[] ballarr;
        int maxLevel = 5;
        int l;
        Stopwatch t;

        public Game()
        {
            ///DONT WRITE ANYTHING BEFORE THIS YOU DENSE MOFO
            Debug.WriteLine("Cons First");
            this.InitializeComponent();
            myStoryboard.Begin();
            point = 0;
            ispressed = 0;
            Trail = 0;
            trailx = traily = 0;
            ispaused = false;
            level = 0;

            t = new Stopwatch();

            xposheld = yposheld = 0;

            //Screen dimensions

            screendimx = Window.Current.Bounds.Width;
            screendimy = Window.Current.Bounds.Height;
            Debug.WriteLine(screendimx + " " + screendimy);

            back.Margin = new Thickness(screendimx / 25, screendimy / 1.25, 0, 0);
            restart.Margin = new Thickness(screendimx / 7, screendimy / 1.25, 0, 0);
            button.Margin = new Thickness(screendimx / 4, screendimy / 1.25, 0, 0);

            AllLevels = new Levels();

            //Integrating time

            time = new DispatcherTimer();
            time.Tick += dispat_tick;
            time.Interval = new TimeSpan(0, 0, 0, 0, 1);//Last parameter for changing update rate
            time.Start();

            this.PointerReleased += pointreleased;
            this.PointerPressed += pointpressed;
            this.PointerMoved += pointmoved;

            AllLevels.MakeStoryLevels(screendimx, screendimy);

            // Debug.WriteLine("Acceleration x" + board.AllBalls[0].getAccelerationx(board.gravpointx, board.gravpointy));
            // Debug.WriteLine("Acceleration y" + board.AllBalls[0].getAccelerationy(board.gravpointx, board.gravpointy));


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String message = e.Parameter as string;
            String[] m = message.Split(' ');
            if (m[0].Equals("True"))
            {
                mute = true;
                mediaElement.IsMuted = true;
            }
            else
            {
                mute = false;
                mediaElement.IsMuted = false;
            }

            l = Convert.ToInt32(m[1]);
            //Debug.WriteLine(l);
            //Debug.WriteLine(level);
            board = AllLevels.StoryLevels[l];
            t.Start();
            //ballarr = new Ellipse[board.AllBalls.Count];

            //for (int i = 0; i < board.AllBalls.Count; i++)
            //{
            //    ballarr[i] = new Ellipse();
            //    //textblockarr[i] = new TextBlock();
            //    testc.Children.Add(ballarr[i]);
            //    //testc.Children.Add(textblockarr[i]);
            //}
        }

        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        int timesTicked = 1;
        int timesToTick = 2;
        Boolean hasEnded;
        int count = 0;
        void dispat_tick(object sender, object e)
        {
            if (!ispaused)
            {
                showboard();

                if (board.levelfinished)
                {
                    t.Stop();
                    ispressed = 0;
                    Ball ball = board.AllBalls[0];
                    ball.setvelocity(0, 0, 0, 0);
                    Debug.WriteLine("Level Complete");

                    myStoryboard2.Begin();

                    //MERA KAAM HAI MADARCHODH
                    dispatcherTimer = new DispatcherTimer();
                    dispatcherTimer.Tick += dispatcherTimer_Tick;
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    //IsEnabled defaults to false
                    startTime = DateTimeOffset.Now;
                    lastTime = startTime;


                    dispatcherTimer.Start();
                    Debug.WriteLine(hasEnded);
                    if (hasEnded)
                    {
                        if (count == 0)
                        {
                            myStoryboard2.Stop();
                            count++;
                        }
                        else
                        {
                            level = (level + 1) % maxLevel;
                            //l = (l + 1) % maxLevel;
                            l++;
                            if (l == 5)
                            {
                                Frame.Navigate(typeof(Level_Select), mute.ToString());
                            }
                            board = AllLevels.StoryLevels[l];
                            myStoryboard.Begin();
                            board.levelfinished = false;
                            //HERE THE CURRENT LEVEL HAS FINALLY ENDED
                        }

                    }
                    //MERA KAAM KHATAM
                    //GameCanvas.Children.Clear();

                }

                if (board.gamestart)
                {
                    board.moveballs();
                }
            }

            //Code to be executed when time is changing
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!ispaused)
            {
                ispaused = true;
                boardcopy = board;
                board.setzero();
            }
            else
            {
                board = boardcopy;
                ispaused = false;
            }
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            lastTime = time;
            //Time since last tick should be very very close to Interval
            timesTicked++;
            if (timesTicked > timesToTick)
            {
                stopTime = time;
                dispatcherTimer.Stop();
                //IsEnabled should now be false after calling stop
                hasEnded = true;
                span = stopTime - startTime;
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Level_Select), mute.ToString());
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            //level++;
            this.Frame.Navigate(typeof(Game), mute.ToString() + " " + l.ToString());
        }

        public void showboard()
        {
            GameCanvas.Children.Clear();
            for (int i = 0; i < board.AllBalls.Count; i++)
            {
                Ball balltodraw = board.AllBalls[i];
                int ball_type = balltodraw.type;
                //ballarr[i].Fill = new SolidColorBrush(Color.FromArgb(255, 128, 0, 0));
                //ballarr[i].Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                //ballarr[i].StrokeThickness = 10 * screendimy / 1080;
                //ballarr[i].Margin = new Thickness(balltodraw.xpos - balltodraw.GetActualRadius(), balltodraw.ypos - balltodraw.GetActualRadius(), 0, 0);
                //ballarr[i].Width = 2 * balltodraw.GetActualRadius();
                //ballarr[i].Height = 2 * balltodraw.GetActualRadius();
                Image i1 = new Image();
                i1.Margin = new Thickness(balltodraw.xpos - balltodraw.GetActualRadius(), balltodraw.ypos - balltodraw.GetActualRadius(), 0, 0);
                i1.Width = 2 * balltodraw.GetActualRadius();
                i1.Height = 2 * balltodraw.GetActualRadius();
                //i1.Source = ballimg.Source;
                if (ball_type == 0)
                    i1.Source = ballimg.Source;
                else if (ball_type == 2)
                    i1.Source = invgravity.Source;
                else if (ball_type == 3)
                    i1.Source = gravityimg.Source;
                else if (ball_type == 4)
                    i1.Source = safe.Source;
                GameCanvas.Children.Add(i1);

            }
            double marginx = board.AllBalls[0].xpos;
            double marginy = board.AllBalls[0].ypos;

            for (int i = 0; i < Trail; i++)
            {
                Image i2 = new Image();
                //i1.Margin = new Thickness(balltodraw.xpos - balltodraw.GetActualRadius(), balltodraw.ypos - balltodraw.GetActualRadius(), 0, 0);
                i2.Width = 20;
                i2.Height = 20;

                marginx += trailx * 0.40; /*/ (Math.Sqrt(trailx * trailx + traily * traily));*/
                marginy += traily * 0.40;/* / (Math.Sqrt(trailx * trailx + traily * traily));*/
                i2.Margin = new Thickness(marginx, marginy, 0, 0);
                i2.Source = dot.Source;
                GameCanvas.Children.Add(i2);
            }
            //testc.Children.Add(e1);


            //Perform the operations
        }

        public void pointpressed(object sender, PointerRoutedEventArgs e)
        {
            ispressed++;
            pressed = true;
            if (ispressed == 1)
            {
                xposheld = e.GetCurrentPoint(null).Position.X;
                yposheld = e.GetCurrentPoint(null).Position.Y;
            }
            Debug.WriteLine("Pressed " + ispressed);

            if (ispressed == 2)
            {
                board.AllBalls[0].updatespeed();
            }

            //When pointer is pressed
        }

        public void pointmoved(object sender, PointerRoutedEventArgs e)
        {
            //double xpos, ypos;
            //xpos = 0;
            //ypos = 0;
            if (ispressed == 1 && pressed)
            {
                xpos = e.GetCurrentPoint(null).Position.X;
                ypos = e.GetCurrentPoint(null).Position.Y;
                setTrail(xposheld, yposheld, xpos, ypos);
            }
            //When pointer is moved
        }

        public void pointreleased(object sender, PointerRoutedEventArgs e)
        {
            if (ispressed == 1)
            {
                xposrelease = e.GetCurrentPoint(null).Position.X;
                yposrelease = e.GetCurrentPoint(null).Position.Y;
                board.AllBalls[0].setvelocity(xposheld, yposheld, xposrelease, yposrelease);
                Debug.WriteLine("Released");
                board.gamestart = true;
                Trail = 0;
                pressed = false;
            }


            //When pointer is released
        }

        public void setTrail(double x1, double y1, double x2, double y2)
        {
            double dist = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (dist > 600)
            {
                Trail = 6;
            }
            Trail = (int)dist / 100;
            trailx = x1 - x2;
            traily = y1 - y2;
        }

    }





}
