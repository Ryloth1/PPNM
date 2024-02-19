class main{

public static int Main(){
	for(double x=1.0/8;x<=10;x+=1.0/8){
		System.Console.WriteLine($"{x} {sfuns.lngamma(x)}");
		}

	return 0;
	}
}
