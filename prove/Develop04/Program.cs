using System;
using System.Net.Quic;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop04 World!");
        int choice = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(
                "1. Breathing Activity\n"+
                "2. Reflecting Activity\n"+
                "3. Listing Activity\n"+
                "4. Sensory Counting Activity\n"+
                "5. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BreathingActivity breathe = new BreathingActivity("Breathing Activity",
                        "relax by walking you through breathing in and out slowly." +
                        "Clear your mind and focus on your breathing.");
                    breathe.BeginActivity();
                    breathe.RunActivity();
                    breathe.EndActivity();
                    break;
                
                case 2:
                    ReflectionActivity reflect = new ReflectionActivity("Reflection Activity",
                        "reflect on positive aspects of an experience.");
                        reflect.BeginActivity();
                        reflect.RunActivity();
                        reflect.EndActivity();
                    break;

                case 3:
                    ListingActivity list = new ListingActivity("Listing Activity",
                        "reflect on good things in your life by having you list as many things as possible.");
                    list.BeginActivity();
                    list.RunActiviity();
                    list.EndActivity();
                    break;

                case 4:
                    SensoryCountingActivity counting = new SensoryCountingActivity("Sensory Counting Activity",
                        "appreciate your surroundings by guiding you to identify colored things.");
                    counting.BeginActivity();
                    counting.RunActiviity();
                    counting.EndActivity();
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("I do not recognize that choice.");
                    break;
            }
        } while (choice != 5);
    }
}