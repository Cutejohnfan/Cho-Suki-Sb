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
    public class ParticleZ : StoryboardObjectGenerator
    {
        StoryboardLayer layer;

        [Configurable]
        public int debugX = 0;

        [Configurable]
        public int debugY = 0;
        public void AundyHearts(int startime, int endtime)
        {
            int particleAmount = 10;
            var Lifetime = 3000;
            var Speed = 280;

            var Xinit = Random(760,1520);
            var Yinit = Random(-10,490);

            var Xend = Xinit-Xinit-Xinit;
            var Yend = Random(-10,490);

            var totaltime = endtime - startime;

            var duration = (double)(endtime - startime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            for(var x = 0; x<particleAmount; x++)
            {
                var sprite = GetLayer("NameHeart").CreateSprite("sb/heart.png");

                var spawnAngle = Random(Math.PI * 2);
                var spawnDistance = (float)(360 * Math.Sqrt(Random(1f)));

                //var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                var moveDistance = Speed * Lifetime * 0.001f;

                var loopDuration = duration / loopCount;
                var startTime = startime + (x * loopDuration) / particleAmount;

                var endTime = startTime + loopDuration * loopCount;

                sprite.StartLoopGroup(startTime, loopCount);
                sprite.Rotate(0,Random(-0.523598776,0.523598776));
                sprite.Scale(0,0.007);
                sprite.Fade(0,0+Random(0,300),0,1);
                sprite.Fade(3000-Random(300,500),3000,1,0);
                sprite.Move(0,3000,Random(85,155),405,Random(85,155),385);
                sprite.EndGroup();
                

            }

        }

        public void SayuHearts(int startime, int endtime)
        {
            var offset = 25;

            int particleAmount = 10;
            var Lifetime = 3000;
            var Speed = 280;

            var Xinit = Random(760,1520);
            var Yinit = Random(-10,490);

            var Xend = Xinit-Xinit-Xinit;
            var Yend = Random(-10,490);

            var totaltime = endtime - startime;

            var duration = (double)(endtime - startime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            for(var x = 0; x<particleAmount; x++)
            {
                var sprite = GetLayer("NameHeart").CreateSprite("sb/heart.png");

                var spawnAngle = Random(Math.PI * 2);
                var spawnDistance = (float)(360 * Math.Sqrt(Random(1f)));

                //var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                var moveDistance = Speed * Lifetime * 0.001f;

                var loopDuration = duration / loopCount;
                var startTime = startime + (x * loopDuration) / particleAmount;

                var endTime = startTime + loopDuration * loopCount;

                sprite.StartLoopGroup(startTime, loopCount);
                sprite.Rotate(0,Random(-0.523598776,0.523598776));
                sprite.Scale(0,0.007);
                sprite.Fade(0,0+Random(0,300),0,1);
                sprite.Fade(3000-Random(300,500),3000,1,0);
                sprite.Move(0,3000,Random(85-offset,155+offset),405,Random(85-offset,155+offset),385);
                sprite.EndGroup();
                

            }

        }


        public void IntroHearts(int startime, int endtime, int particlecount = 5)
        {
            int particleAmount = particlecount;
            var Lifetime = 3000;
            var Speed = 280;

            var Xinit = Random(760,1520);
            var Yinit = Random(-10,490);

            var Xend = Xinit-Xinit-Xinit;
            var Yend = Random(-10,490);

            var totaltime = endtime - startime;

            var duration = (double)(endtime - startime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            for(int i = startime;i<endtime-500;i+=Random(500,1000))
            {
                for(var x = 0; x<particleAmount; x++)
                {
                    var sprite = GetLayer("Heart").CreateSprite("sb/heart.png");

                    var firstposX = Random(-119,759);
                    var firstposY = Random(-3,482);
                    sprite.Rotate(i,Random(-0.523598776,0.523598776));
                    sprite.Move(i,i+5000,firstposX,firstposY,firstposX+Random(-30,30),firstposY+Random(-30,30) ) ;
                    sprite.Scale(i,0.2);
                    sprite.Fade(i,i+500,0,0.6);
                    sprite.Fade(endtime,0);
                }
            }

        }

        public void Transition(int startime, int endtime)
        {
            //Up -1, Down 480
            //Left -115, Right 750
            int particleAmount = 100;

            for(var x = 0; x<particleAmount; x++)
            {
                var sprite = GetLayer("Heart").CreateSprite("sb/heart.png");
                // sprite.Fade(startime,1);
                sprite.Scale(startime,0.1);

                var Xinit = Random(-115,750);
                Log(Xinit);
                var Yinit = 490;

                var position = new Vector2(Xinit,Yinit);
                float newposition = position.Y;
                float oldposition = position.Y;

                double oldrotation = 0;
                double newrotation = 0;

                sprite.MoveX(startime,position.X);

                var durationBeat = (endtime-startime)/363;
                var RandomTime = startime+(363*(Random(0,durationBeat)));

                int lala0 = RandomTime;
                sprite.Fade(lala0,1);

                for(int lala = lala0; lala<=endtime; lala+=363)
                { 
                    newposition = oldposition - 83;
                    newrotation = oldrotation + Random(0.00000,1.0000000);
                    sprite.MoveY(OsbEasing.OutQuad,lala,lala+363,oldposition,newposition);
                    sprite.Rotate(OsbEasing.OutQuad,lala,lala+363,oldrotation,newrotation);
                    oldposition = newposition;
                    oldrotation = newrotation;

                    if(oldposition<-100)
                    {
                        sprite.Fade(lala,0);
                    }

                }

            }

        }

        public void DebugDot()
        {
            layer = GetLayer("Dot");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Fade(0,1);
            sprite.Fade(311685,0);
            //sprite.Scale(0,10);
            sprite.Color(0,"FFFFFF");
            sprite.Move(0,debugX,debugY);

        }
        public void Circle(int startime, int endtime)
        {
            int particleAmount = 20;
            var Lifetime = 3000;
            var Speed = 280;

            var Xinit = Random(760,1520);
            var Yinit = Random(-10,490);

            var Xend = Xinit-Xinit-Xinit;
            var Yend = Random(-10,490);

            var totaltime = endtime - startime;

            var duration = (double)(endtime - startime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            for(var x = 0; x<particleAmount; x++)
            {
                var sprite = GetLayer("Circle").CreateSprite("sb/cir.png");

                var spawnAngle = Random(Math.PI * 2);
                var spawnDistance = (float)(360 * Math.Sqrt(Random(1f)));

                //var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                var moveDistance = Speed * Lifetime * 0.001f;

                var loopDuration = duration / loopCount;
                var startTime = startime + (x * loopDuration) / particleAmount;

                var endTime = startTime + loopDuration * loopCount;

                var firstposX = Random(-119,759);

                var firstposY = Random(-3,482);

                // var time = Random(startime,endtime-1000);

                var value = Random(0.01,0.1);

                Log("Original: " + value + " Modified: " + (value + 0.06) );

                sprite.Rotate(startime,Random(-0.523598776,0.523598776));
                sprite.Scale(OsbEasing.OutQuart,startime,startTime+50,value+0.03,value);
                sprite.Fade(OsbEasing.OutQuart,startime,startime+300,0,0.3);
                // sprite.Fade(startTime,startTime+Random(100,300),0,0.3);
                //sprite.Fade(endtime-Random(500,1000),endtime,0.3,0);
                sprite.Move(startime,startime+20000,firstposX,firstposY,firstposX+Random(-30,30),firstposY+Random(-30,30) ) ;

                sprite.Fade(endtime,0);
                

            }

        }

        public void CircleNoScale(int startime, int endtime)
        {
            int particleAmount = 20;
            var Lifetime = 3000;
            var Speed = 280;

            var Xinit = Random(760,1520);
            var Yinit = Random(-10,490);

            var Xend = Xinit-Xinit-Xinit;
            var Yend = Random(-10,490);

            var totaltime = endtime - startime;

            var duration = (double)(endtime - startime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            for(var x = 0; x<particleAmount; x++)
            {
                var sprite = GetLayer("Circle").CreateSprite("sb/cir.png");

                var spawnAngle = Random(Math.PI * 2);
                var spawnDistance = (float)(360 * Math.Sqrt(Random(1f)));

                //var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                var moveDistance = Speed * Lifetime * 0.001f;

                var loopDuration = duration / loopCount;
                var startTime = startime + (x * loopDuration) / particleAmount;

                var endTime = startTime + loopDuration * loopCount;

                var firstposX = Random(-119,759);

                var firstposY = Random(-3,482);

                // var time = Random(startime,endtime-1000);

                var value = Random(0.01,0.1);

                Log("Original: " + value + " Modified: " + (value + 0.06) );

                sprite.Rotate(startime,Random(-0.523598776,0.523598776));
                sprite.Scale(startime,value);
                sprite.Fade(OsbEasing.OutQuart,startime,startime+300,0,0.3);
                sprite.Move(startime,endtime+10000,firstposX,firstposY,firstposX+Random(-30,30),firstposY+Random(-30,30) ) ;

                sprite.Fade(endtime,0);

                // Special
                if(startime==154594)
                {
                    sprite.Fade(170594,172049,0.3,0.1);
                    sprite.Fade(OsbEasing.OutQuart,172049,172049+300,0.1,0.3);
                }
                

            }

        }

        public void CircleKiai(int startime, int endtime)
        {
            int particleAmount = 20;
            var Lifetime = 3000;
            var Speed = 280;
// 70231 start //Fade out 87685 // 88049 Scale In
            var Xinit = Random(760,1520);
            var Yinit = Random(-10,490);

            var Xend = Xinit-Xinit-Xinit;
            var Yend = Random(-10,490);

            var totaltime = endtime - startime;

            var duration = (double)(endtime - startime);
            var loopCount = Math.Max(1, (int)Math.Floor(duration / Lifetime));

            for(var x = 0; x<particleAmount; x++)
            {
                var sprite = GetLayer("Circle").CreateSprite("sb/cir.png");

                var spawnAngle = Random(Math.PI * 2);
                var spawnDistance = (float)(360 * Math.Sqrt(Random(1f)));

                //var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                var moveDistance = Speed * Lifetime * 0.001f;

                var loopDuration = duration / loopCount;
                var startTime = startime + (x * loopDuration) / particleAmount;

                var endTime = startTime + loopDuration * loopCount;

                var firstposX = Random(-119,759);

                var firstposY = Random(-3,482);

                // var time = Random(startime,endtime-1000); 87685-70231 // 88049

                var value = Random(0.01,0.1);

                Log("Original: " + value + " Modified: " + (value + 0.06) );

                sprite.Rotate(startime,Random(-0.523598776,0.523598776));
                sprite.Scale(startime,value);
                sprite.Fade(OsbEasing.OutQuart,startime,startime+300,0,0.3);
                sprite.Move(startime,endtime+10000,firstposX,firstposY,firstposX+Random(-30,30),firstposY+Random(-30,30) ) ;

                sprite.Fade(startime+17454,0);
                sprite.Fade(startime+17818,0.3);
                sprite.Scale(OsbEasing.OutQuart,startime+17818,startime+17818+1500+50,value+0.03,value);

                sprite.Fade(endtime-300,endtime,0.3,0);
                

            }

        }

        public override void Generate()
        {
		    
            Circle(14958,26594);
            CircleKiai(70231,119685);
            CircleKiai(233140,308594);
            CircleNoScale(154594,180776);
            // CircleNoScale(233140,250594);
            // CircleNoScale(250958,269503);
            // CircleNoScale(273867,288412);
            // CircleNoScale(288412,308594);
            IntroHearts(9140+363,14958);
            IntroHearts(119685,131322,1);
            // IntroHearts(180776,192412,1);
            // IntroHearts(192412,205503,3);

            AundyHearts(3322,26594);
            SayuHearts(26594,49867);
            AundyHearts(49867,70231);
            SayuHearts(70231,93503);

            DebugDot();
            //Transition(154594,166231);

        }
    }
}
