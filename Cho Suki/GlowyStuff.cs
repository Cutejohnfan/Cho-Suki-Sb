using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class GlowyStuff : StoryboardObjectGenerator
    {
        StoryboardLayer layer;
        StoryboardLayer layer2;

        [Configurable]

        public int imtoolazytoadjustrestart = 0;

        [Configurable]

        public int output2value = 0;

        public void intro()
        {
            var starttime = 7850;
            var endtime=15350;
            var particleAmount = Random(2,4);

            string[] typesofcolors = new string[]
            {

                        "#FF7F50","#FFFF8A","#CB8AFF","#97ED6E" // Pink, Purple, Orange

            };

            layer = GetLayer("glow");
            for(int t = starttime; t < endtime; t += 428 ) //How many times it happens, for this case its 5 times/waves
            {
                for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
                {
                    var randomcolor = Random(0,3);
                    var RandomXstart = Random(0,640);
                    var RandomYstart = Random(0,480);

                    

                    var RandomXend = Random(-30,30);
                    var RandomYend = Random(-30,30);

                    double RandomScale = Random(0.000,1.200);

                    var sprite = layer.CreateSprite("sb/leafalt.png"); 
                    sprite.Fade(t+1000,t+2000,0,0.4);
                    //sprite.Fade(endtime,0);
                    sprite.Move(OsbEasing.InQuad,t,t+10000,RandomXstart,RandomYstart,RandomXstart+RandomXend,RandomYstart+RandomYend);
                    sprite.Scale(OsbEasing.InQuad,t,t+5000,0,RandomScale);
                    sprite.Color(t,typesofcolors[randomcolor]);
                    sprite.Additive(t);



                }
            }


        }

        public void pentagram(int starttime, int endtime)
        {
            layer = GetLayer("penta");
            int particleAmount = 1;
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;
            int loopTimes = (endtime - starttime) / 5000;
  
            for(int t = starttime; t < endtime; t += 937 ) //How many times it happens, for this case its 5 times/waves
            {
                for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
                {

                    randomX = Random(-100,754); // Random X axis //also the limit of X
                    randomY = Random(0,480); // Random Y axis //Also the limit of Y
                    rndTime = Random (-400,400); //Random Time

                    var sprite = layer.CreateSprite("sb/pentagon.png"); 

                    string[] typesofcolors = new string[]
                    {

                    "#B9E9C9","#FFFF8A"

                    };

                    var randomtypeofcolorchoose = Random(2);

                    sprite.Color(t + rndTime, typesofcolors[randomtypeofcolorchoose]);

                    rndTET = Random(0, 2*Math.PI);
                    r = Random(10,35);
                    x = randomX + r * Math.Cos(rndTET);
                    y = randomY + r * Math.Sin(rndTET);

                    rndSCL = Random(70,90) / 100.0; //Randomized Scale

                    sprite.Fade(t,t+1000,0.4,0.4);

                    sprite.Scale(t,t+1000,rndSCL,rndSCL);



                    sprite.Rotate(t,t+5000,0,3);
                    sprite.Fade(t+5000,t+5000,0.4,0);
                    sprite.Move(t,t+4500,randomX,590,x,-300);

                }
            }
            
        }
        // public void dot(int starttime, int endtime)
        // {
        //     layer = GetLayer("dot");
        //     var colora = new Color4(67,240,208, 1);
        //     var colorb = new Color4(252, 96, 96, 1);

        //     int particleAmount = Random(25,35);
        //     int randomX, randomY, r, rndTime;
        //     double rndTET, rndSCL;
        //     double x,y;


        //     int loopTimes = (endtime - starttime) / 5000;
  
        //     for(int t = starttime; t < starttime+5000; t += 1000 ) //How many times it happens, for this case its 5 times/waves
        //     {
        //         for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
        //         {

        //             randomX = Random(-100,754); // Random X axis //also the limit of X
        //             randomY = Random(0,480); // Random Y axis //Also the limit of Y
        //             rndTime = Random (-400,400); //Random Time

        //             var sprite = layer.CreateSprite("sb/dot.png"); 

        //             sprite.Color(t + rndTime, "FFFFFF");
        //             sprite.Color(101783,103629,"FFFFFF","#FFFF00");
        //             sprite.Color(105475,"FFFFFF");

        //             sprite.Color(142398,147937,"FFFFFF","#FFFF00");
        //             sprite.Color(149783,"FFFFFF");

        //             rndTET = Random(0, 2*Math.PI);
        //             r = Random(10,35);
        //             x = randomX + r * Math.Cos(rndTET);
        //             y = randomY + r * Math.Sin(rndTET);
        //             rndSCL = Random(5,10) / 100.0; //Randomized Scale

        //             sprite.StartLoopGroup(t + rndTime, loopTimes);
        //             sprite.Fade(0,1000,0,1);
        //             sprite.Scale(0,1000,0,rndSCL);
        //             sprite.Fade(5000,5000,1,0);
        //             //sprite.Scale(4000,5000,1,0);
        //             sprite.Move(0,5000,randomX,490,x,-300);
        //             //sprite.Move(0,5000,randomX,randomY,x,y);
        //             sprite.EndGroup();

        //         }
        //     }
        // }

        public void myowndotbutituseseasingslow(int startime,int endtime)
        {
            layer = GetLayer("SlowDotFront"); 
            layer2 = GetLayer("SlowDotBack"); 

            int particleAmount = Random(5,9);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            for(int t=startime; t<endtime-2000 ; t+=468) // A affects here, t
            {
                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 17000;
                var output2 = 5000;

                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                sprite.Fade(t,1);
                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End
                
                // //0 is top left
                // //X-axis = 0-640 , Y-axis = 0-480

                // var sprite2 = layer.CreateSprite("sb/leafalt.png"); 
                // sprite2.Fade(t,t+100,0,1);
                // sprite2.Scale(t,t+100,0,rndSCL);
                // sprite2.Fade(t+output2,t+output2,1,0);
                // sprite2.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                

                }


            }

        }
        

        public void myowndotbutituseseasingslowtransitiontomedium(int startime,int endtime)
        {
            layer = GetLayer("MediumTransition"); 

            double particlemin = 5;
            double particlemax = 10;
            double particleAmount = Random(particlemin,particlemax);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;
            var snapcalculate = (endtime - startime)/468;

            var slowtomedium = (17000-10000)/snapcalculate;

            var output = 17000;



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
                
                endlife-=slowtomedium;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;
                
                particleAmount = Random(particlemin,particlemax);

                // 
                

                // B affects here

                for(int abc=0; abc<(int)particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                sprite.Fade(t,1);
                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }

                

                output-=slowtomedium;
                particlemin+=0.3;
                particlemax+=0.3;
                


            }

        }

        public void myowndotbutituseseasingmedium(int startime,int endtime)
        {
            int particleAmount = Random(5,9);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            for(int t=startime; t<endtime-3000 ; t+=468) // A affects here, t
            {
                
                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 10000;
                var output2 = 3500;

                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                sprite.Fade(t,1);
                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End

                // // Initializing variables
                // randomX = Random(-100,754); // Random X axis //also the limit of X
                // randomY = Random(500,600); // Random Y axis //Also the limit of Y
                // rndTime = Random (-400,400); //Random Time
                // rndTET = Random(0, 2*Math.PI);
                // r = Random(10,35);
                // x = randomX + r * Math.Cos(rndTET);
                // //y = randomY + r * Math.Sin(rndTET);
                // y = Random(-200,-100);
                // rndSCL = Random(5,10) / 100.0; // Randomized Scale

                // layer = GetLayer("MediumDotBack"); 
                // sprite = layer.CreateSprite("sb/leafalt.png"); 
                // sprite.Fade(t,t+100,0,1);
                // sprite.Scale(t,t+100,0,rndSCL);
                // sprite.Fade(t+output2,t+output2,1,0);
                // sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480

                }


            }

        }

        public void myowndotbutituseseasingmediumtransitiontoslow(int startime,int endtime)
        {
            layer = GetLayer("MediumTransition"); 


            double particlemin = 10;
            double particlemax = 15;
            double particleAmount = Random(particlemin,particlemax);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;

            //Debug is 1875

            var snapcalculate = (endtime - startime)/468; //Debug 4

            var mediumtoslow = (17000-10000)/snapcalculate; //Debug 1750

            var output = 10000;



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {

                particleAmount = Random(particlemin,particlemax);
                
                
                
                endlife+=mediumtoslow;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // 
                

                // B affects here

                for(int abc=0; abc<(int)particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                sprite.Fade(t,1);
                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End
                }

                //

                output+=mediumtoslow;
                particlemin-=0.1;
                particlemax-=0.1;
                


            }

        }

        public void myowndotbutituseseasingmediumtransitiontofast(int startime,int endtime)
        {
            layer = GetLayer("FastTransition"); 


            int particleAmount = Random(15,20);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;
            var snapcalculate = (endtime - startime)/468;

            var mediumtofast = (10000-6000)/snapcalculate;

            var output = 10000;



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
                
                endlife-=mediumtofast;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // 
                

                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,700); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                rndSCL = Random(0.1,0.5);

                //layer = GetLayer("Slowtransition"); 
                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                sprite.Fade(t,1);
                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End
                }

                //

                output-=mediumtofast;
                


            }

        }

        public void myowndotbutituseseasingfasttransitiontomedium(int startime,int endtime)
        {
            layer = GetLayer("FastTransition"); 


            int particleAmount = Random(23,25);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;
            var snapcalculate = (endtime - startime)/468;

        

            var Fasttomedium = (10000-6000)/snapcalculate;

            var output = 6000;

            



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
                
                
                endlife+=Fasttomedium;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // 
                

                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,700); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                sprite.Fade(t,1);
                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End
                }

                //

                output+=Fasttomedium;



            }

        }

        

        public void myowndotbutituseseasingfast(int startime,int endtime, bool altleaf = false)
        {
            int particleAmount = Random(4,8);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            for(int t=startime; t<endtime-1000 ; t+=234) // A affects here, t
            {
                
                // B affects here
                //Log(t);

                if(t>=308594)
                {
                    break;
                }

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 6000;
                var output2 = output2value;



                //Experiemental value
                var randomXinit = Random(-800,-300);
                var randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);


                x = randomXend + Random(0,1000);
                y = Random(-300,-100);
                // End


                // C affects here
                layer = GetLayer("DotFront"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 
                if(altleaf==true)
                {
                    sprite = layer.CreateSprite("sb/leafalt.png"); 
                }
                sprite.Fade(t,1);

                //sprite.Scale(t,t+100,0,rndSCL);


                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End

                if(t>=306776)
                {
                    if(t>=308594)
                    {
                        sprite.Fade(t,0);
                    }
                    else
                    {
                        sprite.Fade(308594,308594+300,1,0);

                    }
                }
                else
                {
                    sprite.Fade(t+output2,t+output2,1,0);

                }

                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //Experiemental value
                randomXinit = Random(-800,-300);
                randomXend = Random(-100,1000);
                randomY = Random(1100,1400); 
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);

                rndSCL = Random(0.1,0.5);

                x = randomXend + Random(0);
                y = Random(-300,-100);
                // End

                layer = GetLayer("FastDotBack"); 
                sprite = layer.CreateSprite("sb/leafalt.png"); 
                if(altleaf==true)
                {   
                    sprite = layer.CreateSprite("sb/leafalt.png"); 
                }
                sprite.Fade(t,1);

                //sprite.Scale(t,t+100,0,rndSCL);
                
                //sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                //Experimental
                sprite.ScaleVec(t,t+output,rndSCL,rndSCL,rndSCL,-rndSCL);
                sprite.Rotate(t,t+3000,Random(0,6.28319),Random(0,6.28319));
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomXinit,randomY,x,y);
                //End

                if(t>=306776)
                {
                    if(t>=308594)
                    {
                        sprite.Fade(t,0);
                    }
                    else
                    {
                        sprite.Fade(308594,308594+300,1,0);

                    }
                }
                else
                {
                    sprite.Fade(t+output2,t+output2,1,0);

                }
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480

                }


            }

        }

        public void myowndotbutituseseasingfasttransition(int startime,int endtime)
        {
            layer = GetLayer("MediumTransition"); 

            int particleAmount = Random(5,10 );
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = 2343; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
               
                endlife-=468;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                

                // 
                

                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 6000;
                var output2 = output2value;


                //layer = GetLayer("Slowtransition"); 
                var sprite = layer.CreateSprite("sb/leafalt.png"); 

            
                // C affects here
                //sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);

                                //Weird?
                                
                                sprite.Fade(endparticleconstant,endparticleconstant+200,1,0); //Why command overlapped when endtime is more than starttime???

                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }
                

            }

        }

        // public void myowndot(int startime,int endtime,int lifespeed)
        // {
        //     // Initializing variables
        //     layer = GetLayer("dot"); 
        //     int particleAmount = Random(25,35);
        //     int randomX, randomY, r, rndTime;
        //     double rndTET, rndSCL;
        //     double x,y;

        //     // Lifespeed affects this stuff: And input is in 4-5 digits, 1,000 - 99,999
        //     // Assuming we set 10,000 as fast, 50,000 is slow
        //     // Hypothetically, the lower the number, the faster it goes and vice versa.

        //     // A) Duration of the particles
        //     // 1870 is 1 beat
        //     // 935 is half beat
        //     // The slower the particle = the earlier it ends

        //     var calculationa = (int)(lifespeed*0.0625 + 1875);

        //     // Fast
        //     // lifespeed * ?? = 2,500
        //     // 10,000 * ?? = 2,500

        //     // Slow
        //     // lifespeed * ?? = 5,000
        //     // 50,000 * ?? = 5,000
        //     // x =  0.0625, y = 1875

        //     // D) Unconvinently, number of particles is also affected by A)
        //     // Ensure that particles are more or less the same even when changing
            
            
            
        //     // B) Spread of particles
        //     var calculationb = lifespeed;
            
        //     // C) Speed
        //     var calculationc = (int)(lifespeed * 0.125 + 3750);
        //     // Shorter number = faster
        //     // It is tested that 5000 is fast

        //     // Fast
        //     // lifespeed * ??? = 5,000
        //     // 10,000 * x + y = 5,000

        //     // Slow
        //     // lifespeed * ??? = 10,000
        //     // 50,000 * x + y = 10,000

        //     //x = 0.125, y = 3750


            

            

        //     for(int t=startime; t<endtime; t+=calculationa) // A affects here, t
        //     {
        //         //("T value now is " + t);
        //         // B affects here

        //         for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
        //         {
        //         // Initializing variables
        //         randomX = Random(-100,754); // Random X axis //also the limit of X
        //         randomY = Random(0,480); // Random Y axis //Also the limit of Y
        //         rndTime = Random (-400,400); //Random Time
        //         rndTET = Random(0, 2*Math.PI);
        //         r = Random(10,35);
        //         x = randomX + r * Math.Cos(rndTET);
        //         y = randomY + r * Math.Sin(rndTET);
        //         rndSCL = Random(5,10) / 100.0; // Randomized Scale


        //         var sprite = layer.CreateSprite("sb/dot.png"); 

        //         // C affects here
        //         sprite.Fade(t,t+100,0,1);
        //         sprite.Scale(t,t+100,0,rndSCL);
        //         sprite.Fade(t+calculationc,t+calculationc+100,1,0);
        //         sprite.Move(t,t+calculationc,randomX,490,x,-300);

        //         }


        //     }



        // }

        // public void musicnotes(int starttime, int endtime)
        // {
        //     var bassclef = "sb/notes/bassclef.png";
        //     var beamnotes = "sb/notes/beamnotes.png";
        //     var flat = "sb/notes/flat.png";
        //     var minim = "sb/notes/minim.png";
        //     var quaver = "sb/notes/quaver.png";
        //     var sharpflat = "sb/notes/sharpflat.png";
        //     var trebleclef = "sb/notes/trebleclef.png";

        //     string[] musicnotes = new string[]
        //     {
        //         bassclef,beamnotes,flat,minim,quaver,sharpflat,trebleclef
        //     };

        //     int particleAmount = Random(10,15);
        //     int randomX, randomY, r, rndTime;
        //     double rndTET, rndSCL;
        //     double x,y;


        //     int loopTimes = (endtime - starttime) / 5000;
  
        //     for(int t = starttime; t < starttime+5000; t += 1000 ) //How many times it happens, for this case its 5 times/waves
        //     {
        //         for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
        //         {

        //             randomX = Random(-100,754); // Random X axis //also the limit of X
        //             randomY = Random(0,480); // Random Y axis //Also the limit of Y
        //             rndTime = Random (-400,400); //Random Time

        //             var randomangleinit = Random(1,10);
        //             var randomangleconversioninit = (randomangleinit*(Math.PI/180));

        //             var randomanglefinan = Random(-1,-10);
        //             var randomangleconversionfinan = (randomanglefinan*(Math.PI/180));

        //             var randomnotes = Random(0,6);

        //             var tempnotes = musicnotes[randomnotes];

        //             var spriteconvertsion = tempnotes;

        //             var sprite = layer.CreateSprite(spriteconvertsion);

        //             sprite.Color(t + rndTime, "FFFFFF");
        //             sprite.Color(101783,103629,"FFFFFF","#FFFF00");
        //             sprite.Color(105475,"FFFFFF");

        //             sprite.Color(142398,147937,"FFFFFF","#FFFF00");
        //             sprite.Color(149783,"FFFFFF");

        //             rndTET = Random(0, 2*Math.PI);
        //             r = Random(10,35);
        //             x = randomX + r * Math.Cos(rndTET);
        //             y = randomY + r * Math.Sin(rndTET);

        //             rndSCL = Random(5,10) / 100.0; //Randomized Scale

        //             sprite.StartLoopGroup(t + rndTime, loopTimes);
        //             sprite.Fade(0,1000,0,1);
        //             sprite.Scale(0,1000,0,rndSCL);
        //             sprite.Fade(5000,5000,1,0);
        //             //sprite.Scale(4000,5000,1,0);
        //             sprite.Move(0,5000,randomX,490,x,-300);
        //             //sprite.Move(0,5000,randomX,randomY,x,y);
        //             sprite.Rotate(0,5000,randomangleconversioninit,randomangleconversionfinan);
        //             sprite.EndGroup();

        //         }
        //     }            


        // }

        public void coverdot(int starttime,int endtime)
        {
            layer = GetLayer("CoverDot");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Scale(starttime,1000);
            sprite.Fade(starttime,endtime,1,1);
            sprite.Color(starttime,"#000000");
        }

        public void coverdotcustom()
        {
            layer = GetLayer("CoverDot");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Scale(222958,1000);
            sprite.Fade(222958,222958+500,0,1);
            sprite.Fade(233140,0);
            sprite.Color(222958,"#000000");
        }

        public void coverdotcustomend()
        {
            layer = GetLayer("CoverDot");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Scale(214231,1000);
            sprite.Fade(214231,1);
            sprite.Fade(217140,217140+500,1,0);
            sprite.Color(214231,"#000000");
        }

        public void lastlastcustomcoverdot()
        {
            layer = GetLayer("CoverDot");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Scale(260776,1000);
            sprite.Fade(260776,1);
            sprite.Fade(262231,0);
            sprite.Color(260776,"#FCBACB");
        }

        public void Calm()
        {
            var starttime = 119685;
            var endtime = 131322;
            layer = GetLayer("SceneBridges2");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Scale(starttime,1000);
            sprite.Fade(starttime,endtime,1,1);
            sprite.Color(starttime,"#ADD8E6");
            sprite.Color(125503,128412,"ADD8E6","FCBACB");
        }

        public override void Generate()
        { //SLOW START 1 BAR EARLY, ENDS 2 BAR EARLY    
        //MEDIUM START 1 BAR EARLY, ENDS 1 BAR EARLY
        //FAST DOESNT NEED, POINT A POINT B.
		//dot(15350,302226); 

        //intro();

        coverdot(87685,88049);
        coverdot(250594,250958);
        coverdot(214231,217140);
        coverdotcustom();
        coverdotcustomend();
        //lastlastcustomcoverdot();
        Calm();


        myowndotbutituseseasingmedium(13503 ,26594);
        myowndotbutituseseasingmediumtransitiontoslow(22958,26594);
        myowndotbutituseseasingslow(26594,33867);
        myowndotbutituseseasingslowtransitiontomedium(32412,38231);
        myowndotbutituseseasingmedium(38231,52776);

        myowndotbutituseseasingfast(68776,105867,true);
        myowndotbutituseseasingfasttransitiontomedium(105140,106594);
        myowndotbutituseseasingmedium(106594,109503);
        myowndotbutituseseasingmediumtransitiontofast(106594,110958);
        myowndotbutituseseasingfast(110958,121140);

        myowndotbutituseseasingmedium(128412,151685);
        myowndotbutituseseasingmediumtransitiontofast(148776,154594);
        myowndotbutituseseasingfast(154594,164776);
        myowndotbutituseseasingfasttransitiontomedium(163322,166231);   
        myowndotbutituseseasingmedium(166231,170594);
        myowndotbutituseseasingmediumtransitiontofast(167685,172049);
        myowndotbutituseseasingfast(172049,180776);

        myowndotbutituseseasingmedium(215685,225867);
        myowndotbutituseseasingfast(231685,268049);
        myowndotbutituseseasingfasttransitiontomedium(267321,269503);
        myowndotbutituseseasingmedium(269503,272412);
        myowndotbutituseseasingmediumtransitiontofast(269503,273867);
        // myowndotbutituseseasingfast(273867,285503);
        // myowndotbutituseseasingfast(288503,307321); 

        myowndotbutituseseasingfast(273867,310231);


        
            
        }
    }
}
