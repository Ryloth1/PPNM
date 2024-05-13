class main{

    public static int binsearch(double[] x, double z){      /* locates the interval for z by bisection */ 
	        if(!(x[0]<=z && z<=x[x.Length-1])) throw new System.Exception("binsearch: bad z");
	        int i=0, j=x.Length-1;
	        while(j-i>1){
		        int mid=(i+j)/2;
		        if(z>x[mid]) i=mid; else j=mid;
		    }
	        return i;
	    }

        public static double linterp(double[] x, double[] y, double z){
            int i=binsearch(x,z);
            double dx=x[i+1]-x[i]; if(!(dx>0)) throw new System.Exception("uups...");
            double dy=y[i+1]-y[i];
            return y[i]+dy/dx*(z-x[i]);
        }
    public static int Main(){

        vector x = new vector(10);
        vector y = new vector(10);
        for(int i = 0; i<10; i++){
            x[i] = i;
            y[i] = System.Math.Sin(x[i]);
            //System.Console.WriteLine($"{x[i]} {y[i]}");
        }
        

        for(double z= 1.0/16;z<=9;z+=1.0/16){
		    System.Console.WriteLine($"{z} {linterp(x, y, z)}");
		} 



        return 0;
    }
}