using ServiceHost;
using SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
          var serviceMethods= new ServiceMethods();
            Accounts one = serviceMethods.GetAUserInfo(1);
            List<Accounts> all = serviceMethods.GetAllUserInfos();
            Console.WriteLine("GetAUserInfo方法测试\r\n" + one.loginAppleId+one.loginPassword);
            Console.WriteLine("GetAllUserInfos方法测试");
            foreach (var list in all)
            {
                Console.Write(list.loginAppleId);
            }
            Console.WriteLine("EditUserInfo方法测试\r\n");
            one.remarks = "one";
            int i = serviceMethods.EditUserInfo(one);
            Console.WriteLine(i);
           Console.Read();

        }
    }
}
