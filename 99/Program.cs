using System;

namespace Lab9
{
    internal class Program
    {
        static void FoundCarParking(CarParkingArray parking)
        {
            if (parking != null && parking.Length > 0)
            {
                double minWorkload = 110;
                int FreePlace = 0;
                for (int i = 0; i < parking.Length; i++)
                {
                    if (parking[i].Workload() < minWorkload)
                    {
                        minWorkload = parking[i].Workload();
                        FreePlace = parking[i].NumSlots - parking[i].NumCars;
                    }
                }
                Console.WriteLine($"\nКоличество пустых мест на наименее загруженной парковке = {FreePlace}");
            }
            else Console.WriteLine("Парковок нет");

        }

        public static int Number(string msg) //ввод числа
        {
            int number;
            Console.WriteLine(msg);
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                return number;
            }
            catch (Exception m)
            {
                Console.WriteLine(m);
                return Number(msg);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                CarParking p1 = new CarParking(Number("Введите количество машин"), Number("Введите количество парковочных мест"));
                Console.WriteLine("-------------Загруженность парковки ручной ввод-------------");
                p1.ShowCarParking();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            CarParking p2 = new CarParking();
            Console.WriteLine("-------------Загруженность парковки ДСЧ-------------");
            p2.ShowCarParking();

            CarParking p3 = new CarParking(p2);
            Console.WriteLine("-------------Конструктор копирования-------------");
            p3.ShowCarParking();
            Console.WriteLine($"Загруженность парковки(метод класса) = {p3.Workload()}%");//Не статическая 
            Console.WriteLine($"Загруженность парковки(статическая функция) = {CarParking.Workload(p3.NumCars, p3.NumSlots)}%"); //  статическая 


            // 2 part
            Console.WriteLine("------------- Унарная операция ++   -------------");
            CarParking p4 = p2++;
            p4.ShowCarParking();
            Console.WriteLine("------------- Унарная операция --   -------------");
            CarParking p5 = p2--;
            p5.ShowCarParking();
            Console.WriteLine("------------- Неявное преобразоывание к типу bool (на парковке есть свободные места) -------------");
            bool b = p4;
            Console.WriteLine(b);
            Console.WriteLine("------------- Явное преобразоывание к типу int -------------");
            p4.ShowCarParking();
            Console.WriteLine($"До 80% нужно {(int)p4} машин");
            Console.WriteLine("------------- Бинарная операция +   -------------");
            CarParking p6 = p2 + p3;
            p6.ShowCarParking();
            Console.WriteLine("------------- Бинарные операции > и <  -------------");
            CarParking p7 = new CarParking();
            Console.WriteLine("------------- cp1 -------------");
            p4.ShowCarParking();
            Console.WriteLine("------------- cp2 -------------");
            p7.ShowCarParking();
            Console.WriteLine($"cp1 > cp2 {p4 > p7}");
            Console.WriteLine($"cp1 < cp2 {p4 < p7}");


            Console.WriteLine("------------- Parking1 -------------");
            CarParkingArray cp1 = new CarParkingArray(5);
            cp1.Show();
            Console.WriteLine("------------- Parking2 (копия 1) -------------");
            CarParkingArray cp2 = new CarParkingArray(cp1);
            cp2.Show();
            cp1[0] = new CarParking(10, 100); //set правильный
            Console.WriteLine($"cp1[0] = {cp1[0]}"); //get
            Console.WriteLine("------------- Parking1(с изменениями) -------------");
            cp1.Show();
            Console.WriteLine("------------- Parking2 -------------");
            cp2.Show();
            try //
            {
                cp2[100] = new CarParking(10, 20); //set неправильный
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try //
            {
                Console.WriteLine(cp2[50]); //get
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            FoundCarParking(cp2);  //поиск наименее зашруженной
            Console.WriteLine("\n------------- Parking3 (без параметров) -------------");
            CarParkingArray cp3 = new CarParkingArray();
            cp3.Show();

            try
            {
                CarParking CP1 = new CarParking(Number("Введите количество машин"), Number("Введите количество парковочных мест"));
                CarParking CP2 = new CarParking(Number("Введите количество машин"), Number("Введите количество парковочных мест"));
                CarParking CP3 = new CarParking(Number("Введите количество машин"), Number("Введите количество парковочных мест"));
                CarParkingArray cp4 = new CarParkingArray(CP1, CP2, CP3); //
                Console.WriteLine("\n------------- Parking4 (ввод с клавиатуры) -------------");
                cp4.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            CarParking.GetCount();
            CarParkingArray.GetCount();


            Console.ReadLine();
        }
    }
}