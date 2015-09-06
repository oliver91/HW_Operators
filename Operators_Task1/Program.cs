using System;

namespace Operators_Task1
{
    class Program
    {
        private static void Main()
        {
            Computer comp1 = new Computer("comp1", "some description",
                new RAM("Kingstone", 4), 
                new HDD("WD", 128), 
                new CPU("Intel", 2400));
            comp1.ShowInfo();

            Computer comp2 = new Computer("comp2", "some description",
                new RAM("Kingstone", 2),
                new HDD("WD", 128),
                new CPU("Intel", 1200));
            comp2.ShowInfo();

            Computer comp3 = new Computer("comp3", "some description",
                new RAM("GoodRam", 8),
                new HDD("Sumsung", 320),
                new CPU("AMD", 1400));
            comp3.ShowInfo();

            Console.WriteLine("\n{0} + {1} = ", comp1.HostName, comp2.HostName);
            try
            {
                Computer superComp = comp1 + comp2;
                superComp.ShowInfo();
            }
            catch (IncompatibleComponentsException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n{0} + {1} = ", comp1.HostName, comp3.HostName);
            try
            {
                Computer superComp2 = comp1 + comp3;
                superComp2.ShowInfo();
            }
            catch (IncompatibleComponentsException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("\n\nClone DEMO (changing comp1 cpu vendor): ");
            Computer comp4 = (Computer)comp1.Clone();
            comp4.HostName = "comp1Clone";
            comp1.Cpu.Vendor = "AMD";
            comp1.ShowInfo();
            comp4.ShowInfo();

            Console.WriteLine("\n\nDeepClone DEMO (changing comp3 cpu value): ");
            Computer comp5 = comp3.DeepClone();
            comp5.HostName = "comp3Clone";
            comp3.Cpu.Value = 1300;
            comp3.ShowInfo();
            comp5.ShowInfo();
        }
    }
}
