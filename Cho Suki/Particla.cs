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
    public class Particla : StoryboardObjectGenerator
    {
        [Configurable]
        public double debugXcord = 0;

        [Configurable]
        public double debugYcord = 0;
        
        public override void Generate()
        {
            FontGenerator japaneseFont;
            FontGenerator NoGlow;

            japaneseFont = LoadFont("sb/lyrics3", new FontDescription() // Can just go storybrew to copy paste this
            {
                FontPath = "Mamelon-3-Hi-Regular.otf",
                FontSize = 100, // SizeW
                Color = Color4.White, // Color
                Padding = Vector2.Zero, // Spacing around character
                FontStyle = System.Drawing.FontStyle.Bold, // Font regular,bold,italic,etc
                TrimTransparency = true, // Remove excessive transpacy in font
                EffectsOnly = false,
                Debug = false,
            }
            ,
            new FontGlow()
            {
                Radius = 16,
                Color = new Color4(255,182,193,1),
            }
            );

            // NoGlow = LoadFont("sb/lyrics3", new FontDescription() // Can just go storybrew to copy paste this
            // {
            //     FontPath = "Mamelon-3-Hi-Regular.otf",
            //     // FontSize = 200, // SizeW Original
            //     FontSize = 100,
            //     Color = Color4.White, // Color
            //     Padding = Vector2.Zero, // Spacing around character
            //     FontStyle = System.Drawing.FontStyle.Regular, // Font regular,bold,italic,etc
            //     TrimTransparency = true, // Remove excessive transpacy in font
            //     EffectsOnly = false,
            //     Debug = false,
            // }    
            // );

            int startTime = 154594;
            int endTime = 180776;
            double beatDivisor = 10;
            double timeInterval = Beatmap.GetTimingPointAt(startTime).BeatDuration / beatDivisor;
            int particleAmount = 5;

            double duration = startTime + (timeInterval + Random(0,((endTime-startTime)/timeInterval)));
            int distanceInterval = 100;
            bool trip1 = false;
            int counter1 = 0;


            StoryboardLayer layer;

            layer = GetLayer("Bounce");
            var message = "Wow, oh oh!";
            var texture = japaneseFont.GetTexture(message); 

            var posX = 220;
            var posY = 240;

            var lineWidth = 0f;
            var lineHeight = 0f;

            var letterX = posX - lineWidth * 0.5f;
            var letterY = posY - lineHeight * 0.5f;

            OsbOrigin origin = OsbOrigin.Centre;

            var scale = 0.25;

            var positionright = new Vector2((float)letterX, (float)letterY) 
                    + texture.OffsetFor(origin) * (float)scale;

            var subtitleBeating = layer.CreateSprite(texture.Path, OsbOrigin.Centre,positionright);

            subtitleBeating.Fade(OsbEasing.OutQuad,155322,155322+300,0,1);
            subtitleBeating.Fade(OsbEasing.InQuad,170594,172049,1,0);

            // Custom Beating
            for(double y = 154594;y<165867;y+=363)
            {
                subtitleBeating.Scale(OsbEasing.Out, y, y + 363,scale+0.05,scale);
            }
            for(double y = 166231; y<169867;y+=(363*2))
            {
                subtitleBeating.Scale(OsbEasing.Out, y, y + 363*2,scale+0.05,scale);
            }
            subtitleBeating.Scale(OsbEasing.Out, 170594, 172049,scale+0.05,scale);


            for(double x = startTime;x<=endTime;x+=timeInterval)
            {

                for(int y = 0; y<=particleAmount;y++)
                {
                    Vector2 startPosition = new Vector2(Random(-607,750), Random(480,600));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);

                    var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);
                    // var sprite2 = GetLayer("").CreateSprite("sb/oh.png", OsbOrigin.Centre, startPosition);
                    sprite.Scale(x, 0.05);
                    // sprite2.Scale(x,0.10);
                    int currentTime = (int)x;
                    if(currentTime<165867) 
                    {
                        while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < 165867) //Delayed by 1/1
                        {

                            sprite.Fade(x,1);
                            // sprite2.Fade(x,1);
                            beatDivisor = 1;
                            if(currentTime>=165867)
                            {
                                beatDivisor = 0.5;
                            }
                            timeInterval = Beatmap.GetTimingPointAt(currentTime).BeatDuration / beatDivisor;

                            sprite.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + MathHelper.DegreesToRadians(Random(10,65)));
                            sprite.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - distanceInterval);
                            sprite.MoveX(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).X, sprite.PositionAt(currentTime).X + distanceInterval);

                            // sprite2.Rotate(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.RotationAt(currentTime), sprite.RotationAt(currentTime) + MathHelper.DegreesToRadians(Random(10,65)));
                            // sprite2.MoveY(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).Y, sprite.PositionAt(currentTime).Y - distanceInterval);
                            currentTime += (int)timeInterval;

                            if(currentTime>165867)
                            {
                                beatDivisor = 0.5;
                            }

                            if(sprite.PositionAt(currentTime).Y<=0) //Breaks loop when above threshold
                            {
                                sprite.Fade(currentTime,0);
                                // sprite2.Fade(currentTime,0);
                                break;
                            }
                            else
                            {
                                // sprite.Fade(169140,0);
                            }
                        }
                    }
                }
            }


            int starttime2 = 166231;
            beatDivisor = 0.5;
            bool phasetwo = false;
            for(double x = starttime2;x<=endTime;x+=timeInterval)
            {
                for(int y = 0; y<=particleAmount;y++)
                {
                    Vector2 startPosition = new Vector2(Random(-107,747), Random(480,700));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);
                    var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);
                    sprite.Scale(x, 0.05);
                    int currentTime = (int)x;
                    if(currentTime<170594) 
                    {
                        while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < 171685) //Delayed by 1/1
                        {
                            sprite.Fade(x,1);
                            if(currentTime>170594 && currentTime<171958) //Works
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
                                sprite.MoveX(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).X, sprite.PositionAt(currentTime).X + distanceInterval);
                                currentTime += (int)timeInterval;
                                beatDivisor=0.5;

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
                            for(int nani = 172049;nani<=174958;nani+=363)
                            {
                                sprite.Rotate(OsbEasing.Out, nani, nani + 363, sprite.RotationAt(nani), sprite.RotationAt(nani) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out,nani,nani + 363, sprite.PositionAt(nani).Y, sprite.PositionAt(nani).Y - distanceInterval);
                                sprite.MoveX(OsbEasing.Out, nani, nani + 363, sprite.PositionAt(nani).X, sprite.PositionAt(nani).X + distanceInterval);

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


            int starttime3 = 172049;
            beatDivisor = 0.5;
            bool phasethree = false;
            for(double x = starttime3;x<=endTime;x+=timeInterval)
            {
                for(int y = 0; y<=particleAmount;y++)
                {
                    Vector2 startPosition = new Vector2(Random(-107,747), Random(480,700));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);

                    var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);

                    sprite.Scale(x, 0.05);
                    int currentTime = (int)x;
                    sprite.Fade(x,1);
                    sprite.Fade(endTime,0);

                    if(currentTime<174958) 
                    {
                        while(sprite.PositionAt(currentTime).Y > endPosition.Y || currentTime < endTime) //Delayed by 1/1
                        {
                            beatDivisor=1;
                            if(currentTime>174958) //Works
                            {
                                phasethree = true;
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
                                sprite.MoveX(OsbEasing.Out, currentTime, currentTime + (int)timeInterval, sprite.PositionAt(currentTime).X, sprite.PositionAt(currentTime).X + distanceInterval);
                                currentTime += (int)timeInterval;
                            }


                            if(sprite.PositionAt(currentTime).Y<=0) //Breaks loop when above threshold
                            {
                                sprite.Fade(currentTime,0);
                                break;
                            }
                        }

                        if(phasethree==true)
                        {
                            var emergencynumber = 0;
                            for(int nani = 174958;nani<=177867;nani+=2909)
                            {
                                if(emergencynumber==1)
                                {
                                    sprite.Rotate(OsbEasing.Out, nani, nani+363, sprite.RotationAt(nani+363), sprite.RotationAt(nani+363) + MathHelper.DegreesToRadians(Random(10,65)));
                                    sprite.MoveY(OsbEasing.Out, nani, nani+363, sprite.PositionAt(nani+363).Y, sprite.PositionAt(nani+363).Y - distanceInterval);
                                    sprite.MoveX(OsbEasing.Out, nani, nani+363, sprite.PositionAt(nani+363).X, sprite.PositionAt(nani+363).X + distanceInterval);
                                }
                                emergencynumber++;
                                sprite.Rotate(OsbEasing.Out, nani + 545, nani + 545+363, sprite.RotationAt(nani + 545), sprite.RotationAt(nani + 545) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out, nani + 545, nani + 545+363, sprite.PositionAt(nani + 545).Y, sprite.PositionAt(nani + 545).Y - distanceInterval);
                                sprite.MoveX(OsbEasing.Out, nani + 545, nani + 545+363, sprite.PositionAt(nani + 545).X, sprite.PositionAt(nani + 545).X + distanceInterval);

                                sprite.Rotate(OsbEasing.Out, nani + 1091, nani + 1091+363, sprite.RotationAt(nani + 1091), sprite.RotationAt(nani + 1091) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out, nani + 1091, nani + 1091+363, sprite.PositionAt(nani + 1091).Y, sprite.PositionAt(nani + 1091).Y - distanceInterval);
                                sprite.MoveX(OsbEasing.Out, nani + 1091, nani + 1091+363, sprite.PositionAt(nani + 1091).X, sprite.PositionAt(nani + 1091).X + distanceInterval);

                                sprite.Rotate(OsbEasing.Out, nani+ 1636, nani + 1636+363, sprite.RotationAt(nani + 1636), sprite.RotationAt(nani + 1636) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out, nani+ 1636, nani + 1636+363, sprite.PositionAt(nani + 1636).Y, sprite.PositionAt(nani + 1636).Y - distanceInterval);
                                sprite.MoveX(OsbEasing.Out, nani+ 1636, nani + 1636+363, sprite.PositionAt(nani + 1636).X, sprite.PositionAt(nani + 1636).X + distanceInterval);

                                sprite.Rotate(OsbEasing.Out, nani+ 2182, nani + 2182+363, sprite.RotationAt(nani+ 2182), sprite.RotationAt(nani+ 2182) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out, nani+ 2182, nani + 2182+363, sprite.PositionAt(nani+ 2182).Y, sprite.PositionAt(nani+ 2182).Y - distanceInterval);
                                sprite.MoveX(OsbEasing.Out, nani+ 2182, nani + 2182+363, sprite.PositionAt(nani+ 2182).X, sprite.PositionAt(nani+ 2182).X + distanceInterval);

                                sprite.Rotate(OsbEasing.Out, nani+ 2545, nani + 2545+363, sprite.RotationAt(nani+ 2545), sprite.RotationAt(nani+ 2545) + MathHelper.DegreesToRadians(Random(10,65)));
                                sprite.MoveY(OsbEasing.Out, nani+ 2545, nani + 2545+363, sprite.PositionAt(nani+ 2545).Y, sprite.PositionAt(nani+ 2545).Y - distanceInterval);
                                sprite.MoveX(OsbEasing.Out, nani+ 2545, nani + 2545+363, sprite.PositionAt(nani+ 2545).X, sprite.PositionAt(nani+ 2545).X + distanceInterval);
                            }
                        }

                    }
                }
            }   


        }
    }
}
