
using System;

namespace Operators_Task1
{
    class Computer : ICloneable
    {
        protected bool Equals(Computer other)
        {
            return Equals(Ram, other.Ram) && Equals(Hdd, other.Hdd) && Equals(Cpu, other.Cpu);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Computer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Ram != null ? Ram.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Hdd != null ? Hdd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Cpu != null ? Cpu.GetHashCode() : 0);
                return hashCode;
            }
        }

        public string HostName { get; set; }
        public string Description { get; set; }
        public RAM Ram { get;}
        public HDD Hdd { get;}
        public CPU Cpu { get;}

        public Computer(string hostName, string description, RAM ram, HDD hdd, CPU cpu)
        {
            HostName = hostName;
            Description = description;
            Ram = ram;
            Hdd = hdd;
            Cpu = cpu;
        }

        public void ShowInfo()
        {
            Console.WriteLine("\nhostName: {0}\ndescription: {1}\n" +
                              "specification:\n " +
                              "RAM: {2} {3} Gb, HDD: {4} {5} Gb, CPU: {6} {7} Mhz",
                HostName, Description, Ram.Vendor, Ram.Value, 
                Hdd.Vendor, Hdd.Value, Cpu.Vendor, Cpu.Value);
        }


        public static bool operator ==(Computer c1, Computer c2)
        {
            if (c1.Ram.Vendor == c2.Ram.Vendor &&
                c1.Hdd.Vendor == c2.Hdd.Vendor &&
                c1.Cpu.Vendor == c2.Cpu.Vendor)
                return true;
            return false;
        }

        public static bool operator !=(Computer c1, Computer c2)
        {
            if (c1?.Ram.Vendor == c2.Ram.Vendor &&
                c1.Hdd.Vendor == c2.Hdd.Vendor &&
                c1.Cpu.Vendor == c2.Cpu.Vendor)
                return false;
            return true;
        }

        public static Computer operator +(Computer c1, Computer c2)
        {
            if (c1 == c2)
            {
                int ramValue = c1.Ram.Value + c2.Ram.Value;
                int hddValue = c1.Hdd.Value + c2.Hdd.Value;
                int cpuValue = c1.Cpu.Value + c2.Cpu.Value;
                string hostName = c1.HostName + c2.HostName;
                string description = String.Format("super computer combines {0} and {1}", c1.HostName, c2.HostName);
                Computer superComputer = new Computer(hostName, description,
                    new RAM(c1.Ram.Vendor, ramValue),
                    new HDD(c1.Hdd.Vendor, hddValue),
                    new CPU(c1.Cpu.Vendor, cpuValue));
                return superComputer;
            }
            else throw new IncompatibleComponentsException();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Computer DeepClone()
        {
            Computer comp = new Computer(this.HostName, this.Description,
                new RAM(Ram.Vendor, Ram.Value),
                new HDD(Hdd.Vendor, Hdd.Value),
                new CPU(Cpu.Vendor, Cpu.Value));
            return comp;
        }
    }

    public class RAM
    {
        private string vendor;
        private int value;

        public string Vendor {
            get { return vendor; }
            set { vendor = value; }
        }
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public RAM(string vend, int val)
        {
            vendor = vend;
            value = val;
        }
    }

    public class HDD
    {
        private string vendor;
        private int value;

        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public HDD(string vend, int val)
        {
            vendor = vend;
            value = val;
        }
    }

    public class CPU
    {
        private string vendor;
        private int value;

        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public CPU(string vend, int val)
        {
            vendor = vend;
            value = val;
        }
    }
}
