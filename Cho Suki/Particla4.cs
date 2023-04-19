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
    public class Particla4 : StoryboardObjectGenerator
    {
        public override void Generate()
        {            
            
            int starttime2 = 273867;
            var endTime = 297140;
            var beatDivisor = 1;
            int distanceInterval = 100;
            bool phasetwo = false;

            double timeInterval = Beatmap.GetTimingPointAt(starttime2).BeatDuration / beatDivisor;
            // Log(timeInterval);
            int particleAmount = 5;

            for(double x = starttime2;x<=endTime;x+=timeInterval)
            {
                for(int y = 0; y<=particleAmount;y++)
                {
                    Vector2 startPosition = new Vector2(Random(-107,747), Random(480,700));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);
                    var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);
                    sprite.Scale(x, 0.05);
                    int currentTime = (int)x;
                    if(currentTime<285503) 
                    {
                        while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < 297140) //Delayed by 1/1
                        {
                            sprite.Fade(x,1);
                            if(currentTime>285503 && currentTime<288412) //Works
                            {
                                phasetwo = true;
                                break;
                                // timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
                                // sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + 0);
                                // sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - 0);
                                // currentTime += (int)timeInterval;
                                // continue;
                            }
                            else
                            {
                                timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
                                sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - distanceInterval);
                                currentTime += (int)timeInterval;
                                beatDivisor=1;

                                if(sprite.PositionAt(currentTime).Y <=0)
                                {
                                    sprite.Fade(currentTime,0);
                                }
                                else
                                {
                                    // sprite.Fade(173503,0);
                                }
                            }


                            if(sprite.PositionAt(currentTime).Y <=0)
                                {
                                    sprite.Fade(currentTime,0);
                                    break;
                                }
                                else
                                {
                                    // sprite.Fade(173503,0);
                                }
                        }

                        if(phasetwo==true)
                        {
                            for(int nani = 288412;nani<=endTime;nani+=363)
                            {
                                sprite.Rotate(OsbEasing.Out, nani, nani + 363, sprite.RotationAt(nani), sprite.RotationAt(nani) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out,nani,nani + 363, sprite.PositionAt(nani).Y, sprite.PositionAt(nani).Y - distanceInterval);

                                if(sprite.PositionAt(currentTime).Y <=0)
                                {
                                    sprite.Fade(currentTime,0);
                                }
                                else
                                {
                                    // sprite.Fade(173503,0);
                                }
                            }
                        }


                    }
                }
            }     

            // ORIGINAL START
            int startTimeA = 288412;
            int endTimeA = 297140;
            timeInterval = Beatmap.GetTimingPointAt(startTimeA).BeatDuration / beatDivisor;
            // Log(timeInterval);

            double duration = startTimeA + (timeInterval + Random(0,((endTimeA-startTimeA)/timeInterval)));
            distanceInterval = 100;

            for(double x = startTimeA;x<=endTimeA;x+=timeInterval)
            {
                for(int y = 0; y<=particleAmount;y++)
                {
                    Vector2 startPosition = new Vector2(Random(-107,747), Random(480,600));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);

                    var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);

                    sprite.Scale(x, 0.05);
                    int currentTime = (int)x;
                        while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < endTimeA) //Delayed by 1/1
                        {
                            sprite.Fade(x,1);
                            beatDivisor = 1;
                            timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
                            sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + MathHelper.DegreesToRadians(Random(10,65)));
                            sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - distanceInterval);
                            currentTime += (int)timeInterval;

                            if(sprite.PositionAt(currentTime).Y<=0) //Breaks loop when above threshold
                            {
                                sprite.Fade(currentTime,0);
                                break;
                            }
                            else
                            {
                                // sprite.Fade(169140,0);
                            }
                        }
                    
                }
            }
            // ORIGINAL END

            
            // int starttime2 = 166231;
            // beatDivisor = 0.5;
            // bool phasetwo = false;
            // for(double x = starttime2;x<=endTime;x+=timeInterval)
            // {
            //     for(int y = 0; y<=particleAmount;y++)
            //     {
            //         Vector2 startPosition = new Vector2(Random(-107,747), Random(480,700));
            //         Vector2 endPosition = new Vector2(Random(-115,750), 0);
            //         var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);
            //         sprite.Scale(x, 0.05);
            //         int currentTime = (int)x;
            //         if(currentTime<170594) 
            //         {
            //             while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < 171685) //Delayed by 1/1
            //             {
            //                 sprite.Fade(x,1);
            //                 if(currentTime>170594 && currentTime<171958) //Works
            //                 {
            //                     phasetwo = true;
            //                     break;
            //                     // timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
            //                     // sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + 0);
            //                     // sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - 0);
            //                     // currentTime += (int)timeInterval;
            //                     // continue;
            //                 }
            //                 else
            //                 {
            //                     timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
            //                     sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + MathHelper.DegreesToRadians(Random(10,65)));
            //                     sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - distanceInterval);
            //                     currentTime += (int)timeInterval;
            //                     beatDivisor=0.5;

            //                     if(sprite.PositionAt(currentTime).Y <=0)
            //                     {
            //                         sprite.Fade(currentTime,0);
            //                     }
            //                     else
            //                     {
            //                         // sprite.Fade(173503,0);
            //                     }
            //                 }


            //                 if(sprite.PositionAt(currentTime).Y <=0)
            //                     {
            //                         sprite.Fade(currentTime,0);
            //                         break;
            //                     }
            //                     else
            //                     {
            //                         // sprite.Fade(173503,0);
            //                     }
            //             }

            //             if(phasetwo==true)
            //             {
            //                 for(int nani = 172049;nani<=174958;nani+=363)
            //                 {
            //                     sprite.Rotate(OsbEasing.Out, nani, nani + 363, sprite.RotationAt(nani), sprite.RotationAt(nani) + MathHelper.DegreesToRadians(Random(10,65)));
            //                     sprite.MoveY(OsbEasing.Out,nani,nani + 363, sprite.PositionAt(nani).Y, sprite.PositionAt(nani).Y - distanceInterval);

            //                     if(sprite.PositionAt(currentTime).Y <=0)
            //                     {
            //                         sprite.Fade(currentTime,0);
            //                     }
            //                     else
            //                     {
            //                         // sprite.Fade(173503,0);
            //                     }
            //                 }
            //             }


            //         }
            //     }
            // }         


        //     int starttime3 = 172049;
        //     beatDivisor = 0.5;
        //     bool phasethree = false;
        //     for(double x = starttime3;x<=endTime;x+=timeInterval)
        //     {
        //         for(int y = 0; y<=particleAmount;y++)
        //         {
        //             Vector2 startPosition = new Vector2(Random(-107,747), Random(480,700));
        //             Vector2 endPosition = new Vector2(Random(-115,750), 0);

        //             var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);

        //             sprite.Scale(x, 0.05);
        //             int currentTime = (int)x;
        //             sprite.Fade(x,1);
        //             sprite.Fade(endTime,0);

        //             if(currentTime<174958) 
        //             {
        //                 while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < endTime) //Delayed by 1/1
        //                 {
        //                     beatDivisor=1;
        //                     if(currentTime>174958) //Works
        //                     {
        //                         phasethree = true;
        //                         break;
        //                         // timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
        //                         // sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + 0);
        //                         // sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - 0);
        //                         // currentTime += (int)timeInterval;
        //                         // continue;
        //                     }
        //                     else
        //                     {
        //                         timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;
        //                         sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + MathHelper.DegreesToRadians(Random(10,65)));
        //                         sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - distanceInterval);
        //                         currentTime += (int)timeInterval;
        //                         Log(timeInterval + " Time");
        //                     }


        //                     if(sprite.PositionAt(currentTime).Y<=0) //Breaks loop when above threshold
        //                     {
        //                         sprite.Fade(currentTime,0);
        //                         break;
        //                     }
        //                 }

        //                 if(phasethree==true)
        //                 {
        //                     var emergencynumber = 0;
        //                     for(int nani = 174958;nani<=177867;nani+=2909)
        //                     {
        //                         if(emergencynumber==1)
        //                         {
        //                             sprite.Rotate(OsbEasing.Out, nani, nani+363, sprite.RotationAt(nani+363), sprite.RotationAt(nani+363) + MathHelper.DegreesToRadians(Random(10,65)));
        //                             sprite.MoveY(OsbEasing.Out, nani, nani+363, sprite.PositionAt(nani+363).Y, sprite.PositionAt(nani+363).Y - distanceInterval);
        //                         }
        //                         emergencynumber++;
        //                         sprite.Rotate(OsbEasing.Out, nani + 545, nani + 545+363, sprite.RotationAt(nani + 545), sprite.RotationAt(nani + 545) + MathHelper.DegreesToRadians(Random(10,65)));
        //                         sprite.MoveY(OsbEasing.Out, nani + 545, nani + 545+363, sprite.PositionAt(nani + 545).Y, sprite.PositionAt(nani + 545).Y - distanceInterval);

        //                         sprite.Rotate(OsbEasing.Out, nani + 1091, nani + 1091+363, sprite.RotationAt(nani + 1091), sprite.RotationAt(nani + 1091) + MathHelper.DegreesToRadians(Random(10,65)));
        //                         sprite.MoveY(OsbEasing.Out, nani + 1091, nani + 1091+363, sprite.PositionAt(nani + 1091).Y, sprite.PositionAt(nani + 1091).Y - distanceInterval);

        //                         sprite.Rotate(OsbEasing.Out, nani+ 1636, nani + 1636+363, sprite.RotationAt(nani + 1636), sprite.RotationAt(nani + 1636) + MathHelper.DegreesToRadians(Random(10,65)));
        //                         sprite.MoveY(OsbEasing.Out, nani+ 1636, nani + 1636+363, sprite.PositionAt(nani + 1636).Y, sprite.PositionAt(nani + 1636).Y - distanceInterval);

        //                         sprite.Rotate(OsbEasing.Out, nani+ 2182, nani + 2182+363, sprite.RotationAt(nani+ 2182), sprite.RotationAt(nani+ 2182) + MathHelper.DegreesToRadians(Random(10,65)));
        //                         sprite.MoveY(OsbEasing.Out, nani+ 2182, nani + 2182+363, sprite.PositionAt(nani+ 2182).Y, sprite.PositionAt(nani+ 2182).Y - distanceInterval);

        //                         sprite.Rotate(OsbEasing.Out, nani+ 2545, nani + 2545+363, sprite.RotationAt(nani+ 2545), sprite.RotationAt(nani+ 2545) + MathHelper.DegreesToRadians(Random(10,65)));
        //                         sprite.MoveY(OsbEasing.Out, nani+ 2545, nani + 2545+363, sprite.PositionAt(nani+ 2545).Y, sprite.PositionAt(nani+ 2545).Y - distanceInterval);
        //                     }
        //                 }

        //             }
        //         }
        //     }   


        }
    }
}
