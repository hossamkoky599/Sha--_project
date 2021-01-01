using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stack
{
    class stackpp<T>
    {
        public int top;

        public T []  ar ;
 
        public stackpp ( int size)

        {
            top = -1;
            ar= new T [size] ;
        
        
        }



        //check

        public bool isempty()
        {
            if (top == -1)
                return true;

            else
                return false;
        
        
        } //end check


        //push

        public void push(T item)
        {

            if (top == ar.Length - 1)
                Console.WriteLine("stack overflow");

            else
            {
                top++;

                ar[top] = item;
            }
        
        }

        //pop


        public int  pop()

        {

            if (top == -1)
            {
                Console.WriteLine("stack underflow");
                return -1;
            }
            else

            {

               int  t = top;
                top--;
                return t;
            
            }

          
        
        } //end pop



        //peak

        public int  peak()
        {

            if (top == -1)
            {
                Console.WriteLine("stack underflow");
               
                return  -1;
            }
            else
            {

                int  t = top;

                return t;

            }

        } //end peak




    }
}
