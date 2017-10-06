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
        /**
         * This method is called when the client connects to the application every second 
         * The new palendroms are then sent to the client 
         **/ 
        public override Task OnConnected()
        {
            Clients.All.Values(maxValue, minValue);
            if (_timer == null)
            {
                _timer = new Timer(1000);
                

                _timer.Elapsed += (s, e) =>
                {
                    //clears the strings used for creating the palendroms
                    string tempWord = "";
                    string wordHalf = "";
                    //generates a size of word based on the max and min value
                    int sizeOfword = randNum.Next(minValue, maxValue);
                    //determines the halway point. 
                    double val = (sizeOfword / 2);
                    int halfway = Convert.ToInt32(Math.Floor(val));
                    //sets the case back to one so it can create  an new palendrom
                    int caseVar = 1;

                    int i = 0;
                    for (int j = 0; j < sizeOfword; j++)
                    {
                        switch (caseVar)
                        {
                            // creates the first half of the word and when it reaches half way if Even drops to case 2 and odd it adds one more letter and drops to case 3   
                            case 1:
                                //pulls a letter from the letter array. 
                                tempWord += letters[randNum.Next(letters.Length)]; 
                                if ((j+1) >= halfway) {                                                                        
                                    
                                    if (sizeOfword % 2 == 0)
                                    {
                                        
                                        caseVar = 2;
                                    }
                                    else
                                    {
                                        tempWord += letters[randNum.Next(letters.Length)];
                                        caseVar = 3;
                                    }
                                    wordHalf = tempWord;
                                    i = wordHalf.Length;
                                }                                    
                                break;
                            //Case 2 generate words for even size words                                                  
                            case 2:
                                tempWord += wordHalf.Substring((i-1),1);
                                i--;
                                break;
                            //Case 3 generates words for odd sized words
                            case 3:
                                if ((i-2) >= 0)
                                {
                                    tempWord += wordHalf.Substring((i - 2), 1);
                                }                            
                                i--;
                                break;
                        }
                    }
                    //updates the client when a word is a
                    Clients.All.palindromes(tempWord);
                    
                };

                _timer.Start();
            }

            return base.OnConnected();
        }
    }
}