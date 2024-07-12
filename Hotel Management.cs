using System;
using System.Collections.Generic;

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();
            string userChoice;

            InitializeRooms(rooms);

            do
            {
                Console.Clear();
                Console.WriteLine("Hotel Management System");
                Console.WriteLine("=======================");
                Console.WriteLine("1. View Available Rooms");
                Console.WriteLine("2. Book a Room");
                Console.WriteLine("3. Check Out");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        ViewAvailableRooms(rooms);
                        break;
                    case "2":
                        BookRoom(rooms);
                        break;
                    case "3":
                        CheckOut(rooms);
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                if (userChoice != "4")
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            } while (userChoice != "4");
        }

        static void InitializeRooms(List<Room> rooms)
        {
            for (int i = 1; i <= 10; i++)
            {
                rooms.Add(new Room { RoomNumber = i, IsBooked = false });
            }
        }

        static void ViewAvailableRooms(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("Available Rooms");
            Console.WriteLine("===============");
            bool availableRooms = false;
            foreach (var room in rooms)
            {
                if (!room.IsBooked)
                {
                    Console.WriteLine($"Room {room.RoomNumber}");
                    availableRooms = true;
                }
            }
            if (!availableRooms)
            {
                Console.WriteLine("No available rooms.");
            }
        }

        static void BookRoom(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("Book a Room");
            Console.WriteLine("===========");
            ViewAvailableRooms(rooms);
            Console.Write("Enter the room number to book: ");
            if (int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Room room = rooms.Find(r => r.RoomNumber == roomNumber && !r.IsBooked);
                if (room != null)
                {
                    room.IsBooked = true;
                    Console.WriteLine($"Room {room.RoomNumber} has been booked successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid room number or the room is already booked.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void CheckOut(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("Check Out");
            Console.WriteLine("=========");
            Console.Write("Enter the room number to check out: ");
            if (int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Room room = rooms.Find(r => r.RoomNumber == roomNumber && r.IsBooked);
                if (room != null)
                {
                    room.IsBooked = false;
                    Console.WriteLine($"Room {room.RoomNumber} has been checked out successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid room number or the room is not booked.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    class Room
    {
        public int RoomNumber { get; set; }
        public bool IsBooked { get; set; }
    }
}
