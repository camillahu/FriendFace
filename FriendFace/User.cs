using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class User(string name, int age, string color)
    {
        public string Name { get; private set; } = name;
        public int Age { get; private set; } = age;
        public string FaveColor { get; private set; } = color;
        public List<User> Friends { get; private set; } = [];

        public void ShowProfile(User currentUser, Main program)
        {
            Console.WriteLine($"{Name}'s profile:");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Favorite Color: {FaveColor}");
            Console.WriteLine();
            ShowFriends(currentUser, program);
        }

        public void ShowFriends(User currentUser, Main program)
        {
            if (Friends.Count > 0)
            {
                Console.WriteLine("Friends:");
                for (var i = 0; i < Friends.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {Friends[i].Name}");
                    Console.WriteLine();
                }
                Console.WriteLine("Select a friend you would like to view by typing their " +
                                  "repective number, or type 0 to add new friend.");
                    program.ChooseFriend(currentUser, program, Friends);  
            }
            else
            {
                Console.WriteLine("You have no friends. Add someone to get started!");
                program.ViewAllUsers(currentUser, program);
            }
            
        }
        public void AddFriend(User currentUser, Main program, List<User> allUsers)
        {
            bool running = true;
            Console.WriteLine($"Select a user you would like to " +
                              $"add by typing their repective number.");

            while (running)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (input > 0 && input <= allUsers.Count)
                {
                    User selectedUser = allUsers[input - 1];
                    Friends.Add(selectedUser);
                    running = false;
                }
                else
                {
                    program.ErrorMessage();
                }
            }
            Console.WriteLine("Friend added. Taking you back to your profile.");
            Console.WriteLine();
            Thread.Sleep(2000);
            ShowProfile(currentUser, program);
        }
        public void RemoveFriend(User currentUser, Main program, User selectedFriend)
        {
            Friends.Remove(selectedFriend);
            Console.WriteLine($"{selectedFriend.Name} is removed from your friends list.");
            Console.WriteLine();
            Console.WriteLine("What would you like to do now?");
            program.DrawOptions(currentUser, program);
        }

        public void ShowFriendProfile(User currentUser, Main program, int input)
        {
            User selectedFriend = Friends[input - 1];
            Console.WriteLine($"{selectedFriend.Name}'s profile:");
            Console.WriteLine($"Age: {selectedFriend.Age}");
            Console.WriteLine($"Favorite Color: {selectedFriend.FaveColor}");
            Console.WriteLine();
            program.FriendOptions(currentUser, program, selectedFriend);
             
        }
    }

    
}
