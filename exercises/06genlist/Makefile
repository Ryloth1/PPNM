Out.txt: main.exe
	mono $< < input.txt 1> Out.txt 2>>log

main.exe : main.cs genlist.dll 
	mcs -out:$@ -target:exe -reference:genlist.dll main.cs

genlist.dll :genlist.cs
	mcs -target:library -out:./genlist.dll $^






clean: 
	$(RM) *.dll *.exe [Oo]ut*