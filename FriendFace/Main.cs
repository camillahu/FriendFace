using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FriendFace
{
    internal class Main
    {
        private List<User> _allUsers = new List<User>
        {
            new("Viktor", 300, "Blå"),
            new("Malin", 600, "Grønn"),
            new("Sofa", 100, "Rosa")
        };

        public void Run(Main program)
        {
            Console.WriteLine("Welcome to FriendFace! \n Create a new user to get started.");
            CreateNewUser(program);
        }

        private void CreateNewUser(Main program)
        {   
            Console.WriteLine("Name:");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Age:");
            int ageInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Favorite color:");
            string colorInput = Console.ReadLine();
            Console.WriteLine();
            SaveOrScrapUser(nameInput, ageInput, colorInput, program);
            
        }

        public void SaveOrScrapUser(string nameInput, int ageInput, string colorInput, Main program)
        {
            Console.WriteLine("New user created. Show profile and save? \n1. Yes \n2. Back to create user \n3. Exit ");

            int input = Convert.ToInt32(Console.ReadLine());
            bool running = true;

            while (running)
            {
                switch (input)
                {
                    case 1:
                        AddNewUser(nameInput, ageInput, colorInput, program);
                        running = false;
                        break;
                    case 2:
                        CreateNewUser(program);
                        running = false;
                        break;
                    case 3:
                        Environment.Exit(1);
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            }
        }

        public void AddNewUser(string nameInput, int ageInput, string colorInput, Main program)
        {
            User newUser = new User(nameInput,  ageInput,  colorInput);
            _allUsers.Add(newUser);

            newUser.ShowProfile(newUser, program);
        }

        public void ChooseFriend(User currentUser, Main program, List<User>Friends)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            bool running = true;

            while (running)
            {
                if (input == 0)
                {
                    ViewAllUsers(currentUser, program);
                    running = false;
                }
                else if (input > 0 && input <= Friends.Count)
                {
                    currentUser.ShowFriendProfile(currentUser, program, input);
                    running = false;
                }
                else
                {
                    ErrorMessage();
                }
            }
        }

        public void ViewAllUsers(User currentUser, Main program)
        {
            Console.WriteLine($"List of all users: ");
            for (var i = 0; i < _allUsers.Count; i++)
            {
                Console.WriteLine($"{i+1}.{_allUsers[i].Name}");
            }

            currentUser.AddFriend(currentUser, program, _allUsers);
        }

        public void FriendOptions(User currentUser, Main program, User selectedFriend)
        {
            Console.WriteLine("What Would you like to do?");
            Console.WriteLine("1. Remove friend");
            Console.WriteLine("2. Back to your profile");
            Console.WriteLine("3. Show extended options");
            Console.WriteLine("4. Exit");
            FriendOptionsInput(currentUser, program, selectedFriend);
        }

        public void FriendOptionsInput(User currentUser, Main program, User selectedFriend)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            bool running = true;

            while (running)
            {
                switch (input)
                {
                    case 1:
                        currentUser.RemoveFriend(currentUser, program, selectedFriend);
                        running = false;
                        break;
                    case 2:
                        currentUser.ShowProfile(currentUser, program);
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("What would you like to do now?");
                        program.DrawOptions(currentUser, program);
                        break;
                    case 4: Environment.Exit(2);
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            }
        }

        public void DrawOptions(User currentUser, Main program)
        {
            Console.WriteLine("1.Show your profile");
            Console.WriteLine("2.View friends list");
            Console.WriteLine("3.Add a new friend");
            Console.WriteLine("4.Make a new user");
            Console.WriteLine("5. Exit");
            OptionsMenu(currentUser, program);
        }

        public void OptionsMenu(User currentUser, Main program)
        {
            bool running = true;
            int input = Convert.ToInt32(Console.ReadLine());

            while (running)
            {
                switch (input)
                {
                    case 1:
                        currentUser.ShowProfile(currentUser, program);
                        running = false;
                        break;
                    case 2:
                        currentUser.ShowFriends(currentUser, program);
                        running = false;
                        break;
                    case 3:
                        ViewAllUsers(currentUser, program);
                        running = false;
                        break;
                    case 4:
                        Run(program);
                        running = false;
                        break;
                    case 5:
                        Environment.Exit(2);
                        break;
                    default:
                        ErrorMessage();
                        break;
                }
            }
           
            Console.Clear();
            Thread.Sleep(2000);
        }

        public void ErrorMessage()
        {
            Console.WriteLine("Please choose a valid number.");
        }
    }
}
