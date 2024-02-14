using System;
using static System.Console;



public static class main{

    static int Main(){

        var list = new genlist<double[]>();
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for(string line = ReadLine(); line!=null; line = ReadLine()){
	        var words = line.Split(delimiters,options);
	        int n = words.Length;
	        var numbers = new double[n];
	        for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
	        list.add(numbers);
       	    }
        WriteLine($"Array before remove(1)");
        for(int i=0;i<list.size;i++){
	        var numbers = list[i];
	        foreach(var number in numbers)Write($"{number : 0.00e+00;-0.00e+00} ");
	        WriteLine();
        }
        
        list.remove(1);
        WriteLine($"Array after remove(1)");
        for(int i=0;i<list.size;i++){
	        var numbers = list[i];
	        foreach(var number in numbers)Write($"{number : 0.00e+00;-0.00e+00} ");
	        WriteLine();
        }
        
    return 0;
    }
}