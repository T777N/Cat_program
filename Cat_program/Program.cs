using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_program
{
    /*
      Cat :nickname,age,gender,Energy,Price,mealQuantity
      Eat();Sleep();Play();
    */
    
     
    class Cat
    {
        public string Nickname { get; set; }
        public double Age { get; set; }
        public string Gender { get; set; }
        public double Energy { get; set; }
        public double Price { get; set; }
        public int MealQuantity { get; set; }
        public Cat()
        {
            Nickname = string.Empty;
            Age = 0;
            Gender = string.Empty;
            Energy = 0;
            Price = 0;
            MealQuantity = 0;
        }
        public Cat(string nickname, double age, string gender, double energy, double price)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Energy = energy;
            Price = price;
        }
        public void Eat()
        {
            ++MealQuantity;
            Energy += 10;
            Age += 0.05; 
        }
        public void Sleep()
        {
            int newAge=(int)Age;
            Age += 0.1;
            Energy += 50;
            if ((int)Age > newAge)
            {
                newAge = (int)Age;
                Price += 10;
            }
        }
        public void Play()
        {
            if (Energy <= 0)
            {
                Sleep();
            }
            else
            {
                Energy -= 10;
                if (Energy <= 0)
                {
                    Sleep();
                }
            }
        }
        public void Show()
        {
            Console.WriteLine($" - - - - Cat information - - - - ");
            Console.WriteLine($" Nickname : {Nickname}");
            Console.WriteLine($" Age : {Age}");
            Console.WriteLine($" Gender : {Gender}");
            Console.WriteLine($" Energy : {Energy}");
            Console.WriteLine($" Price : {Price}");
            Console.WriteLine($" Meal Quantity : {MealQuantity}");
            Console.WriteLine($" + + + + + + + + + + + + + + + + + + + + + + + + + + + + + ");
        }
    }
    class CatHouse
    {
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; }

        public CatHouse()
        {
            Cats = default;
            CatCount = 0;
        }
        public void AddCat(Cat newCat)
        {
            Cat[] temp = new Cat[++CatCount];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newCat;
            Cats = temp;
        }
        public void RemoveCat_byNickName(string name)
        {
            for (int i = 0; i < CatCount; i++)
            {
                if (Cats[i].Nickname == name)
                {
                    Cats[i] = null;
                }
            }
        }
        public void ShowAllCats()
        {
            Console.WriteLine($" ^ ^ ^ ^ ^ Cat house Information ^ ^ ^ ^ ^ ");
            for (int i = 0; i < CatCount; i++)
            {
                Cats[i].Show();
            }
        }
    }
  
    class Petshop
    {
        public CatHouse[] CatHouses;

        public int CatHousesCount { get; set; }
        public Petshop()
        {
            CatHouses = default;
            CatHousesCount = 0;
        }
        public void AddCatHouse(CatHouse catHouse) 
        {
            CatHouse[] temp = new CatHouse[++CatHousesCount];
            if (CatHouses != null)
            {
                CatHouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = catHouse;
            CatHouses = temp; ;
        }
        public void Show()
        {
            for (int i = 0; i <CatHousesCount; i++)
            {
                CatHouses[i].ShowAllCats();
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {

            Cat FirstCat = new Cat("Peleng",4,"Russian",100,1000000);
            Cat SecondCat = new Cat("Simba",3,"Egiptian",100,10000);
            Cat ThirdCat = new Cat("Murka",7,"Azerbaijanian",100,1000);

            CatHouse catHouse = new CatHouse();
            catHouse.AddCat(FirstCat);
            catHouse.AddCat(SecondCat);
            catHouse.AddCat(ThirdCat);
            //catHouse.ShowAllCats();

            Petshop petshop = new Petshop();
            petshop.AddCatHouse(catHouse);
            petshop.Show();
        }

    }

}
