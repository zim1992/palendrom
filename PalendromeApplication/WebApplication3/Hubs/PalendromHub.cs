using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Timers;

namespace WebApplication3.Hubs
{
    public class PalendromHub : Hub
    {
        Timer _timer;
        Random randNum = new Random();
        public static int maxValue=12;
        public static int minValue=5;
       
        private string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "u", "t", "v", "w", "x", "y", "z" };
        public void Update(int MaxValue, int MinValue)
        {
            maxValue = MaxValue;
            minValue = MinValue;
            Clients.All.Values(maxValue,minValue);

        }
        public override Task OnConnected()
        {
            int minValLoc = minValue;
            int maxValLoc = maxValue;

            if (_timer == null)
            {
                _timer = new Timer(1000);
                

                _timer.Elapsed += (s, e) =>
                {
                    string tempWord = "";
                    int sizeOfword = randNum.Next(minValLoc, maxValLoc);
                    double val = (sizeOfword / 2);
                    int halfway = Convert.ToInt32(Math.Floor(val));
                    int caseVar = 1;
                    string wordHalf="";
                    Clients.All.forloop(sizeOfword + " wordSize");
                    Clients.All.forloop(halfway + " Halfway size");
                    for (int j = 0; j < sizeOfword; j++)
                    {
                        switch (caseVar)
                        {
                            // creates the first half of the word and when it reaches half way it goes to case 2 
                            case 1:
                                tempWord += letters[randNum.Next(letters.Length)];
                                if ((j+1) > halfway) {
                                    Clients.All.forloop(j + " j point");

                                    Clients.All.forloop(sizeOfword % 2 == 0);
                                    
                                    wordHalf = tempWord;
                                    if (sizeOfword % 2 == 0)
                                    {
                                        Clients.All.forloop(wordHalf+" case1");
                                        caseVar = 2;
                                    }
                                    else
                                    {
                                        Clients.All.forloop(wordHalf + " case1");
                                        caseVar = 3;
                                    }
                                }                                    
                                break;
                            //Converts the word into a char array Determines if the word is an even or odd set of words if even it goes to case 3 and if odd then it goes to case 4
                            
                            case 2:
                                
                                tempWord += wordHalf.Substring(j-1);
                                Clients.All.forloop(wordHalf + " halfWord cas2");
                                Clients.All.forloop(tempWord+ " temp cas2");

                                break;
                            case 3:
                                tempWord += wordHalf.Substring(j-1);
                                Clients.All.forloop(wordHalf + " halfWord cas3");
                                Clients.All.forloop(tempWord + " temp cas3");
                                break;
                        }
                    }

                    Clients.All.showTime(tempWord);
                    
                    Clients.All.Values(maxValue, minValue);
                    minValLoc = minValue;
                    maxValLoc = maxValue;
                };

                _timer.Start();
            }

            return base.OnConnected();
        }
    }
}