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
    
    public class Lyrica : StoryboardObjectGenerator
    {
        

        StoryboardLayer layer;

        FontGenerator NoGlow;

        FontGenerator NoGlowSmaller;
        

        FontGenerator japaneseFont;
        FontGenerator japaneseFontBlack;

        FontGenerator EnglishFont;

        FontGenerator WesternFont;

        FontGenerator whitejapaneseFont;
        FontGenerator blackjapaneseFont;

        Random rnd;

        [Configurable]
        public double debugX = 0;

        [Configurable]
        public int ahsdaojaj = 0;

        [Configurable]
        public int GlowRadius = 0;

        [Configurable]
        public Color4 GlowColor = new Color4(255, 255, 255, 100);

        [Configurable]
        public bool AdditiveGlow = true;

        [Configurable]
        public int OutlineThickness = 3;

        [Configurable]
        public Color4 OutlineColor = new Color4(50, 50, 50, 200);

        [Configurable]
        public int ShadowThickness = 0;

        [Configurable]
        public Color4 ShadowColor = new Color4(0, 0, 0, 100);

        [Configurable]
        
        public double debugXcord = 0;

        [Configurable]
        
        public double debugYcord = 0;

        int number = 0;
        public void SubtitleLinesCustom1(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF", bool transition=false, bool noglow = false,
                                         bool nomovementwhatsoever = false, bool nogolowsmall = false)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring); 

                    if(nogolowsmall==true)
                    {
                        texture = NoGlowSmaller.GetTexture(charconvertedtostring);                           
                    }  


                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introscaleout = false; // b
                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                bool scaleout = false; // p

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);    

                    if(nogolowsmall==true)
                    {
                        texture = NoGlowSmaller.GetTexture(charconvertedtostring);                           
                    }

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }
                    if(line[i]=='p') // Scaleout at 1/1
                    {
                        scaleout = true;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }
                    if(line[i]=='b') //Intro Custom Position (Scale Big to Normal)
                    {
                        introscaleout = true;
                        continue;
                    }



                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    if(noglow==true)
                    {
                        texture = NoGlow.GetTexture(charconvertedtostring);    
                    }
                    else if(nogolowsmall == true)
                    {
                        Log("Hihi");
                        texture = NoGlowSmaller.GetTexture(charconvertedtostring);       
                    }

                    var scaleoutvalue = 0.4;  

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);

                        if(transition==true)
                        {
                            sprite.Scale(starttime,scale);
                            var timemovement = 1000; // Adjust here
                            var duration = endtime-starttime;
                            var totaltimemovement = timemovement*4;
                            var movementloop = (duration)/totaltimemovement;
                            sprite.StartLoopGroup(starttime,movementloop);
                            sprite.MoveX(0,timemovement,position.X,position.X-10);
                            sprite.MoveX(timemovement,timemovement*2,position.X-10,position.X);
                            sprite.MoveX(timemovement*2,timemovement*3,position.X,position.X+10);
                            sprite.MoveX(timemovement*3,timemovement*4,position.X+10,position.X);

                            // sprite.MoveY(0,movementloop,position.Y,position.Y-10);
                            // sprite.MoveY(movementloop,movementloop*2,position.Y-10,position.Y);
                            // sprite.MoveY(movementloop*2,movementloop*3,position.Y,position.Y+10);
                            // sprite.MoveY(movementloop*3,movementloop*4,position.Y+10,position.Y);
                            sprite.EndGroup();

                            sprite.Fade(endtime-300,endtime,1,0);

                            if(flip==false)
                            {
                                if(scaleout==true)
                                {
                                    letterX += texture.BaseWidth * scaleoutvalue;
                                }
                                else
                                {
                                    letterX += texture.BaseWidth * scale;
                                }

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            if(scaleout==true)
                            {
                                sprite.Scale(starttime+364,scaleoutvalue);
                            }
                            else if(introscaleout==true)
                            {
                                sprite.Scale(OsbEasing.OutQuart,starttime,starttime+1000,scale+0.1,scale);
                            }



                            if(instantfade==true)
                            {
                                sprite.Fade(endtime,0);
                            }
                            else // Default
                            {
                                sprite.Fade(endtime,endtime+250,1,0);
                            }

                            if(enableflip==true)
                            {
                                sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                            }
                            else // Default
                            {
                                sprite.Scale(starttime,scale);
                            }

                            if(randomrotate==true)
                            {
                                sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                            }


                            if(introcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                            }
                            else if(introcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                            }
                            else if(introcustomup==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }
                            else if(introcustomdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                            }
                            else if(introupdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                            }
                            else if(nomovementwhatsoever==true)
                            {
                                
                            }
                            else
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }

                            if(endcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                            }
                            else if(endcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                            }
                            if(endcustomup==true)
                            {

                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                            }
                            else if(endcustomdown==true)
                            {

                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                            }
                            else if(nomovementwhatsoever==true)
                            {

                            }
                            else //Default, No Conditions (Moves Up, then Goes Up)
                            {
                                
                            }

                            if(flip==false)
                            {
                                if(scaleout==true)
                                {
                                    letterX += texture.BaseWidth * scaleoutvalue;
                                }
                                else
                                {
                                    letterX += texture.BaseWidth * scale;
                                }

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * (scale);
                            }
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }

                
        public void SubtitleLinesCustom4(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF",bool goup=false,bool godown=false)
        {

                // if(skiextend == true)
                // {
                //     skicounter(starttime+1000,false);
                // }
                // if(ski==true)
                // {
                //     skicounter(starttime,true);
                // }

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = NoGlow.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                var movecounter = 1;
                var movecounterup = 0;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = NoGlow.GetTexture(charconvertedtostring);   

                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }


                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = NoGlow.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);

                        if(instantfade==true)
                        {
                            sprite.Fade(endtime,0);
                        }
                        else // Default
                        {
                            sprite.Fade(endtime,endtime+250,1,0);
                        }

                        if(enableflip==true)
                        {
                            sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                        }
                        else // Default
                        {
                            //sprite.Scale(starttime,scale);
                            sprite.Scale(starttime,endtime+10000,scale,0);
                    
                        }

                        if(randomrotate==true)
                        {
                            sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                        }


                        if(introcustomleft==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                        }
                        else if(introcustomright==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                        }
                        else if(introcustomup==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                        }
                        else if(introcustomdown==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                        }
                        else if(introupdown==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                        }
                        else
                        {

                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                        }

                        if(endcustomleft==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                        }
                        else if(endcustomright==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                        }
                        if(endcustomup==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                        }
                        else if(endcustomdown==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                        }
                        else //Default, No Conditions (Moves Up, then Goes Up)
                        {
                            
                        }




                        if(flip==false)
                        {
                            letterX += texture.BaseWidth * scale;

                            if(goup==true)
                            {
                                if(i<=2)
                                {
                                    continue;
                                }
                                else
                                {
                                    sprite.MoveX(starttime,endtime+10000,position.X,position.X+250-(50*movecounter)+60); //Anything modify 50
                                    movecounter+=1;
                                }

                            }
                            else
                            {
                                if(i<=2)
                                {
                                    continue;
                                }
                                else
                                {
                                    sprite.MoveX(starttime,endtime+10000,position.X,position.X-50*movecounter);
                                    movecounter+=1;
                                }
                            }

                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * scale;

                            if(godown==true)
                            {
                                if(i<=2)
                                {
                                    continue;
                                }
                                else
                                {
                                    sprite.MoveY(starttime,endtime+10000,position.Y,position.Y+(400)-(100*movecounter) );
                                    movecounter+=1;
                                }

                            }
                            else
                            {
                                if(i<=2)
                                {
                                    continue;
                                }
                                else
                                {
                                    sprite.MoveY(starttime,endtime+10000,position.Y,position.Y-(100*movecounter) );
                                    movecounter+=1;
                                }

                            }

                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }


        public void Perspective(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF",bool goup=false,bool godown=false,bool adddelay = false, int preset=0 )
        {

                // if(skiextend == true)
                // {
                //     skicounter(starttime+1000,false);
                // }
                // if(ski==true)
                // {
                //     skicounter(starttime,true);
                // }

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                //     number+=1;
                //     var linenumber = number + "";
                //     var texture = NoGlow.GetTexture(linenumber);  

                //     var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                //     numbercounter.Scale(starttime,0.25);
                //     numbercounter.Fade(starttime,starttime+100,0,1);
                //     numbercounter.Fade(endtime-100,endtime,1,0);
                //     numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                var movecounter = 1;
                var movecounterup = 0;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = NoGlow.GetTexture(charconvertedtostring);   

                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();


                    var texture = NoGlow.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Scale(starttime,scale);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);
                        sprite.Fade(endtime,0);

                        if(preset==1)
                        {
                            sprite.Scale(starttime,68776,scale,scale*(0.75));
                            sprite.Fade(starttime+250+spawnTime,68776,1,0.5);
                            sprite.MoveY(starttime,68776,sprite.PositionAt(starttime).Y,sprite.PositionAt(starttime).Y+10);
                        }
                        if(preset==2)
                        {
                            sprite.Scale(starttime,68776,scale,scale*(0.80));
                            sprite.Fade(starttime+250+spawnTime,68776,1,0.6);
                        }
                        if(preset==3)
                        {
                            sprite.Scale(starttime,68776,scale,scale*(0.85));
                            sprite.Fade(starttime+250+spawnTime,68776,1,0.7);
                        }
                        if(preset==4)
                        {
                            sprite.Scale(starttime,68776,scale,scale*(0.90));
                            sprite.Fade(starttime+250+spawnTime,68776,1,0.8);
                        }
                        if(preset==5)
                        {
                            sprite.Scale(starttime,68776,scale,scale*(0.95));
                            sprite.Fade(starttime+250+spawnTime,68776,1,0.9);
                        }



                        if(flip==false)
                        {
                            letterX += texture.BaseWidth * scale;
                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * (scale-0.05);
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }


        public void SubtitleLinesCustom2(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF", bool noglow = false, bool noglowsmaller = false)
        {

                // if(skiextend == true)
                // {
                //     skicounter(starttime+1000,false);
                // }
                // if(ski==true)
                // {
                //     skicounter(starttime,true);
                // }

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Instant Fade
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }


                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = japaneseFont.GetTexture(charconvertedtostring);      
                    if(noglow==true)
                    {
                        texture = NoGlow.GetTexture(charconvertedtostring);      
                    }
                    else if(noglowsmaller == true)
                    {
                        texture = NoGlowSmaller.GetTexture(charconvertedtostring);
                    }
                    else if(noglow == false)
                    {
                        texture = japaneseFont.GetTexture(charconvertedtostring);      
                    }

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);

                        if(instantfade==true)
                        {
                            sprite.Fade(endtime,0);
                        }
                        else // Default
                        {
                            sprite.Fade(endtime,endtime+250,1,0);
                        }

                        if(enableflip==true)
                        {
                            sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+300,-scale ,scale,scale,scale);
                        }
                        else // Default
                        {
                            sprite.Scale(starttime,scale);
                        }

                        if(randomrotate==true)
                        {
                            sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+300,Random(-0.523599,0.523599),0);
                        }


                        if(introcustomleft==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                        }
                        else if(introcustomright==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                        }
                        if(introcustomup==true)
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                        }
                        else if(introcustomdown==true)
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                        }
                        else if(introupdown==true)
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+350,position.Y+Random(-20,0),position.Y); 
                        }
                        else
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                        }

                        if(endcustomleft==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                        }
                        else if(endcustomright==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                        }
                        if(endcustomup==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                        }
                        else if(endcustomdown==true)
                        {

                            sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                        }
                        else //Default, No Conditions (Moves Up, then Goes Up)
                        {
                            
                        }




                        if(flip==false)
                        {
                            letterX += texture.BaseWidth * scale;

                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * scale;
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=50;
                    }
                }
        }

        public void SubtitleLinesCustom3(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, 
                                         string colorpick = "#FFFFFF", double fades = 1, int preset = 0)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = NoGlow.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = NoGlow.GetTexture(charconvertedtostring);   

                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET
                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();


                    if(line[i]=='$') // Reset
                    {

                        continue;
                    }

                    var texture = NoGlow.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;


                        if(preset==1)
                        {
                            if(i==0)
                            {
                                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                                sprite.Color(starttime,colorpick);
                                sprite.Scale(starttime,scale);
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+300,position.Y-10,position.Y);
                                sprite.MoveX(OsbEasing.OutQuart,endtime-100,endtime,position.X,position.X-10);
                                sprite.Fade(starttime,fades);
                                sprite.Fade(endtime-100,endtime,1,0);
                            }
                            else if(i==1)
                            {
                                var sprite2 = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                                sprite2.Color(starttime,colorpick);
                                sprite2.Scale(starttime,scale);
                                sprite2.MoveY(OsbEasing.OutQuart,starttime,starttime+300,position.Y+10,position.Y);
                                sprite2.MoveX(OsbEasing.OutQuart,endtime-100,endtime,position.X,position.X+10);
                                sprite2.Fade(starttime,fades);
                                sprite2.Fade(endtime-100,endtime,1,0);
                            }
                        }
                        else if(preset==2)
                        {
                            if(i==0)
                            {
                                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                                sprite.Color(starttime,colorpick);
                                sprite.Scale(starttime,starttime+10000,scale,scale-0.1);
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+300,position.Y-10,position.Y);
                                sprite.MoveY(OsbEasing.OutQuart,endtime-100,endtime,position.Y,position.Y+10);
                                sprite.Fade(starttime,starttime+100,0,fades);
                                sprite.Fade(endtime-100,endtime,1,0);
                            }
                            else if(i==1)
                            {
                                var sprite2 = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                                sprite2.Color(starttime,colorpick);
                                sprite2.Scale(starttime,starttime+10000,scale,scale-0.1);
                                sprite2.MoveY(OsbEasing.OutQuart,starttime,starttime+300,position.Y+10,position.Y);
                                sprite2.MoveY(OsbEasing.OutQuart,endtime-100,endtime,position.Y,position.Y-10);
                                sprite2.Fade(starttime,starttime+100,0,fades);
                                sprite2.Fade(endtime-100,endtime,1,0);
                            }
                            else
                            {
                                var sprite2 = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                                sprite2.Color(starttime,colorpick);
                                sprite2.Scale(starttime,starttime+10000,scale,scale-0.1);
                                sprite2.MoveY(OsbEasing.OutQuart,starttime,starttime+300,position.Y-10,position.Y);
                                sprite2.MoveY(OsbEasing.OutQuart,endtime-100,endtime,position.Y,position.Y+10);
                                sprite2.Fade(starttime,starttime+100,0,fades);
                                sprite2.Fade(endtime-100,endtime,1,0);


                            }
                        }
                        else
                        {
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Move(starttime,starttime+5000,position,position.X+Random(-10,10),position.Y+Random(-10,10));
                            sprite.Fade(starttime,fades);
                            sprite.Fade(endtime,0);

                        }

                        letterX += texture.BaseWidth * scale;
                    }
                    else
                    {
                        letterX += 15;
                    }
                }
        }

        int offsetX = 40;

        public void skiword(int starttime, int endtime)
        {
            
            var line = "すき:";
            var posX = 643-offsetX;
            var posY = 370;
            var scale = 0.25;

            double lineWidth = 0f;
                double lineHeight = 0f;

                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;


                for(int i=0; i<line.Length; i++)
                {

                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        var position = new Vector2((float)letterX, (float)posY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Scale(starttime,scale);
                        sprite.Fade(starttime,starttime+100,0,1);
                        sprite.Fade(endtime-100,endtime,1,0);

                        letterX += texture.BaseWidth * scale;
                    }
                    else
                    {
                        letterX += 15;
                    }

                }


        }

        public void Title(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool fadeinout = false, string colorhex = "#FFFFFF")
        {
                double lineWidth = 0.5f;
                int fadeduration = 250;

                int spawnTime = 0;


                double sequences = 0.0;

                for(int i=0; i<line.Length; i++)
                {
                layer = GetLayer("Subs");
                var characteraverage = (line.Length / 2);
                var currentcharacters = line[i];
                string charconvertedtostring = currentcharacters.ToString();

                var texture = japaneseFont.GetTexture(charconvertedtostring);        
       
                lineWidth += (texture.BaseWidth * scale  * 1.15);
                //Idea is that depending on length, add 100? on X to go left


                var position = new Vector2((float)(posX),(float)(posY));
                if(!texture.IsEmpty)
                {
                    layer = GetLayer("JapaneseSubs");
                    var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                    sprite.Scale(starttime, scale);
                    sprite.Color(starttime, colorhex);

                    var totaltime = endtime - starttime;

                    sprite.Fade(starttime-100,starttime,0,1);
                    sprite.Fade(endtime-100,endtime,1,0);
                    
                    sprite.Move(starttime-100,starttime,position.X,position.Y+Random(-10,10),position.X,position.Y);
                    sprite.Move(endtime-100,endtime,position.X,position.Y,position.X,position.Y+Random(-10,10));

                }
                else
                {
                    posX += 20;
                }

                if(flip==false)
                {
                    posX += texture.BaseWidth * scale  * 1.15;
                }
                else if (flip==true)
                {
                    posY += texture.BaseHeight * scale  * 1.15;
                }
                spawnTime=0; 

                }

        }

        bool fadeconstantposition = false;
        public void English(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.15, bool transition=false, bool fadeend = false,
                            string color = "#FFFFFF")
        {
                layer = GetLayer("SpecialName");
                //var removingthecharacters = String.Join("",line.Split('#','~','`','-','*','%','&','@'));

                double lineWidth = 0f;
                double lineHeight = 0f;

                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;

                bool limegreen = false;
                bool yellowgreen = false;

                for(int i=0; i<line.Length; i++)
                {

                    if(line[i]=='#')
                    {
                        fadeconstantposition = true;
                        continue;
                    }
                    if(line[i]=='$')
                    {
                        fadeconstantposition = false;
                        limegreen = false;
                        yellowgreen = false;
                        continue;
                    }

                    //Colors
                    if(line[i]=='!')
                    {
                        limegreen = true;
                        continue;
                    }
                    if(line[i]=='@')
                    {
                        yellowgreen = true;
                        continue;
                    }

                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        var position = new Vector2((float)letterX, (float)posY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Scale(starttime,scale);
                        sprite.Color(starttime,color);

                        if(transition==true)
                        {
                            sprite.Fade(starttime,starttime+100,0,1);
                            sprite.Scale(starttime,endtime,scale+0.02,scale);
                            sprite.Fade(endtime,0);
                        }
                        else
                        {
                            if(limegreen==true)
                            {

                                sprite.Color(starttime,"#B9E9C9");
                            }
                            else if(yellowgreen==true)
                            {

                                sprite.Color(starttime,"#D5CE58");
                            }


                            if(fadeconstantposition==true) //Default Fading, In Out, Has Offset
                            {
                                sprite.Fade(starttime,starttime+300,0,1);
                                sprite.Fade(endtime-300,endtime,1,0);
                            }
                            else if(fadeend==true)
                            {
                                sprite.Fade(starttime,starttime+300,0,1);
                                sprite.Fade(endtime-300,endtime,1,0);

                            }
                            else //Default Fading, In Out, No Offset
                            {
                                sprite.Fade(starttime,endtime,1,1);
                            }
                        }

                        letterX += texture.BaseWidth * scale;
                    }
                    else
                    {
                        letterX += 15;
                    }

                }

        }

        public void bar(int starttime, int endtime, double posX, double posY, float height, float width, int flip = 0)
        {
            layer = GetLayer("Bar");
            var bar = layer.CreateSprite("sb/p.png");
            bar.Fade(starttime,1);
            bar.Move(starttime,posX,posY);
            bar.Color(starttime,"#FF781F");
            bar.Fade(endtime,endtime+300    ,1,0);

            if(flip==1)
            {
                bar.ScaleVec(OsbEasing.OutQuad,starttime,starttime+1000,0,height,width,height);
                bar.ScaleVec(OsbEasing.OutQuad,endtime,endtime+300,width,height,0,height);
            }
            if(flip==2)
            {
                bar.ScaleVec(OsbEasing.OutQuad,starttime,starttime+1000,width,0,width,height);
                bar.ScaleVec(OsbEasing.OutQuad,endtime,endtime+300,width,height,0,height);
            }

        }

       public void Kiai1Preset(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF", double preset = 0)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;

                int preset1counter = 0;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(preset==0) // Default, Do Nothing
                    {
                        continue;
                    }
                    if(preset==1)
                    {
                        if(!texture.IsEmpty)
                        {

                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            int[] values = {-20,20};
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                            sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X+values[preset1counter]);
                            preset1counter++;
                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }
                    if(preset==2)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,320,position.X);

                            sprite.MoveX(OsbEasing.OutQuad,starttime+546,starttime+546+100,position.X,position.X-95);
                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==2.1)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X,position.X+95);

                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-40);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==3)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            if(i<1)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-75,position.X);
                            }
                            else if(i>=1)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+75,position.X);
                            }

                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-20);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==4)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                            // sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-20);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==5)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveX(starttime,320);

                            if(i==0)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,240,263-50);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,320,320-20);
                            }
                            else if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,240,263+50);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,320,320+20);
                            }


                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==6)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            if(i==0)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-20,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1273,starttime+1273+100,position.X,position.X-60);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            }
                            if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y-20,position.Y);
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1273,starttime+1273+100,position.X,position.X-60);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            }
                            if(i==2)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+20,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1273,starttime+1273+100,position.X,position.X-60);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            }

                            //Custom Command
                            if(starttime==78958)
                            {
                                sprite.Scale(OsbEasing.OutQuart,80594,80594+150,scale,0.4);
                            }
                            else if(starttime==241867)
                            {
                                sprite.Scale(OsbEasing.OutQuart,243503,243503+150,scale,0.4);
                            }


                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==7)
                    {
                        if(!texture.IsEmpty)
                        {
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                            sprite.MoveX(starttime,position.X+125);
                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);

                            //Custom Command
                            if(starttime==80231)
                            {
                                sprite.Scale(OsbEasing.OutQuart,80594,80594+150,scale,0.4);
                            }
                            else if(starttime==243140)
                            {
                                sprite.Scale(OsbEasing.OutQuart,243503,243503+150,scale,0.4);
                            }
                            

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==8)
                    {
                        if(!texture.IsEmpty)
                        {
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);
                            if(i==0)
                            {
                                  
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-10,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X-10);
                            }
                            if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y-10,position.Y);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-10);
                            }
                            if(i==2)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+10,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X+10);
                            }



                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }

                    }
                    if(preset==9)
                    {
                        if(!texture.IsEmpty)
                        {
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);
                            if(i==0)
                            {
                                  
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+10,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X+10);
                            }
                            if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+10,position.Y);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+10);
                            }
                            if(i==2)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-10,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X-10);
                            }



                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }


                    }
                    if(preset==10)
                    {
                        if(!texture.IsEmpty)
                        {
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,267503,scale,scale+0.05);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            if(i==0)
                            {
                                  
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+10,position.X);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-10);

                                sprite.MoveX(OsbEasing.OutQuad,267503,267503+500,position.X,position.X-120);
                                sprite.Fade(endtime,endtime+100,1,0);
                            }
                            if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+10,position.Y);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-10);

                                sprite.MoveX(OsbEasing.OutQuad,267503,267503+500,position.X,position.X-120);
                                sprite.Fade(endtime,endtime+100,1,0);
                            }
                            if(i==2)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-10,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X-10);

                                sprite.MoveY(OsbEasing.OutQuad,267503,267503+500,position.Y,position.Y-10);
                                sprite.Fade(267503,267503+100,1,0);
                            }



                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                    }
                    if(preset==11)
                        {
                            if(!texture.IsEmpty)
                            {
                                layer = GetLayer("Subs");
                                var position = new Vector2((float)letterX, (float)letterY) 
                                    + texture.OffsetFor(origin) * (float)scale;
                                
                                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                                sprite.Color(starttime,colorpick);
                                sprite.Scale(starttime,267503,scale,scale+0.05);
                                sprite.Fade(OsbEasing.OutQuad,starttime,starttime+500,0,1);
                                sprite.Fade(endtime,endtime+100,1,0);
                                sprite.MoveX(starttime,position.X+70);
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+500,position.Y+10,position.Y);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+10);



                                if(flip==false)
                                {
                                    letterX += texture.BaseWidth * scale;

                                }
                                else if(flip==true)
                                {
                                    letterY += texture.BaseHeight * scale;
                                }
                            }

                        }
                }
        }

        public void Kiai2Preset(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF", double preset = 0)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;

                int preset1counter = 0;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(preset==0) // Default, Do Nothing
                    {
                        continue;
                    }
                    if(preset==1)
                    {
                        if(!texture.IsEmpty)
                        {

                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-20,position.X);
                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }
                    if(preset==2)
                    {
                        if(!texture.IsEmpty)
                        {
                            //  
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+20,position.X);
                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-20);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==2.1)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X-20);

                            }
                            else
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                                sprite.MoveX(OsbEasing.OutQuad,endtime,endtime+100,position.X,position.X+20);
                            }

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==3)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y-20,position.Y);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==4)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Scale(102231 ,104412,scale,scale+0.03);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                            sprite.MoveX(OsbEasing.OutQuad,104594,104594+500,position.X,position.X-100);
                            // sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y-20);

                            starttime+=363;

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==5)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+500,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            if(i==0)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+500,position.Y-50,position.Y);
                            }
                            else if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+500,position.Y+50,position.Y);
                            }


                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==6)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            if(i==0)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X-20,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1273,starttime+1273+100,position.X,position.X-60);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            }
                            if(i==1)
                            {
                                sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y-20,position.Y);
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1273,starttime+1273+100,position.X,position.X-60);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            }
                            if(i==2)
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+100,position.X+20,position.X);
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1273,starttime+1273+100,position.X,position.X-60);
                                sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);
                            }

                            //Custom Command
                            sprite.Scale(80594,0.4);


                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }

                    if(preset==7)
                    {
                        if(!texture.IsEmpty)
                        {
                              
                            layer = GetLayer("Subs");
                            var position = new Vector2((float)letterX, (float)letterY) 
                                + texture.OffsetFor(origin) * (float)scale;
                            
                            var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                            sprite.Color(starttime,colorpick);
                            sprite.Scale(starttime,scale);
                            sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
                            sprite.Fade(endtime,endtime+100,1,0);

                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+100,position.Y+20,position.Y);
                            sprite.MoveX(starttime,position.X+125);
                            sprite.MoveY(OsbEasing.OutQuad,endtime,endtime+100,position.Y,position.Y+20);

                            //Custom Command
                            sprite.Scale(80594,0.4);

                            if(flip==false)
                            {
                                letterX += texture.BaseWidth * scale;

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            letterX += 15;
                        }

                    }


                }
        }

        public void SubtitleLinesCustom5Movement(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, 
                                                string colorpick = "#FFFFFF", int movement = 0, int movement1 = 0)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }


                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+300+spawnTime,0,1);

                        if(enableflip==true)
                        {
                            sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                        }
                        else // Default
                        {
                            sprite.Scale(starttime,scale);
                        }

                        var OffsetValue = 0;

                        if(movement1==1)
                        {
                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+300,position.X-20,position.X); //Init
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+500,position.X,position.X-(94*1));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*2),starttime+(1454*2)+300,position.X-(94*1),position.X-(94*2));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*3),starttime+(1454*3)+500,position.X-(94*2),position.X-(110*3));
                            sprite.Fade(endtime,0);
                        }
                        else if(movement1==2)
                        {
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+300,position.Y-20,position.Y);
                            sprite.MoveX(starttime,position.X-(-46));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+300,position.X-(-46),position.X-(50*1));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*2),starttime+(1454*2)+500,position.X-(50*1),position.X-(94*2));
                            sprite.Fade(endtime,0);
                        }
                        else if(movement1==3)
                        {
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+300,position.Y+20,position.Y);
                            sprite.MoveX(starttime,position.X-(-138));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+500,position.X-(-138),position.X-(2*1));
                            sprite.Fade(endtime,0);
                        }
                        else if(movement1==4)
                        {

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+500,position.X-(-234)+20,position.X-(-234));
                            sprite.Fade(endtime,0); 
                        }
                        else
                        {

                            if(movement==2) // Right
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime+3455,starttime+3455+300,position.X,position.X+90);
                            }
                            else if(movement==1) // Left
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1455,starttime+1455+400,position.X,position.X-100);
                            }

                            if(instantfade==true)
                            {
                                sprite.Fade(endtime,0);
                            }
                            else // Default
                            {
                                sprite.Fade(endtime,endtime+250,1,0);
                            }

                            if(randomrotate==true)
                            {
                                sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                            }


                            if(introcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                            }
                            else if(introcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                            }
                            if(introcustomup==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }
                            else if(introcustomdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                            }
                            else if(introupdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                            }
                            else
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }

                            if(endcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                            }
                            else if(endcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                            }
                            if(endcustomup==true)
                            {
                                  
                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                            }
                            else if(endcustomdown==true)
                            {
                                  
                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                            }
                            else //Default, No Conditions (Moves Up, then Goes Up)
                            {
                                
                            }

                        } // This is for Disabling Movement1

                        if(flip==false)
                        {
                            letterX += texture.BaseWidth * scale;

                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * (scale-0.05);
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }


        public void SubtitleLinesCustom7Movement(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, 
                                                string colorpick = "#FFFFFF", int movement = 0, int movement1 = 0)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }


                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);

                        if(enableflip==true)
                        {
                            sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                        }
                        else // Default
                        {
                            sprite.Scale(starttime,scale);
                        }

                        var OffsetValue = 0;

                        if(movement1==1)
                        {
                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+300,position.X-20,position.X); //Init
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+300,position.X,position.X-(72));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*2),starttime+(1454*2)+300,position.X-(72),position.X-(140));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*3),starttime+(1454*3)+300,position.X-(140),position.X-(234));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else if(movement1==2)
                        {
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+300,position.Y-20,position.Y);
                            sprite.MoveX(starttime,position.X-(-67));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+300,position.X-(-67),position.X-(0));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*2),starttime+(1454*2)+300,position.X-(0),position.X-(96));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else if(movement1==3)
                        {
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+300,position.Y+20,position.Y);
                            sprite.MoveX(starttime,position.X-(-138));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+300,position.X-(-138),position.X-(-46));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else if(movement1==4)
                        {

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+300,position.X-(-234)+20,position.X-(-213));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else
                        {

                            if(movement==2) // Right
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime+3455,starttime+3455+300,position.X,position.X+90);
                            }
                            else if(movement==1) // Left
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1455,starttime+1455+400,position.X,position.X-100);
                            }

                            if(instantfade==true)
                            {
                                sprite.Fade(endtime,0);
                            }
                            else // Default
                            {
                                sprite.Fade(endtime,endtime+250,1,0);
                            }

                            if(randomrotate==true)
                            {
                                sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                            }


                            if(introcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                            }
                            else if(introcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                            }
                            if(introcustomup==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }
                            else if(introcustomdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                            }
                            else if(introupdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                            }
                            else
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }

                            if(endcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                            }
                            else if(endcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                            }
                            if(endcustomup==true)
                            {
                                  
                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                            }
                            else if(endcustomdown==true)
                            {
                                  
                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                            }
                            else //Default, No Conditions (Moves Up, then Goes Up)
                            {
                                
                            }

                        } // This is for Disabling Movement1

                        if(flip==false)
                        {
                            letterX += texture.BaseWidth * scale;

                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * (scale-0.05);
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }



        public void SubtitleLinesCustom8Movement(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, 
                                                string colorpick = "#FFFFFF", int movement = 0, int movement1 = 0)
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }


                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = japaneseFont.GetTexture(charconvertedtostring);      

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+350+spawnTime,0,1);

                        if(enableflip==true)
                        {
                            sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                        }
                        else // Default
                        {
                            sprite.Scale(starttime,scale);
                        }

                        var OffsetValue = 0;

                        if(movement1==1)
                        {
                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+300,position.X-20,position.X); //Init
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+300,position.X,position.X-(25));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*2),starttime+(1454*2)+300,position.X-(25),position.X-(70));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*3),starttime+(1454*3)+500,position.X-(70),position.X-(235));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else if(movement1==2)
                        {
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+300,position.Y-20,position.Y);
                            sprite.MoveX(starttime,position.X-(-90));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+300,position.X-(-90),position.X-(-50));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*2),starttime+(1454*2)+500,position.X-(-50),position.X-(118));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else if(movement1==3)
                        {
                            sprite.MoveY(OsbEasing.OutQuad,starttime,starttime+300,position.Y+20,position.Y);
                            sprite.MoveX(starttime,position.X-(-130));
                            sprite.MoveX(OsbEasing.OutQuad,starttime+(1454*1),starttime+(1454*1)+500,position.X-(-138),position.X-(46));
                            sprite.Fade(endtime-100,endtime,1,0);
                        }
                        else if(movement1==4)
                        {

                            sprite.MoveX(OsbEasing.OutQuad,starttime,starttime+500,position.X-(-300)+20,position.X-(-165));
                            sprite.Fade(endtime-100,endtime,1,0); 
                        }
                        else
                        {

                            if(movement==2) // Right
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime+3455,starttime+3455+300,position.X,position.X+90);
                            }
                            else if(movement==1) // Left
                            {
                                sprite.MoveX(OsbEasing.OutQuad,starttime+1455,starttime+1455+400,position.X,position.X-100);
                            }

                            if(instantfade==true)
                            {
                                sprite.Fade(endtime,0);
                            }
                            else // Default
                            {
                                sprite.Fade(endtime,endtime+250,1,0);
                            }

                            if(randomrotate==true)
                            {
                                sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                            }


                            if(introcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                            }
                            else if(introcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                            }
                            if(introcustomup==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }
                            else if(introcustomdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                            }
                            else if(introupdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                            }
                            else
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }

                            if(endcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                            }
                            else if(endcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                            }
                            if(endcustomup==true)
                            {
                                  
                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                            }
                            else if(endcustomdown==true)
                            {
                                  
                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                            }
                            else //Default, No Conditions (Moves Up, then Goes Up)
                            {
                                
                            }

                        } // This is for Disabling Movement1

                        if(flip==false)
                        {
                            letterX += texture.BaseWidth * scale;

                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * (scale-0.05);
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }



        public void SubtitleLinesCustom6(string line, int starttime, int endtime, double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF")
        {

                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                bool scaleout = false; // p

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }
                    if(line[i]=='p') // Scaleout at 1/1
                    {
                        scaleout = true;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }


                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = japaneseFont.GetTexture(charconvertedtostring);    

                    var scaleoutvalue = 0.4;  

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);

                        if(scaleout==true)
                        {
                            sprite.Scale(starttime+364,starttime+364+1000,scaleoutvalue-0.02,scaleoutvalue);
                            //sprite.MoveX(OsbEasing.OutQuart,starttime+1489,starttime+1489+300,position.X,position.X-225);
                        }



                        if(instantfade==true)
                        {
                            sprite.Fade(endtime,0);
                        }
                        else // Default
                        {
                            sprite.Fade(endtime,endtime+250,1,0);
                        }

                        if(enableflip==true)
                        {
                            sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                        }
                        else // Default
                        {
                            sprite.Scale(starttime,scale);
                        }

                        if(randomrotate==true)
                        {
                            sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                        }


                        if(introcustomleft==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                        }
                        else if(introcustomright==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                        }
                        if(introcustomup==true)
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                        }
                        else if(introcustomdown==true)
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                        }
                        else if(introupdown==true)
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                        }
                        else
                        {
                            sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                        }

                        if(endcustomleft==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                        }
                        else if(endcustomright==true)
                        {
                            sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                        }
                        if(endcustomup==true)
                        {
                              
                            sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                        }
                        else if(endcustomdown==true)
                        {
                              
                            sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                        }
                        else //Default, No Conditions (Moves Up, then Goes Up)
                        {
                            
                        }

                        if(flip==false)
                        {
                            if(scaleout==true)
                            {
                                letterX += texture.BaseWidth * scaleoutvalue;
                            }
                            else
                            {
                                letterX += texture.BaseWidth * scale;
                            }

                        }
                        else if(flip==true)
                        {
                            letterY += texture.BaseHeight * scale;
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }

        public void SkiKiai(int starttime)
        {

                // double posX, double posY=262, bool flip = false, double scale=0.25, bool ski=false, string colorpick = "#FFFFFF", bool transition=false
                string line = "すき!";
                bool flip = false;
                double scale = 0.35;
                string colorpick = "#FFFFFF";
                bool transition=false;
                var endtime = starttime+363;
                var ski = true;

                var posX = Random(-50,700);
                var posY = Random(100,420);



                double lineWidth = 0f;
                double lineHeight = 0f;
                int fadeduration = 250;

                int spawnTime = 0;
                

                if(ski==true)
                {
                    // number+=1;
                    // var linenumber = number + "";
                    // var texture = japaneseFont.GetTexture(linenumber);  

                    // var numbercounter = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                    // numbercounter.Scale(starttime,0.25);
                    // numbercounter.Fade(starttime,starttime+100,0,1);
                    // numbercounter.Fade(endtime-100,endtime,1,0);
                    // numbercounter.Move(starttime,672,392);

                }
                
                OsbOrigin origin = OsbOrigin.Centre;

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();
                    var texture = japaneseFont.GetTexture(charconvertedtostring);   

                     
                    lineWidth += texture.BaseWidth * scale;
                    lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
                }

                var letterX = posX - lineWidth * 0.5f;
                var letterY = posY - lineHeight * 0.5f;


                // Instructions

                // $ RESET

                bool introscaleout = false; // b
                bool introcustomleft = false;   // z
                bool introcustomright = false;  // x
                bool introcustomup = false;     // c
                bool introcustomdown = false;   // v

                bool endcustomleft = false;   // a
                bool endcustomright = false;  // s
                bool endcustomup = false;     // f
                bool endcustomdown = false;   // d

                // 1/1 Delay -
                bool adddelay = false; // q
                bool randomrotate = false; // w
                bool invert = false; // t
                bool enableflip = false; // r
                bool enableflipend = false; // 4
                bool introupdown = false; // g

                bool instantfade = false; // u

                bool scaleout = false; // p

                for(int i=0; i<line.Length; i++)
                {
                    var currentcharacters = line[i];
                    string charconvertedtostring = currentcharacters.ToString();

                    if(line[i]=='-') // Add 1/1 delay
                    {
                        starttime += 364;
                        continue;
                    }
                    if(line[i]=='j') // Add 1/2 delay
                    {
                        starttime += 182;
                        continue;
                    }
                    if(line[i]=='k') // Add 1/3 delay
                    {
                        starttime += 121;
                        continue;
                    }
                    if(line[i]=='l') // Add 2/3 delay
                    {
                        starttime += 242;
                        continue;
                    }
                    if(line[i]=='p') // Scaleout at 1/1
                    {
                        scaleout = true;
                        continue;
                    }


                    if(line[i]=='r') // Intro Flip
                    {
                        enableflip = true;
                        continue;
                    }
                    
                    if(line[i]=='4') // End Flip
                    {
                        enableflipend = true;
                        continue;
                    }

                    if(line[i]=='z') //Intro Custom Position (Left)
                    {
                        introcustomleft = true;
                        continue;
                    }
                    if(line[i]=='x') //Intro Custom Position (Right)
                    {
                        introcustomright = true;
                        continue;
                    }
                    if(line[i]=='c') //Intro Custom Position (Up)
                    {
                        introcustomup = true;
                        continue;
                    }
                    if(line[i]=='v') //Intro Custom Position (Down)
                    {
                        introcustomdown = true;
                        continue;
                    }
                    if(line[i]=='u') //Intro Custom Position (Down)
                    {
                        instantfade = true;
                        continue;
                    }
                    if(line[i]=='g') //Intro Custom Position (Up and Down Random)
                    {
                        introupdown = true;
                        continue;
                    }
                    if(line[i]=='b') //Intro Custom Position (Scale Big to Normal)
                    {
                        introscaleout = true;
                        continue;
                    }



                    if(line[i]=='a') //End Custom Position (Left)
                    {
                        endcustomleft = true;
                        continue;
                    }
                    if(line[i]=='s') //End Custom Position (Right)
                    {
                        endcustomright = true;
                        continue;
                    }
                    if(line[i]=='d') //End Custom Position (Up)
                    {
                        endcustomup = true;
                        continue;
                    }
                    if(line[i]=='f') //End Custom Position (Down)
                    {
                        endcustomdown = true;
                        continue;
                    }
                    if(line[i]=='q') //Add Delay
                    {
                        adddelay = true;
                        continue;
                    }
                    if(line[i]=='w') //Add RandomRotate
                    {
                        randomrotate = true;
                        continue;
                    }
                    if(line[i]=='t') //Add RandomRotate
                    {
                        invert = true;
                        continue;
                    }
                    if(line[i]=='$') //End Custom Position (Down)
                    {
                        introcustomleft = false;
                        introcustomright = false;
                        introcustomup = false;
                        introcustomdown = false;
                        endcustomleft = false;
                        endcustomright = false;
                        endcustomup = false;
                        endcustomdown = false;
                        adddelay = false;
                        randomrotate = false;
                        invert = false;
                        instantfade = false;
                        introupdown = false;
                        continue;
                    }

                    var texture = japaneseFont.GetTexture(charconvertedtostring);    

                    var scaleoutvalue = 0.4;  

                    if(!texture.IsEmpty)
                    {

                        layer = GetLayer("Subs");
                        var position = new Vector2((float)letterX, (float)letterY) 
                            + texture.OffsetFor(origin) * (float)scale;
                        
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Color(starttime,colorpick);
                        sprite.Fade(OsbEasing.OutQuad,starttime+spawnTime,starttime+250+spawnTime,0,1);

                        if(transition==true)
                        {
                            sprite.Scale(starttime,scale);
                            var timemovement = 1000; // Adjust here
                            var duration = endtime-starttime;
                            var totaltimemovement = timemovement*4;
                            var movementloop = (duration)/totaltimemovement;
                            sprite.StartLoopGroup(starttime,movementloop);
                            sprite.MoveX(0,timemovement,position.X,position.X-10);
                            sprite.MoveX(timemovement,timemovement*2,position.X-10,position.X);
                            sprite.MoveX(timemovement*2,timemovement*3,position.X,position.X+10);
                            sprite.MoveX(timemovement*3,timemovement*4,position.X+10,position.X);

                            // sprite.MoveY(0,movementloop,position.Y,position.Y-10);
                            // sprite.MoveY(movementloop,movementloop*2,position.Y-10,position.Y);
                            // sprite.MoveY(movementloop*2,movementloop*3,position.Y,position.Y+10);
                            // sprite.MoveY(movementloop*3,movementloop*4,position.Y+10,position.Y);
                            sprite.EndGroup();

                            sprite.Fade(endtime-300,endtime,1,0);

                            if(flip==false)
                            {
                                if(scaleout==true)
                                {
                                    letterX += texture.BaseWidth * scaleoutvalue;
                                }
                                else
                                {
                                    letterX += texture.BaseWidth * scale;
                                }

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                        else
                        {
                            if(scaleout==true)
                            {
                                sprite.Scale(starttime+364,scaleoutvalue);
                            }
                            else if(introscaleout==true)
                            {
                                sprite.Scale(OsbEasing.OutQuart,starttime,starttime+1000,scale+0.1,scale);
                            }



                            if(instantfade==true)
                            {
                                sprite.Fade(endtime,0);
                            }
                            else // Default
                            {
                                sprite.Fade(endtime,endtime+250,1,0);
                            }

                            if(enableflip==true)
                            {
                                sprite.ScaleVec(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,-scale ,scale,scale,scale);
                            }
                            else // Default
                            {
                                sprite.Scale(starttime,scale);
                            }

                            if(randomrotate==true)
                            {
                                sprite.Rotate(OsbEasing.OutQuart,starttime+spawnTime,starttime+spawnTime+250,Random(-0.523599,0.523599),0);
                            }


                            if(introcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X-10,position.X); 
                            }
                            else if(introcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.X+10,position.X); 
                            }
                            else if(introcustomup==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }
                            else if(introcustomdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y-10,position.Y); 
                            }
                            else if(introupdown==true)
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+Random(-20,0),position.Y); 
                            }
                            else
                            {
                                sprite.MoveY(OsbEasing.OutQuart,starttime,starttime+spawnTime+250,position.Y+10,position.Y); 
                            }

                            if(endcustomleft==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X-10); 
                            }
                            else if(endcustomright==true)
                            {
                                sprite.MoveX(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.X,position.X+10); 
                            }
                            if(endcustomup==true)
                            {

                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y+10); 
                            }
                            else if(endcustomdown==true)
                            {

                                sprite.MoveY(OsbEasing.OutQuart,endtime,endtime+spawnTime+250,position.Y,position.Y-10); 
                            }
                            else //Default, No Conditions (Moves Up, then Goes Up)
                            {
                                
                            }

                            if(flip==false)
                            {
                                if(scaleout==true)
                                {
                                    letterX += texture.BaseWidth * scaleoutvalue;
                                }
                                else
                                {
                                    letterX += texture.BaseWidth * scale;
                                }

                            }
                            else if(flip==true)
                            {
                                letterY += texture.BaseHeight * scale;
                            }
                        }
                    }
                    else
                    {
                        letterX += 15;
                    }

                    if(adddelay==true)
                    {
                        spawnTime+=100;
                    }
                }
        }

        public void honestlytoomucheffortbg()
        {
            layer = GetLayer("SpecialDot");
            var dot = layer.CreateSprite("sb/p.png");
            dot.Scale(260776,1000);
            dot.Fade(260776,262231,1,1);
            dot.Color(260776,"FCBACB");
        }

        public void honestlytoomucheffort()
        {
            // layer = GetLayer("SpecialDot");
            // var dot = layer.CreateSprite("sb/p.png");
            // dot.Scale(260776,1000);
            // dot.Fade(260776,262231,1,1);
            // dot.Color(260776,"FCBACB");
            // This make glow wtf?

            var time = 260776;
            layer = GetLayer("SpecialSubs");
            var message = "すき!";

            var posX = 410;
            var posY = 267;

            double lineWidth = 0f;
            double lineHeight = 0f;

            var scale = 0.3;

            var texture = japaneseFont  .GetTexture(message);  

            for(int i=0; i<message.Length; i++)
            {
                var currentcharacters = message[i];
                string charconvertedtostring = currentcharacters.ToString();
                texture = japaneseFont.GetTexture(message);   

                lineWidth += texture.BaseWidth * scale;
                lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
            }

            var letterX = posX - lineWidth * 0.5f;
            var letterY = posY - lineHeight * 0.5f;

            OsbOrigin origin = OsbOrigin.Centre;

            if(!texture.IsEmpty)
            {

                layer = GetLayer("Subs");
                var positionleft = new Vector2((float)letterX, (float)letterY) 
                    + texture.OffsetFor(origin) * (float)scale;

                double letterXleft = letterX;
                var counterleft = 0;
                
                for(int i = time; i<=261322; i+=273) //Left
                {
                    for(int j = 0; j<message.Length;j++)
                    {
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, positionleft);
                        sprite.Scale(i,scale);
                        sprite.Fade(OsbEasing.OutQuad,i,i+300,0,1);
                        sprite.Fade(262231,0);
                    }
                    positionleft.X-=100;
                }
                for(int i = 261503; i<=262231; i+=182)
                {
                    for(int j = 0; j<message.Length;j++)
                    {
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, positionleft);
                        sprite.Scale(i,scale);
                        sprite.Fade(OsbEasing.OutQuad,i,i+300,0,1);
                        if(counterleft>2)
                        {
                            sprite.Fade(i+300,0);
                        }
                        else
                        {
                            sprite.Fade(262231,0);
                        }
                        
                    }
                    positionleft.X-=100;
                    counterleft++;
                }

                var positionright = new Vector2((float)letterX, (float)letterY) 
                    + texture.OffsetFor(origin) * (float)scale;

                double letterXright = letterX;
                var counterright = 0;
                
                for(int i = time; i<=261322; i+=273) //Left
                {
                    for(int j = 0; j<message.Length;j++)
                    {
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, positionright);
                        sprite.Scale(i,scale);
                        sprite.Fade(OsbEasing.OutQuad,i,i+300,0,1);
                        sprite.Fade(262231,0);
                    }
                    positionright.X+=100;
                }
                for(int i = 261503; i<=262231; i+=182)
                {
                    for(int j = 0; j<message.Length;j++)
                    {
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, positionright);
                        sprite.Scale(i,scale);
                        sprite.Fade(OsbEasing.OutQuad,i,i+300,0,1);
                        if(counterright>2)
                        {
                            sprite.Fade(i+300,0);
                        }
                        else
                        {
                            sprite.Fade(262231,0);
                        }
                        
                    }
                    positionright.X+=100;
                    counterright++;
                }



            }
        }


        public void bouncy()
        {
            var startime = 157399;
            var endtime = 172049;
            layer = GetLayer("Bounce");
            var message = "Oh Oh!";
            var texture = japaneseFont.GetTexture(message); 

            var posX = 320;
            var posY = 265;

            var lineWidth = 0f;
            var lineHeight = 0f;

            var letterX = posX - lineWidth * 0.5f;
            var letterY = posY - lineHeight * 0.5f;

            OsbOrigin origin = OsbOrigin.Centre;

            var scale = 0.25;

            var positionright = new Vector2((float)letterX, (float)letterY) 
                    + texture.OffsetFor(origin) * (float)scale;

            if(!texture.IsEmpty)
            {
                var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre);
                sprite.Scale(startime,scale);
            }


        }


        public override void Generate()
        {

            layer = GetLayer("Subs");
            japaneseFont = LoadFont("sb/lyrics", new FontDescription() // Can just go storybrew to copy paste this
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

            NoGlow = LoadFont("sb/lyrics1", new FontDescription() // Can just go storybrew to copy paste this
            {
                FontPath = "Mamelon-3-Hi-Regular.otf",
                // FontSize = 200, // SizeW Original
                FontSize = 100,
                Color = Color4.White, // Color
                Padding = Vector2.Zero, // Spacing around character
                FontStyle = System.Drawing.FontStyle.Regular, // Font regular,bold,italic,etc
                TrimTransparency = true, // Remove excessive transpacy in font
                EffectsOnly = false,
                Debug = false,
            }    
            );

            NoGlowSmaller = LoadFont("sb/lyrics2", new FontDescription() // Can just go storybrew to copy paste this
            {
                FontPath = "Mamelon-3-Hi-Regular.otf",
                // FontSize = 200, // SizeW Original
                FontSize = 50,
                Color = Color4.White, // Color
                Padding = Vector2.Zero, // Spacing around character
                FontStyle = System.Drawing.FontStyle.Regular, // Font regular,bold,italic,etc
                TrimTransparency = true, // Remove excessive transpacy in font
                EffectsOnly = false,
                Debug = false,
            }    
            );

            // // // Intro
            // English("#R3aCt10n$",231,2595,343,249);
            English("#CMS Classroom A Presents",231,2595,320,249);

            English("#aundy$",3322,9412,130,380);
            English("#aundy$",9140,15231,130,380,false,0.15,false,false,"#D61D42");
            English("#aundy$",14958,26594,130,380);
            bar(14958,26594,117,401,15,70,1);

            English("#SayuMana$",26594,49867,130,380);
            bar(26594,49867,120,401,15,120,1);

            English("#aundy$",49867,70231,130,380);
            bar(49867,70231,117,401,15,70,1);

            English("#SayuMana$",70231,93503,130,380);
            bar(70231,93503,120,401,15,120,1);

            English("#aundy$",93503,119685,130,380);
            bar(93503,119685,117,401,15,70,1);

            English("#SayuMana$",119685,142958,130,380);
            bar(131322,142958,120,401,15,120,1);

            English("#aundy$",142958,166231,130,380);
            bar(142958,166231,117,401,15,70,1);

            English("#SayuMana$",166231,192412,130,380);
            bar(166231,180776,120,401,15,120,1);

            English("#aundy$",192412,217140,130,380);

            English("#SayuMana$",217140,244776,130,380);
            bar(217140,222958,120,401,15,120,1);
            bar(233140,244776,120,401,15,120,1);

            English("#aundy$",244776,268049,130,380);
            bar(244776,268049,117,401,15,70,1);
            //bar(250594,268049,117,401,15,70,1);


            English("#SayuMana$",268049,288412,130,380);
            bar(268049,288412,120,401,15,120,1);

            English("#aundy$",288412,302958,130,380);
            bar(288412,302958,117,401,15,70,1);

            English("#Tatin$",302958,308776,130,380);
            bar(302958,308594,120,401,15,65,1);
            

            //skiword(3322,9140);

            SubtitleLinesCustom1("すき!",3322,3685,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",3685,4049,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",4049,4412,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",4412,4776,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",4776,5140,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",5140,5503,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",5503,5867,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",5867,6231,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",6231,6594,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",6594,6958,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",6958,7322,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",7322,7685,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",7685,8412,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",8412,9140,320,265,false,0.25,true,"#FFFFFF");

            Title("すきっ！〜超ver〜",16412,20776,75,264,false,0.4,false,"#FFFFFF");
            bar(14958,16412,318,280,30,410,1);
            bar(15776,20594,318,280,30,550,1);

            English("#Mapped by",20776,23503,320,225);
            bar(20776,23322,320,246,13,135,1);

            English("SayuMana & aundy",20776,23503,320,275);
            bar(20776,23322,328,297,15,230,1);


            English("Hitsound by",23503,26594,320-100,225-50);
            bar(23503,26412,226,247-50,15,150,1);

            English("midorijeon",23503,26594,325-100,275-50);
            bar(23503,26412,226,296-50,15,137,1);

            English("Storyboard by",23503,26594,320+100,225-50);
            bar(23503,26412,423,247-50,15,165,1);

            English("R3aCt10n$",23503,26594,325+100,275-50);
            bar(23503,26412,420,296-50,15,135,1);

            English("Sliderart by",23503,26594,320,225+60);
            bar(23503,26412,325,305,15,150,1);

            English("Tatin$",23503,26594,320,275+60);
            bar(23503,26412,316,305+49,15,75,1);






            //Scene 1
            SubtitleLinesCustom1("こ-の-気-持-ち！",10594,13503,370,272,false,0.45,false,"#D61D42");
            SubtitleLinesCustom1("とまりません！",13503,14958,320,272,false,0.45,false,"#D61D42");
            SubtitleLinesCustom1("とまりません！",14958,16412-300,320,272,false,0.45,false,"#FFFFFF",false,false,true);

            SubtitleLinesCustom1("sqvw君と幼なじみで産まれたい$",26594,38231,719,60,true,0.15,false,"#FFFFFF");
            bar(26594,38231,585,45,690,15,2);

            SubtitleLinesCustom1("aqvw徒歩2分に住んでてほしい$",29322,38231,190,100,true,0.15,false,"#FFFFFF");
            bar(29322,38231,42,445,690,15,2);

            SubtitleLinesCustom1("fvqr「そして大人になって」$",33140,38231,210,180,false,0.15,false,"#FFFFFF");
            bar(33140,38231,200,185,15,205,1);

            SubtitleLinesCustom1("dcqr「突然再会してみたりってね？」$",34958,38231,400,310,false,0.15,false,"#FFFFFF");
            bar(34958,38231,390,315,15,280,1);

            //Scene 2
            SubtitleLinesCustom1("uzqもしくは第一印象$",38231,49867,100,152,false,0.15,false,"#FFFFFF"
                                 ,false, false, false, false);
            bar(38231,49867,-120,156,15,525,1);

            SubtitleLinesCustom1("uxq最悪な初対面だったり$",40958,49867,550,242,false,0.15,false,"#FFFFFF");
            bar(40958,49867,750,245,15,625,1);

            SubtitleLinesCustom1("uzqボーイミーツガール$",44776,49867,100,364,false,0.15,false,"#FFFFFF");
            bar(44776,49867,-120,367,15,550,1);

            SubtitleLinesCustom1("Hey!",46594,46958,320,260,false,0.25,false,"#FFFFFF");

            SubtitleLinesCustom1("ucqごちゃ混ぜたい$",47140,49867,375,130,true,0.15,false,"#FFFFFF"); 
            bar(47140,49867,285,220,240,15,2);

            SubtitleLinesCustom1("uvqシチュエーション$",47140,49867,445,210,true,0.15,false,"#FFFFFF");
            bar(47140,49867,359,310,250,15,2);


            //Bridge

            SubtitleLinesCustom2("rwgu実は-j君が--悪の-組織-と-闘う--ヒーローだ-という-l秘密-lがあっ-lたり$",50049,58594,770,250,false,0.3,false,"#000000",false,true);
            SubtitleLinesCustom1("wrqcu「なんだかんだ-j独り占めしたいな」$",55867,58594,364,285,false,0.3,false,"#000000",false,false,false,true);
            SubtitleLinesCustom3("あぁ",58594,59140,320,275,false,0.5,false,"#000000",1);
            SubtitleLinesCustom3("あぁ",59140,60049,320,275,false,0.25,false,"#000000",1);
            // SubtitleLinesCustom3("あぁ",60049,60594,320,275,false,0.125,false,"#000000",0.4);
            // SubtitleLinesCustom3("あぁ",60594,61503,320,275,false,0.0625,false,"#000000",0.3 );

            SubtitleLinesCustom3("君に",60049,60594,320,275,false,0.5,false,"#000000",1);
            SubtitleLinesCustom3("君に",60594,61503,320,275,false,0.25,false,"#000000",1);
            // SubtitleLinesCustom3("君に",61503,62049,320,275,false,0.125,false,"#000000",0.4);
            // SubtitleLinesCustom3("君に",62049,62958,320,275,false,0.0625,false,"#000000",0.3 );

            SubtitleLinesCustom3("出会った日から",61503,62049,320,275,false,0.5,false,"#000000",1);
            SubtitleLinesCustom3("出会った日から",62049,63867,320,275,false,0.25,false,"#000000",1);
            // SubtitleLinesCustom3("出会った日から",62958,63503,320,275,false,0.125,false,"#000000",0.4);
            // SubtitleLinesCustom3("出会った日から",63503,64412,320,275,false,0.0625,false,"#000000",0.3 );

            //int emergencyoffset = 100;
            int emergencyoffsetX = 90;
            int emergencyoffsetY = -100;
            // Perspective("わたしの",63867,70231,312+emergencyoffsetX,142,false,0.25,false,"#000000",false,false,true,1);
            // Perspective("毎日は",64776,70231,600+emergencyoffsetX,200,true,0.25,false,"#000000",false,false,true,2);
            // Perspective("ラブコメに",65867,70231,300+emergencyoffsetX,400,false,0.25,false,"#000000",true,false,true,3);
            // Perspective("変わった",66594,70231,200+emergencyoffsetX,50,true,0.25,false,"#000000",false,true,true,4);
            // Perspective("んだ",68412,70231,320+emergencyoffsetX,270,false,0.25,false,"#000000",false,false,true,5);

            //Alternative
            SubtitleLinesCustom1("buわたしの毎日はラブコメにんだ",63867,70231,345,267,false,0.30,false,"#000000",false,true);

            //Scene 3
            //skiword(70231,76049);
            SkiKiai(70231);
            SkiKiai(70594);
            SkiKiai(70958);
            SkiKiai(71321);
            SkiKiai(71685);
            SkiKiai(72049);
            SkiKiai(72412);
            SkiKiai(72776);
            SkiKiai(73140);
            SkiKiai(73503);
            SkiKiai(73867);
            SkiKiai(74231);
            SkiKiai(74594);
            SkiKiai(75321);

            Kiai1Preset("君が",76049,76594,320,265,false,0.7,false,"#FFFFFF",1);
            Kiai1Preset("君で",76594,77503,320,265,false,0.7,false,"#FFFFFF",2);
            Kiai1Preset("ある",77140,77503,320,265,false,0.7,false,"#FFFFFF",2.1);
            Kiai1Preset("ため",77503,77867,320,265,false,0.7,false,"#FFFFFF",3);
            Kiai1Preset("の",77867,78231,320,265,false,0.7,false,"#FFFFFF",4);
            Kiai1Preset("存在",78231,78958,320,265,true,0.7,false,"#FFFFFF",5);
            Kiai1Preset("すべて",78958,81321,320,265,false,0.7,false,"#FFFFFF",6);
            Kiai1Preset("が",80231,81321,320,265,false,0.7,false,"#FFFFFF",7);

            SubtitleLinesCustom5Movement("qru弾けそうなんだ",81321,87685,703-13,55,true,0.37,false,"#FFFFFF");
            SubtitleLinesCustom5Movement("qruもうだめだ",83321,87685,300-13,55,true,0.37,false,"#FFFFFF");
            SubtitleLinesCustom5Movement("qru抑えきれない",84776,87685,490,55,true,0.37);

            SubtitleLinesCustom6("pいつか",87685,89140,320,266);
            SubtitleLinesCustom1("bいつか結ばれますように",89140,93503,320,266,false,0.4);


            //Scene 5

            //skiword(93503,99321);
            SkiKiai(93503);
            SkiKiai(93867);
            SkiKiai(94231);
            SkiKiai(94594);
            SkiKiai(94958);
            SkiKiai(95321);
            SkiKiai(95685);
            SkiKiai(96049);
            SkiKiai(96412);
            SkiKiai(96776);
            SkiKiai(97140);
            SkiKiai(97503);
            SkiKiai(97867);
            SkiKiai(98594);

            Kiai2Preset("そんな！",99321,99867,320,265,false,0.7,false,"#FFFFFF",1);
            Kiai2Preset("不意に！",99867,100412,320,265,false,0.7,false,"#FFFFFF",2);
            Kiai2Preset("予告",100412,100958,320,265,false,0.7,false,"#FFFFFF",2.1);
            Kiai2Preset("なしに",100958,101503,320,265,false,0.7,false,"#FFFFFF",3 );
            Kiai2Preset("訪れる",101503,106594,320,265,false,0.7,false,"#FFFFFF",4);
            Kiai2Preset("んだ",104594,106594,320+100,265,false,0.5,false,"#FFFFFF",5);
            
            SubtitleLinesCustom1("b髪をほどいたわたし見て",106594,110958,330,265,false,0.35,false,"#FFFFFF");

            SubtitleLinesCustom5Movement("君が",110958,119685,320,265,false,0.35,false,"FFFFFF",0,1);
            SubtitleLinesCustom5Movement("キュンと",112412,119685,320,265,false,0.35,false,"FFFFFF",0,2);
            SubtitleLinesCustom5Movement("キュンと",113867,119685,320,265,false,0.35,false,"FFFFFF",0,3);
            SubtitleLinesCustom5Movement("しますように",115321,119685,320,265,false,0.35,false,"FFFFFF",0,4);


             SubtitleLinesCustom1("zfq一目見たときビビビッと心に電気が走った",131322,142594,530,222,false,0.15,false,"#FFFFFF"); 
            bar(131322,142594,750,227,15,835,1);

            SubtitleLinesCustom1("xdq絶対絶対絶対これは運命だ",137140,142594,100,282,false,0.15,false,"#FFFFFF");
            bar(137140,142594,-115,287,15,610,1);

            SubtitleLinesCustom1("vqfねえほらドキドキしてやばいの",142594,157503,395,330,false,0.15,false,"#FFFFFF"); 
            bar(142594,157503,379,335,15,305,1);

            SubtitleLinesCustom1("cqd世界中で君だけだよ叫んじゃいたいぜ",148776,157503,150,210,false,0.15,false,"#FFFFFF");
            bar(148776,157503,130,215,15,365,1);

            //English("Wow, oh oh!",155322,160412,320,240,false,0.25,false,true);
            English("すき！",172049,173503,320,240,false,0.25+(0.031825*1),true);
            English("すき！",173503,173867,320,240-(5),false,0.25+(0.031825*2),true);
            English("すき！",173867,174231,320,240-(7),false,0.25+(0.031825*3),true);
            English("すき！",174231,174594,320,240-(9),false,0.25+(0.031825*4),true);
            English("すき！",174594,174958,320,240-(12),false,0.25+(0.031825*5),true);
            English("すき！",174958,177140,320,240-(15),false,0.25+(0.031825*6),true);

            English("すき！",177140,177503,320,240-(19),false,0.25+(0.031825*7),true);
            English("すき！",177503,177867,320,240-(21),false,0.25+(0.031825*8),true);
            English("すき！",177867,180775,320,240-(24),false,0.25+(0.031825*9),true);


            SubtitleLinesCustom1("q「君を振り向かせるにはどうしたらいいんだろう？」",181322,187322,320,250,false,0.3,false,"#000000",false,false,false,true);
            SubtitleLinesCustom1("q「やっぱりもっと自分を変えなきゃいけないのかな？」",184231,187322,320,285,false,0.3,false,"#000000",false,false,false,true);
            SubtitleLinesCustom1("q「とか思ったりしたけどさ」",187685,192594 ,320,250,false,0.3,false,"#000000",false,false,false,true);
            SubtitleLinesCustom1("q「わたしはわたしのまま、-君に伝えればいいんだよね」",189322,192594,320,285,false,0.3,false,"#000000",false,false,false,true);

            SubtitleLinesCustom3("あぁ",192958,193867,320,275,false,0.5,false,"#000000",1,1);
            SubtitleLinesCustom1("qfあぁ誰でも---r主人公なんだ",193867,197685,367,266,false,0.25,false,"#000000",false,true);

             SubtitleLinesCustom1("bu他の誰でもないわたしを生きてゆくんだ",197685,205503,345,267,false,0.30,false,"#000000",false,true);

            // SubtitleLinesCustom1

            //Calm before the storm
            
            SubtitleLinesCustom1("すき!",205503,205867,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",205867,206231,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",206231,206594,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",206594,206958,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",206958,207322,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",207322,207685,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",207685,208049,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",208049,208412,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",208412,208776,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",208776,209140,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",209140,209503,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",209503,209867,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",209867,210594,320,265,false,0.25,true,"#FFFFFF");
            SubtitleLinesCustom1("すき!",210594,211322,320,265,false,0.25,true,"#FFFFFF");


            SubtitleLinesCustom1("qcd君が君であるための存在すべてが",211322,216594,353,266);
            SubtitleLinesCustom1("qzf弾けそうな----んだもうだめだ",216594,222776,373,240);
            SubtitleLinesCustom1("qcd抑えきれない",220049,222776,350,290 );
            SubtitleLinesCustom1("qいつか----結ばれますように",222776,230231,360,266);

            SubtitleLinesCustom3("Ah!!!",230231,232776,320,260,false,0.5,false,"#FFFFFF",1,2);



            SkiKiai(233140);
            SkiKiai(233503);
            SkiKiai(233867);
            SkiKiai(234231);
            SkiKiai(234594);
            SkiKiai(234958);
            SkiKiai(235322);
            SkiKiai(235685);
            SkiKiai(236049);
            SkiKiai(236412);
            SkiKiai(236776);
            SkiKiai(237140);
            SkiKiai(237503);
            SkiKiai(238231);

            Kiai1Preset("君が",238958,239503,320,265,false,0.7,false,"#FFFFFF",1);
            Kiai1Preset("くれた",239503,240049,320,265,false,0.7,false,"#FFFFFF",2);
            Kiai1Preset("たくさん",240049,240776,225,265,false,0.7,false,"#FFFFFF",2.1);
            Kiai1Preset("の",240776,241140,320,265,false,0.7,false,"#FFFFFF",4);            
            Kiai1Preset("気持ち",241140,241503,320,265,false,0.7,false,"#FFFFFF",3);
            Kiai1Preset("の",241503,241867,320,265,false,0.7,false,"#FFFFFF",4);
            Kiai1Preset("すべて",241867,244231,320,265,false,0.7,false,"#FFFFFF",6);
            Kiai1Preset("が",243140,244231,320,265,false,0.7,false,"#FFFFFF",7);

            SubtitleLinesCustom5Movement("qruこぼれそうな",244231,250594,703-13,55,true,0.37,false,"#FFFFFF");
            SubtitleLinesCustom5Movement("qruんだ",244776,250594,530,55,true,0.37,false,"#FFFFFF");
            SubtitleLinesCustom5Movement("qruもうだめだ",246231,250594,300-13,55,true,0.37,false,"#FFFFFF");
            SubtitleLinesCustom5Movement("qruこの思いが",247685,250594,463,55,true,0.37);

            SubtitleLinesCustom6("pぎゅぎゅっと",250594,252049,280,266);
            SubtitleLinesCustom1("b伝わりますように",252049,256412,330,266,false,0.4);


            //Scene 5

            //skiword(256412,99321);
            SkiKiai(256412);
            SkiKiai(256776);
            SkiKiai(257140);
            SkiKiai(257503);
            SkiKiai(257867);
            SkiKiai(258231);
            SkiKiai(258594);
            SkiKiai(258958);
            SkiKiai(259321);
            SkiKiai(259685);
            SkiKiai(260049);
            SkiKiai(260412);

            // SkiKiai(260776);
            // SkiKiai(260958);
            // SkiKiai(261140);
            // SkiKiai(261321);
            // SkiKiai(261503); 
            // SkiKiai(261685);
            // SkiKiai(261867);
            // SkiKiai(262049);
            // SkiKiai(262231);

            honestlytoomucheffort();
            honestlytoomucheffortbg();  
            
            SubtitleLinesCustom1("b全速力の向こうに",269503,273867,330,265,false,0.35,false,"#FFFFFF");

            SubtitleLinesCustom7Movement("何かが",273867,279685,320,265,false,0.35,false,"FFFFFF",0,1);
            SubtitleLinesCustom7Movement("きっと",275321,279685,320,265,false,0.35,false,"FFFFFF",0,2);
            SubtitleLinesCustom7Movement("きっと",276776,279685,320,265,false,0.35,false,"FFFFFF",0,3);
            SubtitleLinesCustom7Movement("待ってる",278231,279685,320,265,false,0.35,false,"FFFFFF",0,4);

            //SubtitleLinesCustom1("何かがきっときっと待ってる",273867,279685,320,330,false,0.35,false,"FFFFFF");

            SubtitleLinesCustom8Movement("曲がり角",279685,288412,320,265,false,0.35,false,"FFFFFF",0,1);
            SubtitleLinesCustom8Movement("で",281140,288412,320,265,false,0.35,false,"FFFFFF",0,2);
            SubtitleLinesCustom8Movement("君に",282594,288412,320,265,false,0.35,false,"FFFFFF",0,3);
            SubtitleLinesCustom8Movement("会えますように",284049,288412,320,265,false,0.35,false,"FFFFFF",0,4);


            //SubtitleLinesCustom1("曲がり角で君に会えますように",279685,288412,320,330,false,0.35,false,"FFFFFF");





            // Ending
            SkiKiai(288776);
            SkiKiai(289140);
            SkiKiai(289503);
            SkiKiai(289867);
            SkiKiai(290231);
            SkiKiai(290594);
            SkiKiai(290958);

            SkiKiai(291685);
            SkiKiai(292049);
            SkiKiai(292776);
            SkiKiai(292412);
            SkiKiai(293140);
            SkiKiai(293503);
            SkiKiai(293867);

            Kiai1Preset("すき!",262231,262958,320,266,false,0.80,false,"#FFFFFF",8);
            Kiai1Preset("すき!",262958,263685,320,266,false,0.50,false,"#FFFFFF",9);
            Kiai1Preset("すき!",263685,264412,320,266,false,0.80,false,"#FFFFFF",8);
            Kiai1Preset("すき!",264412,265140,320,266,false,0.50,false,"#FFFFFF",9);
            Kiai1Preset("すき!",265140,269503,320,266,false,0.80,false,"#FFFFFF",10);
            Kiai1Preset("なんだ",267503,269503,320,266,false,0.5,false,"#FFFFFF",11);

            SubtitleLinesCustom1("cd何も$",294231,295685,365,265,false,0.40);
            SubtitleLinesCustom1("vfかもが$",295685,297140,365,265,false,0.40);
            SubtitleLinesCustom1("zsあぁ!$",297140,302231,365,265,false,0.40);
            SubtitleLinesCustom1("xa好きです$",302231,308594,365,265,false,0.40);



            //Light Blue #FFFFFF
            //Dark Blue #40B0DF
            //Purple #CBC3E3
            //Red #FF8886
            //Pink #FFB6C1
            //Yellow #FED037

            //White #FFFFE0





            // SubtitleLinesCustom1("すき! すき! すき! すき! すき! すき! すき! すき! ",3322,9140,debugaXcord,263,true);


            // Up Down

        }

    }
}


// if(!texture.IsEmpty)
// {

//     layer = GetLayer("Subs");
//     var position = new Vector2((float)letterX, (float)letterY) 
//         + texture.OffsetFor(origin) * (float)scale;
    
//     var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, position);
//     sprite.Color(starttime,colorpick);
//     sprite.Fade(OsbEasing.OutQuad,starttime,starttime+100,0,1);
//     sprite.Fade(endtime,endtime+100,1,0);

    

//     if(flip==false)
//     {
//         letterX += texture.BaseWidth * scale;

//     }
//     else if(flip==true)
//     {
//         letterY += texture.BaseHeight * scale;
//     }
// }
// else
// {
//     letterX += 15;
// }