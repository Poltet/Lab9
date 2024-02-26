using System;

namespace Lab9
{
    public class CarParking
    {
        int numSlots;
        int numCars;
        Random rnd = new Random();
        static int count = 0;
        public int NumCars
        {
            get => numCars;
            set
            {
                if (value < 0)
                    throw new Exception("Количество машин не может быть меньше 0");
                else if (value > NumSlots)
                    throw new Exception("Количество машин не может быть больше количества парковочных мест");
                else numCars = value;
            }
        }
        public int NumSlots
        {
            get => numSlots;
            set
            {
                if (value < 0)
                    throw new Exception("Количество парковочных мест не может быть меньше 0");
                else numSlots = value;
            }
        }
        public CarParking()
        {
            NumSlots = rnd.Next(1, 100);
            NumCars = rnd.Next(1, NumSlots);
            count++;
        }
        public CarParking(int NumCars, int NumSlots)
        {
            this.NumSlots = NumSlots;
            this.NumCars = NumCars;
            count++;
        }
        public CarParking(CarParking p)
        {
            this.NumSlots = p.NumSlots;
            this.NumCars = p.NumCars;
            count++;
        }
        public static double Workload(int NumCars, int NumSlots)
        {
            return Math.Round(NumCars * 100.0 / NumSlots, 2);
        }
        public double Workload()
        {
            return Math.Round(NumCars * 100.0 / NumSlots, 2);
        }
        public static int GetCount()
        {
            Console.WriteLine($"Создано = {count} объектов");
            return count;
        }
        public void ShowCarParking()
        {
            Console.WriteLine($"\nКоличество машин = {NumCars}");
            Console.WriteLine($"Количество парковочных мест = {NumSlots}");
            Console.WriteLine($"Загруженность парковки {Workload(NumCars, NumSlots)}%\n");
        }

        public static CarParking operator ++(CarParking p)
        {
            CarParking temp = new CarParking(p);
            if (temp.NumCars + 1 <= temp.NumSlots) temp.NumCars = temp.NumCars + 1;
            else temp.NumCars = temp.NumCars;
            return temp;
        }
        public static CarParking operator --(CarParking p)
        {
            CarParking temp = new CarParking(p);
            if (temp.NumCars - 1 >= 0) temp.NumCars = temp.NumCars - 1;
            else temp.NumCars = temp.NumCars;
            return temp;
        }
        public static explicit operator int(CarParking p)
        {
            return p.numSlots * 80 / 100 - p.NumCars;
        }
        public static implicit operator bool(CarParking p)
        {
            return p.NumSlots > p.NumCars;
        }
        public static CarParking operator +(CarParking cp1, CarParking cp2)
        {
            CarParking temp = new CarParking();
            temp.NumSlots = cp1.NumSlots + cp2.NumSlots;
            temp.NumCars = cp1.NumCars + cp2.NumCars;
            return temp;
        }
        public static bool operator >(CarParking cp1, CarParking cp2)
        {
            return cp1.Workload() < cp2.Workload() && cp1.NumSlots > cp2.NumSlots; //
        }
        public static bool operator <(CarParking cp1, CarParking cp2)
        {
            return Workload(cp1.NumCars, cp1.NumSlots) > Workload(cp2.NumCars, cp2.NumSlots) && cp1.NumSlots < cp2.NumSlots; //
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((CarParking)obj).NumSlots == NumSlots && ((CarParking)obj).NumCars == NumCars;
        }
        public override string ToString()
        {
            return $"{NumCars} машин(ы) и {NumSlots} парковок";
        }
    }
}