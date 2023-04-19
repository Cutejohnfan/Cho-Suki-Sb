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
    public class Oh : StoryboardObjectGenerator
    {
        StoryboardLayer layer;

        public void particlefunction(int startime, int endtime)
        {
            var totalparticle = 10;

            var constant = 3000;
            var totaltimeneeded = constant; // Modify
            var totaltime = endtime-startime;
            var duration_to_loop = totaltime / totaltimeneeded;

            for(int x = startime; x<=endtime; x+=363)
            {
                for(int i = 0; i<=totalparticle; i++)
                {
                    Vector2 startPosition = new Vector2(Random(-107,747), Random(480,1600));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);
                    var rotatevalue = Random(0,6.28319);

                    layer = GetLayer("Oh");
                    var dot = layer.CreateSprite("sb/oh.png");
                    dot.Scale(startime,0.05);
                    dot.Fade(startime,endtime-300,1,1);
                    dot.Fade(endtime-300,endtime,1,0);

                    dot.StartLoopGroup(startime,duration_to_loop);
                    dot.MoveX(0,constant,startPosition.X,endPosition.X);
                    dot.MoveY(0,constant,startPosition.Y,endPosition.Y);
                    dot.Rotate(0,constant,rotatevalue,rotatevalue+Random(0.50000,1.50000));
                    dot.EndGroup();
                }
            }
        }

        public void intro(int startime,int endtime)
        {
            layer = GetLayer("SlowDotDownUp"); 

            int particleAmount = Random(1,4);
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
                y = Random(-300,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 15000;
                var fadeoutput = Random(4000,7000);

                layer = GetLayer("ViegoSaysOh"); 
                var sprite = layer.CreateSprite("sb/oh.png"); 

                // C affects here
                sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);
                sprite.Fade(t+fadeoutput-300,t+fadeoutput,1,0);
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                
                // //0 is top left
                // //X-axis = 0-640 , Y-axis = 0-480

                // var sprite2 = layer.CreateSprite("sb/dot.png"); 
                // sprite2.Fade(t,t+100,0,1);
                // sprite2.Scale(t,t+100,0,rndSCL);
                // sprite2.Fade(t+output2,t+output2,1,0);
                // sprite2.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                

                }


            }

        }

        public override void Generate()
        {

            //particlefunction(154594,172049);
            intro(154594,172049);

		    
            
        }
    }
}
