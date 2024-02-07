using static System.Console;
public class my_class { public string s; }
public struct my_struct { public string s; }
static class main{
    //static void set_to_7(ref double tmp){ tmp=7;}
    static void set_to_7(double tmp){ tmp=7;}
    static void set_to_7(double[] tmp){ for(int i=0;i<tmp.Length;i++)tmp[i]=7 ;}
    static int Main(){
        my_class A=new my_class();
        my_struct a=new my_struct();
        A.s="hello";
        A.s="hello";
        WriteLine($"A.s={A.s}");
        WriteLine($"a.s={a.s}");
        my_class B=A;
        my_struct b=a;
        WriteLine($"B.s={B.s}");
        WriteLine($"b.s={b.s}");
        B.s="new string";
        B.s=double epsilon=Pow(2,-52);
double tiny=epsilon/2;
double a=1+tiny+tiny;
double b=tiny+tiny+1;
Write($"a==b ? {a==b}\n");
Write($"a>1  ? {a>1}\n");
Write($"b>1  ? {b>1}\n");"new string";
        WriteLine($"A.s={A.s}");
        WriteLine($"a.s={a.s}");
        double x=1;
        set_to_7(x);
        //set_to_7(ref 7)
        WriteLine($"x={x}");
    return 0;
    }
}double epsilon=Pow(2,-52);
double tiny=epsilon/2;
double a=1+tiny+tiny;
double b=tiny+tiny+1;
Write($"a==b ? {a==b}\n");
Write($"a>1  ? {a>1}\n");
Write($"b>1  ? {b>1}\n");