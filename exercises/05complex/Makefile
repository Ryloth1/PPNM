Out.txt: main.exe
	mono $< 1> Out.txt 2>log

main.exe : main.cs cmath.dll 
	mcs -out:$@ -target:exe -reference:cmath.dll -reference:System.Numerics.dll main.cs

cmath.dll :complex.cs cmath.cs
	mcs -target:library -out:./cmath.dll $^






clean: 
	$(RM) *.dll *.exe [Oo]ut*