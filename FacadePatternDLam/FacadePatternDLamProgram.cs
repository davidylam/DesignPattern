using System;

namespace FacadePatternDLam
{
    class FacadePatternDLamProgram
    {
        static void Main(string[] args)
        {
            CommandCenter c = new CommandCenter();
            Console.WriteLine("-----Personal");
            c.PersonalSubsystem();
            Console.WriteLine("-----Commercial");
            c.CommercialSubsystem();
        }

        public class CommandCenter {
            Automatic _a = new Automatic();
            UW _uw = new UW();
            UWSupervisor _uws = new UWSupervisor();

            public void PersonalSubsystem() {
                _a.Display();
                _uw.Display();
            }
            public void CommercialSubsystem()
            {
                _uw.Display();
                _uws.Display();
            }
        }

        public class Automatic
        {
            public void Display()
            {
                Console.WriteLine("From Automatic");
            }
        }
        
        public class UW {
            public void Display() {
                Console.WriteLine("From UW");
            }
        }
        public class UWSupervisor
        {
            public void Display()
            {
                Console.WriteLine("From UW Supervisor");
            }
        }
    }
}
