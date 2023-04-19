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
    public class ParticlaSpecial : StoryboardObjectGenerator
    {
        StoryboardLayer layer;
        public override void Generate()
        {
            var particleAmount = 5;
            for(int y = 0; y<=particleAmount;y++)
            {
                for(double x = 174958;x<=180776;x+=363)
                {
                    Vector2 startPosition = new Vector2(Random(-607,750), Random(480,600));
                    Vector2 endPosition = new Vector2(Random(-115,750), 0);
                    var sprite = GetLayer("").CreateSprite("sb/heart.png", OsbOrigin.Centre, startPosition);
                    sprite.Scale(x, 0.05);
                    sprite.Fade(x,1);
                    // sprite.Fade(180776,0);
                    int currentTime = (int)x;
                    int distanceInterval = 100;

                    // Log(x);
                    if(x<=174958)
                    {
                    sprite.Rotate(OsbEasing.Out, 174958, 174958+363, sprite.RotationAt(174958), sprite.RotationAt(174958) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 174958, 174958+363, sprite.PositionAt(174958).Y, sprite.PositionAt(174958).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 174958, 174958+363, sprite.PositionAt(174958).X, sprite.PositionAt(174958).X + distanceInterval); // A
                    }
                    if(x<=174958 + 545)
                    {
                    sprite.Rotate(OsbEasing.Out, 174958 + 545, 174958 + 545+363, sprite.RotationAt(174958 + 545), sprite.RotationAt(174958 + 545) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 174958 + 545, 174958 + 545+363, sprite.PositionAt(174958 + 545).Y, sprite.PositionAt(174958 + 545).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 174958 + 545, 174958 + 545+363, sprite.PositionAt(174958 + 545).X, sprite.PositionAt(174958 + 545).X  +  distanceInterval); // A
                    }
                    if(x<174958 + 1091)
                    {
                    sprite.Rotate(OsbEasing.Out, 174958 + 1091, 174958 + 1091+363, sprite.RotationAt(174958 + 1091), sprite.RotationAt(174958 + 1091) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 174958 + 1091, 174958 + 1091+363, sprite.PositionAt(174958 + 1091).Y, sprite.PositionAt(174958 + 1091).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 174958 + 1091, 174958 + 1091+363, sprite.PositionAt(174958 + 1091).X, sprite.PositionAt(174958 + 1091).X  +  distanceInterval); // A
                    }
                    if(x<174958 + 1636)
                    {
                    sprite.Rotate(OsbEasing.Out, 174958+ 1636, 174958 + 1636+363, sprite.RotationAt(174958 + 1636), sprite.RotationAt(174958 + 1636) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 174958+ 1636, 174958 + 1636+363, sprite.PositionAt(174958 + 1636).Y, sprite.PositionAt(174958 + 1636).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 174958+ 1636, 174958 + 1636+363, sprite.PositionAt(174958 + 1636).X, sprite.PositionAt(174958 + 1636).X  +  distanceInterval); // A
                    }
                    if(x<174958 + 2182)
                    {
                    sprite.Rotate(OsbEasing.Out, 174958+ 2182, 174958 + 2182+363, sprite.RotationAt(174958+ 2182), sprite.RotationAt(174958+ 2182) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 174958+ 2182, 174958 + 2182+363, sprite.PositionAt(174958+ 2182).Y, sprite.PositionAt(174958+ 2182).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 174958+ 2182, 174958 + 2182+363, sprite.PositionAt(174958+ 2182).X, sprite.PositionAt(174958+ 2182).X  +  distanceInterval); // A
                    }
                    if(x<174958 + 2545)
                    {
                    sprite.Rotate(OsbEasing.Out, 174958+ 2545, 174958 + 2545+363, sprite.RotationAt(174958+ 2545), sprite.RotationAt(174958+ 2545) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 174958+ 2545, 174958 + 2545+363, sprite.PositionAt(174958+ 2545).Y, sprite.PositionAt(174958+ 2545).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 174958+ 2545, 174958 + 2545+363, sprite.PositionAt(174958+ 2545).X, sprite.PositionAt(174958+ 2545).X + distanceInterval); // A
                    }
                    if(x<177867)
                    {
                    sprite.Rotate(OsbEasing.Out, 177867, 177867+363, sprite.RotationAt(177867), sprite.RotationAt(177867) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 177867, 177867+363, sprite.PositionAt(177867).Y, sprite.PositionAt(177867).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 177867, 177867+363, sprite.PositionAt(177867).X, sprite.PositionAt(177867).X + distanceInterval); // A

                    if(sprite.PositionAt(177867).Y<=-200)
                    {
                        sprite.Fade(177867,0);
                    }
                    else
                    {
                        sprite.Fade(180776,0);
                    }

                    }
                    if(x<177867 + 545)
                    {
                    sprite.Rotate(OsbEasing.Out, 177867 + 545, 177867 + 545+363, sprite.RotationAt(177867 + 545), sprite.RotationAt(177867 + 545) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 177867 + 545, 177867 + 545+363, sprite.PositionAt(177867 + 545).Y, sprite.PositionAt(177867 + 545).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 177867 + 545, 177867 + 545+363, sprite.PositionAt(177867 + 545).X, sprite.PositionAt(177867 + 545).X + distanceInterval); // A
                    }
                    if(x<177867 + 1091)
                    {
                    sprite.Rotate(OsbEasing.Out, 177867 + 1091, 177867 + 1091+363, sprite.RotationAt(177867 + 1091), sprite.RotationAt(177867 + 1091) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 177867 + 1091, 177867 + 1091+363, sprite.PositionAt(177867 + 1091).Y, sprite.PositionAt(177867 + 1091).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 177867 + 1091, 177867 + 1091+363, sprite.PositionAt(177867 + 1091).X, sprite.PositionAt(177867 + 1091).X + distanceInterval); // A
                    }
                    if(x<177867 + 1636)
                    {
                    sprite.Rotate(OsbEasing.Out, 177867+ 1636, 177867 + 1636+363, sprite.RotationAt(177867 + 1636), sprite.RotationAt(177867 + 1636) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 177867+ 1636, 177867 + 1636+363, sprite.PositionAt(177867 + 1636).Y, sprite.PositionAt(177867 + 1636).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 177867+ 1636, 177867 + 1636+363, sprite.PositionAt(177867 + 1636).X, sprite.PositionAt(177867 + 1636).X + distanceInterval); // A
                    }
                    if(x<177867 + 2182)
                    {
                    sprite.Rotate(OsbEasing.Out, 177867+ 2182, 177867 + 2182+363, sprite.RotationAt(177867+ 2182), sprite.RotationAt(177867+ 2182) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 177867+ 2182, 177867 + 2182+363, sprite.PositionAt(177867+ 2182).Y, sprite.PositionAt(177867+ 2182).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 177867+ 2182, 177867 + 2182+363, sprite.PositionAt(177867+ 2182).X, sprite.PositionAt(177867+ 2182).X + distanceInterval); // A
                    }
                    if(x<177867 + 2545)
                    {
                    sprite.Rotate(OsbEasing.Out, 177867+ 2545, 177867 + 2545+363, sprite.RotationAt(177867+ 2545), sprite.RotationAt(177867+ 2545) + MathHelper.DegreesToRadians(Random(10,65)));
                    sprite.MoveY(OsbEasing.Out, 177867+ 2545, 177867 + 2545+363, sprite.PositionAt(177867+ 2545).Y, sprite.PositionAt(177867+ 2545).Y - distanceInterval);
                    sprite.MoveX(OsbEasing.Out, 177867+ 2545, 177867 + 2545+363, sprite.PositionAt(177867+ 2545).X, sprite.PositionAt(177867+ 2545).X + distanceInterval); // A
                    }
                } 
            }      
        }
    }
}
