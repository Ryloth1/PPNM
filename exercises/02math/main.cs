using System;
using static System.Console;
using static System.Math;


class main{
	static double sqrt2=Sqrt(2.0);
	static double pow=Pow(2,1.0/5);
	static double expi= Exp(PI);
	static double piex= Pow(PI,E);
	static int Main(){
	double prod=1;
	Write ($"sqrt2= {sqrt2} Proof: sqrt2²={sqrt2*sqrt2} \n");
	Write ($"2^{1.0/5}= {pow} \n");
	Write ($"{E}^{PI}={expi} \n");
	Write ($"{PI}^{E}={piex} \n");
	for (int x=1; x<11; x+=1){
		prod*=x;
		Write ($"Gamma of ({x})={sfuns.fgamma(x)} ({x-1})!={prod} \n");
		}
	return 0;
	}

}
