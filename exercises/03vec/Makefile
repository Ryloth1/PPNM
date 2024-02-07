Out.txt : main.exe Makefile
	mono $< > $@

main.exe: main.cs vec.dll
	mcs -target:exe -out:main.exe -reference:vec.dll vec.cs


vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs

clean:
	$(RM) Out.txt main.exe