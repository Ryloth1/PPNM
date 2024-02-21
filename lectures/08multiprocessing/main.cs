class main{

    public class harmdata {public int a,b; public double sum;}
    public static void harm(object obj){
        harmdata d= (harmdata)obj;
        d.sum = 0;
        System.Console.WriteLine($"harm: a={d.a} b= {d.b}");
        for(int i=d.a; i<= d.b; i++)d.sum+=1.0/i;
        System.Console.WriteLine($"harm: sum={d.sum}");
    }
    public static int Main(string[] args){
        int nterms =(int)1e7,nthreads=1;
        foreach(string arg in args){
            var words = arg.Split(':');
            if(words[0]=="-nterms")nterms=(int)double.Parse(words[1]);
            if(words[0]=="-nthreads")nthreads=(int)double.Parse(words[1]);
        }
        System.Console.WriteLine($"Main: nterms={nterms} nthreads={nthreads}");
        harmdata[] data = new harmdata[nthreads];
        int chunk = nterms/nthreads;
        for(int i=0; i<nthreads;i++){
            data[i] = new harmdata();
            data[i].a=i*chunk+1;
            data[i].b=data[i].a + chunk;
        }
        data[nthreads-1].b =nterms;
        var threads = new System.Threading.Thread[nthreads];
        System.Console.WriteLine($"Main: starting threads...");
        for (int i=0;i<nthreads;i++){
            threads[i] = new System.Threading.Thread(harm);
            threads[i].Start(data[i]);
        }   
        System.Console.WriteLine($"Main: waiting for threads to finish...");  
        foreach (var thread in threads)thread.Join();
        double total=0;
        foreach(harmdata datum in data)total+=datum.sum;
        System.Console.WriteLine($"Main: total sum ={total}");   
        
        //harmdata datum = new harmdata();
        //datum.a=1;
        //datum.b=10000;
        //harm(datum);
        //datum.sum;

        return 0;
    }//Main
}//main