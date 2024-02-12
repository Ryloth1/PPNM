class main{
    static int Main(){

    double x=7;
    System.Console.Out.Write($"this goes to stdout: x={x}\n");
    System.Console.Error.Write($"this goes to stderr: x={x}\n");

    string line = System.Console.In.ReadLine();
    System.Console.Error.Write($"this also goes to stderr: line={line}\n");
    x=double.Parse(line);
    System.Console.Out.Write($"this goes to stdout: x={x}\n");


    return 0;
    }   

}