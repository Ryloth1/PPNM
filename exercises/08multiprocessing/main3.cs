using System.Linq;

class main{
    public static int Main(string[] args){
        int nterms=(int)1e8;
        foreach(string arg in args){
            var words =arg.Split(':');
            if(words[0]=="-nterms")nterms=(int)double.Parse(words[1]);
            }
        System.Console.WriteLine($"Main: nterms={nterms}");
        var sum = new System.Threading.ThreadLocal<double>( ()=>0, trackAllValues:true);
        System.Threading.Tasks.Parallel.For(1,nterms+1, (int i)=>sum.Value+=1.0/i );
        double totalsum=sum.Values.Sum();
        System.Console.WriteLine($"Main: total sum = {totalsum}");

    return 0;
    }
}