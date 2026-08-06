using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
	public class Program
	{
		static int add(int a,int b){
			return a+b;
		}
		static int sub(int a,int b){
			return a-b;
		}
		static int mul(int a,int b){
			return a*b;
		}
		static int div(int a,int b){
            try{
                if(b==0){
                    throw new DivideByZeroException();
                }
            }
            catch(DivideByZeroException){
                Console.WriteLine("Division by zero is not allowed.");
                return 0;
            }
			return a/b;  
		}
		public static void Main(string[] args)
		{
			List<string> History=new List<string>();
			int num1=0;
			int num2=0;
			String oper="";
			int res=0;
			bool con=true;
			while(con){
			try{
				num1=Convert.ToInt32(Console.ReadLine());
				num2=Convert.ToInt32(Console.ReadLine());
				oper=Console.ReadLine()??"";
			}
			catch{
				Console.WriteLine("Invalid output");
			}
			switch(oper){
				case "+":
				res=add(num1,num2);
				break;
				case "-":
				res=sub(num1,num2);
				break;
				case "*":
				res=mul(num1,num2);
				break;
				case "/":
				res=div(num1,num2);
				break;
			}
            Console.WriteLine(res);
			Console.WriteLine("Do you want to continue (y/n)?");
			string choise=Console.ReadLine()??"";
            if(choise=="y"||choise=="Y"){
                con=true;   
            }
            else{
				con=false;
			}
			History.Add($"{num1} {oper} {num2} = {res}");
			}
			for(int i=0;i<History.Count;i++){
				Console.WriteLine(History[i]);
			}
		}
	}
}