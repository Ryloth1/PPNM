using System;
using static System.Math;
using static System.Console;
using static vec;

public class main{
	static int Main(){
		    
		var rnd = new System.Random(1); /* or any other seed */
		double a = rnd.NextDouble();
		vec v = new vec(rnd.NextDouble(),rnd.NextDouble(),rnd.NextDouble());
		vec u = new vec(rnd.NextDouble(),rnd.NextDouble(),rnd.NextDouble());

		u.print();
		v.print();
		WriteLine($"a*u is {a*u}, u*a is {u*a}\n");
		WriteLine($"u+v is {u+v}, -v is {-v}, u-v is {u-v} \n");
		WriteLine($"u*v is {u.dot(v)} or using vec.dot {vec.dot(u,v)}\n");
		WriteLine($" u=v: {approx(u,v)} and if u=u: {approx(u,u)}\n");

	
	

	
	return 0;

	}//Main
}//main
