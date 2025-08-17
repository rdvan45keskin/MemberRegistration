using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMemberService memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member
            {
                Email = "rdvan45keskin@gmail.com",
                FirstName = "Rıdvan",
                LastName = "Keskin",
                DateOfBirth = new DateTime(2003,7,21),
                TcNo = "21830406442"
                
            });
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
