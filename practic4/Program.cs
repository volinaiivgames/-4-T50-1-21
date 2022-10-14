using System;
using System.Collections.Generic;

namespace practic4
{
    class Program
    {
        static List<DateList> Catalogs = new List<DateList>();
        static int CatallogId = 0;
        static int PageId = 0;
        static bool CatalogOpen = false;
        static int CursorStart = 1;

        static void Main(string[] args)
        {
            Load();
            Open();
        }
        static void Load()
        {
            Catalogs.Add(new DateList(new DateTime(2022, 7, 10), new List<Page>() { 
                new Page("Придти на пары", new List<string> { "Описание: с 1 по 5 пару" }),
                new Page("Забрать студак", new List<string> { "Описание: кабинет 105 с 8 до 16" })
            }));
            Catalogs.Add(new DateList(new DateTime(2022, 8, 10), new List<Page>() {
                new Page("Проверить практические", new List<string> { "Описание: Группа Т50-1-21" })
            }));
        }
        static void Open()
        {
            Console.Clear();
            DateList list = Catalogs[CatallogId];
            if (CatalogOpen)
            {
                Page page = list.Pages[PageId];

                Console.WriteLine($"{page.Name}");
                Console.WriteLine($"------------------------------");
                for (int i = 0; i < page.Description.Count; i++) Console.WriteLine($"{page.Description[i]}");
                Console.WriteLine($"Дата: {list.Date}");
            }
            else
            {
                Console.WriteLine($"Выбрана дата: {list.Date}");
                for (int i = 0; i < list.Pages.Count; i++) Console.WriteLine($"  {i + 1}. {list.Pages[i].Name}");
            }
            setCursor();
        }

        static void setCursor()
        {
            if(!CatalogOpen)
            {
                Console.SetCursorPosition(0, PageId + CursorStart);
                Console.WriteLine("->");
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && !CatalogOpen)
            {
                if(PageId + CursorStart != CursorStart) PageId--;
                Console.SetCursorPosition(0, PageId + CursorStart);
                Console.WriteLine("->");
            }
            else if (key.Key == ConsoleKey.DownArrow && !CatalogOpen)
            {
                if(PageId != Catalogs[CatallogId].Pages.Count- CursorStart) PageId++;
                Console.SetCursorPosition(0, PageId + CursorStart);
                Console.WriteLine("->");
            }
            else if (key.Key == ConsoleKey.LeftArrow && !CatalogOpen)
            {
                if (CatallogId != 0) CatallogId--;
            }
            else if (key.Key == ConsoleKey.RightArrow && !CatalogOpen)
            {
                if (Catalogs.Count-1 != CatallogId) CatallogId++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (CatalogOpen) CatalogOpen = false;
                else CatalogOpen = true;
            }
            Open();
        }
    }
}
