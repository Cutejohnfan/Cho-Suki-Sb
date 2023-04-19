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
    public class Transition0 : StoryboardObjectGenerator
    {
        StoryboardLayer layer;
        
        [Configurable]
        public float debugYvalue = 0;

        [Configurable]
        public int debugYvalue2 = 0;

        [Configurable]
        public float debugXvalue = 0;

        [Configurable]
        public int debugXvalue2 = 0;
        public void slide()
        {
            var offset = 330;
            var offset2 = 517;

            layer = GetLayer("RightSided");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.ScaleVec(0,2000,500);
            sprite.Color(0,"#FCBACB");
            sprite.Rotate(0,-0.174533);

            var sprite2 = layer.CreateSprite("sb/p.png");
            sprite2.ScaleVec(0,2000,500);
            sprite2.Color(0,"#FCBACB");
            sprite2.Rotate(0,-0.174533);

            sprite.Fade(0,0);
            sprite2.Fade(0,0);

            sprite.Fade(9140,1);
            sprite2.Fade(9140,1);

            sprite.Fade(14958,0);
            sprite2.Fade(14958,0);

            sprite.Move(OsbEasing.OutQuart,9140,9140+800,320,-3-330,320,10);
            sprite2.Move(OsbEasing.OutQuart,9140,9140+800,320,482+330,320,517);

            

        }

        public void heartexpands(int starttime)
        {

            string[] RandomColor = {"#F3F3F3","#74BDCB","#FF75D8","#FFA384","#B5E5CF","#3D5B59"};

            var RandomColorPick = RandomColor[Random(0,4)];
            layer = GetLayer("HeartsExpands");
            var sprite = layer.CreateSprite("sb/heart.png",OsbOrigin.Centre);    
            sprite.Scale(starttime,starttime+300,0,2.5);
            sprite.MoveY(starttime,264);
            sprite.Color(starttime,RandomColorPick);

        }

        public void firstintro()
        {
            layer = GetLayer("Hearts");
            var sprite = layer.CreateSprite("sb/p.png");

        }

        public void scenebridge(int starttime, int endtime)
        {
            layer = GetLayer("SceneBridges2");
            var sprite = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);   
            sprite.Scale(starttime,1000);
            sprite.Color(starttime,"#ADD8E6");
            sprite.Fade(starttime,1);

            if(starttime==49867)
            {
                sprite.Fade(64776,0);
                layer = GetLayer("SceneBridges2");
                var position = new Vector2(320,264);
                var sprite2a = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                var sprite2b = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                var sprite2c = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                var sprite2d = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   

                    // var spritemiddleforgot = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   

                    //Consider centerleft
                var sprite2e = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                var sprite2f = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                var sprite2g = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                var sprite2h = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);  

                var start1 = 64412;
                var start2 = 64776;
                var start3 = 65140;
                var start4 = 65503;
                // var startmiddle = 

                sprite2a.Color(start1,"CBE4F9");
                sprite2a.Fade(start1,start2+363,1,1);
                sprite2a.ScaleVec(start1,1600,530);
                sprite2a.MoveX(OsbEasing.InQuad,start1,start1+363,-533,1175);

                sprite2b.Color(start2,"EFF9DA");
                sprite2b.Fade(start2,start3+363,1,1);
                sprite2b.ScaleVec(start2,1600,530);
                sprite2b.MoveX(OsbEasing.InQuad,start2,start2+363,-533,1175);

                sprite2c.Color(start3,"F9EBDF");
                sprite2c.Fade(start3,start4+363,1,1);
                sprite2c.ScaleVec(start3,1600,530);
                sprite2c.MoveX(OsbEasing.InQuad,start3,start3+363,-533,1175);

                sprite2d.Color(start4,"D6CDEA");
                sprite2d.Fade(start4,66594+363,1,1);
                sprite2d.ScaleVec(start4,1600,530);
                sprite2d.MoveX(OsbEasing.InQuad,start4,start4+363,-533,1175);


                var start5 = 65867;
                var start6 = 66231;
                var start7 = 66594;
                var start8 = 66958;

                //Consider 750,-107); Move
                //Consider 1720,530); scale

                sprite2e.Color(start5,"CBE4F9");
                sprite2e.Fade(start5,start5+363+363,1,1);
                sprite2e.ScaleVec(start5,1600,530);
                sprite2e.MoveX(OsbEasing.InQuad,start5,start5+363,-533,1175);

                sprite2f.Color(start6,"EFF9DA");
                sprite2f.Fade(start6,start6+363+363,1,1);
                sprite2f.ScaleVec(start6,1600,530);
                sprite2f.MoveX(OsbEasing.InQuad,start6,start6+363,-533,1175);

                sprite2g.Color(start7,"F9EBDF");
                sprite2g.Fade(start7,start7+363+363,1,1);
                sprite2g.ScaleVec(start7,1600,530);
                sprite2g.MoveX(OsbEasing.InQuad,start7,start7+363,-533,1175);

                sprite2h.Color(start8,"D6CDEA");
                sprite2h.Fade(start8,68958,1,1); 
                sprite2h.ScaleVec(start8,1600,530);
                sprite2h.MoveX(OsbEasing.InQuad,start8,start8+363,-533,1175);

                var time0 = 67321;
                string[] colors = {"CBE4F9","EFF9DA","F9EBDF","D6CDEA"};
                for(int i=0;i<=3;i++)
                {

                    var spriteEnd = layer.CreateSprite("sb/p.png",OsbOrigin.CentreRight,position);   
                    spriteEnd.Color(time0,colors[i]);
                    spriteEnd.Fade(time0,time0+(363*2),1,1);
                    spriteEnd.ScaleVec(time0,1600,530);
                    spriteEnd.MoveX(OsbEasing.InQuad,time0,time0+363,-533,1175);
                    time0+=363;
                }

                var increment = 0;
                var flip = false;
                var time = 67321;
                for(int i = 0; i<=8;i++)
                {   //108 intervals
                    //240 center
                    var x = -54 + increment;
                    var newposition = new Vector2(x,240);
                    var bar = layer.CreateSprite("sb/p.png",OsbOrigin.Centre,newposition);  
                    bar.ScaleVec(time,108,480);
                    bar.Fade(time,1);
                    bar.Color(time,"FCBACB");
                    if(flip==false)
                    {
                        flip=true;
                        bar.MoveY(OsbEasing.Out,time,time+182,-248,240);
                    }
                    else if(flip==true)
                    {
                        flip=false;
                        bar.MoveY(OsbEasing.Out,time,time+182,726,240);
                    }

                    bar.Fade(69049,0); 
                    

                    increment+=108;
                    time+=182;
                }

                

            }
            else if(starttime==180776)
            {
                layer = GetLayer("SceneBridges2");
                var sprite2 = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);   
                
            }

        }

        public void scenebridge2()
        {
            string[] colors = {"CBE4F9","EFF9DA","F9EBDF",
                               "D6CDEA","CBE4F9","EFF9DA",
                               "F9EBDF","D6CDEA","CBE4F9",
                               "EFF9DA","F9EBDF","D6CDEA"};
            var time = 198231;
            for(int i = 0; i<12;i++)
            {
                var position = new Vector2(320,264);
                var sprite = layer.CreateSprite("sb/p.png",OsbOrigin.CentreLeft,position); 

                if(i==11)
                {
                    Log("run?");
                    sprite.Fade(time,204412,1,1);
                    sprite.Fade(204412,0);
                    sprite.ScaleVec(time,1600,530);
                    sprite.Color(time,colors[i]);
                    sprite.MoveX(OsbEasing.InQuad,time,time+363,747,-220);
                }
                else
                {
                    sprite.Fade(time,time+363+363,1,1);
                    sprite.ScaleVec(time,1600,530);
                    sprite.Color(time,colors[i]);
                    sprite.MoveX(OsbEasing.InQuad,time,time+363,747,-220);
                }

                time += 363;
            }


            var increment = 0;
            var flip = false;
            var time1 = 201140;
            for(int i = 0; i<=8;i++)
            {   //108 intervals
                //240 center
                // var x = -54 + increment;
                var x = (810-108) + increment;
                var newposition = new Vector2(x,240);
                var bar = layer.CreateSprite("sb/p.png",OsbOrigin.Centre,newposition);  
                bar.ScaleVec(time1,108,480);
                bar.Fade(time1,1);
                bar.Color(time1,"FCBACB");
                Log(newposition.X);
                if(flip==false)
                {
                    flip=true;
                    bar.MoveY(OsbEasing.Out,time1,time1+182,-248,240);
                }
                else if(flip==true)
                {
                    flip=false;
                    bar.MoveY(OsbEasing.Out,time1,time1+182,726,240);
                }

                bar.Fade(204412,0); 
                

                increment-=108;
                time1+=182;
            }

            var lastpositionfr = new Vector2(320,240);
            var lasttransition = layer.CreateSprite("sb/p.png",OsbOrigin.BottomCentre,lastpositionfr);  
            lasttransition.ScaleVec(202594,853,265);
            lasttransition.MoveY(OsbEasing.OutQuad,202594,202594+300,-1,264);
            lasttransition.Fade(202594,204412,1,1);
            lasttransition.Color(202594,"#FFD580");

            var lasttransition2 = layer.CreateSprite("sb/p.png",OsbOrigin.TopCentre,lastpositionfr);  
            lasttransition2.ScaleVec(202594,853,265);
            lasttransition2.MoveY(OsbEasing.OutQuad,202594,202594+300,482,264);
            lasttransition2.Fade(202594,204412,1,1);
            lasttransition2.Color(202594,"#FFD580");


        }

        public void ThirdKiaiTransition()
        { 
            var starttime = 68776;
            var constant = 300;
            layer = GetLayer("SceneBridges3");

            var PointXleft = 68;
            var PointYleft = 240;
            var viggeteleft = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);  
            viggeteleft.ScaleVec(starttime,starttime+constant,450+(25+(10)),1000,450+(25+(10)),1000);
            viggeteleft.Color(starttime,starttime+constant,"#FFD580","#FFD580");
            viggeteleft.Fade(starttime,1);
            viggeteleft.Move(OsbEasing.OutQuart,starttime,starttime+constant,992,PointYleft,
                                                                             562,PointYleft);

            var PointXright = 565;
            var PointYright = 240;
            var viggeteright = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            viggeteright.ScaleVec(starttime,starttime+constant,450+(25),1000,450+(25),1000);
            viggeteright.Color(starttime,starttime+constant,"#FFD580","#FFD580 ");
            viggeteright.Fade(starttime,1);
            viggeteright.Move(OsbEasing.OutQuart,starttime,starttime+constant,-347,PointYright,
                                                                             83,PointYright);
            if(starttime==68776)
            {
                viggeteleft.Fade(70231,0);
                viggeteright.Fade(70231,0);
            }

        }

        public void After2ndKiai()
        { 
            var starttime = 180776;
            layer = GetLayer("SceneBridges3");
            var sprite = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);   
            sprite.Scale(180776,1000);
            sprite.Color(180776,"#ADD8E6");
            sprite.Fade(180776,193140,1,1);

            var vege2  = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);   
            vege2.ScaleVec(192412,2000,1000);
            vege2.Rotate(192412,-0.523599);
            vege2.Color(192412,"#CBC3E3");
            vege2.MoveX(OsbEasing.OutQuad,192412,192412+300,1865,600);
            vege2.MoveY(192412,100);
            vege2.Fade(192412,198958,1,1);

        }
        public void kiaivege(int starttime, int endtime)
        {
            layer = GetLayer("Kiai");
            var vege = layer.CreateSprite("sb/v.png",OsbOrigin.Centre);   
            vege.Scale(starttime,0.47);
            vege.Color(starttime,"#FFB6C1");
            vege.Fade(starttime,starttime+546,0,0.5);
            vege.Fade(endtime,0);
        }

        public void lasttransitioniwantsleep()
        {
            layer = GetLayer("Kiai");
            var starttime = 287503;
            var endtime = 288412;

            var up = layer.CreateSprite("sb/p.png",OsbOrigin.BottomCentre);   
            up.ScaleVec(287503,855,265);
            up.MoveY(287503,265);
            up.MoveX(OsbEasing.OutQuad,287503,287503+363,-545,320);
            up.Fade(0,0);
            up.Fade(287503,endtime,1,1);
            up.Color(287503,"FCBACB");

            var down = layer.CreateSprite("sb/p.png",OsbOrigin.TopCentre);   
            down.ScaleVec(287503,855,265);
            down.MoveY(287503,265);
            down.MoveX(OsbEasing.OutQuad,287503,287503+(363),debugXvalue,debugYvalue);
            down.Fade(0,0);
            down.Fade(287503,endtime,1,1);
            down.Color(287503,"FCBACB");

            var counterwhat = 0;

        }


        public override void Generate()
        {
		    slide();
            ThirdKiaiTransition();
            scenebridge(49867,70231);
            scenebridge(180776,204412);
            kiaivege(81321,87685);
            kiaivege(244231,250594);
            After2ndKiai();
            scenebridge2();
            lasttransitioniwantsleep();
            // heartexpands(13503);
            // heartexpands(13685);
            // heartexpands(13867);
            // heartexpands(14049);
            // heartexpands(14231);
            // heartexpands(14412);
            // heartexpands(14594);
            // heartexpands(14776);
            
        }
    }
}
