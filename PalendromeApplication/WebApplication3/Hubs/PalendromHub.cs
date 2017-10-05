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
            if (MaxValue > MinValue)
            {
                maxValue = MaxValue;
                minValue = MinValue;
                Clients.All.Values(maxValue, minValue);
            }           

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
                    int i = 0;
                    for (int j = 0; j < sizeOfword; j++)
                    {
                        switch (caseVar)
                        {
                            // creates the first half of the word and when it reaches half way it goes to case 2 
                            case 1:
                                tempWord += letters[randNum.Next(letters.Length)]; 
                                if ((j+1) >= halfway) {                                                                        
                                    
                                    if (sizeOfword % 2 == 0)
                                    {
                                        
                                        caseVar = 2;
                                    }
                                    else
                                    {
                                        tempWord += letters[randNum.Next(letters.Length)];
                                        i = wordHalf.Length;
                                        caseVar = 3;
                                    }
                                    wordHalf = tempWord;
                                    i = wordHalf.Length;
                                }                                    
                                break;
                            //Converts the word into a char array Determines if the word is an even or odd set of words if even it goes to case 3 and if odd then it goes to case 4
                            
                            case 2:
                                tempWord += wordHalf.Substring((i-1),1);
                                i--;
                                break;
                            case 3:
                                if ((i-2) >= 0)
                                {
                                    tempWord += wordHalf.Substring((i - 2), 1);
                                }                            
                                i--;
                                break;
                        }
                    }

                    Clients.All.palindromes(tempWord);                    
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