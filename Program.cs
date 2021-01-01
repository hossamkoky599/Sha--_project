using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stack
{
    class Program
    {

        public static string revstr(string word) 
        {
            string o = "";
            stackpp<char> s1 = new stackpp<char>(word.Length);
            foreach (char c in word)
            {
                s1.push(c);
            }
            while (!s1.isempty())
            {
                o += s1.ar[s1.pop()];
            }
            Console.WriteLine();
            return o;
        }

        public static bool isBalancedParenthesis(string expn)
        {
            stackpp<char> stk = new stackpp<char>(expn.Length);
            foreach (char ch in expn)
            {
                switch (ch)
                {
                    case '{':
                    case '[':
                    case '(':
                        stk.push(ch);
                        break;
                    case '}':
                        if (stk.ar[stk.pop()] != '{')
                            return false;
                        break;
                    case ']':
                        if (stk.ar[stk.pop()] != '[')
                            return false;
                        break;
                    case ')':
                        if (stk.ar[stk.pop()] != '(')
                            return false;
                        break;
                }
            }
            return stk.isempty();
        }


        static bool InfixToPostfixConvert(ref string infixBuffer, out string postfixBuffer)
        {
            int priority = 0;
            postfixBuffer = "";
            int f = 0;
            stackpp<Char> s1 = new stackpp<char>(infixBuffer.Length);

            for (int i = 0; i < infixBuffer.Length; i++)
            { 
                char ch = infixBuffer[i];
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    f = -1;
                    // check the precedence
                    if (s1.isempty())
                        s1.push(ch);
                    else
                    {
                        if (s1.ar[s1.peak()] == '*' || s1.ar[s1.peak()] == '/')
                            priority = 1;
                        else
                            priority = 0;
                        if (priority == 1)
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfixBuffer += " " + s1.ar[s1.pop()];
                                i--;
                            }
                            else
                            { // Same
                                postfixBuffer +=" "+ s1.ar[s1.pop()];
                                i--;
                            }
                        }
                        else
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfixBuffer += " " + s1.ar[s1.pop()];
                                i--;
                            }
                            else
                                s1.push(ch);
                        }
                    }//end if stack not empty
                }//end check operator
                else
                {

                    if (f == -1)
                    {
                        postfixBuffer += " ";
                    }
                    postfixBuffer += ch;
                    f = 0;

                }
            }
           // postfixBuffer += " ";
            int len = s1.top;
            for (int j = 0; j <= len; j++)
                postfixBuffer +=" "+ s1.ar[s1.pop()];
            return true;
        }


        public static void RpnLoop(string input)
        {
            
                // The stack of integers not yet operated on. 
                stackpp<int> values = new stackpp<int>(input.Length);
                string[] arr = input.Split(' ');
                foreach (string token in input.Split(new char[] { ' ' }))
                {
                   
                    // If the value is an integer...
                    int value;
                    if (int.TryParse(token, out value))
                        values.push(value);
                    else
                    {
                        int rhs =values.ar[ values.pop()];
                        int lhs = values.ar[values.pop()];
                        switch (token)
                        {
                            case "+":
                                values.push(lhs + rhs);
                                break;
                            case "-":
                                values.push(lhs - rhs);
                                break;
                            case "*":
                                values.push(lhs * rhs);
                                break;
                            case "/":
                                values.push(lhs / rhs);
                                break;
                            case "%":
                                values.push(lhs % rhs);
                                break;
                            default:
                                throw new ArgumentException(string.Format("Unrecognized token: {0}", token));
                        }
                    }
                }//foreach

                Console.WriteLine(values.ar[values.pop()].ToString());
        }




        static void Main(string[] args)
        {

            Console.WriteLine("Enter length of array");
            int n = int.Parse ( Console.ReadLine());

            
            stackpp<int> p = new stackpp<int>(n);

            // while to display the choice after each opearation
            while (true)
            {

            Console.WriteLine("----------choice --------");

            Console.WriteLine("1- Want to push");

              Console.WriteLine("2- Want to pop");

              Console.WriteLine("3- Want to peak");
              Console.WriteLine("4- Reverse string ");
              Console.WriteLine("6- IsBalancedParenthesis Or not ");
              Console.WriteLine("7-Rpn");
              Console.WriteLine("8-Rpn-Postfix");

              Console.WriteLine("5- want to Exit");

               
            int choice = int.Parse(Console.ReadLine());

           

                switch (choice)
                {

                    case 1:

                        Console.WriteLine("Enter number which push it");
                        int pu = int.Parse(Console.ReadLine());
                        p.push(pu);
                        break;

                    case 2:
                       int z =p.ar[ p.pop()];
                        Console.WriteLine("the number which pop it : "+z);
                        break;

                    case 3 :
                      int y =p.ar[p.peak()];
                      Console.WriteLine("the number which peak it : "+y);
                        break;

                    case 4 :
                        Console.WriteLine("enter word :");
                        string w = Console.ReadLine();
                        Console.WriteLine(revstr(w));

                        break;
                    case 6 :
                         Console.WriteLine("enter Exp :");
                        string ex = Console.ReadLine();
                        Console.WriteLine(isBalancedParenthesis(ex));
                        break;

                    case 7:
                        string postfix = "";
                        Console.WriteLine("enter eq");
                        string eq = Console.ReadLine();

                        InfixToPostfixConvert(ref eq,out postfix);

                        Console.WriteLine(postfix);
                        RpnLoop(postfix);
                        break;

                    case 8:
                         Console.WriteLine("enter eq");
                        string equa = Console.ReadLine();
                        RpnLoop(equa);
                        break;
                    case 5:
                        return;
                        break;


                    default :
                        Console.WriteLine("Error");
                        break;


                } //end witch

            } //end while


        }
    }
}
