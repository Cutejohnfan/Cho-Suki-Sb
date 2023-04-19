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
    public class ObjectHit : StoryboardObjectGenerator
    {
        [Configurable]
        public double debug1 = 0;

        public void bigcircle(int starttime, int endtime = 0)
        {
            var FadeTime = 200;
            var FadeTime2 = 400;
            var HighlightSpriteScale = 0.2;
            //2 particles left and right
            var layer = GetLayer("Anim");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                var constant = 5;
                var randomdecimal = Random(1.0,2.5);
                Log(randomdecimal);

                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime + 5 <= hitobject.StartTime))
                    continue;

                var intervals=70;
                var hSprite = layer.CreateAnimation("sb/Anim/Ellipse.png",11,intervals,OsbLoopType.LoopOnce, OsbOrigin.Centre);
                hSprite.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                // hSprite.Scale(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + FadeTime, 0, HighlightSpriteScale * 2.2);
                hSprite.Scale(OsbEasing.OutCirc, hitobject.StartTime, hitobject.StartTime + FadeTime + 100 + FadeTime2, 0, HighlightSpriteScale * randomdecimal);

                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 0, 1);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime + FadeTime + 100, hitobject.StartTime + FadeTime + 100 + FadeTime2, 1, 0);

                Log(hitobject.StartTime + " and " + hitobject.EndTime);
            }

        }

        public void bigcirclenoRandom(int starttime, int endtime = 0)
        {
            var FadeTime = 200;
            var FadeTime2 = 400;
            var HighlightSpriteScale = 0.2;
            //2 particles left and right
            var layer = GetLayer("Anim");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                var constant = 5;
                var randomdecimal = 2;
                Log(randomdecimal);

                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime + 5 <= hitobject.StartTime))
                    continue;

                var intervals=70;
                var hSprite = layer.CreateAnimation("sb/Anim/Ellipse.png",11,intervals,OsbLoopType.LoopOnce, OsbOrigin.Centre);
                hSprite.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                // hSprite.Scale(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + FadeTime, 0, HighlightSpriteScale * 2.2);
                hSprite.Scale(OsbEasing.OutCirc, hitobject.StartTime, hitobject.StartTime + FadeTime + 100 + FadeTime2, 0, HighlightSpriteScale * randomdecimal);

                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 0, 1);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime + FadeTime + 100, hitobject.StartTime + FadeTime + 100 + FadeTime2, 1, 0);

                Log(hitobject.StartTime + " and " + hitobject.EndTime);
            }

        }

        public void unobigcircle(int starttime, int endtime = 0)
        {
            var FadeTime = 200;
            var FadeTime2 = 400;
            var HighlightSpriteScale = 0.2;
            //2 particles left and right
            var layer = GetLayer("Anim");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                var constant = 5;
                var randomdecimal = Random(1.0,2.5);
                Log(randomdecimal);

                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime + 5 <= hitobject.StartTime))
                    continue;

                var intervals=35;
                var hSprite = layer.CreateAnimation("sb/AnimReverse/Ellipse.png",29,intervals,OsbLoopType.LoopOnce, OsbOrigin.Centre);
                hSprite.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                // hSprite.Scale(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + FadeTime, 0, HighlightSpriteScale * 2.2);
                hSprite.Scale(OsbEasing.InQuad, hitobject.StartTime, hitobject.StartTime + FadeTime + 100 + FadeTime2, HighlightSpriteScale * randomdecimal, 0);

                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 0, 1);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime + FadeTime + 100, hitobject.StartTime + FadeTime + 100 + FadeTime2, 1, 0);
            }

        }

        public void sparklez(int starttime, int endtime = 0)
        {
            var FadeTime = 200;
            var FadeTime2 = 400;
            var HighlightSpriteScale = 0.2;
            //2 particles left and right
            var layer = GetLayer("Spark");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                var constant = 50;
                var randomdecimal = Random(1.0,2.5);
                Log(randomdecimal);

                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime + 5 <= hitobject.StartTime))
                    continue;
                
                var objectnumberparticles = Random(10,15);
                for(int x = 0; x<=objectnumberparticles; x++)
                {
                    var bass = layer.CreateSprite("sb/dot.png", OsbOrigin.Centre);
                    // //If use Dot...
                    // bass.Scale(hitobject.StartTime,0.15);
                    bass.Scale(hitobject.StartTime,Random(0.01,0.1));
                    bass.Fade(hitobject.StartTime,1);
                    //bass.Color(hitobject.StartTime,"FFB6C1");
                    bass.Move(OsbEasing.OutQuart,hitobject.StartTime,hitobject.EndTime+Random(1000,3000),hitobject.Position.X,hitobject.Position.Y,hitobject.Position.X+Random(-constant,constant),hitobject.Position.Y+Random(-constant,constant));
                    bass.Fade(OsbEasing.OutCirc,hitobject.EndTime+Random(500,1000),hitobject.EndTime+Random(500,1000)+300,1,0);
                    bass.Rotate(hitobject.StartTime,Random(0,6.28319));

                }
            }

        }



        public override void Generate()
        {
            bigcircle(228776,230140);
            bigcirclenoRandom(128412,130594); 
            sparklez(125503,127685);
            sparklez(230231,231685);
            //bigcirclenoRandom(287685,288412);
            // unobigcircle(230231,231685);
            bigcircle(232594,233049);
            
        }
    }
}
