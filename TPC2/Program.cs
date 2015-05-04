using System;

class Program{
    static void conv1(long n1) {
        short n2 = (short)n1;
        Console.WriteLine(n2);
    }
    static void conv2(long n1) {
        checked
        {
            short n2 = (short)n1;
            Console.WriteLine(n2);
        }
    }
    static void Main(){
        conv1(50000);
        conv2(50000);    
    }
}