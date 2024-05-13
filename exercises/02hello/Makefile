Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs
	mcs main.cs -out:main.exe -target:exe

clean: 
	rm -f main.exe main Out.txt
