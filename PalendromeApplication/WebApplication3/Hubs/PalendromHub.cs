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
                    int halway = Convert.ToInt32(Math.Floor(val));
                    int caseVar = 0;
                    for (int j = 0; j < sizeOfword; j++)
                    {
                        switch (caseVar)
                        {
                            case 1:
                                tempWord += letters[randNum.Next(letters.Length)];
                                if (j < halway)
                                    caseVar = 2;
                                break;
                            case 2:
                                if (sizeOfword % 2 == 0)
                                {
                                    caseVar = 3;

                                }
                                else
                                {
                                    caseVar = 4;
                                }
                                break;
                            case 3:
                                
                                break;
                            case 4:
                                break;

                        }
                        //Checks if the word generation is halfway
                        if (j < halway&&sizeOfword%2==0)
                        {
                            
                        }
                        if(j < halway && sizeOfword % 2 != 0)
                        {

                        }
                        else
                        {
                            tempWord += letters[randNum.Next(letters.Length)];
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