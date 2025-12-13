using SchoolSystem.Data;
using SchoolSystem.Models;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Service;
using SchoolSystem.ConsoleUI;

namespace SchoolSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogInMenu.LogIn();
        }
    }
}
