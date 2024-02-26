using System;

namespace Lab9
{
    public class CarParkingArray
    {
        CarParking[] parking;
        static Random rnd = new Random();
        static int count2 = 0;
        public int Length
        {
            get { return parking.Length; }
        }

        public void Show()
        {
            if (parking != null && parking.Length > 0)
            {
                for (int i = 0; i < parking.Length; i++) { Console.WriteLine(parking[i].ToString() + $", загруженность {parking[i].Workload()}%"); }
                Console.WriteLine();
            }
            else Console.WriteLine("Коллекция пуста\n");
        }
        public CarParkingArray(params CarParking[] p)
        {
            parking = new CarParking[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                this.parking[i] = new CarParking(p[i].NumCars, p[i].NumSlots);
            }
            count2++;
        }
        public CarParkingArray(int length)
        {
            if (length > 0)
            {
                parking = new CarParking[length];
                for (int i = 0; i < length; i++)
                {
                    int rand = rnd.Next(1, 100);
                    parking[i] = new CarParking(rnd.Next(1, rand), rand);
                }
            }
            count2++;
        }
        public CarParkingArray()
        {
            parking = new CarParking[3];
            for (int i = 0; i < 3; i++)
            {
                parking[i] = new CarParking();
            }
            count2++;
        }
        public CarParkingArray(CarParkingArray other) //copy
        {
            this.parking = new CarParking[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                this.parking[i] = new CarParking(other.parking[i]);
            }
            count2++;
        }
        public CarParking this[int index]
        {
            get
            {
                if (0 <= index && index < parking.Length)
                    return parking[index];
                else
                    throw new Exception($"Индекс {index} выходит за пределы коллекции");
            }
            set
            {
                if (0 <= index && index < parking.Length)
                    parking[index] = value;
                else
                    Console.WriteLine($"Индекс {index} выходит за пределы коллекции");
            }
        }
        public static int GetCount()
        {
            Console.WriteLine($"Создано = {count2} коллекции");
            return count2;
        }
    }
}
