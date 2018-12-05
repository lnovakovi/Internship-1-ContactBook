using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDictionary = new Dictionary<int, Tuple<string, string, int, string>>();


            var choice = 0;
            do
            {
                bool check = false;
                Console.WriteLine("Dobrodošli u adresar!\nUnesite redni broj opcije koju želite izvršiti:\n1.dodavanje upisa\n2.promjena imena,adrese ili broja\n3.brisanje upisa\n4.pretraga po broju\n5.pretraga po imenu\n6.izlaz iz programa");

                do
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (choice < 1 || choice > 6)
                        {
                            Console.Write("Unesite broj od 1-6.\n");
                            
                        }
                        check = true;
                    }
                    catch (Exception)
                    {

                        Console.Write("Krivi unos! Morate unijeti broj! \n");
                    }
                } while (check == false);
                check = false;
                switch (choice)
                {

                    case 1:
                        Console.Write("Unos novog kontakta\n");
                        Console.Write("Unesite ime:\t");
                        var name = Console.ReadLine();
                        Console.Write("Unesite prezime:\t");
                        var surname = Console.ReadLine();
                        var numberString = "";
                        var number = 0;
                        var numberConfirmation = 0;
                        Console.Write("Unesite broj:\t");
                        numberString = RemoveChar(Console.ReadLine());
                        try
                         {

                            number = int.Parse(numberString);
                               
                         }
                         catch (Exception)
                         {

                            Console.Write("krivo ste unijeli broj");
                            return;
                                
                         }
                        

                        
                        Console.Write("Ponovo unesite broj kao potvrdu:\t");
                        numberString = RemoveChar(Console.ReadLine());
                        try
                        {
                            numberConfirmation = int.Parse(numberString);
                        }
                        catch (Exception)
                        {

                            Console.Write("krivo ste unijeli broj");
                            return;
                        }
                        Console.Write("Unesite adresu:\t");
                        var address = Console.ReadLine();
                        var answer = "";
                        if (number == numberConfirmation)
                        {
                            Console.WriteLine("Jeste li sigurni?\t");
                            answer = Console.ReadLine();
                            if (answer.ToLower() == "da")
                            {
                                if (myDictionary.ContainsKey(number))
                                {
                                    Console.Write("broj vec postoji!");
                                }
                                else
                                {
                                    myDictionary.Add(number, AddContact(name, surname, number, address));
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Otkazana radnja.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Otkazana radnja.Krivi broj potvrde.");

                        }
                        break;

                    case 2:
                        var newNumber = 0;
                        var newNumberConfirmation = 0;
                        var newName = "";
                        var newSurname = "";
                        var newAddress = "";
                        Console.Write("Mijenjanje imena,adrese ili broja");
                        Console.Write("Unesite broj za koji zelite napraviti izmjenu");
                        numberString = RemoveChar(Console.ReadLine());
                        try
                        {
                            number = int.Parse(numberString);
                        }
                        catch (Exception)
                        {

                            Console.Write("krivo ste unijeli broj");
                            return;
                        }
                        if (CheckIfExists(myDictionary, number))
                        {
                            Console.Write("Unesite promjene");
                            Console.Write("Unesite novo ime:\t");
                            newName = Console.ReadLine();
                            Console.Write("Unesite novo prezime:\t");
                            newSurname = Console.ReadLine();
                            Console.Write("Unesite novu adresu:\t");
                            newAddress = Console.ReadLine();
                            Console.Write("Unesite novi broj:\t");
                            numberString = RemoveChar(Console.ReadLine());
                            try
                            {
                                newNumber = int.Parse(numberString);
                            }
                            catch (Exception)
                            {

                                Console.Write("krivo ste unijeli broj");
                                return;
                            }
                            Console.Write("Ponovo unesite broj kao potvrdu:\t");
                            numberString = RemoveChar(Console.ReadLine());
                            try
                            {
                                newNumberConfirmation = int.Parse(numberString);
                            }
                            catch (Exception)
                            {

                                Console.Write("krivo ste unijeli broj");
                                return;
                            }
                        }
                        else
                        {
                            Console.Write("Takav kontakt ne postoji u adresaru");
                        }

                        if (newNumber == newNumberConfirmation)
                        {
                            Console.WriteLine("Jeste li sigurni?");
                            answer = Console.ReadLine();
                            if (answer.ToLower() == "da")
                            {
                                ChangeContact(myDictionary, newName, newSurname, number, newNumber, newAddress);
                            }
                            else
                            {
                                Console.Write("Otkazana radnja");
                            }
                        }
                        else
                        {
                            Console.Write("Otkazana radnja.Krivi unos broja.");

                        }
                        break;
                    case 3:
                        Console.Write("brisanje upisa");
                        Console.Write("Unesite broj koji zelite izbrisati:\t");
                        numberString = RemoveChar(Console.ReadLine());
                        try
                        {
                            number = int.Parse(numberString);
                        }
                        catch (Exception)
                        {

                            Console.Write("krivo ste unijeli broj");
                            return;
                        }
                        Console.Write("Ponovo unesite broj kao potvrdu:\t");
                        numberString = RemoveChar(Console.ReadLine());
                        try
                        {
                            numberConfirmation = int.Parse(numberString);
                        }
                        catch (Exception)
                        {

                            Console.Write("krivo ste unijeli broj");
                            return;
                        }
                        if (number == numberConfirmation)
                        {
                            if (CheckIfExists(myDictionary, number))
                            {
                                myDictionary.Remove(number);
                            }
                            else
                            {
                                Console.Write("Takav broj ne postoji u imeniku");
                            }
                        }
                        else
                        {
                            Console.Write("Krivo ste unijeli broj potvrde");
                        }

                        break;

                    case 4:
                        Console.Write("Pretraga po broju\nUnesite broj koji želite pretražiti:\t");
                        numberString = RemoveChar(Console.ReadLine());
                        try
                        {
                            number = int.Parse(numberString);
                        }
                        catch (Exception)
                        {

                            Console.Write("krivo ste unijeli broj");
                            return;
                        }
                        if (CheckIfExists(myDictionary, number))
                        {
                            Console.Write(SearchByNumber(myDictionary, number));
                        }
                        else
                        {
                            Console.Write("Ne postoji kontakt s takvim brojem");
                        }
                        break;

                    case 5:
                        Console.Write("Pretraga po imenu\n");
                        Console.Write("Unesite ime, dio imena/prezimena:\t");
                        name = Console.ReadLine();
                        SearchByName(myDictionary, name);
                        break;


                }

            } while (choice != 6);
        }
        static string RemoveChar(string s)
        {
            var arrayOfCharachters = new string[]{ ".","-"," ","/"};
            foreach (var item in arrayOfCharachters)

            {
                s=s.Replace(item,"");
            }
            return s;
        }
        static Tuple<string, string, int, string> AddContact(string name, string surname, int number, string address)
        {
            var myTuple = new Tuple<string, string, int, string>(name, surname, number, address);
            return myTuple;
        }

        static Dictionary<int, Tuple<string, string, int, string>> ChangeContact(Dictionary<int, Tuple<string, string, int, string>> dictionary, string name, string surname, int oldNumber, int newNumber, string address)
        {
            foreach (var keys in dictionary.Keys)
            {
                if (keys == oldNumber)
                {
                    dictionary.Remove(keys);
                    var newTuple = new Tuple<string, string, int, string>(name, surname, newNumber, address);
                    dictionary.Add(newNumber, newTuple);
                    break;
                }

            }
            return dictionary;
        }
        static bool CheckIfExists(Dictionary<int, Tuple<string, string, int, string>> dictionary, int number)
        {
            if (dictionary.ContainsKey(number))
                return true;
            else
                return false;
        }
        static string SearchByNumber(Dictionary<int, Tuple<string, string, int, string>> dictionary, int number)
        {

            var contact = dictionary[number];
            string print = "Ime i Prezime: " + contact.Item1 + "  " + contact.Item2 + "  Broj: " + contact.Item3.ToString() + "  Adresa: " + contact.Item4;
            return print;
        }
        static void SearchByName(Dictionary<int, Tuple<string, string, int, string>> dictionary, string search)
        {
            var br = 0;

            var list = dictionary.Values.ToList();
            list = list.OrderBy(t => t.Item2).ThenBy(t => t.Item1).ToList();
            foreach (var item in list)
            {
                if (item.Item1.StartsWith(search) || item.Item2.StartsWith(search))
                {
                    br += 1;
                    Console.Write("Prezime i Ime: " + item.Item2 + "  " + item.Item1 + "  Broj: " + item.Item3.ToString() + "  Adresa: " + item.Item4 + "\n");

                }
            }
            if (br == 0)
            {
                Console.Write("Nismo pronasli nikog po takvom imenu!");
            }
        }
    }
}
