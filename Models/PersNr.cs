using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnummer_kontroll.Models
{
    public class PersNr
    {
        public List<int> Personnummer { get; set; }
        public string Input { get; set; }
        public int ControlSum { get; set; }


        public void RunProgram()
        {
            InputPhase();
            Personnummer = new List<int>();
            if (!CheckInput())
            {
                Console.WriteLine("Ange 9st siffror");
                return;
            }
            if (!CheckValidPersNr())
            {
                Console.WriteLine("Fel Månad/Datum");
            }
            try
            {
                CalcControlSum();
            }
            catch (Exception)
            {
                throw new Exception("Något gick fel vid beräkningen av kontrollsumman");
            }
            Console.WriteLine($"Kontrollsumman är: {ControlSum}");

        }

        private void CalcControlSum()
        {
            int multiplier = 2;
            int sumOfDigits = 0;
            foreach (var item in Personnummer)
            {
                if (item * multiplier > 10)
                {
                    sumOfDigits += (item * multiplier) / 10;
                    sumOfDigits += (item * multiplier) % 10;
                }
                else
                {
                    sumOfDigits = item * multiplier;
                }
                
                if (multiplier == 2)
                {
                    multiplier = 1;
                }
                if (multiplier == 1)
                {
                    multiplier = 2;
                }
            }
            Console.WriteLine(sumOfDigits);
            ControlSum = (10 - (sumOfDigits % 10)) % 10;
        }

        private bool CheckValidPersNr()
        {
            // Check Month
            int month = (Personnummer[2] * 10) + Personnummer[3];
            if (month < 1 || month > 12)
            {
                return false;
            }

            //Check Date
            int date = (Personnummer[4] * 10) + Personnummer[5];
            if (date < 1 || date > 31)
            {
                return false;
            }

            return true;
        }

        private bool CheckInput()
        {
            //Check input has correct length
            if (Input.Length < 9 || Input.Length > 9)
            {
                return false;
            }

            //Check input only contains digits
            for (int i = 0; i < Input.Length; i++)
            {
                int e;
                char a = Input[i];
                if (int.TryParse(a.ToString(), out e))
                {
                    Personnummer.Add(e);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void InputPhase()
        {
            // Prompts user for input
            Console.WriteLine("Ange ett personnummer utan kontrollsiffra");
            Input = Console.ReadLine();
        }
    }
}
