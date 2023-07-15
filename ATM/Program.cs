namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enter();
        }


        public static string newPassword = "123456";
        public static double balance = 123000.34;
        public static double helpBalance = balance;
        public static void Payment()
        {
            Console.Clear();
            if (helpBalance < 0)
            {
                Console.WriteLine("Hisobingizda yetarli mablag' mavjud emas !");
                helpBalance = balance;
            }
            else
            {
                balance = helpBalance;

                Console.Clear();
                Console.WriteLine("Muvaffaqiyatli amalga oshirildi !");
                Console.WriteLine($"Balansingizda {balance} - so'm qoldi ");
            }
            BackMenu();
        }
        public static byte choose()
        {
            Console.Write("Kategoriyani tanlang : ");
            byte choosen = 0;
            while (!byte.TryParse(Console.ReadLine(), out  choosen))
            {
                Console.WriteLine("\n Iltimos faqat berilgan kategoriyani tanlang ! ");
            }
            return choosen;
        } 
        public static void Enter()
        {
            Console.WriteLine("Chooose the language (Tilni tanlang) ");
            Console.WriteLine("1.O'zbek");
            Console.WriteLine("2.English");

            double.TryParse(Console.ReadLine(), out double choosen);
            if(choosen == 1)
            {
                Password();
            }
            
        }
        static void Password()
        {
            Console.Clear();
            Console.Write("Parolni kiriting : ");
            string password = Console.ReadLine();
            if (password == newPassword)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Parol xato parolni qayta kiriting ");
                Console.ReadKey();
                Password();
            }
        }    
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("MENU");
            Console.WriteLine("1.Balansni tekshirish");
            Console.WriteLine("2.Naqd pul olish");
            Console.WriteLine("3.SMS xabarnoma");
            Console.WriteLine("4.Parolni o'zgartirish");
            Console.WriteLine("5.Mobil aloqa uchun to'lov");
            Console.WriteLine("6.Kredit uchun to'lovlar");
            Console.WriteLine("7.Kommunal to'lovlar");
            Console.WriteLine("0.Dasturdan chiqish");

            switch (choose())
            {
                case 1:   Balance();  break;
                case 2:   GetMoney(); break;
                case 3:   SMS();      break;
                case 4: ChangePassword(); break;
                case 5:;  break;
                case 6:;  break;
                case 7:;  break;
                case 0:; break;
                default: Menu(); break;
            }
        }
        public static void Balance()
        {
            Console.Clear();
            Console.WriteLine("BALANS");
            Console.WriteLine($"Balansingizda {balance} so'm qoldi ");
            BackMenu();
        }
        public static void GetMoney()
        {
            Console.Clear();
            Console.WriteLine("Naqd pul olish");
            Console.WriteLine("1.50 ming");
            Console.WriteLine("2. 100 ming");
            Console.WriteLine("3. 200 ming");
            Console.WriteLine("4. 300 ming");
            Console.WriteLine("5. 400 ming");
            Console.WriteLine("6. Boshqa summa ");
            Console.WriteLine("0. Orqaga ");

            switch (choose())
            {
                case 1: helpBalance -= 50000; break;
                case 2: helpBalance-= 100000; break;
                case 3: helpBalance-= 200000; break;
                case 4: helpBalance -= 300000; break;
                case 5: helpBalance -= 400000; break;
                case 6: helpBalance -= 500000; break;
                case 0: Menu();break;
                default: GetMoney();break;
            }
            Payment();
        }
        public static void BackMenu()
        {
            Console.WriteLine("0. Orqaga");

            if(choose() == 0)
            Menu();
            else
            {
                Console.Clear();
                BackMenu();
            }
        }
        public static void SMS()
        {
            Console.Clear();
            Console.WriteLine("SMS xabarnoma");
            Console.WriteLine("1.SMS xabarnomani o'chirish ");
            Console.WriteLine("2.SMS xabarnomani yoqish ");

            switch (choose())
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("SMS xabarnoma o'chirildi ");
                    BackMenu();   break;
                case 2:
                    {
                        Console.Clear();
                        Console.Write("Telefon raqamini kiriting ");
                        string callNumber = Console.ReadLine();
                        Console.WriteLine("SMS xabarnoma yoqildi .");
                        BackMenu(); break;
                    }
                case 0 :
                    {
                        Menu(); break;
                    }
                default:  SMS(); break;
            }

        }
        public static void ChangePassword()
        {
            Console.Clear();
            Console.WriteLine("PAROLNI O'ZGARTIRISH");
            Console.WriteLine("1.Yangi parolni kiritish");
            Console.WriteLine("0. Orqaga");
            if (choose()==1)
            {
                Console.Clear();
                Console.Write("Yangi parolni kiriting : ");
                newPassword = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Parol o'zgartirldi !");
                BackMenu();
            }
            else 
                Menu();
        }
        public static void Paynet()
        {
            Console.Clear();
            Console.WriteLine("Mobil alowa uchun to'lov ");
            Console.WriteLine("1.Uzmobile");
            Console.WriteLine("2.Beeline");
            Console.WriteLine("3.Ucell");
            Console.WriteLine("4.MOBIUZ");
            Console.WriteLine("5.Perfectum");
            Console.WriteLine("0. Orqaga");

            if (choose()==0)
            {
                Menu();
            }
            else if (choose() > 0 && choose() < 6)
            {
                Console.Clear();
                Console.Write("Raqamingizni kiriting :  +998 ");
                string callNumber = Console.ReadLine();

                Console.Write("To'lov summasini kiriting : ");
                double.TryParse(Console.ReadLine(), out double paynet);

                helpBalance -= paynet;
                Payment();
            }
            else
            {
                Paynet();
            }
        }
    }
}