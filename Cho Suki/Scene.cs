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
    public class Scene : StoryboardObjectGenerator
    {
        [Configurable]
        public float debugXvalue = 0;

        [Configurable]
        public float debugYvalue = 0;


        StoryboardLayer layer;

        public void debugdot(){

        layer = GetLayer("Editor");
        var editor = layer.CreateSprite("sb/p.png");
        editor.ScaleVec(0,312025,5,5,5,5);
        editor.Fade(0,1);
        editor.Fade(312025,0);
        editor.Color(0,312025,"#FF0000","#FF0000");
        // editor.Move(0,debugXvalue,debugYvalue);
        
        ////Up -3, Down 482, Left = -119, Right 759
        editor.MoveY(0,264); //Default area

        }


        public void heart(){

            layer = GetLayer("Heart");
            var editor = layer.CreateSprite("sb/heart.png");
            editor.ScaleVec(0,214034,1,1,1,1);
            editor.Fade(0,1);
            editor.Fade(214034,0);
            editor.Color(0,214034,"#E55B13","#E55B13");

        }

        public void main()
        {
            layer = GetLayer("Main");
            var editor = layer.CreateSprite("D7xzWsbJ_2x.jpg");


            editor.Scale(OsbEasing.OutQuad,14958,14958+300, 0.45,0.396 ) ;

            editor.Fade(0,0);
            editor.Fade(14958,1);
            editor.Fade(214034,0);
        }

        public void flash(int startime)
        {
            layer = GetLayer("Flash");
            var flashe = layer.CreateSprite("sb/p.png");
            flashe.Scale(startime,1000);
            flashe.Fade(startime,startime+200,0.4,0);
        }

        public void Movement1()
        {
            var rate = 50;
            var Xoffset = 30;
            int startTime = 14958;
            int endTime = 308776;

            layer = GetLayer("ShakeBg");
            var sprite = layer.CreateSprite("D7xzWsbJ_2x.jpg");
            sprite.Scale(startTime, 480/900.0);
            sprite.Scale(OsbEasing.OutQuad,startTime,startTime+600,0.55,0.432);

            layer = GetLayer("Blur");
            var blur = layer.CreateSprite("sb/blur.jpg");
            blur.Scale(startTime, 480/900.0);
            blur.Scale(OsbEasing.OutQuad,startTime,startTime+600,0.55,0.432);

            var singlecolor = layer.CreateSprite("sb/p.png");
            singlecolor.Scale(0,1000);
            singlecolor.Color(0,"#FCBACB");
            singlecolor.Fade(0,0);

            //Modify fades here
            sprite.Fade(startTime,1);
            blur.Fade(startTime,startTime+500,1,0);

            sprite.Fade(26594,0);
            blur.Fade(26594,1);

            sprite.Fade(38231,1);
            blur.Fade(OsbEasing.OutQuad,38231,38231+500,1,0.5);

            sprite.Fade(49867,0);
            blur.Fade(49867,0);

            sprite.Fade(70231,1);

            sprite.Fade(87685,0);
            blur.Fade(87685,0);

            sprite.Fade(88049,1);
            blur.Fade(OsbEasing.OutQuad,88049,88049+300,1,0);

            sprite.Scale(OsbEasing.OutQuad,88049,88049+600,0.55,0.432);
            blur.Scale(OsbEasing.OutQuad,88049,88049+600,0.55,0.432);

            blur.Fade(OsbEasing.InQuad,89140,90594,0,1);
            //blur.Fade(93503,0);
            blur.Fade(OsbEasing.OutCirc,93503,93503+300,1,0);

            blur.Fade(OsbEasing.InQuad,105140,106594,0,1);
            blur.Fade(OsbEasing.OutQuad,110958,110958+300,1,0);

            blur.Fade(119685,0);
            sprite.Fade(119685,0);



            sprite.Fade(170594,172049,1,0.3);
            sprite.Fade(OsbEasing.OutQuad,172049,172049+300,0.3,1);


            // singlecolor.Fade(119685,1); 
            // singlecolor.Fade(131322,0); 
            blur.Fade(131322,1);

            blur.Fade(180776,0);
            sprite.Fade(180776,0);
            // singlecolor.Fade(180776,1);

            blur.Fade(OsbEasing.InQuad,217140,217140+500,0,1);

            sprite.Fade(154594,1); 
            blur.Fade(OsbEasing.OutQuad,154594,154594+300,1,0);

            blur.Fade(222958,222958+500,1,0);
            // blur.Fade(OsbEasing.OutQuad,223322,223322+500,0,1);


            sprite.Fade(250594,0);
            sprite.Fade(250958,1);
            blur.Fade(OsbEasing.OutQuad,250958,250958+300,1,0);
            sprite.Scale(OsbEasing.OutQuad,250958,250958+600,0.55,0.432);
            blur.Scale(OsbEasing.OutQuad,250958,250958+600,0.55,0.432);

            blur.Fade(OsbEasing.InQuad,252049,253503,0,1);
            blur.Fade(OsbEasing.OutCirc,256412,256412+300,1,0);

            blur.Fade(233140,0);
            sprite.Scale(OsbEasing.OutQuad,233140,233140+600,0.55,0.432);
            sprite.Fade(233140,1); 
            sprite.Fade(269503,0);
            sprite.Fade(273867,1);
            sprite.Fade(308594,308594+300,1,0); 
            blur.Fade(OsbEasing.InQuad,268049,269503,0,1);
            blur.Fade(OsbEasing.OutQuad,273867,273867+300,1,0);
            


            int[] xCord = new int[]{ // The 3 possible x cord to move
            270+Xoffset,280+Xoffset,290+Xoffset
            };

            int[] yCord = new int[]{// The 3 possible y cord to move
                220,250,260
            };

            double[] rotation = new double[]{  // The 3 possible rotation
                0.02, 0.04, 0.06
            };

            var previousCord = new Vector2(280,250);

            double previousRotation = 0;

            var loopTime = (endTime-startTime)/rate;

            for(int i = 0; i < rate; i++){

                var xCordInd = Random(3); // Generates which x cord to move

                var yCordInd = Random(3);// Generates which y cord to move

                var rotInd = Random(3);// Generates which rotation to use

                var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

                sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
                blur.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

                previousCord = tempCord;

                var tempRot = rotation[rotInd];

                sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);
                blur.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

                previousRotation = tempRot;
            }
        }     

        public void updownblackbars(int starttime, int endtime){
            var offset = 30;
            layer = GetLayer("BlackBars");
            var blackbars1 = layer.CreateSprite("sb/p.png");
            blackbars1.ScaleVec(starttime,40,1000);
            blackbars1.Fade(starttime,1);
            blackbars1.Fade(OsbEasing.OutQuad,endtime,endtime+450,1,0);
            var rotateangle1 = MathHelper.DegreesToRadians(90);
            blackbars1.Rotate(starttime,rotateangle1);
            blackbars1.Move(OsbEasing.OutQuad,starttime,starttime+450,320,20-offset,320,20);
            blackbars1.Move(OsbEasing.OutQuad,endtime,endtime+450,320,20,320,20-offset);
            blackbars1.Color(starttime,"#000000");

            var blackbars2 = layer.CreateSprite("sb/p.png");
            blackbars2.ScaleVec(starttime,40,1000);
            blackbars2.Fade(starttime,1);
            blackbars2.Fade(OsbEasing.OutQuad,endtime,endtime+450,1,0);
            var rotateangle2 = MathHelper.DegreesToRadians(90);
            blackbars2.Rotate(starttime,rotateangle2);
            blackbars2.Move(OsbEasing.OutQuad,starttime,starttime+450,320,460+offset,320,460);
            blackbars2.Move(OsbEasing.OutQuad,endtime,endtime+450,320,460,320,460+offset);
            blackbars2.Color(starttime,"#000000");
        }

        public void slowflash(int starttime)
        {
            layer = GetLayer("Flash");
            var sprite = layer.CreateSprite("sb/p.png");
            sprite.Scale(starttime,1000);
            sprite.Color(starttime-500,"#FFFFFF");
            sprite.Fade(starttime-500,starttime,0,1);
            sprite.Fade(starttime,starttime+300,1,0);

        }

        public void haha()
        {
            layer = GetLayer("InBetween");
            var inbetweendotandheart = layer.CreateSprite("sb/p.png");
            inbetweendotandheart.Scale(170594,1000);
            inbetweendotandheart.Color(170594,"000000");
            inbetweendotandheart.Fade(170594,172049,0,0.9);
            inbetweendotandheart.Fade(OsbEasing.OutQuad,172049,172049+300,0.9,0);
        }

        public void vege()
        {
            layer = GetLayer("SceneVege");
            var vege = layer.CreateSprite("sb/v.png",OsbOrigin.Centre);   
            vege.Scale(0,0.47);
            vege.Color(0,"#00000");
            vege.Fade(0,0);

            vege.Fade(26594,38231,1,1);
            vege.Fade(OsbEasing.OutQuad,38231,38231+300,0.9,0.4);
            vege.Fade(38231+300,49867,0.4,0.4);


        }

        public override void Generate()
        {
            vege();
            haha();
            updownblackbars(26594,49867);
            updownblackbars(131322,154594); 
		    debugdot();
            heart();

            flash(14958);
            flash(26594);
            flash(131322);
            flash(233140);
            flash(262231);
            flash(288412);
            slowflash(49867);
            slowflash(119685);
            slowflash(180776);
            slowflash(204412);
            Movement1();
            flash(70231);
            
        }
    }
}

