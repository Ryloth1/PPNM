class main{
    static int Main(string[] args){
        string infile=null,outfile=null;
        foreach(var arg in args){
            System.Console.Error.WriteLine(arg);
            string[] words = arg.Split(':');
            if(words[0]=="-input")infile=words[1];
            if(words[0]=="-output")outfile=words[1];
            if(words[0]=="-numbers"){
                string[] numbers=words[1].Split(',');
                foreach(var number in numbers){
                    double x=double.Parse(number);
                    System.Console.Error.WriteLine($"{x}");  
                }
            }

        }
        if(infile==null || outfile==null){
            System.Console.Error.WriteLine("wrong argument");
            return 1;
        }

        var instream =new System.IO.StreamReader(infile);
        var outstream =new System.IO.StreamWriter(outfile,append:false);

        for(string line =instream.ReadLine();line!=null;line=instream.ReadLine()){
            double x=double.Parse(line);
            outstream.WriteLine($"x={x} Sin({x})={System.Math.Sin(x)}");
        }
       
        instream.Close();
        outstream.Close();

        return 0;
    } //Main
}//main